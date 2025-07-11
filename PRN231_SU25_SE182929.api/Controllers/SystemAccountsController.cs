using HandbagManagementRepository.Models;
using HandbagManagementService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PRN231_SU25_SE182929.api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class SystemAccountsController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ISystemAccountService _service;

        public class AuthRes()
        {
            public string Token { get; set; }
            public string Role { get; set; }
        }

        public SystemAccountsController(IConfiguration config, ISystemAccountService service)
        {
            _config = config;
            _service = service;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRq request)
        {
            var user = _service.GetAccount(request.Email, request.Password);

            if (user == null || user.Result == null)
                return Unauthorized();

            var token = GenerateJSONWebToken(user.Result);

            return Ok(new AuthRes
            {
                Token = token,
                Role = user.Result.Role.ToString()
            });
        }

        private string GenerateJSONWebToken(SystemAccount account)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"]
                    , _config["Jwt:Audience"]
                    , new Claim[]
                    {
                new(ClaimTypes.Name, account.Username),
                new(ClaimTypes.Role, account.Role.ToString()),
                    },
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }

        public sealed record LoginRq(string Email, string Password);
    }
}
