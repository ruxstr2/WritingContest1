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
    public class StoryGenresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StoryGenresController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("AddStoryGenre")]
        public async Task<IActionResult> AddStoryGenre([FromBody] StoryGenre storyGenre)
        {

            await _context.StoryGenres.AddAsync(storyGenre);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("DeleteByStory{id}")]
        public async Task<ActionResult<StoryGenre>> DeleteByStory(int id)
        {
            try
            {
                var genreStoryToDelete = await _context.StoryGenres.Where(x => x.StoryId == id).FirstOrDefaultAsync();

                if (genreStoryToDelete == null)
                {
                    return NotFound($"Story with id = {id} not found");
                }

                _context.StoryGenres.Remove(genreStoryToDelete);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
