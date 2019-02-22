using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestLog4NetWeb.Controllers
{
    public class SuperController : Controller
    {
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected override void OnException(ExceptionContext filterContext)
        {
            _logger.Info(filterContext.Exception.ToString());
            //_logger.Info(filterContext.RouteData);
            base.OnException(filterContext);
        }
    }
}