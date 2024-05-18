using KinoUG.Server.Data;
using KinoUG.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KinoUG.Server.Controllers
{

    public class CartController : BaseApiController
    {
        private readonly DataContext _context;
        public CartController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}")]

        public async Task <IActionResult> getCart(string userId)
        {
            var cart = await _context.Carts
                .Include(c => c.Items)
                .ThenInclude(i => i.Ticket)
                .FirstOrDefaultAsync(c => c.UserId == userId);
            
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> AddToCart(string userId, CartItem cartItem) { 
         var cart = await _context.Carts.Include(c=>c.Items).FirstOrDefaultAsync(c => c.UserId == userId);
            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId,
                    Items = new List<CartItem>()
                };
                _context.Carts.Add(cart);
            }
            else
            {
                cart.Items.Add(cartItem);
            }

                cart.TotalPrice = cart.Items.Sum(i => i.Price * i.Quantity);
                await _context.SaveChangesAsync();
            
                
                return Ok(cart);
            }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> RemoveItemFromCart (string userId, int itemId)
        {
            var cart = await _context.Carts.Include(c => c.Items).FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                return NotFound();
            }

            var item = cart.Items.FirstOrDefault(i => i.Id == itemId);
            if ( item == null)
            {
                return NotFound();
            }
            cart.Items.Remove(item);
            cart.TotalPrice = cart.Items.Sum(i => i.Price * i.Quantity);
            
            await _context.SaveChangesAsync();
            return Ok(cart);
        }
    
    
    }

}

