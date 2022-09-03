using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingContest1.DAL.Entities;
using WritingContest1.DAL.Interfaces;

namespace WritingContest1.DAL.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;

        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Author author)
        {
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Author>> GetAll()
        {
            var students = await (await GetAllQuery()).ToListAsync();
            /*    var list = new List<StudentModels>();
                foreach (var student in students)
                {
                    var studentModel = new StudentModels
                    {
                        Name = student.Name
                    };
                    list.Add(studentModel);
                }

                //var students = _context.Students.WhereClauses();
                return list;*/
            return students;

        }

        private async Task<IQueryable<Author>> GetAllQuery()
        {
            var query = _context.Authors.AsQueryable();
            return query;
        }

        public async Task<Author> GetById(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            return author;
        }

        public async Task Update(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
        }

    }
}
