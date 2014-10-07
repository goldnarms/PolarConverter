using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartupAttribute(typeof(PolarConverter.JSWeb.Startup))]
namespace PolarConverter.JSWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
            ConfigureAuth(app);
        }
    }
}
