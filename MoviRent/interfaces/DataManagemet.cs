using MoviRent.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviRent.interfaces
{
    interface DataManagement
    {
        void CreateUser(User user);
        void CreateMovie(Movie movie);
        List<User> GetAllUser();
        List<User> GetUserWhoBorrowed();
        List<Movie> GetAllMovies();
        List<Movie> GetAllUnborrowedMovies();
        List<Movie> GetAllBorrowedMovies();
        User GetSingleUser(String userId);
        Movie GetSingleMovie(String movieId);
        Movie GetSingleMovie(String title);
        void UpdateUser(User user);
        void UpdatetMovie(Movie movie);
        void DeleteUser(String userId);
        void DeleteMovie(String movieId);
    }
}
