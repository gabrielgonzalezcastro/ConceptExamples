using System.Web.Optimization;
using Base.SinglePageApplication.Bundles;

namespace Base.SinglePageApplication
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // -Optional- set this to true to override web.config setting optimization mode based on debug compilation
            // allows you to programmatically determine if bundling is enabled via a custom methodology.
             BundleTable.EnableOptimizations = false;

            // -Optional- ignore for any of our testing files that get added since we never want our tests to run in optimized mode.
           // bundles.IgnoreList.Ignore("*.test.js", OptimizationMode.WhenEnabled);

            // -Optional- switch to any "optimized" extensions when running in optimization mode, if replacements can be found.
            //bundles.FileExtensionReplacementList.Add("optimized", OptimizationMode.WhenEnabled);

            #region Script Bundles
            // script bundle declarations
            // ScriptBundle is the same as generic bundle, except it automatically applies the default JsMinify transformation
            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/Scripts/modernizr-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/frameworks").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/underscore.js",
                "~/Scripts/angular.js",
                "~/Scripts/angular-route.js",
                "~/Scripts/toastr.js",
                "~/Scripts/lodash.js",
                "~/Scripts/restangular.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/ui-bootstrap-tpls-0.13.4.min.js",
                 "~/Scripts/angular-sanitize.js",
                 "~/Scripts/accounting.min.js"));

            // the order you include scripts in the bundle is the order they will be consolidated
            bundles.Add(new ScriptBundle("~/bundles/app")
                .Include("~/Scripts/app/bootstrap/restangularBootstrapper.js")
                .Include("~/Scripts/app/app.js")
                .IncludeDirectory("~/Scripts/app/services", "*.js")
                .IncludeDirectory("~/Scripts/app/controllers", "*.js"));


            #endregion

            #region Style Bundles
            
            // style bundle declarations, work the same as ScriptBundles except they have a CssMinify specific
            // transformation associated with them.
            bundles.Add(new LessStyleBundle("~/content/site").Include(
                "~/Content/bootstrap/bootstrap.css",
                "~/Content/site.less",
                "~/Content/toastr.css"));
            
            #endregion

        }
    }
}