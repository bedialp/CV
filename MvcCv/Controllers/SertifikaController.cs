using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        GenericRepository<TblSertifikalarim> repo = new GenericRepository<TblSertifikalarim>();

        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }

        // SERTIFIKA EKLEME ISLEMI
        [HttpGet]
        public ActionResult SertifikaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SertifikaEkle(TblSertifikalarim sertifikalar)
        {
            if (!ModelState.IsValid)
            {
                return View("SertifikaEkle");
            }
            repo.TAdd(sertifikalar);
            return RedirectToAction("Index");
        }

        // SERTIFIKA SILME ISLEMI
        public ActionResult SertifikaSil(int id)
        {
            TblSertifikalarim s = repo.Find(x => x.ID == id);
            repo.TDelete(s);
            return RedirectToAction("Index");
        }

        // SERTIFIKA GUNCELLEME ISLEMI
        [HttpGet]
        public ActionResult SertifikaGuncelle(int id)
        {
            TblSertifikalarim s = repo.Find(x => x.ID == id);
            return View(s);
        }
        [HttpPost]
        public ActionResult SertifikaGuncelle(TblSertifikalarim s)
        {
            if (!ModelState.IsValid)
            {
                return View("SertifikaGuncelle");
            }
            TblSertifikalarim sertifikalarim = repo.Find(x => x.ID == s.ID);
            sertifikalarim.Aciklama = s.Aciklama;
            sertifikalarim.Kurs = s.Kurs;
            sertifikalarim.Tarih = s.Tarih;
            sertifikalarim.SertifikaURL = s.SertifikaURL;

            repo.TUpdate(sertifikalarim);
            return RedirectToAction("Index");
        }

    }
}