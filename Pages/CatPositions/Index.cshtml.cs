using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using kitties.Models;
using kitty_store.Data;

namespace kitty_store.Pages.CatPositions
{
    public class IndexModel : PageModel
    {
        private readonly kitty_store.Data.kitty_storeContext _context;

        public IndexModel(kitty_store.Data.kitty_storeContext context)
        {
            _context = context;
        }

        public IList<CatPosition> CatPosition { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CatPosition = await _context.CatPosition.ToListAsync();
        }
    }
}
