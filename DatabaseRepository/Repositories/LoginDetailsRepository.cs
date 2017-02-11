using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseRepository.Repositories
{
    public class LoginDetailsRepository
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

    }
}
