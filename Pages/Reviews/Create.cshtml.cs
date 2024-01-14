using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Medii_Muresan_brisan2.Data;
using Medii_Muresan_brisan2.Models;

namespace Medii_Muresan_brisan2.Pages.Reviews
{
    public class CreateModel : PageModel
    {
        private readonly Medii_Muresan_brisan2.Data.Medii_Muresan_brisan2Context _context;

        public CreateModel(Medii_Muresan_brisan2.Data.Medii_Muresan_brisan2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["MovieId"] = new SelectList(_context.Movie, "MovieId", "Title");
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Name");
            return Page();
        }

        [BindProperty]
        public Review Review { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Repopulate the SelectList items if there's an error
                ViewData["MovieId"] = new SelectList(_context.Movie, "MovieId", "Title");
                ViewData["UserId"] = new SelectList(_context.User, "UserId", "Name");
                return Page();
            }

            _context.Review.Add(Review);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
