using Api.Models;
using DatabaseRepository;
using DatabaseRepository.Interfaces;
using Giveaways.Services.Interfaces;
using Giveaways.Services.Models;
using Giveaways.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Api.Controllers
{
    [EnableCors(origins: "http://couponsandgiveawaysapi.azurewebsites.net", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        public ILoginService LoginService;
        public IRegistrationService RegistrationService;

        public LoginController()
        {
            this.LoginService = new LoginService();
            this.RegistrationService = new RegistrationService();
        }

        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult AuthenticateUser([FromBody]UserLogin user)
        {
            if(!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, "ModelState is not valid");
            }
            bool authResult = LoginService.ValidateUser(user.UserName, user.Password);
            if(authResult)
            {
                return Ok(true);
            }
            return Content(HttpStatusCode.BadRequest, "Authentication failed");
        }

        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult RegisterUser([FromBody]UserRegistration user)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, "ModelState is not valid");
            }
            bool result = RegistrationService.RegisterUser(user);
            if(result)
            {
                return Ok(true);
            }
            return Content(HttpStatusCode.BadRequest, "Registration Failed");
        }

        [AllowAnonymous]
        [HttpGet]
        public string login()
        {
            return "login";
        }
    }
}
