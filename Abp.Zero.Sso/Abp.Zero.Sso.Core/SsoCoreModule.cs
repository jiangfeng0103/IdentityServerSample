using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Abp.Localization;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;

namespace Abp.Zero.Sso
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class SsoCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = true;

            //Add/remove languages for your application
            Configuration.Localization.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flag-gb",true));

            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    SsoCoreConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        Assembly.GetExecutingAssembly(),
                        "Abp.Zero.Sso.Localization.Source"
                        )
                    )
                );

        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
