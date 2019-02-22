using StarWarsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionDesWookies.Controllers
{
    public class DroideController : Controller
    {
        private DroideDataLayer _dataLayer = new DroideDataLayer();

        // GET: Droide
        public ActionResult Index()
        {
            List<Droide> listeDroides = this._dataLayer.Select();
            return View(listeDroides);
        }

        // GET: Droide/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Droide/Create
        public ActionResult Create()
        {
            List<Modele> listeModeles = new ModeleDataLayer().Select();
            ViewBag.listeModeles = listeModeles;
            return View();
        }

        // POST: Droide/Create
        [HttpPost]
        public ActionResult Create(Droide droide)
        {
            try
            {
                // TODO: Add insert logic here
                _dataLayer.UpdateOrInsertOne(droide);
                return RedirectToAction("Index");
            }
            catch
            {
                List<Modele> listeModeles = new ModeleDataLayer().Select();
                ViewBag.listeModeles = listeModeles;
                return View();
            }
        }

        // GET: Droide/Edit/5
        public ActionResult Edit(int id)
        {
            List<Droide> listeDroides = _dataLayer.Select("",id);
            List<Modele> listeModeles = new ModeleDataLayer().Select();
            ViewBag.listeModeles = listeModeles;
            return View(listeDroides[0]);
        }

        // POST: Droide/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Droide droide)
        {
            try
            {
                // TODO: Add update logic here
                if(this.ModelState.IsValid)
                    _dataLayer.UpdateOrInsertOne(droide);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Droide/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Droide/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Droide droide)
        {
            try
            {
                // TODO: Add delete logic here
                _dataLayer.delete(droide);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
