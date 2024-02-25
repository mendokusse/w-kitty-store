using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using kitties.Models;
using kitty_store.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using kitty_store.Models;

namespace kitty_store.Pages.Cats
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly kitty_storeContext _context;
        private readonly UserManager<User> _userManager;

        public IndexModel(kitty_storeContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Cat> Cat { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Cat = await _context.Cat.ToListAsync();
        }
    }
}
