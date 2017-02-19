using Giveaways.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giveaways.Services.Interfaces
{
    public interface IRegistrationService
    {
        bool RegisterUser(UserRegistration user);
    }
}
