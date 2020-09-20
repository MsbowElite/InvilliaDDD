using AutoMapper;
using InvilliaDDD.Identity.API.Data.Interfaces;
using InvilliaDDD.Identity.API.Entities;
using InvilliaDDD.Identity.API.Helpers;
using InvilliaDDD.Identity.API.Models;
using InvilliaDDD.WebApi.Core.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InvilliaDDD.Identity.API.Services
{
    public interface IUserService
    {
        Task<UserAuthModel> Login(string username, string password);
        TokenModel Authentication();
        Task Register(User user, bool adminRole);
    }

    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly IRepositoryWrapper _rw;
        private readonly IMapper _mapper;

        public UserService(IOptions<AppSettings> appSettings, IRepositoryWrapper rw, IMapper mapper)
        {
            _appSettings = appSettings.Value;
            _rw = rw;
            _mapper = mapper;
        }

        public async Task Register(User user, bool adminRole)
        {
            user.Password = SecurePasswordHasher.Hash(user.Password, Encoding.ASCII.GetBytes(_appSettings.Salt));

            await _rw.User.CreateUser(user);

            if(adminRole) user.UserRoles.Add(new UserRoles { UserId = user.Id, RoleId = StaticRoles.Admin });

            user.UserRoles.Add(new UserRoles { UserId = user.Id, RoleId = StaticRoles.Friend });
            user.UserRoles.Add(new UserRoles { UserId = user.Id, RoleId = StaticRoles.Default });

            await _rw.User.UpdateUserAsync(user);
        }

        public async Task<UserAuthModel> Login(string username, string password)
        {
            password = SecurePasswordHasher.Hash(password, Encoding.ASCII.GetBytes(_appSettings.Salt));

            var user = await _rw.User.GetUserAuthenticateAsync(username, password);
            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.Now.AddYears(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            // resolve claims
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Id.ToString()));

            foreach (var role in user.UserRoles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role.RoleId));
            }

            tokenDescriptor.Subject = new ClaimsIdentity(identity);
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var resultUser = _mapper.Map<User, UserAuthModel>(user);
            resultUser.Token = tokenHandler.WriteToken(token);

            return resultUser;
        }

        public TokenModel Authentication()
        {
            var tokenModel = new TokenModel();
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Role, StaticRoles.Default)
                }),
                Expires = DateTime.Now.AddYears(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            tokenModel.Token = tokenHandler.WriteToken(token);

            return tokenModel;
        }
    }
}
