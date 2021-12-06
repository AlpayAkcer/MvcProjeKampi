using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.DTO;
using MvcProjeKampi.Models;
using Newtonsoft.Json;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        IAuthService authService = new AuthManager(new AdminManager(new EfAdminDal()), new WriterManager(new EfWriterDal()));

        //Context context = new Context();

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogIn(AdminLogInDto adminLogInDto)
        {


            if (authService.AdminLogin(adminLogInDto))
            {
                FormsAuthentication.SetAuthCookie(adminLogInDto.AdminMail, false);
                Session["AdminMail"] = adminLogInDto.AdminMail;
                var session = Session["AdminMail"];
                ViewBag.a = session;
                return RedirectToAction("Index", "AdminIstatistikler");
            }
            else
            {
                ViewData["ErrorMessage"] = "Kullanıcı adı veya Parola yanlış";
                return View();
            }
        }

        public ActionResult AdminLogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AdminLogin", "LogIn");
        }

        [HttpGet]
        public ActionResult WriterLogIn()
        {
            return View();
        }


        [HttpPost]
        public ActionResult WriterLogIn(WriterLogInDto writerLogInDto)
        {

            if (authService.WriterLogin(writerLogInDto))
            {
                FormsAuthentication.SetAuthCookie(writerLogInDto.WriterMail, false);
                Session["WriterMail"] = writerLogInDto.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                ViewData["ErrorMessage"] = "Kullanıcı adı veya Parola yanlış";
                return RedirectToAction("WriterLogin");
            }
        }

        public ActionResult WriterLogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("WriterLogin", "LogIn");
        }
    }
}