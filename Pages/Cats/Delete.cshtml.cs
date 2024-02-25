using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using kitties.Models;
using kitty_store.Data;
using Microsoft.AspNetCore.Authorization;

namespace kitty_store.Pages.Cats
{
    
    public class DeleteModel : PageModel
    {
        private readonly kitty_storeContext _context;

        public DeleteModel(kitty_storeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cat Cat { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _context.Cat.FirstOrDefaultAsync(m => m.Id == id);

            if (cat == null)
            {
                return NotFound();
            }
            else
            {
                Cat = cat;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _context.Cat.FindAsync(id);
            if (cat != null)
            {
                Cat = cat;
                _context.Cat.Remove(Cat);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
