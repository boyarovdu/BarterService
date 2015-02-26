using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BarterService.Startup))]
namespace BarterService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
