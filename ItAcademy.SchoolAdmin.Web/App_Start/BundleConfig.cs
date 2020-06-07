using System.Web;
using System.Web.Optimization;

namespace ItAcademy.SchoolAdmin.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle(Links.Bundles.Scripts.bootstrap).Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle(Links.Bundles.Content.sitecontent).Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
