using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStoreWebAPI.Data;
using BookStoreWebAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebAPI.Repository
{
    public class BooksRepo : IBooksRepo
    {
        private readonly DbContextBook _context;
        private readonly IMapper _mapper;
        public BooksRepo(DbContextBook context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Books>> GetAllBooksAsync()
        {
            var record = await _context.Books.Select(x=> new Books()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description
            }).ToListAsync();

            return record;

            //var record = await _context.Books.
        }
        public async Task<Books> GetById(int id)
        {
            // var record = await _context.Books.Where(x=>x.Id == id).Select(x=> new Books()
            // {
            //     Id = x.Id,
            //     Title = x.Title,
            //     Description = x.Description
            // }).FirstOrDefaultAsync();

            var record = await _context.Books.FindAsync(id);

            return record;

            // var record = await _context.Books.FindAsync(id);
            // return _mapper.Map<IEnumerable<Books>>(BookModel);
        }

        public async Task<int> Create(Books book)
        {
            var _book = new Books()
            {
                Title = book.Title,
                Description = book.Description
            };

            _context.Books.Add(_book);
            await _context.SaveChangesAsync();
            return _book.Id ;

        }

        public async Task Update(Books book, int id)
        {
            var _book = await _context.Books.FindAsync(id);
            
            if(_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                await _context.SaveChangesAsync();
            }
            return ;
        }

        public async Task UpdatePatch(JsonPatchDocument book, int id)
        {
            var _book = await _context.Books.FindAsync(id);
            if(_book != null)
            {
                book.ApplyTo(_book);
                await _context.SaveChangesAsync();
            }
            return ;
        }

        public async Task Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if(book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }



    }
}