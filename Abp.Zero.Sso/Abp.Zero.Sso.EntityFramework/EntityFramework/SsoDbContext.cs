using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Zero.EntityFramework;
using Abp.Zero.Sso.Authorization.Roles;
using Abp.Zero.Sso.Authorization.Users;
using Abp.Zero.Sso.MultiTenancy;

namespace Abp.Zero.Sso.EntityFramework
{
    public class SsoDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public SsoDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in ModuleZeroSampleProjectDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of ModuleZeroSampleProjectDbContext since ABP automatically handles it.
         */
        public SsoDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        public SsoDbContext(DbConnection connection)
            : base(connection, true)
        {

        }
    }
}
