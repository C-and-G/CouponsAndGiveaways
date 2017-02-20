using DatabaseRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseRepository.Interfaces
{
    public interface ILoginDetailsRepository : IRepositoryBase<LoginDetails>
    {
        string GetUserSalt(string userId);

        string GetUserPassword(string userId);

        void AddUser(LoginDetails loginDetails);

        void UpdateUserPassword(LoginDetails loginDetails);
    }
}
