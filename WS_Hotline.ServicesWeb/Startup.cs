using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WS_Hotline.ServicesWeb.Startup))]
namespace WS_Hotline.ServicesWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

