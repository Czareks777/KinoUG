using AutoMapper;
using KinoUG.Server.Data;
using KinoUG.Server.DTO;
using KinoUG.Server.Helper;
using KinoUG.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KinoUG.Server.Controllers
{
    
    public class MovieController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _automapper;
        public MovieController(DataContext context, IMapper automapper)
        {
            _context = context;
            _automapper = automapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovies()
        {
           var movies = await _context.Movies.ToListAsync();
            return _automapper.Map<List<MovieDTO>>(movies);
        }

        
        [HttpPost]
        public async Task<IActionResult> AddMovie(AddMovieDTO film)
        {
            var movie = new Movie
            {
                Title = film.Title,
                Description = film.Description,

            };
            
            _context.Movies.Add(movie);
            
            await _context.SaveChangesAsync();
            var movieDto = _automapper.Map<MovieDTO>(movie);    

            return Ok(movieDto);
        }

        // DELETE: api/movies/5
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }



    }
}
