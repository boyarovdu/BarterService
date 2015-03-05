using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BarterService.Web.Startup))]
namespace BarterService.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
