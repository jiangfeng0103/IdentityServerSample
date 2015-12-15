using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Runtime.Caching;
using Abp.Zero.Configuration;
using Abp.Zero.Sso.Authorization.Users;
using Abp.Zero.Sso.MultiTenancy;

namespace Abp.Zero.Sso.Authorization.Roles
{
    public class RoleManager : AbpRoleManager<Tenant, Role, User>
    {
        public RoleManager(RoleStore store, IPermissionManager permissionManager, IRoleManagementConfig roleManagementConfig, ICacheManager cacheManager)
            : base(store, permissionManager, roleManagementConfig, cacheManager)
        {

        }
    }
}
