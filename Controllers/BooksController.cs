using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BookStoreWebAPI.Models;
using BookStoreWebAPI.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepo _booksRepo;

        public BooksController(IBooksRepo booksRepo)
        {
            _booksRepo = booksRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books1 = await _booksRepo.GetAllBooksAsync();
            return Ok(books1);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById ([FromRoute]int id)
        {
            var book = await _booksRepo.GetById(id);
            if(book == null)
            {
                
                return NotFound();
            }
            return Ok(book);

        }

        [HttpPost]
        public async Task<IActionResult> Create ([FromBody]Books book)
        {
            int id = await _booksRepo.Create(book);
            return CreatedAtAction(nameof(GetById), new {id = id, Controller = "books"}, id);

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromBody]Books book, [FromRoute]int id)
        {
            await _booksRepo.Update(book, id);
            return Ok();
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> UpdatePatch([FromBody]JsonPatchDocument book, [FromRoute]int id)
        {
            await _booksRepo.UpdatePatch(book, id);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _booksRepo.Delete(id);
            return Ok();

        }
    }
}