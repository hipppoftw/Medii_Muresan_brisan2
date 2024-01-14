namespace Medii_Muresan_brisan2.Models
{
    public class Screening
    {
        public int ScreeningId { get; set; } // Identificator unic pentru fiecare proiecție
        public int MovieId { get; set; } // ID-ul filmului proiectat
        public int CinemaId { get; set; } // ID-ul sălii de cinema unde are loc proiecția
        public DateTime ScreeningTime { get; set; } // Data și ora proiecției

        // Relații cu alte entități
        public Movie Movie { get; set; } // Filmul proiectat
        public Cinema Cinema { get; set; } // Sala de cinema unde are loc proiecția
    }
}
