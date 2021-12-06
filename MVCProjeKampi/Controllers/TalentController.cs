using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class TalentController : Controller
    {
        SkillManager skillManager = new SkillManager(new EfSkillDal());
        // GET: Talent
        public ActionResult Index()
        {
            var result = skillManager.GetList();
            return View(result);
        }
        public ActionResult TalentCard()
        {
            var result = skillManager.GetList();
            return View(result);
        }

        [HttpGet]
        public ActionResult AddTalent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTalent(Skill skill)
        {
            skillManager.SkillAdd(skill);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTalent(int id)
        {
            var result = skillManager.GetById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult UpdateTalent(Skill skill)
        {
            skillManager.SkillUpdate(skill);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTalent(int Id)
        {
            var result = skillManager.GetById(Id);
            skillManager.SkillDelete(result);
            return RedirectToAction("Index");
        }

    }
}