using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Limitless.Web.Startup))]
namespace Limitless.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
