using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.MultiTenancy;
using Abp.Runtime.Session;
using Abp.Zero.Sso.Authorization.Users;
using Abp.Zero.Sso.MultiTenancy;
using Microsoft.AspNet.Identity;

namespace Abp.Zero.Sso
{
    public abstract class SsotApplicationServiceBase : ApplicationService
    {
         public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected SsotApplicationServiceBase()
        {
            LocalizationSourceName = SsoCoreConsts.LocalizationSourceName;
        }

        protected virtual Task<User> GetCurrentUserAsync()
        {
            var user = UserManager.FindByIdAsync(AbpSession.GetUserId());
            if (user == null)
            {
                throw new ApplicationException("There is no current user!");
            }
            return user;
        }

        protected virtual User GetCurrentUser()
        {
            var user = UserManager.FindById(AbpSession.GetUserId());
            if (user == null)
            {
                throw new ApplicationException("There is no current user!");
            }
            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual Tenant GetCurrentTenant()
        {
            return TenantManager.GetById(AbpSession.GetTenantId());
        }
    }
}
