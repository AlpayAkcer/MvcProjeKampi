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
        MessageManager mm = new MessageManager(new EfMessageDal());

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

        public ActionResult ContactDelete(int id)
        {
            var contactValues = cm.GetByID(id);
            cm.ContactDelete(contactValues);
            return RedirectToAction("Index");
        }

        public PartialViewResult ContactMenuPartial()
        {
            string session = (string)Session["AdminMail"];

            var contact = cm.GetList().Count();
            ViewBag.contact = contact;

            var sendMail = mm.GetListSendbox(session).Count();
            ViewBag.sendMail = sendMail;

            var receiverMail = mm.GetListInbox(session).Count();
            ViewBag.receiverMail = receiverMail;

            var draftMail = mm.GetListDraft(session).Count(); //GetListSendbox().Where(m => m.IsDraft == true).Count();
            ViewBag.draftMail = draftMail;

            //var trashMail = mm.GetListTrash().Count();
            //ViewBag.trashMail = trashMail;

            //var readMail = mm.GetReadList(session).Count;
            //ViewBag.readMail = readMail;

            //var unReadMail = mm.GetUnReadList(session).Count;
            //ViewBag.unReadMail = unReadMail;

            //var importantMail = mm.GetListImportant(session).Count();
            //ViewBag.importantMail = importantMail;

            //var spamMail = mm.GetListSpam(session).Count();
            //ViewBag.spamMail = spamMail;

            return PartialView();
        }
    }
}