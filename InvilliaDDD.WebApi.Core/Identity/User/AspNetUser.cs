using InvilliaDDD.WebApi.Core.Identity.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace InvilliaDDD.WebApi.Core.Identity.User
{
    public class AspNetUser : IAspNetUser
    {
        private readonly IHttpContextAccessor _accessor;

        public AspNetUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Name => _accessor.HttpContext.User.Identity.Name;

        public Guid GetId()
        {
            return IsAuthenticated() ? Guid.Parse(_accessor.HttpContext.User.GetId()) : Guid.Empty;
        }

        public string GetEmail()
        {
            return IsAuthenticated() ? _accessor.HttpContext.User.GetEmail() : "";
        }

        public string GetToken()
        {
            return IsAuthenticated() ? _accessor.HttpContext.User.GetToken() : "";
        }

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public bool CheckRole(string role)
        {
            return _accessor.HttpContext.User.IsInRole(role);
        }

        public IEnumerable<Claim> GetClaims()
        {
            return _accessor.HttpContext.User.Claims;
        }

        public HttpContext GetHttpContext()
        {
            return _accessor.HttpContext;
        }
    }
}
