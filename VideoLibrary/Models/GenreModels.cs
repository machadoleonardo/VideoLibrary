using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoLibrary.Models
{
    public class GenreModels
    {
        public ulong IdGenre { get; set; }
        public int NameGenre { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Active { get; set; }
    }
}