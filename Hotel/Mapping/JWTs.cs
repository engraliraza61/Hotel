using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Hotel.DBClass;

namespace Hotel.Mapping
{
    public class JWTs
    {
        public static string GenerateJSONWebToken(Users userInfo, IConfiguration config)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //var claims = new[] {
            //new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username) };

            var claims = new[] {
             new Claim("userId", userInfo.UserId.ToString()),
             new Claim("userName", userInfo.UserTitle.ToString()),
             new Claim("phoneEmail", userInfo.Email.ToString()),
             new Claim("password", userInfo.Password.ToString()),
            };
            var token = new JwtSecurityToken(config["Jwt:Issuer"],
              config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
