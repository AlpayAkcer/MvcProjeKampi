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

        public PartialViewResult ContactMenuPartial()
        {
            var contact = cm.GetList().Count();
            ViewBag.contact = contact;

            var sendMail = mm.GetMessageSendBox().Count();
            ViewBag.sendMail = sendMail;

            var receiverMail = mm.GetMessagesInbox().Count();
            ViewBag.receiverMail = receiverMail;

            var draftMail = mm.GetMessageSendBox().Where(m => m.IsDraft == true).Count();
            ViewBag.draftMail = draftMail;

            var readMessage = mm.GetMessagesInbox().Where(m => m.IsRead == true).Count();
            ViewBag.readMessage = readMessage;

            var unreadMessage = mm.GetAllRead().Count();
            ViewBag.unreadMessage = unreadMessage;

            return PartialView();
        }
    }
}