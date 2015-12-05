using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using IdentityModel.Client;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.Notifications;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using IdentityServer3.Pr.WebSite.Models;

namespace IdentityServer3.Pr.WebSite
{
    public partial class Startup
    {
        // 有关配置身份验证的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {

            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ClientId = "sts",
                Authority = Constants.BaseAddress,
                RedirectUri = "http://www.b.com/",
                ResponseType = "id_token token",
                Scope = "openid email write",
                SignInAsAuthenticationType = "Cookies",
                
                Notifications = new OpenIdConnectAuthenticationNotifications
                {
                    SecurityTokenValidated = SecurityTokenValidated
                }
            });

        }

        static Task SecurityTokenValidated(SecurityTokenValidatedNotification<OpenIdConnectMessage,
            OpenIdConnectAuthenticationOptions> notification)
        {
            var token = notification.ProtocolMessage.AccessToken;
            if (!string.IsNullOrEmpty(token))
            {
                notification.AuthenticationTicket.Identity.AddClaim(new Claim("access_token", token));
            }

            return Task.FromResult(true);
        }
    }
}