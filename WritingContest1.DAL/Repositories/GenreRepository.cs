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
    public class GenreRepository : IGenreRepository
    {
        private readonly AppDbContext _context;

        public GenreRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Genre genre)
        {
            await _context.Genres.AddAsync(genre);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Genre genre)
        {
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
        }

        public async Task<List<GenreModels>> GetAll()
        {
            var genres = await (await GetAllQuery()).ToListAsync();
            var list = new List<GenreModels>();
            foreach (var genre in genres)
            {
                var genreModel = new GenreModels
                {
                    Name = genre.Name
                };
                list.Add(genreModel);
            }

            //var students = _context.Students.WhereClauses();
            return list;

        }

        private async Task<IQueryable<Genre>> GetAllQuery()
        {
            var query = _context.Genres.AsQueryable();
            return query;
        }

        public async Task<Genre> GetById(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            return genre;
        }

        public async Task Update(Genre genre)
        {
            _context.Genres.Update(genre);
            await _context.SaveChangesAsync();
        }

    }
}
