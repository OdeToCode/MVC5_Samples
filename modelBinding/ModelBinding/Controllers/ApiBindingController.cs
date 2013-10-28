using System.Web.Http;
using ModelBinding.Models;

namespace ModelBinding.Controllers
{
    public class Test : ApiController
    {
        public void Get()
        {
            
        }   
    }

    public class ApiBindingController : ApiController
    {       
        [Route("api/binding/simple")]
        public IHttpActionResult GetSimple(string name)
        {
            return Ok(name);
        }

        [Route("api/binding/simple")]
        public IHttpActionResult PostSimple(string name)
        {
            return Ok(name);
        }

        [Route("api/binding/complex")]
        public IHttpActionResult PostComplex(Employee employee)
        {
            return Ok(employee);
        }

        [Route("api/binding/morecomplex")]
        public IHttpActionResult PostMoreComplex(Department department)
        {
            return Ok(department);
        }
    }
}
