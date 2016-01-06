using MoviRent.data;
using MoviRent.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviRent.logic
{
    class SortRequirementsDefinition : RequirementsDefinition
    {
        public DataManagement dataManagement { get; set; }

        public SortRequirementsDefinition(DataManagement datamanagement)
        {
            this.dataManagement = datamanagement;
        }

            public List<User> GetAllUser()
            {
                List<User> users = dataManagement.GetAllUser();
                users.Sort((x, y) => x.lastName.CompareTo(y.lastName));
                return users;
            }

            public List<User> GetUserWhoBorrowed()
            {
                List<User> users = dataManagement.GetUserWhoBorrowed();
                users.Sort((x, y) => x.lastName.CompareTo(y.lastName));
                return users;

            }

            public List<Movie> GetAllMovies()
            {
                List<Movie> movies = dataManagement.GetAllMovies();
                movies.Sort((x, y) => x.title.CompareTo(y.title));
                return movies;
            }

            public List<Movie> GetAllUnborrowedMovies()
            {
                List<Movie> movies = dataManagement.GetAllUnborrowedMovies();
                movies.Sort((x, y) => x.title.CompareTo(y.title));
                return movies;
            }

            public List<Movie> GetAllBorrowedMovies()
            {
                List<Movie> movies = dataManagement.GetAllBorrowedMovies();
                movies.Sort((x, y) => x.title.CompareTo(y.title));
                return movies;
            }

            public Movie GetMovieById(int movieId)
            {
                return dataManagement.GetSingleMovie(movieId);
            }

            public void CreateMovie(Movie movie)
            {
                dataManagement.CreateMovie(movie);
            }

            public void UpdateMovie(Movie movie)
            {
                dataManagement.UpdatetMovie(movie);
            }

            public User GetUserById(int userId)
            {
                return dataManagement.GetSingleUser(userId);
            }

            public void CreateUser(User user)
            {
                dataManagement.CreateUser(user);
            }

            public void UpdateUser(User user)
            {
                dataManagement.UpdateUser(user);
            }

            public void BorrowMovie(int userId, Movie movie)
            {
                dataManagement.UpdatetMovie(movie);
            }

            public void ReturnBorrowedMovie(Movie movie)
            {
                dataManagement.UpdatetMovie(movie);
            }

            public void DeleteUser(User user)
            {
                dataManagement.DeleteUser(user);
            }
          public void DeleteMovie(Movie movie)
          {
              dataManagement.DeleteMovie(movie);
          }
    }
}
