using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class EgitimController : Controller
    {
        GenericRepository<TblEgitimlerim> repo = new GenericRepository<TblEgitimlerim>();
        public ActionResult Index()
        {
            var education = repo.List();
            return View(education);
        }

        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult EgitimEkle(TblEgitimlerim education)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(education);
            return RedirectToAction("Index");
        }


        public ActionResult EgitimSil(int id)
        {
            TblEgitimlerim e = repo.Find(x => x.ID == id);
            repo.TDelete(e);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult EgitimGuncelle(int id)
        {
            TblEgitimlerim eg = repo.Find(x => x.ID == id);
            return View(eg);
        }

        [HttpPost]
        public ActionResult EgitimGuncelle(TblEgitimlerim eg)
        {
            TblEgitimlerim egitimler = repo.Find(x => x.ID == eg.ID);
            egitimler.Baslik = eg.Baslik;
            egitimler.AltBaslik1 = eg.AltBaslik1;
            egitimler.AltBaslik2 = eg.AltBaslik2;
            egitimler.GNO = eg.GNO;
            egitimler.Tarih = eg.Tarih;
            
            repo.TUpdate(egitimler);
            return RedirectToAction("Index");
        }

    }
}