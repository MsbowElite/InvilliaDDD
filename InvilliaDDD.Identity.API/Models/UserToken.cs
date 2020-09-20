﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvilliaDDD.Identity.API.Models
{
    public class UserToken
    {
        public string Id { get; set; }

        public string Login { get; set; }

        public IEnumerable<UserClaim> Claims { get; set; }
    }
}
