using StarWarsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionDesWookies.Controllers
{
    public class WookieController : Controller
    {
        private WookieDataLayer _dataLayer = new WookieDataLayer();
        // GET: Wookie
        public ActionResult Index()
        {
            List<Wookie> listeWookies = _dataLayer.Select();
            return this.View(listeWookies);
        }

        // GET: Wookie/Create
        public ActionResult Create()
        {
            List<Planete> listePlanetes = new PlaneteDataLayer().Select();
            ViewBag.listePlanetes = listePlanetes;
            return View();
        }

        // POST: Wookie/Create
        [HttpPost]
        public ActionResult Create(Wookie wookie)
        {
            try
            {
                // TODO: Add insert logic here
                this._dataLayer.UpdateOrInsertOne(wookie);
                return RedirectToAction("Index");
            }
            catch
            {
                List<Planete> listePlanetes = new PlaneteDataLayer().Select();
                ViewBag.listePlanetes = listePlanetes;
                return View();
            }
        }

        // GET: Wookie/Edit/5
        public ActionResult Edit(int id)
        {
            Wookie wookie = _dataLayer.Select().Find(item => item.ID == id);
            List<Planete> listePlanetes = new PlaneteDataLayer().Select();
            ViewBag.listePlanetes = listePlanetes;
            return View(wookie);
        }

        // POST: Wookie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Wookie wookie)
        {
            try
            {
                // TODO: Add update logic here
                _dataLayer.UpdateOrInsertOne(wookie);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Wookie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Wookie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Wookie wookie)
        {
            try
            {
                // TODO: Add delete logic here
                _dataLayer.delete(wookie);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}