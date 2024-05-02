using KinoUG.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KinoUG.Server.Controllers
{
   
    public class CartController :BaseApiController
    {
        private readonly DataContext _context;
        public CartController(DataContext context)
        {
            _context = context;
        }
    
        
    }
}
