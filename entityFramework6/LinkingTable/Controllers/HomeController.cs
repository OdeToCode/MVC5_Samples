using System.Linq;
using System.Web.Mvc;
using LinkingTable.Models;
using System.Data.Entity;

namespace LinkingTable.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var context = new ClinicalTrialContext();
            var model = context.Studies.Include(s => s.Drugs).ToList();
            return View(model);
        }

        public ActionResult Delete(int studyId, int drugid)
        {
            var context = new ClinicalTrialContext();
            var study = context.Studies.Include(s => s.Drugs)
                               .Single(s => s.Id == studyId);
            var drug = study.Drugs.Single(d => d.Id == drugid);
            study.Drugs.Remove(drug);
            
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}