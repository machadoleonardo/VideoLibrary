using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VideoLibrary.Entities
{
    public class Movie
    {
        [Display(Name = "Id Filme")]
        public Guid Id { get; set; }
        [Display(Name = "Filme")]
        public string NameMovie { get; set; }
        [Display(Name = "Data de criação")]
        public DateTime CreationDateMovie { get; set; }
        [Display(Name = "Ativo")]
        public bool Active { get; set; }
        public Guid GenreId { get; set; }
        public Genre Genre { get; set; }
        [NotMapped]
        [Display(Name = "Remover")]
        public bool IsRemove { get; set; }

    }
}