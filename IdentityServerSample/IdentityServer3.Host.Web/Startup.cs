using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using Serilog;

namespace IdentityServer3.Host.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Trace()
                .CreateLogger();

            app.UseIdentityServer();
        }
    }
}