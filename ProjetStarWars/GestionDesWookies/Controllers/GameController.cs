using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StarWarsLibrary;

namespace GestionDesWookies.Controllers
{
    public class GameController : Controller
    {
        private CombatDataLayer _combatDataLayer = new CombatDataLayer();
        private AttaqueDataLayer _attaqueDataLayer = new AttaqueDataLayer();
        private PlaneteDataLayer _planeteDataLayer = new PlaneteDataLayer();
        private Random r = new Random();

        // GET: Resultat
        public ActionResult Resultat(Attaque attaque)
        {
            ActionResult result = this.RedirectToAction("Login", "Player");
            if (this.Session["USER_LOGIN"] != null && !string.IsNullOrEmpty(this.Session["USER_LOGIN"].ToString()))
            {
                Planete p = new PlaneteDataLayer().Select("", (int)attaque.PlaneteID)[0];
                ViewBag.planete = p;
                result = this.View(attaque);
            }
            return result;
        }

        // GET: CreateAttaque
        public ActionResult CreateAttaque()
        {
            ActionResult result = this.RedirectToAction("Login", "Player");
            if (this.Session["USER_LOGIN"] != null && !string.IsNullOrEmpty(this.Session["USER_LOGIN"].ToString()))
            {
                List<Planete> listePlanetes = this._planeteDataLayer.Select();
                ViewBag.listePlanetes = listePlanetes;
                result = this.View();
            }
            return result;
        }

        // POST: CreateAttaque
        [HttpPost]
        public ActionResult CreateAttaque(Attaque attaque)
        {
            ActionResult result = this.RedirectToAction("Login", "Player");      
            if (this.Session["USER_LOGIN"] != null && !string.IsNullOrEmpty(this.Session["USER_LOGIN"].ToString())){
                result = this.RedirectToAction("CreateAttaque", "Game");
                if (attaque.NbWookies < 1000 && attaque.NbWookies > 50 && attaque.NbDroides > 1000 && this._planeteDataLayer.Select("", (int)attaque.PlaneteID).Count > 0)
                {
                    attaque.DateDebut = DateTime.Now;
                    attaque = generateAttaque(attaque);
                    result = this.RedirectToAction("Resultat","Game", attaque);
                }
            }
            return result;
        }


        private Attaque generateAttaque(Attaque attaque)
        {
            this._attaqueDataLayer.UpdateOrInsertOne(attaque);

            List<Wookie> listeWookies = new WookieDataLayer().Select().Take((int)attaque.NbWookies).ToList();
            List<Droide> listeDroides = new DroideDataLayer().Select().Take((int)attaque.NbDroides).ToList();

            while(listeWookies.Count > 0 && listeDroides.Count > 0)
            {              
                generateCombat(attaque, listeWookies, listeDroides);
            }

            attaque.NbDroides = listeDroides.Count;
            attaque.NbWookies = listeWookies.Count;
            attaque.Victorieux = attaque.NbDroides > attaque.NbWookies;
            attaque.DateFin = DateTime.Now;

            this._attaqueDataLayer.UpdateOrInsertOne(attaque);

            return attaque;
        }

        private void generateCombat(Attaque attaque, List<Wookie> listeWookies, List<Droide> listeDroides)
        {
            int indexW = r.Next(0,listeWookies.Count);
            Wookie wookie = listeWookies[indexW];

            int indexD = r.Next(0,listeDroides.Count);
            Droide droide = listeDroides[indexD];

            int pvWookie = (int)wookie.PointsDeVie;
            if (wookie.Combat.Where(c => c.AttaqueID == attaque.ID).Count() > 0)
            {
                Combat c = wookie.Combat.Where(cb => cb.WookieID == wookie.ID && cb.AttaqueID == attaque.ID).OrderBy(w => w.DateCombat).Last();
                pvWookie = (int)c.PointsDeVieWookie;
            }
            int pvDroide = (int)droide.PointsDeVie;
            if (droide.Combat.Where(c => c.AttaqueID == attaque.ID).Count() > 0)
            {
                Combat c = droide.Combat.Where(cb => cb.DroideID == droide.ID && cb.AttaqueID == attaque.ID).OrderBy(w => w.DateCombat).Last();
                pvDroide = (int)c.PointsDeVieDroide;
            }

            bool tourDeJeu = Convert.ToBoolean(r.Next(0, 2));
            bool vainqueur = true;
            while (pvDroide > 0 && pvWookie > 0)
            {
                if (tourDeJeu)
                {
                    int wookieAttaque = r.Next(10, 26);
                    pvDroide -= wookieAttaque;
                }
                else
                {
                    int droideAttaque = r.Next(10, 16);
                    pvWookie -= droideAttaque;
                }
                tourDeJeu = !tourDeJeu;
            }

            if (pvDroide <= 0)
                vainqueur = false;

            Combat combat = new Combat()
            {
                PointsDeVieDroide = pvDroide,
                PointsDeVieWookie = pvWookie,
                DateCombat = DateTime.Now,
                Vainqueur = vainqueur,
                WookieID = wookie.ID,
                DroideID = droide.ID,
                AttaqueID = attaque.ID
            };

            if (vainqueur)
            {
                listeWookies.Remove(wookie);
                listeDroides[indexD].Combat.Add(combat);
            }
            if (!vainqueur)
            {
                listeDroides.Remove(droide);
                listeWookies[indexW].Combat.Add(combat);
            }

            this._combatDataLayer.UpdateOrInsertOne(combat);
        }

        private void generateOnce()
        {
            Random r = new Random();
            for(int i = 0; i < 10000; i++)
            {
                Droide d = new Droide()
                {
                    DateF = DateTime.Now,
                    Matricule = Guid.NewGuid().ToString(),
                    ModeleID = r.Next(1, 6),
                    PointsDeVie = r.Next(10, 61)
                };
                new DroideDataLayer().UpdateOrInsertOne(d);
            }

            for(int i = 0; i < 1000; i++)
            {
                Wookie w = new Wookie()
                {
                    DateN = DateTime.Now,
                    PlaneteID = r.Next(1, 5),
                    Sexe = Convert.ToBoolean(r.Next(0, 2)),
                    Nom = Guid.NewGuid().ToString(),
                    PointsDeVie = r.Next(50, 100)
                };
                new WookieDataLayer().UpdateOrInsertOne(w);
            }
        }
    }
}