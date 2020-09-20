using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvilliaDDD.Identity.API.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "The field {0} is mandatory")]
        public string Login { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [StringLength(100, ErrorMessage = "The field {0} must have between {2} and {1} characters", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
