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

        private UserService _userService;
        private bool _allowDebugLogin;

        public AuthController(AppDbContext context, JwtGenService jwtGen, IConfiguration config, UserService userService)
        {
            _allowDebugLogin = config.GetValue<bool>("Jwt:AllowDebugLogin");
            _jwtGen = jwtGen;
            _context = context;
            _userService = userService;
        }

        [HttpPost("debug")]
        public async Task<IActionResult> DebugLogin([FromBody] DebugLoginInfoRequest info)
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

            return Ok(new { token = await _jwtGen.GenerateToken(user) });
        }


        // Authenticate against the api using google login information obtained via the google api
        [HttpPost("google")]
        public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginInfoRequest info)
        {

            var payload = await GoogleJsonWebSignature.ValidateAsync(info.Token);

            var googleId = payload.Subject;

            User? user;
            if (info.LinkKey != null)
            {
                user = await _userService.ConsumeLinkKey(info.LinkKey.Value);
                if (user == null)
                {
                    return BadRequest("Invalid link key");
                }
                user.GoogleId = googleId;
                user.Email = payload.Email;
                user.DisplayName = payload.Name;
                await _context.SaveChangesAsync();
            }
            else
            {
                user = await _context.Users.FirstOrDefaultAsync((u) => u.GoogleId == googleId);
                //TODO: Create a new user here once we add support for non admin users 
                if (user == null)
                {
                    return Unauthorized();
                }
            }



            return Ok(new { token = await _jwtGen.GenerateToken(user) });
        }

    }
}
