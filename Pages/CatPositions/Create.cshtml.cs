using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using kitties.Models;
using kitty_store.Data;

namespace kitty_store.Pages.CatPositions
{
    public class CreateModel : PageModel
    {
        private readonly kitty_store.Data.kitty_storeContext _context;

        public CreateModel(kitty_store.Data.kitty_storeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CatPosition CatPosition { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CatPosition.Add(CatPosition);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
