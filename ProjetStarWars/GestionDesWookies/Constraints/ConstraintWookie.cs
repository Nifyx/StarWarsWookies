using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace GestionDesWookies.Constraints
{
    public class ConstraintWookie : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            bool ret = false;
            int nbWookies = Int32.Parse(values[parameterName].ToString());
            if (nbWookies > 50 && nbWookies < 1000)
                ret = true;
            return ret;
        }
    }
}