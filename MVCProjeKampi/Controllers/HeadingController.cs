using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
                                                    Text = x.Name + " " + x.Surname,
                                                    Value = x.WriterId.ToString()
                                                }).ToList();

            ViewBag.categoryValue = valuecategory;
            ViewBag.writerValue = valuewriter;

            return View();
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
    }
}