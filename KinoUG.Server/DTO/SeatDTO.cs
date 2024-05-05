namespace KinoUG.Server.DTO
{
    public class SeatDTO
    {
        public int Id { get; set; }
        public int MovieId { get; set; } 
        public int HallId { get; set; } 
        public int TicketId { get; set; }   
        public int SeatNumber { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public bool IsBought { get; set;}

    }
}
