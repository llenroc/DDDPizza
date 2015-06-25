using System.Web.Optimization;

namespace DDDPizza.Api
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/lib/jquery/dist/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/lib/modernizr/modernizr.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/lib/bootstrap/dist/js/bootstrap.js",
                      "~/Scripts/lib/respond/src/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                      "~/Scripts/lib/angular/angular.js",
                      "~/Scripts/lib/angular-resource/angular-resource.js",
                      "~/Scripts/lib/angular-animate/angular-animate.js",
                      "~/Scripts/lib/angular-sanitize/angular-sanitize.js",
                      "~/Scripts/lib/angular-ui-router/release/angular-ui-router.js",
                      "~/Scripts/lib/angular-bootstrap/ui-bootstrap-tpls.js",
                      "~/Scripts/lib/angular-filter/dist/angular-filter.js",
                      "~/Scripts/lib/angular-toastr/dist/angular-toastr.tpls.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Scripts/lib/font-awesome/css/font-awesome.css",
                      "~/Scripts/lib/angular-toastr/dist/angular-toastr.css",
                      "~/Scripts/lib/angular-bootstrap/ui-bootstrap-csp.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                 "~/Scripts/app/app.min.js"));



        }
    }
}
