using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya>();
        public ActionResult Index()
        {
            var medya = repo.List();
            return View(medya);
        }

        // AKTIF - PASIF DURUMU 
        public ActionResult MakeActive(int id)
        {
            TblSosyalMedya i = repo.Find(x => x.ID == id);
            i.Status = true;
            repo.TUpdate(i);
            return RedirectToAction("Index");
        }
        public ActionResult MakePassive(int id)
        {
            TblSosyalMedya i = repo.Find(x => x.ID == id);
            i.Status = false;
            repo.TUpdate(i);
            return RedirectToAction("Index");
        }

        // SOSYAL MEDYA EKLE
        [HttpGet]
        public ActionResult SosyalMedyaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SosyalMedyaEkle(TblSosyalMedya s)
        {
            repo.TAdd(s);
            return RedirectToAction("Index");
        }

        // SOSYAL MEDYA GUNCELLE
        [HttpGet]
        public ActionResult SosyalMedyaGuncelle(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            return View(hesap);
        }
        [HttpPost]
        public ActionResult SosyalMedyaGuncelle(TblSosyalMedya s)
        {
            var hesap = repo.Find(x => x.ID == s.ID);
            hesap.Ad = s.Ad;
            hesap.Link = s.Link;
            hesap.Ikon = s.Ikon;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }

        // SOSYAL MEDYA SILME ISLEMI
        public ActionResult SosyalMedyaSil(int id)
        {
            TblSosyalMedya i = repo.Find(x => x.ID == id);
            repo.TDelete(i);
            return RedirectToAction("Index");
        }
    }
}