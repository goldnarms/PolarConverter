using System.Web.Optimization;

namespace PolarConverter.MVC.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/scripts/jquery-2.0.0.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/scripts/jquery-ui-1.10.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/scripts/jquery.unobtrusive*",
                        "~/scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/plupload").Include(
                "~/scripts/plupload.full.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/plupload2").Include(
                "~/scripts/plupload.js",
                "~/scripts/plupload.gears.js",
                "~/scripts/plupload.silverlight.js",
                "~/scripts/plupload.flash.js",
                "~/scripts/plupload.browserplus.js",
                "~/scripts/plupload.html4.js",
                "~/scripts/plupload.html5.js",
                "~/scripts/jquery.plupload.queue/jquery.plupload.queue.js",
                "~/scripts/jquery.ui.plupload/jquery.ui.plupload.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                "~/scripts/jstz*",
                "~/scripts/knockout-2.2.1.js",
                "~/scripts/knockout.localStorage.js",
                "~/scripts/viewModel.js",
                "~/scripts/polarconverter.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/normalize.css",
                "~/Content/Style.css",
                "~/scripts/jquery.plupload.queue/css/jquery.plupload.queue.css",
                "~/Content/themes/custom-theme/jquery-ui-1.8.21.custom.css",
                "~/Content/themes/base/jquery-ui.css",
                "~/Content/themes/base/jquery.ui.all.css"
                ));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"
                        ));
        }
    }
}