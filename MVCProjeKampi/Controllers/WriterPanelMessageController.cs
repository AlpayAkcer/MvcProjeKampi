using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System.Web.Mvc;
using System.Linq;
using EntityLayer.Concrete;
using System;
using FluentValidation.Results;

namespace MVCProjeKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        // GET: WriterPanelMessage
        public ActionResult Inbox()
        {
            string session = (string)Session["WriterMail"];
            var messageListInbox = messageManager.GetListInbox(session);
            return View(messageListInbox);
        }

        public PartialViewResult WriterLeftMenuPartial()
        {
            return PartialView();
        }

        public ActionResult SendBox()
        {
            string session = (string)Session["WriterMail"];
            var messageListSendbox = messageManager.GetListSendbox(session);
            return View(messageListSendbox);
        }

        public ActionResult GetMessageDetails(int id)
        {
            var values = messageManager.GetById(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NewMessage(Message message, string button)
        {
            ValidationResult results = messageValidator.Validate(message);
            string session = (string)Session["WriterMail"];
        
            if (button == "send")
            {
                if (results.IsValid)
                {
                    message.SenderMail = session;
                    //message.IsDraft = false;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    messageManager.MessageAdd(message);
                    return RedirectToAction("Sendbox");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
       
            else if (button == "draft")
            {
                if (results.IsValid)
                {
                    message.SenderMail = session;
                    message.Draft = true;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    messageManager.MessageAdd(message);
                    return RedirectToAction("DraftMessages");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
          
            else if (button == "cancel")
            {
                return RedirectToAction("NewMessage");
            }
            return View();
        }

        public ActionResult IsRead(int id)
        {
            var result = messageManager.GetById(id);
            if (result.Read == false)
            {
                result.Read = true;
            }
            else
            {
                result.Read = false;
            }
            messageManager.MessageUpdate(result);
            return RedirectToAction("Inbox");
        }

        public ActionResult MessageRead(int id)
        {
            var messageValue = messageManager.GetById(id);

            if (messageValue.Read)
            {
                messageValue.Read = false;
            }
            else
            {
                messageValue.Read = true;
            }

            messageManager.MessageUpdate(messageValue);
            return RedirectToAction("Inbox");
        }

        public ActionResult MessageUnRead()
        {
            string session = (string)Session["WriterMail"];
            var result = messageManager.GetUnReadMessageForInbox(session);
            return View(result);
        }
    }
}