using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PolarConverter.JSWeb.Startup))]
namespace PolarConverter.JSWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
