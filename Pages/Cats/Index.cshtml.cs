using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using kitties.Models;
using kitty_store.Data;

namespace kitty_store.Pages.Cats
{
    public class IndexModel : PageModel
    {
        private readonly kitty_storeContext _context;

        public IndexModel(kitty_storeContext context)
        {
            _context = context;
        }

        public IList<Cat> Cat { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Cat = await _context.Cat.ToListAsync();
        }
    }
}
