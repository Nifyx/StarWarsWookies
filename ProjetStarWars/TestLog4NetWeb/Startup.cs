using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestLog4NetWeb.Startup))]
namespace TestLog4NetWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
