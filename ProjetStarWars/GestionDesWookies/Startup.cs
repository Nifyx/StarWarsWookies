using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GestionDesWookies.Startup))]
namespace GestionDesWookies
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
