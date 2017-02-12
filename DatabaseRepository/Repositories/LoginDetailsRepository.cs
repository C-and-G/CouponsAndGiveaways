using DatabaseRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giveaways.DataMapping.Mapping;

namespace DatabaseRepository.Repositories
{
    public class LoginDetailsRepository : RepositoryBase<LoginDetails>, ILoginDetailsRepository
    {
        public LoginDetailsRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        public string GetUserSalt(string userId)
        {
            var user = this.GetAll().FirstOrDefault(p => p.UserId == userId);
            if (user == null)
                return null;
            return user.Salt;
        }

        public string GetUserPassword(string userId)
        {
            var user = this.GetAll().FirstOrDefault(p => p.UserId == userId);
            if (user == null)
                return null;
            return user.Password;
        }

        public void AddUser(LoginDetails loginDetails)
        {
            this.Add(loginDetails);
        }

        public void UpdateUserPassword(LoginDetails loginDetails)
        {
            var details = this.GetAll().FirstOrDefault(p => p.MemberId == loginDetails.MemberId);
            details.Password = loginDetails.Password;
            details.Salt = loginDetails.Salt;
            this.Update(details);
        }
    }
}