using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace kitty_store.Models
{
    public class User : IdentityUser
    {
        [Key]
        public int Id { get; set; }
        
        public string UserName { get; set; }
        public string Password { get; set; }

        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
    }
}