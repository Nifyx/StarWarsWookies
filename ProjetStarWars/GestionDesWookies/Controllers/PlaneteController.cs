using StarWarsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionDesWookies.Controllers
{
    public class PlaneteController : Controller
    {
        private PlaneteDataLayer _dataLayer = new PlaneteDataLayer();
        // GET: Planete
        public ActionResult Index()
        {
            List<Planete> listePlanetes = new PlaneteDataLayer().Select();
            return View(listePlanetes);
        }

        // GET: Planete/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Planete/Create
        [HttpPost]
        public ActionResult Create(Planete planete)
        {
            try
            {
                // TODO: Add insert logic here
                this._dataLayer.UpdateOrInsertOne(planete);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Planete/Edit/5
        public ActionResult Edit(int id)
        {
            Planete planete = _dataLayer.Select().Find(item => item.ID == id);
            return View(planete);
        }

        // POST: Planete/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Planete planete)
        {
            try
            {
                _dataLayer.UpdateOrInsertOne(planete);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Planete/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Planete/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Planete planete)
        {
            try
            {
                // TODO: Add delete logic here
                _dataLayer.delete(planete);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}