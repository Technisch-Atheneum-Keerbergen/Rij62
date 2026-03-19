// **********************************
//          *** CRUD  ***
// Author: Xavier Demaerel
// Date: 19/03/2026
// File: Controllers/OauthLogin.cs
// **********************************
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Rij62.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        [HttpGet("login")]
        public IActionResult Login()
        {
            var redirectUrl = Url.Action("GoogleResponse", "Auth", null, Request.Scheme);
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            return Challenge(properties, "Google");
        }

        [HttpGet("google-response")]
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync("Cookies");

            var claims = result.Principal.Identities.FirstOrDefault()?.Claims;

            var email = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var name = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            // TODO: create user / generate JWT

            var token = "test_token"; // later JWT

            return Redirect($"http://localhost:5173/auth/callback?token={token}");
        }
    }
}
