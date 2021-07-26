using JWT_1.Models;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace JWT_1.Helpers
{
    public class TokenGenerator
    {

        public static string GenerateToken(int userId, string username, ICollection<Role> roles)
        {
            string key = StaticValues.JWT_Secret;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<String> stringRoles = new List<string>();

            foreach(var role in roles)
            {
                stringRoles.Add(role.Name);
            }
            //create list of the claims

            var permClaims = new List<Claim>
            {
                new Claim (JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
                new Claim (JwtRegisteredClaimNames.Nbf , new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim (JwtRegisteredClaimNames.Exp , new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
                new Claim("Id",userId.ToString()),
                new Claim("Name",username.ToString()),
                new Claim("Roles", JsonConvert.SerializeObject(stringRoles)),

            };

            //Create Secrurity token object by giving required parameters

            var header = new JwtHeader(credentials);
            var payload = new JwtPayload(permClaims);
            var token = new JwtSecurityToken(header, payload);
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt_token;

        }
    }
}