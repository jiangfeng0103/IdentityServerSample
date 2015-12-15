using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Modules;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;

namespace Abp.Zero.Sso.WebApi
{
     [DependsOn(typeof(AbpWebApiModule), typeof(SsoApplicationModule))]
    public class SsoWebApiModule : AbpModule
    {
         public override void Initialize()
         {
             IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

             DynamicApiControllerBuilder
                 .ForAll<IApplicationService>(typeof(SsoApplicationModule).Assembly, "app")
                 .Build();
         }
    }
}
