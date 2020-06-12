using System.Web.Optimization;

namespace ItAcademy.SchoolAdmin.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle(Links.Bundles.Scripts.Bootstrap).Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle(Links.Bundles.Content.Sitecontent).Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle(Links.Bundles.Scripts.JQuery).Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle(Links.Bundles.Scripts.JQueryValidation).Include(
                        "~/Scripts/jquery.validate*"));
        }
    }
}
