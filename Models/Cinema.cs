using System.ComponentModel.DataAnnotations;

namespace Medii_Muresan_brisan2.Models
{
    public class Cinema
    {
        public int CinemaId { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(300)]
        public string Location { get; set; }

        [Required]
        public int Capacity { get; set; }

    }
}
