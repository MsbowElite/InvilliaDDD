﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core3Layers.Core.Interfaces;

namespace Core3Layers.Infrastructure
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        //private readonly UserManager<IdentityUser> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Initialize()
        {

        }
    }
}
