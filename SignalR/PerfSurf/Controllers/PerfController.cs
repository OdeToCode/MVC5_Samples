using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace PerfSurf.Controllers
{
    public class PerfController : ApiController
    {
        [Route("perf/categories")]
        public IHttpActionResult GetPerformanceCategories()
        {
            var model = PerformanceCounterCategory
                .GetCategories()
                .OrderBy(c => c.CategoryName)
                .Select(c => CleanName(c.CategoryName));

            return Ok(model);
        }
     
        [Route("perf/{category}/counters")]
        public IHttpActionResult GetCounters(string category)
        {
            var counterCategory =
                PerformanceCounterCategory
                    .GetCategories()
                    .Where(c => CleanName(c.CategoryName) == category)
                    .FirstOrDefault();

            if (counterCategory == null)
            {
                return NotFound();
            }
            
            var instance = GetDefaultInstance(counterCategory);
            return Ok(counterCategory.GetCounters(instance).Select(c => c.CounterName));
        }

        [Route("perf/{category}/counters/{counter}")]
        public bool GetCounter(string category)
        {
            return true;
        }

        public string CleanName(string name)
        {
            return Regex.Replace(name, "[:.]", "");
        }

        public string GetDefaultInstance(PerformanceCounterCategory category)
        {
            return category
                .GetInstanceNames()
                .OrderBy(n => n)
                .FirstOrDefault();
        }
     }
}
