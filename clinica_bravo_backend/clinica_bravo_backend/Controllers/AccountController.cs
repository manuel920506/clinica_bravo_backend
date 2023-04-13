using clinica_bravo_backend.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace clinica_bravo_backend.Controllers {
    [Route("api/accounts")]
    [ApiController]
    public class AccountController: ControllerBase {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, 
            IConfiguration configuration,
            SignInManager<IdentityUser> signInManager) {
            this.userManager = userManager;
            this.configuration = configuration;
            this.signInManager = signInManager;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthenticationResponse>> Login([FromBody] UserCredentials credentials) {
            var result = await signInManager.PasswordSignInAsync(credentials.Email, credentials.Password,
                isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded) {
                return await CreateToken(credentials);
            } else { 
                return BadRequest("Incorrect Login");
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult<AuthenticationResponse>> Create([FromBody] UserCredentials credentials) {
            var user = new IdentityUser { UserName = credentials.Email, Email = credentials.Email };
            var result = await userManager.CreateAsync(user, credentials.Password);

            if (result.Succeeded) {
               return await CreateToken(credentials);
            } else {
                return BadRequest(result.Errors);
            } 
        }

        private async Task<AuthenticationResponse> CreateToken(UserCredentials credentials) {
            var claims = new List<Claim>() {
                new Claim("email", credentials.Email)
            };

            var user = await userManager.FindByEmailAsync(credentials.Email);
            var climsDB = await userManager.GetClaimsAsync(user);

            claims.AddRange(climsDB);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["keyjwt"]));
            var credls = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration =  System.DateTime.UtcNow.AddYears(1);

            var token = new JwtSecurityToken(issuer: null, audience: null, claims: claims,
                expires: expiration, signingCredentials: credls);

            return new AuthenticationResponse() {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
