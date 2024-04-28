using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HobiController : Controller
    {
        GenericRepository<TblHobilerim> repo = new GenericRepository<TblHobilerim>();

        [HttpGet]
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }
        [HttpPost]
        public ActionResult Index(TblHobilerim h)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Aciklama1 = h.Aciklama1;
            t.Aciklama2 = h.Aciklama2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}