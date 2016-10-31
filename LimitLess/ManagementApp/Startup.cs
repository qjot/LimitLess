using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManagementApp.Startup))]
namespace ManagementApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
