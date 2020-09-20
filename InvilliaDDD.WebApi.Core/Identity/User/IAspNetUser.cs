using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace InvilliaDDD.WebApi.Core.Identity.User
{
    public interface IAspNetUser
    {
        string Name { get; }

        Guid GetId();

        string GetEmail();

        string GetToken();

        bool IsAuthenticated();

        bool CheckRole(string role);

        IEnumerable<Claim> GetClaims();

        HttpContext GetHttpContext();
    }
}
