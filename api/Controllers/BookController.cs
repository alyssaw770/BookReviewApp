using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Book;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace api.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        //unmutable
        private readonly ApplicationDbContext _context;
        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var books = _context.Books.ToList()
            .Select(b => b.ToBookDto());
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var book= _context.Books.Find(id);

            if(book == null)
            {
                return NotFound();
            }

            return Ok(book.ToBookDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateBookRequestDto bookDto)
        {
            var bookModel = bookDto.ToBookFromCreateDTO();

            _context.Add(bookModel);
            _context.SaveChanges();

            return  CreatedAtAction(nameof(GetById), new {id = bookModel.Id }, bookModel.ToBookDto());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateBookRequestDto updateDto)
        {
            var bookModel = _context.Books.FirstOrDefault(x => x.Id == id);

            if(bookModel == null)
            {
                return NotFound();
            }

            bookModel.Genre = updateDto.Genre;
            bookModel.Author = updateDto.Author;
            bookModel.Title = updateDto.Title;
            bookModel.Publisher = updateDto.Publisher;

            _context.SaveChanges();

            return Ok(bookModel.ToBookDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var bookModel = _context.Books.FirstOrDefault(x => x.Id == id);
            
            if(bookModel == null)
            {
                return NotFound();
            }

            _context.Books.Remove(bookModel);

            _context.SaveChanges();

            return NoContent();
        }
    }
}