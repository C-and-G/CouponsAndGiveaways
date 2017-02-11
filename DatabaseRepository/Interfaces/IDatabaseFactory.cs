using Giveaways.DataMapping.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseRepository.Interfaces
{
    public interface IDatabaseFactory : IDisposable
    {
        GiveawaysEntities GetGiveawaysEntitiesContext();
    }
}
