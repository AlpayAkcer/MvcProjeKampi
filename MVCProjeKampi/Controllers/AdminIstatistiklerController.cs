using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    [Authorize]
    public class AdminIstatistiklerController : Controller
    {
        Context _context = new Context();

        // GET: AdminIstatistikler
        public ActionResult Index()
        {
            // Toplam Kategori Sayısını Çekme
            var totalCategoryCount = _context.Categories.Count();
            ViewBag.totalCategoryCountList = totalCategoryCount;

            // Yazılım-26 Kategorisine bağlı başlıkları çekme
            var titleSoftware = _context.Headings.Count(x => x.CategoryId == 26);
            ViewBag.titleSoftwareCount = titleSoftware;

            // Yazar İsimlerinin içerisinde "A" ile başlayan kişiler
            var theNameContainsWriter = _context.Writers.Count(x => x.WriterName.Contains("a") && x.WriterName.Contains("A"));
            ViewBag.writerNameContains = theNameContainsWriter;

            // Kagetori içerisinde en çok başlığı olan kategori Adı
            var categoryTitleCount = _context.Headings.Max(x => x.Category.Name);
            ViewBag.categoryWithTheMostTitles = categoryTitleCount;

            var totalHeading = _context.Headings.Where(x => x.IsActive == true).Count();
            ViewBag.totalHeadingList = totalHeading;

            var totalContentCount = _context.Contents.Where(x => x.IsActive == true).Count();
            ViewBag.totalContentList = totalContentCount;

            var totalAdminCount = _context.Admins.Count();
            ViewBag.totalAdminList = totalAdminCount;

            var totalMessageCount = _context.Messageses.Count();
            ViewBag.totalMessageList = totalMessageCount;

            var InReadCount = _context.Messageses.Where(x => x.Read == true).Count();
            ViewBag.InRead = InReadCount;

            var IsDraftCount = _context.Messageses.Where(x => x.Draft == true).Count();
            ViewBag.IsDraft = IsDraftCount;

            //var IsTrashCount = _context.Messageses.Where(x => x.Trash == true).Count();
            //ViewBag.IsTrash = IsTrashCount;

            // Kategorilerde aktif olanların toplamı
            var isActiveCategoryCount = _context.Categories.Count(x => x.IsActive == true);
            ViewBag.categoryIsActiveTotalCount = isActiveCategoryCount;

            return View();
        }
    }
}