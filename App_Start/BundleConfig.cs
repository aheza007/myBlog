using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace SimpleBlog.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/admin/scripts")
                .Include("~/Scripts/jquery-2.1.3.js")
                .Include("~/Scripts/jquery.validate.js")
                .Include("~/Scripts/jquery.validate.unobtrusive.js")
                .Include("~/Scripts/bootstrap.js")
                .Include("~/Areas/Admin/Scripts/Forms.js"));

            bundles.Add(new ScriptBundle("~/scripts")
                .Include("~/Scripts/jquery-2.1.3.js")
                .Include("~/Scripts/jquery.validate.js")
                .Include("~/Scripts/jquery.validate.unobtrusive.js")
                .Include("~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/admin/styles")
                .Include("~/Content/style/bootstrap.css")
                .Include("~/Content/style/Admin.css"));

            bundles.Add(new StyleBundle("~/styles")
                .Include("~/Content/Style/bootstrap.css")
                .Include("~/Content/Style/Site.css"));
            
        }
    }
}