﻿// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
public static partial class MVC
{
    public static ItAcademy.SchoolAdmin.Web.Controllers.EmployeeController Employee = new ItAcademy.SchoolAdmin.Web.Controllers.T4MVC_EmployeeController();
    public static ItAcademy.SchoolAdmin.Web.Controllers.HomeController Home = new ItAcademy.SchoolAdmin.Web.Controllers.T4MVC_HomeController();
    public static ItAcademy.SchoolAdmin.Web.Controllers.PositionController Position = new ItAcademy.SchoolAdmin.Web.Controllers.T4MVC_PositionController();
    public static ItAcademy.SchoolAdmin.Web.Controllers.SubjectController Subject = new ItAcademy.SchoolAdmin.Web.Controllers.T4MVC_SubjectController();
    public static ItAcademy.SchoolAdmin.Web.Controllers.TeacherController Teacher = new ItAcademy.SchoolAdmin.Web.Controllers.T4MVC_TeacherController();
    public static ItAcademy.SchoolAdmin.Web.Controllers.TestExceptionsController TestExceptions = new ItAcademy.SchoolAdmin.Web.Controllers.T4MVC_TestExceptionsController();
    public static ItAcademy.SchoolAdmin.Web.Controllers.WorkerController Worker = new ItAcademy.SchoolAdmin.Web.Controllers.T4MVC_WorkerController();
    public static T4MVC.SharedController Shared = new T4MVC.SharedController();
}

namespace T4MVC
{
}

#pragma warning disable 0436
namespace T4MVC
{
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class Dummy
    {
        private Dummy() { }
        public static Dummy Instance = new Dummy();
    }
}
#pragma warning restore 0436

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal partial class T4MVC_System_Web_Mvc_ActionResult : System.Web.Mvc.ActionResult, IT4MVCActionResult
{
    public T4MVC_System_Web_Mvc_ActionResult(string area, string controller, string action, string protocol = null): base()
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }
     
    public override void ExecuteResult(System.Web.Mvc.ControllerContext context) { }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public string Protocol { get; set; }
    public RouteValueDictionary RouteValueDictionary { get; set; }
}



