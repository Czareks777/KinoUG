namespace KinoUG.Server.Models
{
    public class Seat
    {
        public Movie Movie { get; set; }
        public Ticket Ticket { get; set; }
        public int SeatNumber { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public bool isBought { get; set; }

    }
}
