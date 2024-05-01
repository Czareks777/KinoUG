using System.ComponentModel.DataAnnotations.Schema;

namespace KinoUG.Server.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        [ForeignKey("UserId")]
        public string UserId { get;set; }
        [ForeignKey("SeatId")]
        public int Seat { get; set; }
        [ForeignKey("MovieId")]
        public int MovieId { get; set; }
        
        public User User { get; set; }
    }
}
