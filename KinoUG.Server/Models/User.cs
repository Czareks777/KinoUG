using Microsoft.AspNetCore.Identity;

namespace KinoUG.Server.Models
{
    public class User 
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public List <Ticket> UserTickets { get; set; }


    }
}
