using Api.Models;
using Giveaways.Services.Interfaces;
using Giveaways.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class LoginController : ApiController
    {
        public ILoginService LoginService;
        public IRegistrationService RegistrationService;

        public LoginController(ILoginService loginService)
        {
            this.LoginService = loginService;
        }

        [HttpPost]
        public IHttpActionResult AuthenticateUser([FromBody]UserLogin user)
        {
            bool authResult = LoginService.ValidateUser(user.UserName, user.Password);
            if(authResult)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpPost]
        public IHttpActionResult RegisterUser([FromBody]UserRegistration user)
        {
            bool result = RegistrationService.RegisterUser(user);
            if(result)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        // GET: api/Login
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Login
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
    }
}
