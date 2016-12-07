using System.Web;
using System.Web.Optimization;

namespace ManagementApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                       "~/Scripts/jquery-{version}.js",
                       // needed for drag/move events in fullcalendar
                       "~/Scripts/jquery-{version}.js",
                       "~/Scripts/bootstrap.js",
                       "~/Scripts/lib/moment.min.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.1.1.js",
                        "~/Scripts/jquery-ui-1.8.12.js",
                         "~/Scripts/lib/moment.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            //Calendar css file
            bundles.Add(new StyleBundle("~/Content/fullcalendarcss").Include(
                     //"~/Content/themes/base/jquery.ui.all.css",
                     "~/Content/fullcalendar.min.css"
                     //"~/Script/fullcalendar.print.css"
                     ));

            //Calendar Script file

            bundles.Add(new ScriptBundle("~/bundles/fullcalendarjs").Include(
                     "~/Scripts/fullcalendar.js",
                      "~/Scripts/views/calendarViewScript.js"));
        }
    }
}
