﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly Medii_Muresan_brisan2.Data.Medii_Muresan_brisan2Context _context;

        public IndexModel(Medii_Muresan_brisan2.Data.Medii_Muresan_brisan2Context context)
        {
            _context = context;
        }

        public IList<Screening> Screening { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Screening != null)
            {
                Screening = await _context.Screening
                .Include(s => s.Cinema)
                .Include(s => s.Movie).ToListAsync();
            }
        }
    }
}
