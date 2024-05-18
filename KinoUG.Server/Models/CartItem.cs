namespace KinoUG.Server.Models
{
    public class CartItem
    {
        public int Id { get; set;}
        public int TicketId { get; set;}
        public decimal Price { get; set; }
        public Ticket Ticket { get; set; }
        public int Quantity { get; set; }
    }
}
