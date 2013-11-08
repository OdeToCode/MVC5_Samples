using System.Web.Mvc;

namespace BasicIdentityWithDiagrams.Controllers
{
    [Authorize]
    public class SecretController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
	}
}