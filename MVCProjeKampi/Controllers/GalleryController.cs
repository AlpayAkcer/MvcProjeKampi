using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager im = new ImageFileManager(new EfImageFilesDal());
        // GET: Gallery
        public ActionResult Index()
        {
            var files = im.GetList();
            return View(files);
        }
    }
}