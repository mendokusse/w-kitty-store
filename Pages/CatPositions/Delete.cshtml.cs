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
    public class DeleteModel : PageModel
    {
        private readonly kitty_store.Data.kitty_storeContext _context;

        public DeleteModel(kitty_store.Data.kitty_storeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CatPosition CatPosition { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catposition = await _context.CatPosition.FirstOrDefaultAsync(m => m.Id == id);

            if (catposition == null)
            {
                return NotFound();
            }
            else
            {
                CatPosition = catposition;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catposition = await _context.CatPosition.FindAsync(id);
            if (catposition != null)
            {
                CatPosition = catposition;
                _context.CatPosition.Remove(CatPosition);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
