using InvilliaDDD.Identity.API.Data.Interfaces;
using InvilliaDDD.Identity.API.Entities;
using InvilliaDDD.WebApi.Core.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvilliaDDD.Identity.API.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IdentityManagerContext _db;
        private readonly IRepositoryWrapper _rw;

        public DbInitializer(IdentityManagerContext db, IRepositoryWrapper rw)
        {
            _db = db;
            _rw = rw;
        }

        public void Initialize()
        {
            //if (_db.Database.GetPendingMigrations().Any())
            //{
            //    _db.Database.Migrate();
            //}
            try
            {

                if (_db.Role.Count() == 0)
                {
                    List<Role> roles = new List<Role>()
                {
                    new Role
                    {
                    CreatedAt = DateTime.Now,
                    Id = StaticRoles.Admin
                    },
                    new Role
                    {
                    CreatedAt = DateTime.Now,
                    Id = StaticRoles.User
                    },
                    new Role
                    {
                    CreatedAt = DateTime.Now,
                    Id = StaticRoles.Default
                    }
                };

                    _db.Role.AddRangeAsync(roles);
                    _db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
