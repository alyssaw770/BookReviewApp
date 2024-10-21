using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Dtos.Book;
using api.Models;

namespace api.Mappers
{
    public static class BookMappers
    {
        public static BookDto ToBookDto(this Book bookModel)
        {
            return new BookDto
            {
                Id = bookModel.Id,
                Genre = bookModel.Genre,
                Author = bookModel.Author,
                Title = bookModel.Title,
                Publisher = bookModel.Publisher
            };
        }

        public static Book ToBookFromCreateDTO(this CreateBookRequestDto bookDto)
        {
            return new Book
            {
                Genre = bookDto.Genre,
                Author = bookDto.Author,
                Title = bookDto.Title,
                Publisher = bookDto.Publisher
            };
        }
    }
}