using System.Web;
using System.Web.Optimization;

namespace WebSiteTemplete
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            //Style Bundles
            bundles.Add(new StyleBundle("~/css")
                            .Include("~/css/bootstrap.min.css",
                                     "~/css/owl.min.css",
                                     "~/css/owl.theme.default.css",
                                       "~/css/styles.css",
                                     "~/css/aos.css",
                                       "~/css/fancybox.css",
                                     "~/css/responsive-font.css",
                                      "~/css/fontawsome.min.css",
                                     "~/css/cust-fonts.css"));
            bundles.Add(new StyleBundle("~/js")
                  .Include("~/js/jquery.min_3.6.0.js",
                           "~/js/bootstrap.min.js",
                           "~/js/owl.carousel.min.js",
                             "~/js/fancybox.umd.js",
                           "~/js/aos.js",
                             "~/js/main.js"
                          ));
        }
    }
}
