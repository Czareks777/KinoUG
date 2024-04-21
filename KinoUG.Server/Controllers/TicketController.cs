using KinoUG.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KinoUG.Server.Controllers
{
    
    public class TicketController : BaseApiController
    {
        private readonly DataContext _context;
        public TicketController(DataContext context)
        {
            _context = context;
        }
    }
}
