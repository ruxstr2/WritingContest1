using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingContest1.BLL.Interfaces
{
    public interface IStoryManager
    {
        Task<List<string>> ModifyStory();
    }
}
