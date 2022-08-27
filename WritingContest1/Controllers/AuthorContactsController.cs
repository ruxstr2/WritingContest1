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
    public class AuthorContactsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthorContactsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("AddAuthorContact")]
        public async Task<IActionResult> AddAuthorContact([FromBody] AuthorContact authorContact)
        {
            if (string.IsNullOrEmpty(authorContact.Email))
            {
                return BadRequest("Email is null");
            }

            if (string.IsNullOrEmpty(authorContact.Phone))
            {
                return BadRequest("Phone is null");
            }

            await _context.AuthorContacts.AddAsync(authorContact);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("GetContact/{id}")]
        public async Task<IActionResult> GetAuthorContact([FromRoute] int id)
        {
            //var authorContact = await _context.Authors.FindAsync(id);
            var authorContact = await _context.AuthorContacts.Where(x => x.Id == id).Include(x => x.Author).FirstOrDefaultAsync();

            return Ok(authorContact);
        }

        [HttpDelete("DeleteContact{id}")]
        public async Task<ActionResult<AuthorContact>> DeleteAuthorContact(int id)
        {
            try
            {
                var authorContactToDelete = await _context.AuthorContacts.FindAsync(id);

                if (authorContactToDelete == null)
                {
                    return NotFound($"AuthorContact with id = {id} not found");
                }

                _context.AuthorContacts.Remove(authorContactToDelete);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        [HttpPut("UpdatePhone/{id}")]
        public async Task<ActionResult<Author>> UpdatePhone(int id, string phone)
        {
            try
            {

                var authorContactToUpdate = await _context.AuthorContacts.FindAsync(id);

                if (authorContactToUpdate == null)
                {
                    return NotFound($"AuthorContact with Id = {id} not found");
                }

                authorContactToUpdate.Phone = phone;
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
