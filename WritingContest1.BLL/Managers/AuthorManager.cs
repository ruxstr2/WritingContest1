using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingContest1.BLL.Interfaces;
using WritingContest1.DAL.Interfaces;

namespace WritingContest1.BLL.Managers
{
    public class AuthorManager : IAuthorManager
    {
        private readonly IAuthorRepository _authorRepo;

        public AuthorManager(IAuthorRepository authorRepo)
        {
            _authorRepo = authorRepo;
        }

        public async Task<List<string>> ModifyAuthor()
        {
            var authors = await _authorRepo.GetAll();
            var list = new List<string>();

            foreach (var author in authors)
            {
                list.Add($"AuthorName: {author.Name}");
            }

            return list;
        }
    }
}
