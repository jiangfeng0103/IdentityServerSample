using IdentityServer3.Host.Configuration.Config;
using Microsoft.Owin;
using Owin;
using Serilog;

[assembly: OwinStartup(typeof(IdentityServer3.Host.Web.Startup))]

namespace IdentityServer3.Host.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Trace()
                .CreateLogger();

            app.UseIdentityServer();
        }
    }
}
