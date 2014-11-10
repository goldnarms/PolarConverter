using System.Web;
using System.Web.Optimization;

namespace PolarConverter.JSWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/libraries").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-animate.js",
                        "~/Scripts/underscore.js",
                        "~/Scripts/angulartics.js",
                        "~/Scripts/angulartics-ga.js",
                        "~/bower_components/angular-local-storage/angular-local-storage.js",
                        "~/bower_components/angular-promise-tracker/promise-tracker.js",
                        "~/bower_components/angular-loading-bar/src/loading-bar.js",
                        "~/bower_components/angular-scroll/angular-scroll.js"
                        )
                        .IncludeDirectory("~/App/Controllers/", "*.js")
                        .IncludeDirectory("~/App/Directives/", "*.js")
                        .IncludeDirectory("~/App/Enums/", "*.js")
                        .IncludeDirectory("~/App/Services/", "*.js")
                        .Include("~/App/app.js")
                        .Include("~/App/config.js")
                        );

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/bower_components/bootstrap/dist/js/bootstrap.js",
                        "~/bower_components/bootstrap-datepicker/js/bootstrap-datepicker.js",
                        "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/bower_components/bootstrap/dist/css/bootstrap.css",
                        "~/bower_components/bootstrap-datepicker/css/datepicker.css",
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/bower_components/angular-busy/angular-busy.css",
                      "~/bower_components/angular-loading-bar/src/loading-bar.css",
                      "~/Content/fontello.css"));
        }
    }
}
