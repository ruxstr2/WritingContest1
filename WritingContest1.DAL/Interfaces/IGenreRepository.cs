using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingContest1.DAL.Entities;
using WritingContest1.DAL.Models;

namespace WritingContest1.DAL.Interfaces
{
    public interface IGenreRepository
    {
        Task<List<GenreModels>> GetAll();
        Task<Genre> GetById(int id);
        Task Create(Genre genre);
        Task Update(Genre genre);
        Task Delete(Genre genre);
    }
}
