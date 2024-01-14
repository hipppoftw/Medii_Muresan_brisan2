﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly Medii_Muresan_brisan2.Data.Medii_Muresan_brisan2Context _context;

        public DeleteModel(Medii_Muresan_brisan2.Data.Medii_Muresan_brisan2Context context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Cinema == null)
            {
                return NotFound();
            }
            var cinema = await _context.Cinema.FindAsync(id);

            if (cinema != null)
            {
                Cinema = cinema;
                _context.Cinema.Remove(Cinema);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
