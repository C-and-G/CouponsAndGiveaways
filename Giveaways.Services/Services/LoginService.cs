using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseRepository.Interfaces;
using System.Security.Cryptography;

namespace Giveaways.Services.Services
{
    public class LoginService
    {
        private readonly ILoginDetailsRepository LoginDetailsRepository;

        public LoginService(ILoginDetailsRepository loginDetailsRepository)
        {
            this.LoginDetailsRepository = loginDetailsRepository;
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
