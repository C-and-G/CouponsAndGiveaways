using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseRepository.Interfaces;
using System.Security.Cryptography;
using Giveaways.Services.Models;
using Giveaways.Services.Interfaces;
using DatabaseRepository;
using DatabaseRepository.Repositories;

namespace Giveaways.Services.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginDetailsRepository LoginDetailsRepository;

        public LoginService()
        {
            IDatabaseFactory databaseFactory = new DatabaseFactory();
            LoginDetailsRepository = new LoginDetailsRepository(databaseFactory);
        }

        public bool ValidateUser(string userId, string password)
        {
            var salt = LoginDetailsRepository.GetUserSalt(userId);
            if (salt == null)
                return false;
            var userPassword = LoginDetailsRepository.GetUserPassword(userId);
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(salt + password));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            foreach (var i in result)
            {
                strBuilder.Append(i.ToString("x2"));
            }
            var hashedPassword = strBuilder.ToString();
            if (String.Equals(userPassword, hashedPassword))
                return true;
            return false;
        }
    }
}
