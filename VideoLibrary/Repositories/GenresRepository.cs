using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VideoLibrary.Context;
using VideoLibrary.Entities;

namespace Repositories
{
    public class GenresRepository
    {
        protected VideoLibraryContext db = new VideoLibraryContext();

        public Genre GetGenreById(Guid? id) => db.Set<Genre>().Find(id);

        public void RemoveGenreListIds(IEnumerable<Guid> GenreList)
        {
            var Genres = db.Set<Genre>().Where(Genre => GenreList.Contains(Genre.Id)).ToList();
            RemoveGenresList(Genres);
        }

        public void UpdateGenre(Genre Genre)
        {
            db.Entry(Genre).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void RemoveGenreById(Guid id)
        {
            var db = this.db.Set<Genre>().Find(id);
            this.db.Entry(db).State = EntityState.Deleted;
            this.db.Set<Genre>().Remove(db);
            this.db.SaveChanges();
        }

        public List<Movie> GetMoviesAssociatedGenre(Guid idGenre)
        {
            return db.Set<Movie>().Where(movie => movie.GenreId == idGenre && movie.Active == true).ToList();
        }

        public List<Genre> ContainsGenre(Genre genreQuery)
        {
            return db.Set<Genre>().Where(genre => genreQuery.NameGenre == genre.NameGenre && genre.Active == true).ToList();
        }

        public bool Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            return disposing;
        }

        public void CreateGenre(Genre genre)
        {
            db.Genre.Add(genre);
            db.SaveChanges();
        }

        public void RemoveGenre(Genre Genre)
        {
            db.Entry(Genre).State = EntityState.Deleted;
            db.Set<Genre>().Remove(Genre);
            db.SaveChanges();
        }

        public void RemoveGenresList(IEnumerable<Genre> Genres)
        {
            Genres.ToList().ForEach(Genre => RemoveGenre(Genre));
        }
        public List<Genre> GetAllActives()
        {
            return db.Genre.Where(Genre => Genre.Active).ToList();
        }

        public void LogicalRemovalGenresByIds(Guid[] idsGenres)
        {
            var GenresList = db.Set<Genre>().Where(Genre => idsGenres.Contains(Genre.Id)).ToList();
            LogicalRemovalGenres(GenresList);

        }

        public void LogicalRemovalGenreById(Guid idGenre)
        {
            var Genre = this.db.Set<Genre>().Find(idGenre);
            LogicalRemovalGenre(Genre);
        }

        public void LogicalRemovalGenres(List<Genre> GenresList)
        {
            GenresList.ForEach(Genre => LogicalRemovalGenre(Genre));
        }

        public void LogicalRemovalGenre(Genre Genre)
        {
            Genre.Active = false;
            db.Entry(Genre).State = EntityState.Modified;
            db.SaveChanges();
        }
    }

}
