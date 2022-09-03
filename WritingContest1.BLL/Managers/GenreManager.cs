using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingContest1.BLL.Interfaces;
using WritingContest1.DAL.Interfaces;

namespace WritingContest1.BLL.Managers
{
    public class GenreManager : IGenreManager
    {
        private readonly IGenreRepository _genreRepo;

        public GenreManager(IGenreRepository genreRepo)
        {
            _genreRepo = genreRepo;
        }

        public async Task<List<string>> ModifyGenre()
        {
            var genres = await _genreRepo.GetAll();
            var list = new List<string>();

            foreach (var genre in genres)
            {
                list.Add($"GenreName: {genre.Name}");
            }

            return list;
        }
    }
}
