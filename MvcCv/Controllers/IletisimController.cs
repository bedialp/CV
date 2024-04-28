using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class IletisimController : Controller
    {
        GenericRepository<TblIletisim> repo = new GenericRepository<TblIletisim>();

        public ActionResult Index()
        {
            var iletisim = repo.List();
            return View(iletisim);
        }

        // ILETISIM SILME ISLEMI
        public ActionResult IletisimSil(int id)
        {
            TblIletisim i = repo.Find(x => x.ID == id);
            repo.TDelete(i);
            return RedirectToAction("Index");
        }

        public ActionResult MakeActive(int id)
        {
            TblIletisim i = repo.Find(x => x.ID == id);
            i.Status=true;
            repo.TUpdate(i);
            return RedirectToAction("Index");
        }
        public ActionResult MakePassive(int id)
        {
            TblIletisim i = repo.Find(x => x.ID == id);
            i.Status = false;
            repo.TUpdate(i);
            return RedirectToAction("Index");
        }
    }
}