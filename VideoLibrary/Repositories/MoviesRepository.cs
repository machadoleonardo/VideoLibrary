using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VideoLibrary.Context;
using VideoLibrary.Entities;

namespace Repositories
{
    public class MoviesRepository
    {
        protected VideoLibraryContext db = new VideoLibraryContext();

        public List<Movie> GetAllActives()
        {
            return db.Movie.Include(movie => movie.Genre).Where(movie => movie.Active == true).ToList();
        }
        public Movie GetMovieById(Guid? id) => db.Set<Movie>().Find(id);
        public void LogicalRemovalMovie(Movie movie)
        {
            movie.Active = false;
            db.Entry(movie).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void LogicalRemovalMovies(List<Movie> moviesList)
        {
            moviesList.ForEach(movie => LogicalRemovalMovie(movie));
        }
        public void LogicalRemovalMovieById(Guid? idMovie)
        {
            var movie = this.db.Set<Movie>().Find(idMovie);
            LogicalRemovalMovie(movie);
        }
        public void LogicalRemovalMoviesByIds(Guid[] idsMovies)
        {
            var moviesList = db.Set<Movie>().Where(movie => idsMovies.Contains(movie.Id)).ToList();
            LogicalRemovalMovies(moviesList);          
        }

        public void CreateMovie(Movie movie)
        {
            movie.Id = Guid.NewGuid();
            db.Movie.Add(movie);
            db.SaveChanges();
        }

        public bool ContainsMovie(Movie movieQuery)
        {
            return db.Set<Movie>().Any(movie => movieQuery.NameMovie.Equals(movie.NameMovie) && movie.Active);
        }
                
        public void RemoveMovie(Movie movie)
        {
            db.Entry(movie).State = EntityState.Deleted;
            db.Set<Movie>().Remove(movie);
            db.SaveChanges();
        }
        public void RemoveMovieById(Guid? id)
        {
            var db = this.db.Set<Movie>().Find(id);
            this.db.Entry(db).State = EntityState.Deleted;
            this.db.Set<Movie>().Remove(db);
            this.db.SaveChanges();
        }
        public void RemoveMoviesList(List<Movie> movies)
        {
            movies.ForEach(movie => RemoveMovie(movie));
        }
        public void RemoveMovieListIds(IEnumerable<Guid> movieList)
        {
            var movies = db.Set<Movie>().Where(movie => movieList.Contains(movie.Id)).ToList();
            RemoveMoviesList(movies);
        }
        public void UpdateMovie(Movie movie)
        {
            db.Entry(movie).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}