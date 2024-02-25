using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using kitties.Models;
using kitty_store.Data;
using Microsoft.AspNetCore.Authorization;

namespace kitty_store.Pages.Cats
{
    [Authorize(Roles = "Admin")]
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
        public Cat Cat { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cat.Add(Cat);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
