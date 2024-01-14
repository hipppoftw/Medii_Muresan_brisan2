using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Medii_Muresan_brisan2.Data;
using Medii_Muresan_brisan2.Models;

namespace Medii_Muresan_brisan2.Pages.Screenings
{
    public class DetailsModel : PageModel
    {
        private readonly Medii_Muresan_brisan2.Data.Medii_Muresan_brisan2Context _context;

        public DetailsModel(Medii_Muresan_brisan2.Data.Medii_Muresan_brisan2Context context)
        {
            _context = context;
        }

      public Screening Screening { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Screening == null)
            {
                return NotFound();
            }

            var screening = await _context.Screening.FirstOrDefaultAsync(m => m.ScreeningId == id);
            if (screening == null)
            {
                return NotFound();
            }
            else 
            {
                Screening = screening;
            }
            return Page();
        }
    }
}
