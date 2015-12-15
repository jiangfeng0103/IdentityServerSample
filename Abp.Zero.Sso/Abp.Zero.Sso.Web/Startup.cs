using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Abp.Zero.Sso.Web.Startup))]
namespace Abp.Zero.Sso.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
