using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Medii_Muresan_brisan2.Models;

namespace Medii_Muresan_brisan2.Data
{
    public class Medii_Muresan_brisan2Context : DbContext
    {
        public Medii_Muresan_brisan2Context (DbContextOptions<Medii_Muresan_brisan2Context> options)
            : base(options)
        {
        }

        public DbSet<Medii_Muresan_brisan2.Models.Cinema> Cinema { get; set; } = default!;

        public DbSet<Medii_Muresan_brisan2.Models.Movie>? Movie { get; set; }

        public DbSet<Medii_Muresan_brisan2.Models.User>? User { get; set; }

        public DbSet<Medii_Muresan_brisan2.Models.Review>? Review { get; set; }

        public DbSet<Medii_Muresan_brisan2.Models.Screening>? Screening { get; set; }

        public DbSet<Medii_Muresan_brisan2.Models.Booking>? Booking { get; set; }
    }
}
