using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Giveaways.Services
{
    public class RegistrationService
    {
        public string UserId { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
        public int MemberId { get; set; }
        public string HashedPassword { get; set; }
        
        private void CreateSalt()
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] data = new byte[4];
                rng.GetBytes(data);
                Salt = BitConverter.ToString(data);
            }
        }

        private void GenerateHashValue()
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Salt + Password));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            foreach(var i in result)
            {
                strBuilder.Append(i.ToString("x2"));
            }
            HashedPassword = strBuilder.ToString();
        }
    }
}
