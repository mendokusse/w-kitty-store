using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using kitties.Models;
using kitty_store.Models;
using Microsoft.AspNetCore.Identity;

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
        public DbSet<IdentityUserRole<string>> UserRoles { get; set; } // Добавляем DbSet для таблицы AspNetUserRoles

        public async Task<string> GetRoleIdForUser(string userId)
        {
            var userRole = await UserRoles.FirstOrDefaultAsync(ur => ur.UserId == userId);
            return userRole?.RoleId;
        }
    }
}