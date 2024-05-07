using KinoUG.Server.Data;
using KinoUG.Server.DTO;
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
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
        {
            return await _context.Tickets.ToListAsync();
        }
        
        
        [HttpPost]
        public async Task<IActionResult> AddTicket(AddTicketDTO addTicketDTO)
        {

            var ticketFind = await _context.Tickets.Where(t=>t.SeatId.Equals(addTicketDTO.SeatId)&&t.ScheduleId.Equals(addTicketDTO.ScheduleId)).FirstOrDefaultAsync();
           
            if (ticketFind != null)
            {
                return BadRequest("Ticket for this seat is already sold.");
            }
           
            var ticket = new Ticket
            {
               UserId = "02ba3193-a80f-4013-bd8b-beb1bf4a0b41",
               SeatId = addTicketDTO.SeatId, 
               ScheduleId = addTicketDTO.ScheduleId,
               Price = addTicketDTO.Price,
            };


            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return Ok("Ticket successfully assigned to the seat..");
        }
        
        
       
        
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
