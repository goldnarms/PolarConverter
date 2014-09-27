using System;
using System.Configuration;
using System.Diagnostics;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Nemiro.OAuth;
using Nemiro.OAuth.Clients;
using Newtonsoft.Json;
using PolarConverter.JSWeb.OauthClients;

namespace PolarConverter.JSWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ViewEngineConfig.RegisterViewEngines(ViewEngines.Engines);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            DependencyConfig.RegisterDependencies();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            HttpConfiguration config = GlobalConfiguration.Configuration;
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            MvcHandler.DisableMvcResponseHeader = true;
            OAuthManager.RegisterClient(new StravaOauthClient(ConfigurationManager.AppSettings["StravaClientId"], ConfigurationManager.AppSettings["StravaClientSecret"]));
            OAuthManager.RegisterClient(new FacebookClient(ConfigurationManager.AppSettings["FacebookId"], ConfigurationManager.AppSettings["FacebookSecret"]));

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var lastError = Server.GetLastError();
            Trace.TraceError("Application error: {0} --\n{1}", lastError.Message, lastError);
        }
    }
}
