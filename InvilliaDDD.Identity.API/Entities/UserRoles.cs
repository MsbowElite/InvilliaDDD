using System;
using System.Collections.Generic;

namespace InvilliaDDD.Identity.API.Entities
{
    public partial class UserRoles
    {
        public Guid UserId { get; set; }
        public string RoleId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
