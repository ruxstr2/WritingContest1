using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WritingContest1.BLL.Interfaces;
using WritingContest1.DAL.Interfaces;

namespace WritingContest1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsV2Controller : ControllerBase
    {
        private readonly IAuthorManager _authorManager;

        public AuthorsV2Controller(IAuthorManager authorManager)
        {
            _authorManager = authorManager;
        }

        [HttpGet("get-modify")]
        public async Task<IActionResult> GetModify()
        {
            var list = await _authorManager.ModifyAuthor();
            return Ok(list);
        }
    }
}
