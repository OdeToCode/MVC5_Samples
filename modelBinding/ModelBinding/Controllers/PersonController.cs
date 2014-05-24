using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ModelBinding.Controllers
{
    public interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }
    }

    public class Person : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class PersonController : Controller
    {
        public ViewResult Update()
        {
            var person = new Person();
            TryUpdateModel<IPerson>(person);
            return View(person);
        }
    }
}