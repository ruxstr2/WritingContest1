using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WritingContest1.DAL;
using WritingContest1.DAL.Entities;

namespace WritingContest1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GenresController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("AddGenre")]
        public async Task<IActionResult> AddGenre([FromBody] Genre genre)
        {
            if (string.IsNullOrEmpty(genre.Name))
            {
                return BadRequest("Name is null");
            }

            await _context.Genres.AddAsync(genre);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("GetGenre/{id}")]
        public async Task<IActionResult> GetGenre([FromRoute] int id)
        {
            //var authorContact = await _context.Authors.FindAsync(id);
            var genre = await _context.Genres.Where(x => x.Id == id).FirstOrDefaultAsync();

            return Ok(genre);
        }

        [HttpDelete("DeleteGenre{id}")]
        public async Task<ActionResult<Genre>> DeleteGenre(int id)
        {
            try
            {
                var genreToDelete = await _context.Genres.FindAsync(id);

                if (genreToDelete == null)
                {
                    return NotFound($"Genre with id = {id} not found");
                }

                _context.Genres.Remove(genreToDelete);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        [HttpPut("UpdateName/{id}")]
        public async Task<ActionResult<Genre>> UpdateName(int id, string name)
        {
            try
            {

                var genreToUpdate = await _context.Genres.FindAsync(id);

                if (genreToUpdate == null)
                {
                    return NotFound($"Genre with Id = {id} not found");
                }

                genreToUpdate.Name = name;
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
    }
}
