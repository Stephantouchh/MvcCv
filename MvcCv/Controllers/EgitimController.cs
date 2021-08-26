using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<TblEgitimlerim> repo = new GenericRepository<TblEgitimlerim>();
       
        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }
        [HttpGet]
        public ActionResult YeniEgitim()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniEgitim(TblEgitimlerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniEgitim");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            repo.TDelete(egitim);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            return View(egitim);
        }
        [HttpPost]
        public ActionResult EgitimGetir(TblEgitimlerim egt)
        {
            var e = repo.Find(x => x.ID == egt.ID);
            e.Baslik = egt.Baslik;
            e.AltBaslik1 = egt.AltBaslik1;
            e.AltBaslik2 = egt.AltBaslik2;
            e.GNO = egt.GNO;
            e.Tarih = egt.Tarih;
            repo.TUpdate(e);
            return RedirectToAction("Index");
        }
    }
}