using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Rij62.Services;


public class JwtGenService
{
    
     private string _jwtIssuerSigningKey;

    public JwtGenService(IConfiguration config)
    {
         var key =  config.GetValue<string>("Jwt:IssuerSigningKey");
            _jwtIssuerSigningKey = key;
    }
    
    public async Task<string> GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_jwtIssuerSigningKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
                [
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("IsAdmin", user.IsAdmin.ToString())
                ]),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            )
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
        
    }
}