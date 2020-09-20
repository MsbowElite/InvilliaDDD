using InvilliaDDD.Identity.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvilliaDDD.Identity.API.Data
{
    public class IdentityManagerDbContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityManagerDbContext(DbContextOptions<IdentityManagerDbContext> options)
            : base(options)
        {

        }
    }
}
