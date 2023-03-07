using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreWebAPI.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace BookStoreWebAPI.Repository
{
    public interface IBooksRepo
    {
        Task<List<Books>> GetAllBooksAsync();

        Task<Books> GetById(int id);

        Task<int> Create(Books inputbook);

        Task Update(Books book, int id);

        Task UpdatePatch(JsonPatchDocument book, int id);

        Task Delete(int id);
    }
}