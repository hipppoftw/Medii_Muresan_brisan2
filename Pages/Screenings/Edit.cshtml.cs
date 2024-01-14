using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Medii_Muresan_brisan2.Data;
using Medii_Muresan_brisan2.Models;

namespace Medii_Muresan_brisan2.Pages.Screenings
{
    public class EditModel : PageModel
    {
        private readonly Medii_Muresan_brisan2.Data.Medii_Muresan_brisan2Context _context;

        public EditModel(Medii_Muresan_brisan2.Data.Medii_Muresan_brisan2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Screening Screening { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Screening == null)
            {
                return NotFound();
            }

            var screening =  await _context.Screening.FirstOrDefaultAsync(m => m.ScreeningId == id);
            if (screening == null)
            {
                return NotFound();
            }
            Screening = screening;
           ViewData["CinemaId"] = new SelectList(_context.Cinema, "CinemaId", "Location");
           ViewData["MovieId"] = new SelectList(_context.Movie, "MovieId", "MovieId");
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

            _context.Attach(Screening).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScreeningExists(Screening.ScreeningId))
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

        private bool ScreeningExists(int id)
        {
          return (_context.Screening?.Any(e => e.ScreeningId == id)).GetValueOrDefault();
        }
    }
}
