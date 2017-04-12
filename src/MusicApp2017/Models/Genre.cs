using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicApp2017.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, ErrorMessage = "Genre name cannot be more than 20 characters")]
        public string Name { get; set; }
        //public List<Album> Albums { get; set; }
    }
}