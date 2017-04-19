using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp2017.Models
{
    public class AlbumRating
    {
        public int AlbumRatingID { get; set; }

        public int AlbumID { get; set; }
        public Album Album { get; set; }

        public String UserID { get; set; }
        public ApplicationUser User { get; set; }
        public int Rating { get; set; }
    }
}
