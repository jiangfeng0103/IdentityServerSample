using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using Abp.Zero.Sso.Authorization.Roles;
using Abp.Zero.Sso.Authorization.Users;
using Abp.Zero.Sso.Editions;

namespace Abp.Zero.Sso.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, Role, User>
    {
        public TenantManager(IRepository<Tenant> tenantRepository,
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, EditionManager editionManager)
            : base(tenantRepository, tenantFeatureRepository, editionManager)
        {

        }
    }
}
