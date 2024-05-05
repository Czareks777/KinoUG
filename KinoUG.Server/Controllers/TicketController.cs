using KinoUG.Server.Data;
using KinoUG.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KinoUG.Server.Controllers
{
    
    public class TicketController : BaseApiController
    {
        private readonly DataContext _context;
        public TicketController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
        {
            return await _context.Tickets.ToListAsync();
        }
        
        /*
        [HttpPost]
        public async Task<IActionResult> AssignSeatToTicket(int seatId, string userId, int movieId)
        {
            var seat = await _context.Seats.FindAsync(seatId);
            if (seat == null)
            {
                return BadRequest("Seat is taken or non existent");
            }

            var ticketFind = await _context.Tickets.FindAsync(movieId, seatId);
           
            if (ticketFind != null)
            {
                return BadRequest("Ticket for this seat is already sold.");
            }
           
            var ticket = new Ticket
            {
                UserId = userId,
                SeatId = seatId, 
                MovieId = movieId
            };

            seat.Tickets = ticket; 

            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return Ok("Ticket successfully assigned to the seat..");
        }
        */
        
        [HttpPost("cancel/{ticketId}")]
        public async Task<IActionResult> CancelTicket(int ticketId)
        {
            var ticket = await _context.Tickets.Include(t => t.SeatId)
                .FirstOrDefaultAsync(t => t.Id == ticketId);

            if (ticket == null)
            {
                return NotFound("Ticket not found.");
            }
            var seat  = await _context.Seats.FindAsync(ticket.SeatId);
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return Ok("Ticket has been canceled and seat freed.");
        }
    }
}
