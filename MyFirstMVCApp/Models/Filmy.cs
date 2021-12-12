using System.ComponentModel.DataAnnotations;
using System;

namespace MyFirstMVCApp.Models
{
    public class Filmy
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}
