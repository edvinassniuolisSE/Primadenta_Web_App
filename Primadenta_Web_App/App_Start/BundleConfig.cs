using System.Web.Optimization;

namespace Primadenta_Web_App
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/owl.carousel.js",
                        "~/Scripts/slick.js",
                        "~/Scripts/jquery.cookie.js",
                        "~/Scripts/waypoints.min.js",
                        "~/Scripts/jquery.counterup.min.js",
                        "~/Scripts/jquery.parallax-1.1.3.js",
                        "~/Scripts/front.js",
                        "~/Scripts/owl.carousel.min.js",
                        "~/Scripts/bootbox.js",
                        "~/Scripts/datatables/jquery.datatables.js",
                        "~/Scripts/datatables/datatables.bootstrap.js",
                        "~/Scripts/canvasjs.min.js",
                        "~/Scripts/jquery.canvasjs.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      //"~/Content/bootstrap.css",
                      //"~/Content/bootstrap.min.css",
                      //"~/Content/site.css",
                      "~/Content/CustomCSS/animate.css",
                      "~/Content/CustomCSS/custom.css",
                      "~/Content/CustomCSS/font-awesome.css"));
        }
    }
}
