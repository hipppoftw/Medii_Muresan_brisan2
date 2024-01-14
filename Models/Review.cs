using System.ComponentModel.DataAnnotations;

namespace Medii_Muresan_brisan2.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }

        [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10")]
        public int Rating { get; set; }

        // Relații cu alte entități
        public Movie Movie { get; set; }
        public User User { get; set; }
    }
}
