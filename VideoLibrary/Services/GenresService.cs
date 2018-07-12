using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoLibrary.Entities;

namespace Repositories.Services
{
    public class GenresService
    {
        private GenresRepository genresRepository = new GenresRepository();

        public List<Genre> GetAllActives() => genresRepository.GetAllActives();

        public Genre GetGenreById(Guid? id) => genresRepository.GetGenreById(id);
        public void LogicalRemovalGenre(Genre genre) => genresRepository.LogicalRemovalGenre(genre);
        public void LogicalRemovalGenres(List<Genre> genres) => genresRepository.LogicalRemovalGenres(genres);
        public List<Movie> LogicalRemovalGenreById(Guid idGenre)
        {
            List<Movie> moviesAssociatedGenre = genresRepository.GetMoviesAssociatedGenre(idGenre);
            if (moviesAssociatedGenre == null)
            {
                genresRepository.LogicalRemovalGenreById(idGenre);
            }
            return moviesAssociatedGenre;
        }

        public List<Movie> LogicalRemovalGenresByIds(Guid[] idsGenres)
        {
            List<Movie> moviesAssociatedGenres = new List<Movie>();
            
            foreach(Guid idGenre in idsGenres)
            {
                List<Movie> list = genresRepository.GetMoviesAssociatedGenre(idGenre);
                if (list != null && list.Any())
                    list.ForEach(movieAssociatedGenre => moviesAssociatedGenres.Add(movieAssociatedGenre));
                else
                    genresRepository.LogicalRemovalGenresByIds(idsGenres);
             }
            return moviesAssociatedGenres;
        }
        

        public Genre UpdateGenre(Genre genre) {
            var genres = genresRepository.ContainsGenre(genre);
            if (genres != null && genres.Any())
            {
                genresRepository.UpdateGenre(genre);
                return genre;
            }
            return null;
        }

        public virtual void RemoveGenreById(Guid id) => genresRepository.RemoveGenreById(id);

        public virtual void RemoveGenre(Genre genre) => genresRepository.RemoveGenre(genre);

        public virtual void RemoveGenreList(IEnumerable<Genre> genres) => genresRepository.RemoveGenresList(genres);

        public Genre CreateGenre(Genre genre) {
            var genres = genresRepository.ContainsGenre(genre);
            if (genres == null || !genres.Any())
            {
                genre.Id = Guid.NewGuid();
                genre.Active = true;
                genresRepository.CreateGenre(genre);
                return genre;
            }
            return null;
        }
        
    }
}