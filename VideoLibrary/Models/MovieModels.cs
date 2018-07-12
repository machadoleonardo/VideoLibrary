using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoLibrary.Models
{
    public class MovieModels
    {

        public ulong IdMovie { get; set; }
        public string NameMovie { get; set; }
        public DateTime CreationDateMovie { get; set; }
        public bool Active { get; set; }
        public GenreModels GenreMovie { get; set; }

    }
}