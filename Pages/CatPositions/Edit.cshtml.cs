using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using kitties.Models;
using kitty_store.Data;

namespace kitty_store.Pages.CatPositions
{
    public class EditModel : PageModel
    {
        private readonly kitty_storeContext _context;

        public EditModel(kitty_storeContext context)
        {
            _context = context;
        }
        
        private bool CatPositionExists(int id)
        {
            return _context.CatPosition.Any(e => e.Id == id);
        }

        [BindProperty]
        public CatPosition? CatPosition { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CatPosition = await _context.CatPosition.FirstOrDefaultAsync(m => m.Id == id);

            if (CatPosition == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CatPosition).State = EntityState.Modified;
            CatPosition.DateModified = DateTime.Now; // Установка времени изменения

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
        


    }
}
