using System.Web;
using System.Web.Optimization;

namespace Limitless.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-1.12.1.js",
                         "~/Scripts/lib/moment.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/business-casual.css"));
            bundles.Add(new ScriptBundle("~/bundles/fullcalendarjs").Include(
                    "~/Scripts/fullcalendar.js",
                     "~/Scripts/views/calendarViewScript.js",
                     "~/Scripts/locale/en-gb.js",
                     "~/Scripts/views/eventView.js"));

            bundles.Add(new StyleBundle("~/bundles/fullcalendarcss").Include(
                       "~/Content/fullcalendar.css"));
        }
    }
}
