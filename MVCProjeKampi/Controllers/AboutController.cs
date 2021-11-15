using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class AboutController : Controller
    {                                               // contructor metod olduğu için efaboutdal clasını etmek gerekiyor.

        AboutManager aboutmanager = new AboutManager(new EfAboutDal());
        // GET: About
        public ActionResult Index()
        {
            var aboutValues = aboutmanager.GetList();
            return View(aboutValues);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            var aboutValues = aboutmanager.GetList();
            return View(aboutValues);
        }
        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            aboutmanager.AboutAdd(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult aboutPartial()
        {
            return PartialView();
        }
    }
}