using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicIdentityWithDiagrams.Controllers
{
    [Authorize(Roles="admin")]
    public class SecretController : Controller
    {
        public ContentResult Index()
        {
            return Content("This is a secret...");
        }
	}
}