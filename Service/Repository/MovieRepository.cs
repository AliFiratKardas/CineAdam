 using DataAccess.Context;
using DataAccess.Entity;
using Service.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repository
{
    public class MovieRepository : IMovieRepository
    {

        private readonly MovieContext movieContext;
        public MovieRepository(MovieContext _moviecontext)
        {
            movieContext = _moviecontext;
        }

        public string AddMovie(Movie movie)
        {
            try
            {
                movieContext.Movies.Add(movie);
                movieContext.SaveChanges();
                return "ekleme başarılı";

            }
            catch (Exception ex)
            {

                return ex.Message;
            };
        }

        public bool Any(Expression<Func<Movie, bool>> exp)
        {
            return movieContext.Movies.Any(exp);
        }



        public string Deletemovie(int movieId)
        {

            try
            {
                movieContext.Movies.Remove(Find(movieId));
                movieContext.SaveChanges();
                return "silme işlemi başarılı";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public Movie Find(int movieId)
        {

            return movieContext.Movies.Find(movieId);
        }

        public List<Movie> GetMovies()
        {
            return movieContext.Movies.ToList();
        }

        public string Updatemovie(Movie movie)
        {

            try
            {
                Movie updated = Find(movie.Id);
                movieContext.Entry(updated).CurrentValues.SetValues(movie);
                movieContext.SaveChanges();

                return "Film güncellendi";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }



        }

        public List<Movie> Where(Expression<Func<Movie, bool>> exp)
        {

            return movieContext.Movies.Where(exp).ToList();
        }
    }
}
