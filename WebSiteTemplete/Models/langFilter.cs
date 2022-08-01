using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace TailorSystem.Models
{
    public class langFilter: ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            HttpCookie httpCookie = new HttpCookie("Language");
            String  ss;
            try
            {
              ss = HttpContext.Current.Request.Cookies["Language"].Value;

            }
            catch (Exception)
            {

                 ss = "";
            }
            var val = ss;
            if(ss == null ||ss=="")
            {
                val = "en";
            }
            
            if(val == "ar")
            {
                CultureInfo inf = CultureInfo.GetCultureInfo("ar-SA");
                Thread.CurrentThread.CurrentCulture = inf;
                Thread.CurrentThread.CurrentUICulture = inf;
            }
            if (val == "en")
            {
                CultureInfo inf = CultureInfo.GetCultureInfo("en-US");
                Thread.CurrentThread.CurrentCulture = inf;
                Thread.CurrentThread.CurrentUICulture = inf;
            }
        }
    }
}