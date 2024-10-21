using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
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
    }
}