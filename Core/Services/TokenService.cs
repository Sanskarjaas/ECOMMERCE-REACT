using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Core.Entities.Identity;
using Microsoft.Extensions.Configuration;

namespace Core.Services

{
    //public class TokenService
    //     {
    //         private readonly IConfiguration _config;
    //     private readonly SymmetricSecurityKey _key;

    //     public TokenService(IConfiguration config)
    //     {
    //         _config = config;
    //         _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));
    //     }
    //     public string CreateToken(AppUser user)
    //     {
    //         var claims = new List<Claim>
    //             {
    //                 new Claim(ClaimTypes.Email,user.Email),
    //                 new Claim(ClaimTypes.GivenName,user.DisplayName)


    //             };
    //         var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha5125Signature);
    //         var tokenDescriptor = new SecurityTokenDescriptor
    //         {
    //             SubjectAlternativeNameBuilder = new ClaimsIdentity(claims),

    //         };
    //         return null;
    //     }
    // }
}