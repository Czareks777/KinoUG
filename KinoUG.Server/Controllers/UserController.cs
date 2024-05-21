using KinoUG.Server.Data;
using KinoUG.Server.DTO;
using KinoUG.Server.Models;
using KinoUG.Server.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

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
        [Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await _context.Users
                .Select(u => new UserDTO
                {
                    Name = u.Name,
                    Surname = u.Surname,
                    Email = u.Email,
                    UserName = u.Email
                })
                .ToListAsync();
            return Ok(users);
        }

        [HttpGet("{userId}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult<UserDTO>> GetUser(string userId)
        {
            var user = await _context.Users
                .Where(u => u.Id == userId)
                .Select(u => new UserDTO
                {
                    Name = u.Name,
                    Surname = u.Surname,
                    Email = u.Email,
                    UserName = u.Email
                })
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
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
                    UserName = u.Email
                })
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        [Route("CreateUser")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult<UserDTO>> CreateUser(CreateUserDTO createUserDTO)
        {
            try
            {
                var user = new User
                {
                    UserName = createUserDTO.Email,
                    Email = createUserDTO.Email,
                    Name = createUserDTO.Name,
                    Surname = createUserDTO.Surname
                };

                var result = await _userManager.CreateAsync(user, createUserDTO.Password);
                var assignRoleResult = await _userManager.AddToRoleAsync(user, Roles.User);
                if (!assignRoleResult.Succeeded)
                {
                    return new BadRequestObjectResult(assignRoleResult.Errors);
                }
                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }

                return Ok(new User
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    UserName = user.Email,
                });
            }
            catch (Exception ex) 
            { return StatusCode(500, new { Error = "An error occurred while creating the user", Details = ex.Message }); }
           
        }

        [HttpPut("{userId}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult> UpdateUser(string userId, UpdateUserDTO updateUserDTO)
        {
            try
            {
                var user = await _context.Users.FindAsync(userId);

                if (user == null)
                {
                    return NotFound();
                }

                user.Name = updateUserDTO.Name;
                user.Surname = updateUserDTO.Surname;
                user.Email = updateUserDTO.Email;
                user.UserName = updateUserDTO.Email;

                var result = await _userManager.UpdateAsync(user);

                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while updating the user", Details = ex.Message });
            }
        }

        [HttpDelete("{userId}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult> DeleteUser(string userId)
        {
           
                var user = await _context.Users.FindAsync(userId);

                if (user == null)
                {
                    return NotFound();
                }

                var result = await _userManager.DeleteAsync(user);

                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }

                return NoContent();
            }
        
        
        [HttpPost("{userId}/assign-role")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult> AssignRole(string userId, [FromBody] string role)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);

                if (user == null)
                {
                    return NotFound();
                }

                var result = await _userManager.AddToRoleAsync(user, role);

                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while assigning the role", Details = ex.Message });
            }
        }

        [HttpPost("{userId}/remove-role")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult> RemoveRole(string userId, [FromBody] string role)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);

                if (user == null)
                {
                    return NotFound();
                }

                var result = await _userManager.RemoveFromRoleAsync(user, role);

                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while removing the role", Details = ex.Message });
            }
        }
    }
    }

