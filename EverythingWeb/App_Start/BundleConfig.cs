using System.Web;
using System.Web.Optimization;

namespace EverythingWeb
{
    public class BundleConfig
    {
        //捆绑是通过 RegisterBundles 参数对象的 Add 方法添加。Add 方法的参数需要一个ScriptBundle类或
        //StyleBundle 类的实例对象，脚本文件用的是ScriptBundle 类，样式文件用的是StyleBundle类，
        //它们的构造参数代表着捆绑在一起的文件的引用。Include方法用于包含具体要捆绑的文件。
        //其中的 {version} 是文件版本的占位符，MVC会在相应的目录下定位到最新的一个版本文件。
        // 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备就绪，请使用 https://modernizr.com 上的生成工具仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
