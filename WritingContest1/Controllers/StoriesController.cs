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
    public class StoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("AddStory")]
        public async Task<IActionResult> AddStory([FromBody] Story story)
        {
            if (string.IsNullOrEmpty(story.Title))
            {
                return BadRequest("Title is null");
            }

            if (story.WordCount == null)
            {
                return BadRequest("WordCount is null");
            }

            await _context.Stories.AddAsync(story);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("GetStory/{id}")]
        public async Task<IActionResult> GetStory([FromRoute] int id)
        {
            //var authorContact = await _context.Authors.FindAsync(id);
            var story = await _context.Stories.Where(x => x.Id == id).Include(x => x.Author).FirstOrDefaultAsync();

            return Ok(story);
        }

        [HttpDelete("DeleteStory{id}")]
        public async Task<ActionResult<Story>> DeleteStory(int id)
        {
            try
            {
                var storyToDelete = await _context.Stories.FindAsync(id);

                if (storyToDelete == null)
                {
                    return NotFound($"Story with id = {id} not found");
                }

                _context.Stories.Remove(storyToDelete);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        [HttpPut("UpdateTitle/{id}")]
        public async Task<ActionResult<Story>> UpdateTitle(int id, string title)
        {
            try
            {

                var storyToUpdate = await _context.Stories.FindAsync(id);

                if (storyToUpdate == null)
                {
                    return NotFound($"Story with Id = {id} not found");
                }

                storyToUpdate.Title = title;
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
