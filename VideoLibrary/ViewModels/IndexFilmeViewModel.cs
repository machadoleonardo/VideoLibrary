using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoLibrary.Entities;

namespace VideoLibrary.ViewModels
{
    public class IndexFilmeViewModel
    {
        public int idFilme { get; set; }
        public List<Genre> ListaGeneros { get; set; }
        public string NomeFilme { get; set; }
        public DateTime DataFilme { get; set; }
    }
}