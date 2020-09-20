using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvilliaDDD.Identity.API.Models
{
    public class UserLoginSuccessful
    {
        public string AccessToken { get; set; }

        public double ExpiresIn { get; set; }

        public UserToken UserToken { get; set; }
    }
}
