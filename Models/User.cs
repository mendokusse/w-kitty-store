using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace kitty_store.Models
{
    public class User : IdentityUser
    {

        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
    }
}