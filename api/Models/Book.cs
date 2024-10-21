using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace api.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Genre { get; set; } = string.Empty;
        public string Author { get; set; } =  string.Empty;
        public string? Title { get; set; } 
        public string? Publisher { get; set; }

        public List<Review> Reviews { get; set; } = new List<Review>();

        // [Column(TypeName = "decimal(18,2)")]
        // public decimal Purchase { get; set; }
        // [Column(TypeName = "decimal(18,2)")]
        // public decimal LastDiv { get; set; }

    }
}