using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class AdminIstatistiklerController : Controller
    {
        Context _context = new Context();

        // GET: AdminIstatistikler
        public ActionResult Index()
        {
            // Toplam Kategori Sayısını Çekme
            var totalCategoryCount = _context.Categories.Count();
            ViewBag.totalCategoryCountList = totalCategoryCount;

            // Yazılım Kategorisine bağlı başlıkları çekme
            var titleSoftware = _context.Headings.Count(x => x.CategoryId == 26);
            ViewBag.titleSoftwareCount = titleSoftware;

            // Yazar İsimlerinin içerisinde "A" ile başlayan kişiler
            var theNameContainsWriter = _context.Writers.Count(x => x.Name.Contains("a") && x.Name.Contains("A"));
            ViewBag.writerNameContains = theNameContainsWriter;

            // Kagetori içerisinde en çok başlığı olan kategori Adı
            var categoryTitleCount = _context.Headings.Max(x => x.Category.Name);
            ViewBag.categoryWithTheMostTitles = categoryTitleCount;


            // Kategorilerde aktif olanların toplamı
            var isActiveCategoryCount = _context.Categories.Count(x => x.IsActive == true);
            ViewBag.categoryIsActiveTotalCount = isActiveCategoryCount;

            return View();
        }
    }
}