using FitnessApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FitnessApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly SymmetricSecurityKey _key;
        private readonly WorkoutDbContext _con;


        public TokenController(IConfiguration configuration, WorkoutDbContext con)
        {
            _key = new SymmetricSecurityKey(UTF8Encoding.UTF8.GetBytes(configuration["Key"]!));
            _con = con;
        }

        [HttpPost]
        public string GenerateToken(User user)
        {
            string token = string.Empty;
            string requiredRole = user.Role;
            // Static sign-in check for admin
            if (requiredRole == "Admin")
            {
                if (ValidateUser(user.EmailId, user.Password, requiredRole))
                {
                    token = GenerateAdminToken(user);
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                // Define the role required for token generation (e.g., "Admin" for regular users)
                // Adjust the required role as needed

                if (ValidateUser(user.EmailId, user.Password, requiredRole))
                {
                    var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.NameId, user.UserName!),
                    new Claim(JwtRegisteredClaimNames.Email, user.EmailId),
                    new Claim(ClaimTypes.Role, user.Role!) // Add the user's role as a claim
                };

                    var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
                    var tokenDescription = new SecurityTokenDescriptor
                    {
                        SigningCredentials = cred,
                        Subject = new ClaimsIdentity(claims),
                        Expires = DateTime.Now.AddMinutes(2)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var createToken = tokenHandler.CreateToken(tokenDescription);
                    token = tokenHandler.WriteToken(createToken);
                }
                else
                {
                    return string.Empty;
                }
            }

            return token;
        }

        // Static token generation for admin
        private string GenerateAdminToken(User user)
        {
            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.NameId, user.UserName),
            new Claim(JwtRegisteredClaimNames.Email, user.EmailId), // Static admin email
            new Claim(ClaimTypes.Role, user.Role) // Admin role
        };

            var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var tokenDescription = new SecurityTokenDescriptor
            {
                SigningCredentials = cred,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(2)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createToken = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(createToken);
        }

        // Validate user based on email, password, and role
        private bool ValidateUser(string email, string password, string requiredRole)
        {
            var user = _con.users.FirstOrDefault(u => u.EmailId == email && u.Password == password);
            return user != null && user.Role == requiredRole;
        }
    }
}
