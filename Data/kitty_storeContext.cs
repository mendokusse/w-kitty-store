using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using kitties.Models;

namespace kitty_store.Data
{
    public class kitty_storeContext : DbContext
    {
        public kitty_storeContext (DbContextOptions<kitty_storeContext> options)
            : base(options)
        {
        }

        public DbSet<kitties.Models.Cat> Cat { get; set; } = default!;
        public DbSet<kitties.Models.CatPosition> CatPosition { get; set; } = default!;
    }
}
