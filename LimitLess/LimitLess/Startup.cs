using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LimitLess.Startup))]
namespace LimitLess
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
