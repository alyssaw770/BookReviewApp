using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Book
{
    public class CreateBookRequestDto
    {
        public string Genre { get; set; } = string.Empty;
        public string Author { get; set; } =  string.Empty;
        public string? Title { get; set; } 
        public string? Publisher { get; set; }
    }
}