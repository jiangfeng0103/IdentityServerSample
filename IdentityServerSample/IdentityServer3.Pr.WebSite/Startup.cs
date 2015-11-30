using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityServer3.Pr.WebSite.Startup))]
namespace IdentityServer3.Pr.WebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
