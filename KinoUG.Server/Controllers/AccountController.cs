using AutoMapper;
using KinoUG.Server.Data;
using KinoUG.Server.DTO;
using KinoUG.Server.Models;
using KinoUG.Server.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KinoUG.Server.Controllers
{
 
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
       private readonly SignInManager<User> _signInManager;
        public AccountController(DataContext context,ITokenService tokenService,UserManager<User> userManager,SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO model)
        {
            var user = new User
            {
                UserName = model.Email,
                Name = model.Name,
                Surname = model.Surname,
               Email = model.Email

            };

            // Create the user
            var result = await _userManager.CreateAsync(user, model.Password);

            var assignRoleResult = await _userManager.AddToRoleAsync(user, Roles.User);

            if (!assignRoleResult.Succeeded)
            {
                return new BadRequestObjectResult(assignRoleResult.Errors);
            }

            if (result.Succeeded)
            {
                return Ok();
            }

            return new BadRequestObjectResult(result.Errors);
        }




        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginDTO model)
        {
            var userEmail = await _userManager.FindByEmailAsync(model.Email);
            if (userEmail == null)
            {
                return BadRequest("Incorrect email");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(userEmail, model.Password,false);

            if (!result.Succeeded)
            {
                return BadRequest("Incorrect email or password");
            }

            // Generate JWT
            var user = await _userManager.FindByNameAsync(model.Email);
            var token = await _tokenService.GenerateJwtToken(user, TimeSpan.FromMinutes(600));

            return Ok(token);
        }


    }
}
