namespace KinoUG.Server.Models
{
    public class Seat
    {
        public int Id { get; set; }
        public int MovieId { get; set; } 
        public Movie Movie { get; set; }
        public int HallId { get; set; } 
        public Hall Hall { get; set; } 
        public Ticket Ticket { get; set; }
        public int SeatNumber { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public bool IsBought { get; set;}

    }
}
