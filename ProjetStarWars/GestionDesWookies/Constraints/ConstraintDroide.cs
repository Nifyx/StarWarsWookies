using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace GestionDesWookies.Constraints
{
    public class ConstraintDroide : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            bool ret = false;
            int nbDroides = Int32.Parse(values[parameterName].ToString());
            if (nbDroides > 1000)
                ret = true;
            return ret;
        }
    }
}