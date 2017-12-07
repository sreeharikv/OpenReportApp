using System.Web;
using System.Web.Optimization;

namespace OpenReportApp.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //BUNDLE:   ~/bundles/jquery
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.1.4.min.js"));

            //BUNDLE:   ~/bundles/jqueryval
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            //BUNDLE:   ~/bundles/knockout
            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                        "~/Scripts/knockout-3.4.2.js",
                        "~/Scripts/knockout.validation.js",
                        "~/Scripts/knockout.mapping-latest.js"));

            //BUNDLE:   ~/bundles/bootstrap/js
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.min.js"));

            //BUNDLE:   ~/bundles/modernizr
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));


            //BUNDLE:   ~/bundles/bootstrap/css
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                "~/Content/css/bootstrap.min.css"));

            //BUNDLE:   ~/Content/css
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/css/layout.css",
                 "~/Content/css/icons.css",
                 "~/Content/css/uielements.css"));

            Add_AppScripts(bundles);
        }

        private static void Add_AppScripts(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/App").Include(
            //    "")
            //    );
        }
    }
}