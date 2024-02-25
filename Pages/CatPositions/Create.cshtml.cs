using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using kitties.Models;
using kitty_store.Data;

namespace kitty_store.Pages.CatPositions
{
    public class CreateModel : PageModel
    {
        private readonly kitty_storeContext _context;

        public CreateModel(kitty_storeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CatPosition CatPosition { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            CatPosition.DateAdded = DateTime.Now;
            _context.CatPosition.Add(CatPosition);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}