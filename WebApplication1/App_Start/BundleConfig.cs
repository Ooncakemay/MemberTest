using System.Web;
using System.Web.Optimization;

namespace WebApplication1
{
    public class BundleConfig
    {
        // 如需「搭配」的詳細資訊，請瀏覽 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                     "~/Scripts/jquery-3.3.1.min.js",
                         "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好實際執行時，請使用 http://modernizr.com 上的建置工具，只選擇您需要的測試。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(

                      "~/Content/AuthModel.Areas.Admin.Content.reset.css",
                      "~/Content/AuthModel.Areas.Admin.Content.Header.css",
                      "~/Content/jquery.ui.core.css",
                      "~/Content/jquery.ui.resizable.css",
                      "~/Content/jquery.ui.selectable.css",
                      "~/Content/jquery.ui.accordion.css",
                      "~/Content/jquery.ui.autocomplete.css",
                      "~/Content/jquery.ui.button.css",
                      "~/Content/jquery.ui.dialog.css",
                      "~/Content/jquery.ui.slider.css",
                      "~/Content/jquery.ui.tabs.css",
                      "~/Content/jquery.ui.datepicker..css",
                      "~/Content/jquery.ui.progressbar.css",
                      "~/Content/jquery.ui.theme.css",
                       "~/Content/member.css",
                      "~/Content/style.css"));
        }
    }
}
