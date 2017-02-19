using DatabaseRepository.Interfaces;
using Giveaways.DataMapping.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseRepository.Repositories
{
    public class UserDetailsRepository : RepositoryBase<UserDetails>, IUserDetailsRepository
    {
        public UserDetailsRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
