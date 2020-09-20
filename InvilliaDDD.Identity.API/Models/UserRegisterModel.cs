using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvilliaDDD.Identity.API.Models
{
    public class UserRegisterModel : UserModel
    {
        public bool AdminRole { get; set; }
    }
}
