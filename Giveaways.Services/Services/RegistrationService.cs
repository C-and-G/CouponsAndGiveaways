using DatabaseRepository.Interfaces;
using Giveaways.DataMapping.Mapping;
using Giveaways.Services.Interfaces;
using Giveaways.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Giveaways.Services.Services
{
    public class RegistrationService : IRegistrationService
    {
        public IUserDetailsRepository UserDetailsRepository;
        public IUnitOfWork UnitOfWork;
        public ILoginDetailsRepository LoginDetailsRepository;
        
        public RegistrationService(IUserDetailsRepository userDetailsRepository, IUnitOfWork unitOfWork, ILoginDetailsRepository loginDetailsRepository)
        {
            this.UserDetailsRepository = userDetailsRepository;
            this.UnitOfWork = unitOfWork;
            this.LoginDetailsRepository = loginDetailsRepository;
        }
        private string CreateSalt()
        {
            var salt = string.Empty;
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] data = new byte[4];
                rng.GetBytes(data);
                salt = BitConverter.ToString(data);
            }
            return salt;
        }

        private string GenerateHashValue(string salt, string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(salt + password));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            foreach(var i in result)
            {
                strBuilder.Append(i.ToString("x2"));
            }
            return strBuilder.ToString();
        }

        public bool RegisterUser(UserRegistration user)
        {
            var userDetails = new UserDetails();
            var existingUser = UserDetailsRepository.GetAll().FirstOrDefault(p => p.Email == user.Email);
            if (existingUser != null)
                return false;
            PopulateUserDetails(userDetails, user);
            UserDetailsRepository.Add(userDetails);
            UnitOfWork.Commit();
            var loginDetails = new LoginDetails()
            {
                MemberId = userDetails.MemberId
            };
            PopulateLoginDetails(loginDetails, user);
            LoginDetailsRepository.Add(loginDetails);
            this.UnitOfWork.Commit();
            return true;
        }

        private void PopulateLoginDetails(LoginDetails loginDetails, UserRegistration user)
        {
            loginDetails.Salt = CreateSalt();
            loginDetails.Password = GenerateHashValue(loginDetails.Salt, loginDetails.Password);
            loginDetails.UserId = user.Email;
            loginDetails.VerificationStatus = false;
        }

        private void PopulateUserDetails(UserDetails userDetails, UserRegistration user)
        {
            userDetails.Age = user.Age;
            userDetails.Email = user.Email;
            userDetails.FirstName = user.FirstName;
            userDetails.Gender = user.Gender;
            userDetails.LastName = user.LastName;
            userDetails.MemberId = Guid.NewGuid().ToString();
        }
    }
}
