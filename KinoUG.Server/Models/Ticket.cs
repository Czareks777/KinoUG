using System.ComponentModel.DataAnnotations.Schema;

namespace KinoUG.Server.Models
{
    public class Ticket
    {
        public string TicketId { get; set; }
        [ForeignKey("UserId")]
        public string UserId { get;set; }
        public string Seat { get; set; }
        [ForeignKey("MovieId")]
        public string MovieId { get; set; }
        
        public User User { get; set; }
    }
}
