using PerfSurf.Models;
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
       
     
        //[Route("perf/{id}/counters")]
        //public IHttpActionResult GetCounters(string category)
        //{
        //    var counterCategory =
        //        PerformanceCounterCategory
        //            .GetCategories()
        //            .Where(c => CleanName(c.CategoryName) == category)
        //            .FirstOrDefault();

        //    if (counterCategory == null)
        //    {
        //        return NotFound();
        //    }
            
        //    var instance = GetDefaultInstance(counterCategory);
        //    return Ok(counterCategory.GetCounters(instance).Select(c => c.CounterName));
        //}

        //[Route("perf/{category}/counters/{counter}")]
        //public bool GetCounter(string category)
        //{
        //    return true;
        //}

        protected override void Dispose(bool disposing)
        {
            if (db != null)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
     }
}
