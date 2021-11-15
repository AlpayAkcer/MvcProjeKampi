using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator contactValidator = new ContactValidator();


        public ActionResult Index()
        {
            var getlistContact = cm.GetList();
            return View(getlistContact);
        }

        public ActionResult GetContactDetails(int id)
        {
            var getcontactValues = cm.GetByID(id);
            return View(getcontactValues);
        }

        public PartialViewResult ContactMenuPartial()
        {
            return PartialView();
        }
    }
}