using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using kitties.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using kitty_store.Models;

namespace kitty_store.Data
{
    public class kitty_storeContext : IdentityDbContext<User>
    {
        public kitty_storeContext(DbContextOptions<kitty_storeContext> options)
            : base(options)
        {
        }

        public DbSet<Cat> Cat { get; set; }
        public DbSet<CatPosition> CatPosition { get; set; }
    }
}

