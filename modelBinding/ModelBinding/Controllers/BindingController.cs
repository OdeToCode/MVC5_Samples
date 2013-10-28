using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ModelBinding.Models;

namespace ModelBinding.Controllers
{
    public class BindingController : Controller
    {
        public ActionResult Simple()
        {
            return View();
        }

        public ActionResult SimpleDestination(string firstName, string lastName)
        {
            ViewBag.Name = firstName + " " + lastName;
            return View();
        }

        public ActionResult Environment(string id)
        {
            ViewBag.ValueProviders = ValueProvider;
            return View();
        }

        [HttpGet]
        public ActionResult ComplexType()
        {
            var employee = new Employee
            {
                Id = 1,
                FirstName = "Scott",
                LastName = "Allen",
                HireDate = new DateTime(2002, 10, 1)
            };
            return View(employee);
        }

        [HttpPost]
        public ActionResult ComplexType(Employee employee)
        {
            ViewBag.ShowResults = true;
            return View(employee);
        }

        //// Alternative to above code
        //[HttpPost]
        //public ActionResult ComplexType(FormCollection collection)
        //{
        //    var employee = new Employee();
        //    TryUpdateModel(employee);
        //    ViewBag.ShowResults = true;
        //    return View(employee);
        //}

        [HttpGet]
        public ActionResult Nested()
        {
            var project = new Project
            {
                Name = "WebSite",
                Leader = new Employee {FirstName = "Scott"}
            };
            return View(project);
        }

        [HttpPost]
        public ActionResult Nested(Project project)
        {
            ViewBag.ShowResults = true;
            return View(project);
        }

        [HttpGet]
        public ActionResult Collection()
        {
            var department = new Department();
            department.Name = "Engineering";
            department.Employees = new List<Employee>
            {
                new Employee() { FirstName="Scott", LastName = "Allen", HireDate=DateTime.Now},
                new Employee() { FirstName="Alan", LastName = "Scott", HireDate=DateTime.Now}
            };
            return View(department);
        }

        [HttpPost]
        public ActionResult Collection(Department department)
        {
            ViewBag.ShowResults = true;
            return View(department);
        }

        [HttpGet]
        public ActionResult Enumeration()
        {
            var manager = new Manager() {Name = "Scott", Level = ManagerType.Middle};
            return View(manager);
        }

        [HttpPost]
        public ActionResult Enumeration(Manager manager)
        {
            ViewBag.ShowResults = true;
            return View(manager);
        }

        [HttpGet]
        public ActionResult Override()
        {
            var account = new Account("Expenses");
            account.Amount = 1000m;

            return View(account);
        }

        [HttpPost]
        public ActionResult Override(Account account)
        {
            ViewBag.ShowResults = true;
            return View(account);
        }

        [HttpGet]
        public ActionResult Custom()
        {
            var employee = new Employee() {FirstName = "Scott", LastName="Allen", HireDate = DateTime.Now};
            return View(employee);
        }

        [HttpPost]
        public ActionResult Custom(Employee employee)
        {
            ViewBag.ShowResults = true;
            return View(employee);
        }

        [HttpGet]
        public ActionResult SimpleApi()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ComplexApi()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MoreComplexApi()
        {
            return View();
        }
    }
}