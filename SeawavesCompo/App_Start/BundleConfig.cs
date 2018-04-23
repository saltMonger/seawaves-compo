﻿using System.Web;
using System.Web.Optimization;

namespace SeawavesCompo
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/utils").Include(
                        "~/Scripts/BindingsUtils/knockout-3.4.2.js",
                        "~/Scripts/BindingsUtils/moment-with-locales.js"));

            bundles.Add(new ScriptBundle("~/bundles/timeutils").Include(
                        "~/Scripts/TimeEditingUtils/jquery.datetimepicker.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/jquery*"));


            //CUSTOM FILES
            bundles.Add(new ScriptBundle("~/User/UserPage").Include(
                       "~/Scripts/Users/ViewDetails/UserUpdateController.js"));


            //CONTROLLERS
            bundles.Add(new ScriptBundle("~/bundles/CompetitionHost").Include(
                "~/Scripts/Competitions/Create/CreateCompetitionViewModel.js",
                "~/Scripts/Competitions/Create/CreateCompetitionActions.js"));
        }
    }
}