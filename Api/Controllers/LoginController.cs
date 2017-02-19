using Api.Models;
using Giveaways.Services.Interfaces;
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

        public LoginController(ILoginService loginService)
        {
            this.LoginService = loginService;
        }

        [HttpGet]
        public HttpStatusCode AuthenticateUser([FromBody]UserLogin user)
        {
            bool authResult = LoginService.ValidateUser(user.UserName, user.Password);
            if(authResult)
            {
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.Forbidden;
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
