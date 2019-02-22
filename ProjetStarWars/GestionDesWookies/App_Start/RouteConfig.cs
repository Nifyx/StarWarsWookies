using GestionDesWookies.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GestionDesWookies
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Resultat",
                url: "resultat/{attaqueID}",
                defaults: new { controller = "Game", action = "Resultat" }
            );

            routes.MapRoute(
                name: "CreerAttaque",
                url: "nouvelle-attaque/",
                defaults: new { controller = "Game", action = "CreateAttaque" }
            );

            routes.MapRoute(
                name: "LancerJeu",
                url: "lancer-jeu/{nbWookies}/{nbDroides}/{planete}",
                defaults: new { controller = "Game", action = "CreateAttaque" }
                //constraints: new { nbWookies = new ConstraintWookie(), nbDroides = new ConstraintDroide(), planete = new ConstraintPlanete() }
            );

            routes.MapRoute(
                name: "LoginToCreate",
                url: "login/{login}/{password}",
                defaults: new { controller = "Player", action = "Login" }
            );

            routes.MapRoute(
                name: "Login",
                url: "login/",
                defaults: new { controller = "Player", action = "Login" }
            );

            routes.MapRoute(
                name: "ListeDesDroides",
                url: "liste/droides",
                defaults: new { controller = "Droide", action = "Index" }
            );

            routes.MapRoute(
                name: "EditionDroide",
                url: "edition-droide/{id}",
                defaults: new { controller = "Droide", action = "Edit" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
