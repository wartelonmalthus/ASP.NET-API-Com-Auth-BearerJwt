using Microsoft.AspNetCore.Authentication;
using ApiAuth.Settings;
using Models.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ApiAuth.Services

{
    public static  class TokenService
    {   
        public static string GenerateToken(User user){

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(Settings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor{

                Subject = new ClaimsIdentity(new Claim[]{

                    new Claim(ClaimTypes.Name, user.Username), // User.Identity.Name
                    new Claim(ClaimTypes.Role, user.Role)   //User.IsInRole

                }),

                Expires = DateTimes.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key),
                SecurityAlgorithms.HmacSha256Signature )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
            



        }
    }
}