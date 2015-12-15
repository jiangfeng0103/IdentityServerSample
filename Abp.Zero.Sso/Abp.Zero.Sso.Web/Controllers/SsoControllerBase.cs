using Abp.Auditing;
using Abp.UI;
using Abp.IdentityFramework;
using Abp.Web.Mvc.Controllers;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace Abp.Zero.Sso.Web.Controllers
{
    public class SsoControllerBase : AbpController
    {
        protected SsoControllerBase()
        {
            LocalizationSourceName = SsoCoreConsts.LocalizationSourceName;
        }
    }
}