using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Medii_Muresan_brisan2.Data;
using Medii_Muresan_brisan2.Models;

namespace Medii_Muresan_brisan2.Pages.Cinemas
{
    public class DetailsModel : PageModel
    {
        private readonly Medii_Muresan_brisan2.Data.Medii_Muresan_brisan2Context _context;

        public DetailsModel(Medii_Muresan_brisan2.Data.Medii_Muresan_brisan2Context context)
        {
            _context = context;
        }

      public Cinema Cinema { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cinema == null)
            {
                return NotFound();
            }

            var cinema = await _context.Cinema.FirstOrDefaultAsync(m => m.CinemaId == id);
            if (cinema == null)
            {
                return NotFound();
            }
            else 
            {
                Cinema = cinema;
            }
            return Page();
        }
    }
}
