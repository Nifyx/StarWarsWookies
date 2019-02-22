using StarWarsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace GestionDesWookies.Constraints
{
    public class ConstraintPlanete : IRouteConstraint
    {
        private PlaneteDataLayer _dataLayer = new PlaneteDataLayer();
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            bool ret = false;
            int idPlanete = (int)values[parameterName];
            if (_dataLayer.Select("",idPlanete).Count > 0)
                ret = true;
            return ret;
        }
    }
}