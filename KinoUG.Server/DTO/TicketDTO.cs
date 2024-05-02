using System.ComponentModel.DataAnnotations.Schema;

namespace KinoUG.Server.DTO
{
    public class TicketDTO
    {
        public int Id { get; set; }
        [ForeignKey("SeatId")]
        public int SeatId { get; set; }
        [ForeignKey("MovieId")]
        public int MovieId { get; set; }
    }
}
