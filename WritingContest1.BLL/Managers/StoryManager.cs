using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingContest1.BLL.Interfaces;
using WritingContest1.DAL.Interfaces;

namespace WritingContest1.BLL.Managers
{
    public class StoryManager : IStoryManager
    {
        private readonly IStoryRepository _storyRepo;

        public StoryManager(IStoryRepository storyRepo)
        {
            _storyRepo = storyRepo;
        }

        public async Task<List<string>> ModifyStory()
        {
            var stories = await _storyRepo.GetAll();
            var list = new List<string>();

            foreach (var story in stories)
            {
                list.Add($"StoryTitle: {story.Title}");
            }

            return list;
        }
    }
}
