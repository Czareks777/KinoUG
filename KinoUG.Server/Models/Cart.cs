using System.ComponentModel.DataAnnotations.Schema;

namespace KinoUG.Server.Models
{
    public class Cart
    { 
        public string UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("TicketId")]
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        [NotMapped]
        public double Price { get; set; }

        //public int Count
        
    }
}
