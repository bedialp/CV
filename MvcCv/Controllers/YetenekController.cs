using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class YetenekController : Controller
    {
        GenericRepository<TblYeteneklerim> repo = new GenericRepository<TblYeteneklerim>();
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }

        // YETENEK EKLEME ISLEMI
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(TblYeteneklerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        // YETENEK SILME ISLEMI
        public ActionResult YetenekSil(int id)
        {
            TblYeteneklerim y = repo.Find(x => x.ID == id);
            repo.TDelete(y);
            return RedirectToAction("Index");
        }

        // YETENEK GUNCELLEME ISLEMI
        [HttpGet]
        public ActionResult YetenekGuncelle(int id)
        {
            var y = repo.Find(x => x.ID == id);
            return View(y);
        }
        [HttpPost]
        public ActionResult YetenekGuncelle(TblYeteneklerim t)
        {
            var y = repo.Find(x => x.ID == t.ID);
            y.Yetenek = t.Yetenek;
            y.Oran = t.Oran;

            repo.TUpdate(y);
            return RedirectToAction("Index");
        }
    }
}