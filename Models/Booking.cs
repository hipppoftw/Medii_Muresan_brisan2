namespace Medii_Muresan_brisan2.Models
{
    public class Booking
    {

        public int BookingId { get; set; } // Identificator unic pentru fiecare rezervare
        public int UserId { get; set; } // ID-ul utilizatorului care face rezervarea
        public int ScreeningId { get; set; } // ID-ul proiecției pentru care se face rezervarea
        public DateTime BookingTime { get; set; } // Data și ora la care s-a făcut rezervarea

        // Relații cu alte entități
        public User User { get; set; } // Utilizatorul care a făcut rezervarea
        public Screening Screening { get; set; }
    }
}
