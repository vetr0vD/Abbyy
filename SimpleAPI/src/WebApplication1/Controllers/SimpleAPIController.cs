using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Constartors;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;

namespace SimpleAPI.Controllers
{
    [Route("")]
    [RequireHttps]
    public class SimpleAPIController : Controller
    {
        IRepository _repository = null;

        public SimpleAPIController(
            IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("Login")]
        public async Task Login()
        {
            var user = Request.HttpContext.User;
            if (user == null || !user.Identities.Any(identity => identity.IsAuthenticated))
            {
                await Request.HttpContext.Authentication.ChallengeAsync("Facebook");
                return;
            }

            try
            {
                string email = null, id = null, firstname = null, surname = null;
                foreach (var it in user.Claims)
                {
                    if (it.Type.Contains("emailaddress"))
                    {
                        email = it.Value;
                    }
                    else if (it.Type.Contains("nameidentifier"))
                    {
                        id = it.Value;
                    }
                    else if (it.Type.Contains("givenname"))
                    {
                        firstname = it.Value;
                    }
                    else if (it.Type.Contains("surname"))
                    {
                        surname = it.Value;
                    }
                }

                _repository.SaveUser(new User(email, id, firstname, surname));
            }
            catch
            {
                await Request.HttpContext.Authentication.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return;
            }

            return;
        }

        [HttpGet("UserInfo")]
        public User[] GetUserInfo()
        {
            return _repository.GetUsers();
        }

        [HttpGet("Logout")]
        public async Task Logout()
        {
            var user = Request.HttpContext.User;
            if (user != null && user.Identities.Any(identity => identity.IsAuthenticated))
            {
                await Request.HttpContext.Authentication.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
        }
    }
}
