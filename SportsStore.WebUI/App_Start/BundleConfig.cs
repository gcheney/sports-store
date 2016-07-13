using System.Web.Optimization;

namespace SportsStore.WebUI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/styles")
                .Include("~/content/bootstrap.css")
                .Include("~/content/bootstrap-theme.css")
                .Include("~/content/error-styles.css"));

            bundles.Add(new ScriptBundle("~/scripts")
                .Include("~/scripts/jquery-1.9.1.js")
                .Include("~/scripts/jquery.validate.js")
                .Include("~/scripts/jquery.validate.unobtrusive.js")
                .Include("~/scripts/bootstrap.js"));
        }
    }
}