﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
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
                RedirectUri = "http://www.a.com/",
                ResponseType = "id_token token",
                //Scope = "openid email write",
                SignInAsAuthenticationType = "Cookies",



                Notifications = new OpenIdConnectAuthenticationNotifications
                   {
                       SecurityTokenValidated = async n =>
                           {
                               var nid = new ClaimsIdentity(
                                   n.AuthenticationTicket.Identity.AuthenticationType,
                                   IdentityServer3.Core.Constants.ClaimTypes.GivenName,
                                   IdentityServer3.Core.Constants.ClaimTypes.Role);

                               //// get userinfo data
                               var userInfoClient = new UserInfoClient(
                                   new Uri(n.Options.Authority + "/connect/userinfo"),
                                   n.ProtocolMessage.AccessToken);

                               var userInfo = await userInfoClient.GetAsync();
                               userInfo.Claims.ToList().ForEach(ui => nid.AddClaim(new Claim(ui.Item1, ui.Item2)));

                               // keep the id_token for logout
                               nid.AddClaim(new Claim("id_token", n.ProtocolMessage.IdToken));

                               // add access token for sample API
                               nid.AddClaim(new Claim("access_token", n.ProtocolMessage.AccessToken));

                               // keep track of access token expiration
                               nid.AddClaim(new Claim("expires_at", DateTimeOffset.Now.AddSeconds(int.Parse(n.ProtocolMessage.ExpiresIn)).ToString()));

                               // add some other app specific claim
                               nid.AddClaim(new Claim("app_specific", "some data"));

                               n.AuthenticationTicket = new AuthenticationTicket(
                                   nid,
                                   n.AuthenticationTicket.Properties);
                           },

                       RedirectToIdentityProvider = n =>
                           {
                               if (n.ProtocolMessage.RequestType == OpenIdConnectRequestType.LogoutRequest)
                               {
                                   var idTokenHint = n.OwinContext.Authentication.User.FindFirst("id_token");

                                   if (idTokenHint != null)
                                   {
                                       n.ProtocolMessage.IdTokenHint = idTokenHint.Value;
                                   }
                               }

                               return Task.FromResult(0);
                           }
                   }
            });
        }
    }
}