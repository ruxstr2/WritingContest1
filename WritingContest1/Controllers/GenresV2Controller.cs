using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WritingContest1.BLL.Interfaces;

namespace WritingContest1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresV2Controller : ControllerBase
    {
        private readonly IGenreManager _genreManager;

        public GenresV2Controller(IGenreManager genreManager)
        {
            _genreManager = genreManager;
        }

        [HttpGet("get-modify")]
        public async Task<IActionResult> GetModify()
        {
            var list = await _genreManager.ModifyGenre();
            return Ok(list);
        }
    }
}
