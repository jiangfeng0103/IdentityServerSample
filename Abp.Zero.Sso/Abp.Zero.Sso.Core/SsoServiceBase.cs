using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abp.Zero.Sso
{
    public abstract class SsoServiceBase : AbpServiceBase
    {
        protected SsoServiceBase()
        {
            LocalizationSourceName = SsoCoreConsts.LocalizationSourceName;
        }
    }
}
