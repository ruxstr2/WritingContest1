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
    public class StoriesV2Controller : ControllerBase
    {
        private readonly IStoryManager _storyManager;

        public StoriesV2Controller(IStoryManager storyManager)
        {
            _storyManager = storyManager;
        }

        [HttpGet("get-titles")]
        public async Task<IActionResult> GetModify()
        {
            var list = await _storyManager.ModifyStory();
            return Ok(list);
        }
    }
}