namespace Links
{
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static class Content {
        public const string UrlPath = "~/Content";
        public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
        public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class css {
            public const string UrlPath = "~/Content/css";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class bootstrap {
                public const string UrlPath = "~/Content/css/bootstrap";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
                public static readonly string bootstrap_theme_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/bootstrap-theme.min.css") ? Url("bootstrap-theme.min.css") : Url("bootstrap-theme.css");
                public static readonly string bootstrap_theme_css_map = Url("bootstrap-theme.css.map");
                public static readonly string bootstrap_theme_min_css = Url("bootstrap-theme.min.css");
                public static readonly string bootstrap_theme_min_css_map = Url("bootstrap-theme.min.css.map");
                public static readonly string bootstrap_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/bootstrap.min.css") ? Url("bootstrap.min.css") : Url("bootstrap.css");
                public static readonly string bootstrap_css_map = Url("bootstrap.css.map");
                public static readonly string bootstrap_min_css = Url("bootstrap.min.css");
                public static readonly string bootstrap_min_css_map = Url("bootstrap.min.css.map");
            }
        
            public static readonly string Site_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/Site.min.css") ? Url("Site.min.css") : Url("Site.css");
        }
    
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class fonts {
            public const string UrlPath = "~/Content/fonts";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
            public static readonly string glyphicons_halflings_regular_eot = Url("glyphicons-halflings-regular.eot");
            public static readonly string glyphicons_halflings_regular_svg = Url("glyphicons-halflings-regular.svg");
            public static readonly string glyphicons_halflings_regular_ttf = Url("glyphicons-halflings-regular.ttf");
            public static readonly string glyphicons_halflings_regular_woff = Url("glyphicons-halflings-regular.woff");
            public static readonly string glyphicons_halflings_regular_woff2 = Url("glyphicons-halflings-regular.woff2");
        }
    
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class scripts {
            public const string UrlPath = "~/Content/scripts";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class js {
                public const string UrlPath = "~/Content/scripts/js";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
                public static readonly string EmployeeSearch_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/EmployeeSearch.min.js") ? Url("EmployeeSearch.min.js") : Url("EmployeeSearch.js");
                public static readonly string EmployeeUpdate_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/EmployeeUpdate.min.js") ? Url("EmployeeUpdate.min.js") : Url("EmployeeUpdate.js");
                public static readonly string LimitCheckbox_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/LimitCheckbox.min.js") ? Url("LimitCheckbox.min.js") : Url("LimitCheckbox.js");
                public static readonly string SubjectSearch_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/SubjectSearch.min.js") ? Url("SubjectSearch.min.js") : Url("SubjectSearch.js");
                public static readonly string SubjectUpdate_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/SubjectUpdate.min.js") ? Url("SubjectUpdate.min.js") : Url("SubjectUpdate.js");
            }
        
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class lib {
                public const string UrlPath = "~/Content/scripts/lib";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
                [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
                public static class bootstrap {
                    public const string UrlPath = "~/Content/scripts/lib/bootstrap";
                    public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
                    public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
                    public static readonly string bootstrap_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/bootstrap.min.js") ? Url("bootstrap.min.js") : Url("bootstrap.js");
                    public static readonly string bootstrap_min_js = Url("bootstrap.min.js");
                }
            
                [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
                public static class jquery {
                    public const string UrlPath = "~/Content/scripts/lib/jquery";
                    public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
                    public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
                    public static readonly string jquery_3_3_1_intellisense_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/jquery-3.3.1.intellisense.min.js") ? Url("jquery-3.3.1.intellisense.min.js") : Url("jquery-3.3.1.intellisense.js");
                    public static readonly string jquery_3_3_1_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/jquery-3.3.1.min.js") ? Url("jquery-3.3.1.min.js") : Url("jquery-3.3.1.js");
                    public static readonly string jquery_3_3_1_min_js = Url("jquery-3.3.1.min.js");
                    public static readonly string jquery_3_3_1_min_map = Url("jquery-3.3.1.min.map");
                    public static readonly string jquery_3_3_1_slim_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/jquery-3.3.1.slim.min.js") ? Url("jquery-3.3.1.slim.min.js") : Url("jquery-3.3.1.slim.js");
                    public static readonly string jquery_3_3_1_slim_min_js = Url("jquery-3.3.1.slim.min.js");
                    public static readonly string jquery_3_3_1_slim_min_map = Url("jquery-3.3.1.slim.min.map");
                }
            
                [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
                public static class jquery_signalr {
                    public const string UrlPath = "~/Content/scripts/lib/jquery-signalr";
                    public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
                    public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
                    public static readonly string jquery_signalR_2_4_1_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/jquery.signalR-2.4.1.min.js") ? Url("jquery.signalR-2.4.1.min.js") : Url("jquery.signalR-2.4.1.js");
                    public static readonly string jquery_signalR_2_4_1_min_js = Url("jquery.signalR-2.4.1.min.js");
                }
            
                [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
                public static class jquery_validation {
                    public const string UrlPath = "~/Content/scripts/lib/jquery-validation";
                    public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
                    public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
                    public static readonly string jquery_validate_vsdoc_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/jquery.validate-vsdoc.min.js") ? Url("jquery.validate-vsdoc.min.js") : Url("jquery.validate-vsdoc.js");
                    public static readonly string jquery_validate_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/jquery.validate.min.js") ? Url("jquery.validate.min.js") : Url("jquery.validate.js");
                    public static readonly string jquery_validate_min_js = Url("jquery.validate.min.js");
                    public static readonly string jquery_validate_unobtrusive_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/jquery.validate.unobtrusive.min.js") ? Url("jquery.validate.unobtrusive.min.js") : Url("jquery.validate.unobtrusive.js");
                    public static readonly string jquery_validate_unobtrusive_min_js = Url("jquery.validate.unobtrusive.min.js");
                }
            
            }
        
        }
    
    }

    
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static partial class Bundles
    {
        public static partial class Content 
        {
            public static partial class css 
            {
                public static partial class bootstrap 
                {
                    public static class Assets
                    {
                        public static readonly string bootstrap_theme_css = T4MVCHelpers.ProcessAssetPath("~/Content/css/bootstrap/bootstrap-theme.css");
                        public static readonly string bootstrap_theme_min_css = T4MVCHelpers.ProcessAssetPath("~/Content/css/bootstrap/bootstrap-theme.min.css");
                        public static readonly string bootstrap_css = T4MVCHelpers.ProcessAssetPath("~/Content/css/bootstrap/bootstrap.css");
                        public static readonly string bootstrap_min_css = T4MVCHelpers.ProcessAssetPath("~/Content/css/bootstrap/bootstrap.min.css");
                    }
                }
                public static class Assets
                {
                    public static readonly string Site_css = T4MVCHelpers.ProcessAssetPath("~/Content/css/Site.css");
                }
            }
            public static partial class fonts 
            {
                public static class Assets
                {
                }
            }
            public static partial class scripts 
            {
                public static partial class js 
                {
                    public static class Assets
                    {
                        public static readonly string EmployeeSearch_js = T4MVCHelpers.ProcessAssetPath("~/Content/scripts/js/EmployeeSearch.js"); 
                        public static readonly string EmployeeUpdate_js = T4MVCHelpers.ProcessAssetPath("~/Content/scripts/js/EmployeeUpdate.js"); 
                        public static readonly string LimitCheckbox_js = T4MVCHelpers.ProcessAssetPath("~/Content/scripts/js/LimitCheckbox.js"); 
                        public static readonly string SubjectSearch_js = T4MVCHelpers.ProcessAssetPath("~/Content/scripts/js/SubjectSearch.js"); 
                        public static readonly string SubjectUpdate_js = T4MVCHelpers.ProcessAssetPath("~/Content/scripts/js/SubjectUpdate.js"); 
                    }
                }
                public static partial class lib 
                {
                    public static partial class bootstrap 
                    {
                        public static class Assets
                        {
                            public static readonly string bootstrap_js = T4MVCHelpers.ProcessAssetPath("~/Content/scripts/lib/bootstrap/bootstrap.js"); 
                            public static readonly string bootstrap_min_js = T4MVCHelpers.ProcessAssetPath("~/Content/scripts/lib/bootstrap/bootstrap.min.js"); 
                        }
                    }
                    public static partial class jquery 
                    {
                        public static class Assets
                        {
                            public static readonly string jquery_3_3_1_intellisense_js = T4MVCHelpers.ProcessAssetPath("~/Content/scripts/lib/jquery/jquery-3.3.1.intellisense.js"); 
                            public static readonly string jquery_3_3_1_js = T4MVCHelpers.ProcessAssetPath("~/Content/scripts/lib/jquery/jquery-3.3.1.js"); 
                            public static readonly string jquery_3_3_1_min_js = T4MVCHelpers.ProcessAssetPath("~/Content/scripts/lib/jquery/jquery-3.3.1.min.js"); 
                            public static readonly string jquery_3_3_1_slim_js = T4MVCHelpers.ProcessAssetPath("~/Content/scripts/lib/jquery/jquery-3.3.1.slim.js"); 
                            public static readonly string jquery_3_3_1_slim_min_js = T4MVCHelpers.ProcessAssetPath("~/Content/scripts/lib/jquery/jquery-3.3.1.slim.min.js"); 
                        }
                    }
                    public static partial class jquery_signalr 
                    {
                        public static class Assets
                        {
                            public static readonly string jquery_signalR_2_4_1_js = T4MVCHelpers.ProcessAssetPath("~/Content/scripts/lib/jquery-signalr/jquery.signalR-2.4.1.js"); 
                            public static readonly string jquery_signalR_2_4_1_min_js = T4MVCHelpers.ProcessAssetPath("~/Content/scripts/lib/jquery-signalr/jquery.signalR-2.4.1.min.js"); 
                        }
                    }
                    public static partial class jquery_validation 
                    {
                        public static class Assets
                        {
                            public static readonly string jquery_validate_js = T4MVCHelpers.ProcessAssetPath("~/Content/scripts/lib/jquery-validation/jquery.validate.js"); 
                            public static readonly string jquery_validate_min_js = T4MVCHelpers.ProcessAssetPath("~/Content/scripts/lib/jquery-validation/jquery.validate.min.js"); 
                            public static readonly string jquery_validate_unobtrusive_js = T4MVCHelpers.ProcessAssetPath("~/Content/scripts/lib/jquery-validation/jquery.validate.unobtrusive.js"); 
                            public static readonly string jquery_validate_unobtrusive_min_js = T4MVCHelpers.ProcessAssetPath("~/Content/scripts/lib/jquery-validation/jquery.validate.unobtrusive.min.js"); 
                        }
                    }
                    public static class Assets
                    {
                    }
                }
                public static class Assets
                {
                }
            }
            public static class Assets
            {
            }
        }
    }
}

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal static class T4MVCHelpers {
    // You can change the ProcessVirtualPath method to modify the path that gets returned to the client.
    // e.g. you can prepend a domain, or append a query string:
    //      return "http://localhost" + path + "?foo=bar";
    private static string ProcessVirtualPathDefault(string virtualPath) {
        // The path that comes in starts with ~/ and must first be made absolute
        string path = VirtualPathUtility.ToAbsolute(virtualPath);
        
        // Add your own modifications here before returning the path
        return path;
    }

    private static string ProcessAssetPathDefault(string virtualPath) {
        // The path that comes in starts with ~/ and should retain this prefix
        return virtualPath;
    }

    // Calling ProcessVirtualPath through delegate to allow it to be replaced for unit testing
    public static Func<string, string> ProcessVirtualPath = ProcessVirtualPathDefault;
    public static Func<string, string> ProcessAssetPath = ProcessAssetPathDefault;

    // Calling T4Extension.TimestampString through delegate to allow it to be replaced for unit testing and other purposes
    public static Func<string, string> TimestampString = System.Web.Mvc.T4Extensions.TimestampString;

    // Logic to determine if the app is running in production or dev environment
    public static bool IsProduction() { 
        return (HttpContext.Current != null && !HttpContext.Current.IsDebuggingEnabled); 
    }
}





#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114


