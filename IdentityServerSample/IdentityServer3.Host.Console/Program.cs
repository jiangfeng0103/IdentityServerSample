using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Owin;
using Serilog;

namespace IdentityServer3.Host.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Title = "IdentityServer3";

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.LiterateConsole()
                .CreateLogger();

            var webApp = WebApp.Start("https://localhost:44333", app => app.UseIdentityServer());

            System.Console.WriteLine("identityserver up and running....");

            while (true)
            {
                var key = System.Console.ReadKey(true);
                if (key.Key == ConsoleKey.B)
                {
                    Process.Start("https://localhost:44333/core");
                }
                else
                {
                    break;
                }
            }

            webApp.Dispose();
        }
    }
}
