using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviRent.data;

namespace MoviRent.interfaces
{
    interface RequirementsDefinition
    {
        List<User> GetAllUser();
        List<User> GetUserWhoBorrowed();
        List<Movie> GetAllMovies();
        List<Movie> GetAllUnborrowedMovies();
        List<Movie> GetAllBorrowedMovies();
        Movie GetMovieById(int movieId);
        void CreateMovie(Movie movie);
        void UpdateMovie(Movie movie);
        User GetUserById(int userId);
        void CreateUser(User user);
        void UpdateUser(User user);
        void BorrowMovie(int userId, Movie movie);
        void ReturnBorrowedMovie(Movie movie);
        void DeleteUser(String userId);
        void DeleteMovie(String movieId);
    }
}
