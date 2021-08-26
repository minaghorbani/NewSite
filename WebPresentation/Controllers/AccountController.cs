using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebPresentation.Models;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace WebPresentation.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    public class AccountController : Controller
    {
        public IConfiguration Configuration { get;}
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            Configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //[Route("/api/token")]
        [HttpPost]
        public async Task<IActionResult> Token(string userName, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, false, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(userName);
                var token = GenerateJsonWebToken(user);

                return Ok(token);
            }
            else {
                return BadRequest("Not Found");
            }
        }

        public string GenerateJsonWebToken(ApplicationUser user)
        {
            var secretKey = Encoding.UTF8.GetBytes(Configuration["BearerTokens:Key"]);
            //var secretKey = Encoding.UTF8.GetBytes("this is a sample");
            var signinCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey),SecurityAlgorithms.HmacSha256Signature);

            var claims = GetUserClaims(user);

            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = Configuration["BearerTokens:Issuer"],
                Audience = Configuration["BearerTokens:Audience"],
                IssuedAt = DateTime.Now,
                NotBefore = DateTime.Now.AddMinutes(0),
                Expires= DateTime.Now.AddMinutes(60),
                SigningCredentials=signinCredentials,
                Subject=new ClaimsIdentity(claims),
            };

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            JwtSecurityTokenHandler.DefaultMapInboundClaims=false;
            JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();

            var tokenHandler = new JwtSecurityTokenHandler();

            var securityToken = tokenHandler.CreateToken(descriptor);

            var jwt = tokenHandler.WriteToken(securityToken);

            return jwt;
        }
        private IEnumerable<Claim> GetUserClaims(ApplicationUser user)
        {
            var securityStampClaimType = new ClaimsIdentityOptions().SecurityStampClaimType;

            var list = new List<Claim> {
            new Claim( ClaimTypes.Name,user.UserName),
            new Claim( ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim( securityStampClaimType,user.SecurityStamp.ToString()),
            //new Claim( ClaimTypes.Role),
            };

            //var roles=new Role[] 
            //list.Add(new Claim(ClaimTypes.Role, role.Name));
            return list;
        }
            
    }
}
