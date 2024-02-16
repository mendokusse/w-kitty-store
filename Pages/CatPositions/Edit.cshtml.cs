using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using kitties.Models;
using kitty_store.Data;

namespace kitty_store.Pages.CatPositions
{
    public class EditModel : PageModel
    {
        private readonly kitty_store.Data.kitty_storeContext _context;

        public EditModel(kitty_store.Data.kitty_storeContext context)
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

            var catposition =  await _context.CatPosition.FirstOrDefaultAsync(m => m.Id == id);
            if (catposition == null)
            {
                return NotFound();
            }
            CatPosition = catposition;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CatPosition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatPositionExists(CatPosition.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CatPositionExists(int id)
        {
            return _context.CatPosition.Any(e => e.Id == id);
        }
    }
}
