using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoLibrary.Entities;

namespace Services
{
    public class MoviesService
    {
        private MoviesRepository MoviesRepository = new MoviesRepository();

        public Movie GetMovieById(Guid? idMovie) => MoviesRepository.GetMovieById(idMovie);
        public List<Movie> GetAllAtivos() => MoviesRepository.GetAllActives();
        public void LogicalRemovalMovie(Movie movie) => MoviesRepository.LogicalRemovalMovie(movie);
        public void LogicalRemovalMovies(List<Movie> movies) => MoviesRepository.LogicalRemovalMovies(movies);
        public void LogicalRemovalMovieById(Guid idMovie) => MoviesRepository.LogicalRemovalMovieById(idMovie);
        public void LogicalRemovalMoviesByIds(Guid[] idsMovies) => MoviesRepository.LogicalRemovalMoviesByIds(idsMovies);
        public void RemoveMovie(Movie movie) => MoviesRepository.RemoveMovie(movie);
        public void RemoveMovieById(Guid idMovie) => MoviesRepository.RemoveMovieById(idMovie);
        public void RemoveMoviesList(List<Movie> movies) => MoviesRepository.RemoveMoviesList(movies);
        public Movie UpdateMovie(Movie movie)
        {
            var movies = MoviesRepository.GetMovieById(movie.Id);
            if (movies != null)
            {
                MoviesRepository.UpdateMovie(movie);
                return movie;
            }
            return null;
        }

        public bool CreateMovie(Movie movie)
        {
            var movieExists = MoviesRepository.ContainsMovie(movie);
            if (!movieExists)
            {
                MoviesRepository.CreateMovie(movie);
                return true;
            }
            return false;
        }
    }
}