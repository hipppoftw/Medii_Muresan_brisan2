using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Medii_Muresan_brisan2.Data;
using Medii_Muresan_brisan2.Models;

namespace Medii_Muresan_brisan2.Pages.Bookings
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
        ViewData["ScreeningId"] = new SelectList(_context.Screening, "ScreeningId", "ScreeningId");
        ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId");
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Booking == null || Booking == null)
            {
                return Page();
            }

            _context.Booking.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
