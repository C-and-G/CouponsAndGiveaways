using DatabaseRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giveaways.DataMapping.Mapping;

namespace DatabaseRepository
{
    class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private GiveawaysEntities giveawaysEntitiesContext;

        public GiveawaysEntities GetGiveawaysEntitiesContext()
        {
            return giveawaysEntitiesContext ?? (giveawaysEntitiesContext = new GiveawaysEntities());
        }

        protected override void DisposeCore()
        {
            if (giveawaysEntitiesContext != null)
                giveawaysEntitiesContext.Dispose();
        }
    }
}
