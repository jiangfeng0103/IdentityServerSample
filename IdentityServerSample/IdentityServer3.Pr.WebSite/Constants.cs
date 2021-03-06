﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityServer3.Pr.WebSite
{
    public static class Constants
    {
        public const string BaseAddress = "http://www.sts.com/core";

        public const string AuthorizeEndpoint = BaseAddress + "/connect/authorize";
        public const string LogoutEndpoint = BaseAddress + "/connect/endsession";
        public const string TokenEndpoint = BaseAddress + "/connect/token";
        public const string UserInfoEndpoint = BaseAddress + "/connect/userinfo";
        public const string IdentityTokenValidationEndpoint = BaseAddress + "/connect/identitytokenvalidation";
        public const string TokenRevocationEndpoint = BaseAddress + "/connect/revocation";
    }
}