using KinoUG.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KinoUG.Server.Controllers
{
    
    public class MovieController : BaseApiController
    {
        private readonly DataContext _context;
        public MovieController(DataContext context)
        {
            _context = context;
        }
    }
}
