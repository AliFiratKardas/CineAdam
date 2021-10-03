using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.IRepository
{
    public interface IMovieRepository
    {
        List<Movie> GetMovies();


        string AddMovie(Movie movie);

        Movie Find(int movieId);

        string Updatemovie(Movie movie);

        string Deletemovie(int movieId);

        List<Movie> Where(Expression<Func<Movie, bool>> exp);

        bool Any(Expression<Func<Movie, bool>> exp);
        

        
    }
}
