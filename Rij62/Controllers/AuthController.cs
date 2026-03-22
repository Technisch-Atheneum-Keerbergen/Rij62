// **********************************
//          *** CRUD  ***
// Author: Xavier Demaerel
// Date: 19/03/2026
// File: Controllers/OauthLogin.cs
// **********************************
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rij62.Data;
using Google.Apis.Auth;
using Rij62.Models.Api;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Rij62.Services;

namespace Rij62.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private AppDbContext _context;
        private JwtGenService _jwtGen;
        private bool _allowDebugLogin;

        public AuthController(AppDbContext context, JwtGenService jwtGen, IConfiguration config)
        {
            _allowDebugLogin = config.GetValue<bool>("Jwt:AllowDebugLogin");
            _jwtGen = jwtGen;
            _context = context;
        }

        [HttpPost("debug")]
        public async Task<IActionResult> DebugLogin([FromBody] DebugLoginInfo info)
        {
            if (!_allowDebugLogin)
            {
                return StatusCode(418); // I'm a tea pot
            }

            var user = await _context.Users.FindAsync(info.Id);
            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(new { token=await _jwtGen.GenerateToken(user)});
        }


        // Authenticate against the api using google login information obtained via the google api
        [HttpPost("google")]
        public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginInfo info)
        {

            var payload = await GoogleJsonWebSignature.ValidateAsync(info.Token);
           
            var googleId = payload.Subject;

            var user = await _context.Users.FirstOrDefaultAsync((u) => u.GoogleId == googleId);
            //TODO: Create a new user here once we add support for non admin users 
            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(new { token = await _jwtGen.GenerateToken(user) });
        }

    }
}
