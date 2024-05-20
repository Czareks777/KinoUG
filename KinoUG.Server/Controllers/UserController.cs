using KinoUG.Server.Data;
using KinoUG.Server.DTO;
using KinoUG.Server.Models;
using KinoUG.Server.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace KinoUG.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;

        public UserController(DataContext context, ITokenService tokenService, UserManager<User> userManager)
        {
            _context = context;
            _tokenService = tokenService;
            _userManager = userManager;
        }


        [HttpGet]
        [Route("GetUsers")]
      
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await _context.Users
                .Select(u => new UserDTO
                {
                    Name = u.Name,
                    Surname = u.Surname,
                    Email = u.Email,
                    UserName = u.UserName
                })
                .ToListAsync();
            return Ok(users);
        }



        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDTO>> GetUser(string userId)
        {
            var user = await _context.Users
                .Where(u => u.Id == userId.ToString())
                .Select(u => new UserDTO
                {
                    Name = u.Name,
                    Surname = u.Surname,
                    Email = u.Email,
                    
                })
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            var result =  user;

            return Ok(result);
        }


        [HttpGet]
        [Route("GetCurrentUser")]
        [Authorize]
        public async Task<ActionResult<UserDTO>> GetCurrentUser()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);

            var user = await _context.Users
                .Where(u => u.Email == userEmail)
                .Select(u => new UserDTO
                {
                    Name = u.Name,
                    Surname = u.Surname,
                    Email = u.Email,
                })
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

    }
}
