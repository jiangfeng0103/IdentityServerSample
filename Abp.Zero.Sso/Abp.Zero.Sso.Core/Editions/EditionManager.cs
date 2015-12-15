using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Editions;
using Abp.Application.Features;
using Abp.Domain.Repositories;

namespace Abp.Zero.Sso.Editions
{
    public class EditionManager : AbpEditionManager
    {
        public EditionManager(IRepository<Edition> editionRepository,
            IRepository<EditionFeatureSetting, long> editionFeatureRepository)
            : base(editionRepository, editionFeatureRepository) { }

        public const string DefaultEditionName = "Standard";

    }
}
