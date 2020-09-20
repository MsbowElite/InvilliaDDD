using System;
using System.Collections.Generic;

namespace InvilliaDDD.Identity.API.Entities
{
    public partial class User
    {
        public User()
        {
            UserRoles = new HashSet<UserRoles>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte Code { get; set; }

        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
