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
    public class AuthorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthorsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("AddAuthor")]
        public async Task<IActionResult> AddAuthor([FromBody] Author author)
        {
            if (string.IsNullOrEmpty(author.Name))
            {
                return BadRequest("Name is null");
            }

            if (string.IsNullOrEmpty(author.City))
            {
                return BadRequest("City is null");
            }

            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("GetAuthor/{id}")]
        public async Task<IActionResult> GetAuthor([FromRoute] int id)
        {
            var author = await _context.Authors.FindAsync(id);
            //var author = await _context.Authors.Where(x => x.Id == id).FirstOrDefaultAsync();

            return Ok(author);
        }

/*        [HttpGet("GetAuthor+Contact/{id}")]
        public async Task<IActionResult> GetAuthorAndContact([FromRoute] int id)
        {
            //var author = await _context.Authors.FindAsync(id);
            var author = await _context.Authors.Where(x => x.Id == id).Include(x => x.AuthorContact).FirstOrDefaultAsync();

            return Ok(author);
        }*/

        [HttpDelete("DeleteAuthor{id}")]
        public async Task<ActionResult<Author>> DeleteAuthor(int id)
        {
            try
            {
                var authorToDelete = await _context.Authors.FindAsync(id) ;

                if (authorToDelete == null)
                {
                    return NotFound($"Author with id = {id} not found");
                }

                _context.Authors.Remove(authorToDelete);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        [HttpPut("UpdateCity/{id}")]
        public async Task<ActionResult<Author>> UpdateAuthorCity(int id, string city)
        {
            try
            {

                var authorToUpdate = await _context.Authors.FindAsync(id);

                if (authorToUpdate == null)
                {
                    return NotFound($"Author with Id = {id} not found");
                }

                authorToUpdate.City = city;
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
