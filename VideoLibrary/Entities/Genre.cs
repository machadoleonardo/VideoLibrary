using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VideoLibrary.Entities
{
    public class Genre
    {
        [Display(Name = "Id Gênero")]
        public Guid Id { get; set; }
        [Display(Name = "Gênero")]
        public string NameGenre { get; set; }
        [Display(Name = "Data de criação")]
        public DateTime CreationDateGenre { get; set; }
        [Display(Name = "Ativo")]
        public bool Active { get; set; }
        [NotMapped]
        [Display(Name = "Remover")]
        public bool IsRemove { get; set; }
    }
}