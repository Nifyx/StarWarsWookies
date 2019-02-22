using StarWarsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionDesWookies.Controllers
{
    public class ModeleController : Controller
    {
        private ModeleDataLayer _dataLayer = new ModeleDataLayer();
        // GET: Modele
        public ActionResult Index()
        {
            List<Modele> listeModeles = new ModeleDataLayer().Select();
            return View(listeModeles);
        }

        // GET: Modele/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Modele/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Modele/Create
        [HttpPost]
        public ActionResult Create(Modele modele)
        {
            try
            {
                // TODO: Add insert logic here
                this._dataLayer.UpdateOrInsertOne(modele);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Modele/Edit/5
        public ActionResult Edit(int id)
        {
            List<Modele> listeModeles = _dataLayer.Select("",id);
            return View(listeModeles[0]);
        }

        // POST: Modele/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Modele modele)
        {
            try
            {
                _dataLayer.UpdateOrInsertOne(modele);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Modele/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Modele/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Modele modele)
        {
            try
            {
                // TODO: Add delete logic here
                _dataLayer.delete(modele);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
