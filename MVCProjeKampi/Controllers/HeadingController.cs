using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        HeadingValidator headingValidator = new HeadingValidator();

        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        // GET: Heading
        public ActionResult Index()
        {
            var headingValues = hm.GetHeadingList();
            return View(headingValues);
        }


        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();

            List<SelectListItem> valuewriter = (from x in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurName,
                                                    Value = x.WriterId.ToString()
                                                }).ToList();

            ViewBag.categoryValue = valuecategory;
            ViewBag.writerValue = valuewriter;

            return View();
        }

        public ActionResult HeadingByCategory(int id)
        {
            var headingCategory = hm.HeadingByCategory(id);
            return View(headingCategory);
        }

        public ActionResult HeadingByWriter(int id)
        {
            var headingWriter = hm.HeadingByWriter(id);
            return View(headingWriter);
        }

        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {

            ValidationResult result = headingValidator.Validate(p);

            if (result.IsValid)
            {
                p.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                hm.HeadingAddBL(p);
                return RedirectToAction("Index");
            }
            else
            {
                //Değişken türü, Değişken tür adı, içinden , dizinin adı
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }


        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;

            var HeadingValue = hm.GetByID(id);
            return View(HeadingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            p.IsActive = true;
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }


        public ActionResult DeleteHeading(int id)
        {
            var HeadingValue = hm.GetByID(id);
            hm.HeadingDelete(HeadingValue);
            return RedirectToAction("Index");
        }
    }
}