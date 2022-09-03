using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingContest1.DAL.Entities;
using WritingContest1.DAL.Models;

namespace WritingContest1.DAL.Interfaces
{
    public interface IStoryRepository
    {
        Task<List<StoryModels>> GetAll();
        Task<Story> GetById(int id);
        Task Create(Story story);
        Task Update(Story story);
        Task Delete(Story story);
    }
}
