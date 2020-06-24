using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ziekenhuis_StayHealthy.Startup))]
namespace Ziekenhuis_StayHealthy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
