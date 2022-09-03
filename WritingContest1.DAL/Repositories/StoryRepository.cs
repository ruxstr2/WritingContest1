using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingContest1.DAL.Entities;
using WritingContest1.DAL.Interfaces;
using WritingContest1.DAL.Models;

namespace WritingContest1.DAL.Repositories
{
    public class StoryRepository : IStoryRepository
    {
        private readonly AppDbContext _context;

        public StoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Story story)
        {
            await _context.Stories.AddAsync(story);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Story story)
        {
            _context.Stories.Remove(story);
            await _context.SaveChangesAsync();
        }

        public async Task<List<StoryModels>> GetAll()
        {
            var stories = await (await GetAllQuery()).ToListAsync();
            var list = new List<StoryModels>();
            foreach (var story in stories)
            {
                var storyModel = new StoryModels
                {
                    Title = story.Title
                };
                list.Add(storyModel);
            }

            //var students = _context.Students.WhereClauses();
            return list;

        }

        private async Task<IQueryable<Story>> GetAllQuery()
        {
            var query = _context.Stories.AsQueryable();
            return query;
        }

        public async Task<Story> GetById(int id)
        {
            var story = await _context.Stories.FindAsync(id);
            return story;
        }

        public async Task Update(Story story)
        {
            _context.Stories.Update(story);
            await _context.SaveChangesAsync();
        }

    }
}
