using InvilliaDDD.Identity.API.Extensions;
using InvilliaDDD.Identity.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InvilliaDDD.Identity.API.Controllers
{
    public partial class AccountController
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _signInManager.PasswordSignInAsync(userLogin.Login, userLogin.Password, false, true);

            if (result.Succeeded)
            {
                return CustomResponse(await GenerateJwt(userLogin.Login));
            }

            if (result.IsLockedOut)
            {
                AddError("User locked temporary by to many invalid tries");
                return CustomResponse();
            }

            AddError("User and/or password are incorrect");
            return CustomResponse();
        }

        private async Task<UserLoginSuccessful> GenerateJwt(string login)
        {
            var user = await _userManager.FindByNameAsync(login);

            var claims = await _userManager.GetClaimsAsync(user);

            var claimsIdentity = await GetUserClaims(claims, user);

            var encodedToken = EncodeToken(claimsIdentity);

            return GetTokenObject(encodedToken, user, claims);
        }

        private async Task<ClaimsIdentity> GetUserClaims(ICollection<Claim> claims, ApplicationUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.UtcNow.ToUnixEpochDate().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToUnixEpochDate().ToString()));

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var claimsIdentity = new ClaimsIdentity(claims);

            return claimsIdentity;
        }

        private string EncodeToken(ClaimsIdentity claimsIdentity)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpireInHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            return tokenHandler.WriteToken(token);
        }

        private UserLoginSuccessful GetTokenObject(string encodedToken, ApplicationUser user, IEnumerable<Claim> claims)
        {
            return new UserLoginSuccessful
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpireInHours).TotalMilliseconds,
                UserToken = new UserToken
                {
                    Id = user.Id,
                    Login = user.UserName,
                    Claims = claims.Select(x => new UserClaim { Type = x.Type, Value = x.Value })
                }
            };
        }
    }
}
