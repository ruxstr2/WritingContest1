﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingContest1.DAL.Entities;

namespace WritingContest1.DAL.Interfaces
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAll();
        Task<Author> GetById(int id);
        Task Create(Author author);
        Task Update(Author author);
        Task Delete(Author author);
        //Task<IQueryable<Author>> GetAllQuery();
    }
}
