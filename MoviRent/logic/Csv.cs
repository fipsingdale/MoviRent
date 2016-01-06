using MoviRent.data;
using MoviRent.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MoviRent.logic
{
    class Csv : DataManagement
    {
        String userFile = "UserDetails.csv";
        String movieFile = "MovieDetails.csv";
        System.IO.StreamWriter csvWriter;
        System.IO.StreamReader csvReader;
        public void CreateUser(User user)
        {
            csvWriter = new System.IO.StreamWriter(userFile, true);
            csvWriter.WriteLine(user);
            csvWriter.Close();
        }
        public void CreateMovie(Movie movie)
        {
            csvWriter = new System.IO.StreamWriter(movieFile, true);
            csvWriter.WriteLine(movie);
            csvWriter.Close();
        }
        public List<User> GetAllUser()
        {
            String tmpUser;
            List<User> users = new List<User>();
            //Insert correct path to file
            csvReader = new System.IO.StreamReader(@"UserDetails.csv");
            while (null != (tmpUser = csvReader.ReadLine()))
            {
                User user = new User();
                String[] userData = tmpUser.Split(',').ToArray();
                user.userId = userData[0];
                user.firstName = userData[1];
                user.lastName = userData[2];
                user.dateOfBirth = Convert.ToDateTime(userData[3]);
                users.Add(user);
            }
            return users;
        }
        public List<User> GetUserWhoBorrowed()
        {
            throw new NotImplementedException();
        }
        public List<Movie> GetAllMovies()
        {
            String tmpMovie;
            List<Movie> movies = new List<Movie>();
            //Insert correct path to file
            csvReader = new System.IO.StreamReader(@"MovieDetails.csv");
            while (null != (tmpMovie = csvReader.ReadLine()))
            {
                Movie movie = new Movie();
                String[] movieData = tmpMovie.Split(',').ToArray();
                movie.genre = movieData[0];
                movie.description = movieData[1];
                movie.title = movieData[2];
                movie.director = movieData[3];
                movies.Add(movie);
            }
            return movies;
        }
        public List<Movie> GetAllUnborrowedMovies()
        {
            throw new NotImplementedException();
        }
        public List<Movie> GetAllBorrowedMovies()
        {
            throw new NotImplementedException();
        }
        public User GetSingleUser(String userId)
        {
            String tmpUser;
            //Insert correct path to file
            User user = new User();
            csvReader = new System.IO.StreamReader(@"UserDetails.csv");
            while (null != (tmpUser = csvReader.ReadLine()))
            {
                if (tmpUser.StartsWith(Convert.ToString(userId)))
                {
                    String[] userData = tmpUser.Split(',').ToArray();
                    user.userId = userData[0];
                    user.firstName = userData[1];
                    user.lastName = userData[2];
                    user.dateOfBirth = Convert.ToDateTime(userData[3]);
                }
            }
            return user;
        }
        public Movie GetSingleMovie(String movieId)
        {
            String tmpMovie;
            //Insert correct path to file
            Movie movie = new Movie();
            csvReader = new System.IO.StreamReader(@"MovieDetails.csv");
            while (null != (tmpMovie = csvReader.ReadLine()))
            {
                if (tmpMovie.StartsWith(movieId))
                {
                    String[] movieData = tmpMovie.Split(',').ToArray();
                    movie.genre = movieData[0];
                    movie.description = movieData[1];
                    movie.title = movieData[2];
                    movie.director = movieData[3];
                }
            }
            return movie;
        }
        public Movie GetSingleMovie(string title)
        {
            String tmpMovie;
            //Insert correct path to file
            Movie movie = new Movie();
            csvReader = new System.IO.StreamReader(@"MovieDetails.csv");
            while (null != (tmpMovie = csvReader.ReadLine()))
            {
                if (tmpMovie.Contains(title))
                {
                    String[] movieData = tmpMovie.Split(',').ToArray();
                    movie.genre = movieData[0];
                    movie.description = movieData[1];
                    movie.title = movieData[2];
                    movie.director = movieData[3];
                }
            }
            return movie;
        }
        public void UpdateUser(User user)
        {
            String tmpUser;
            //Insert correct path to file
            System.IO.StreamWriter csvWriterTmp = new System.IO.StreamWriter("tmpFile.csv");
            csvReader = new System.IO.StreamReader(@"UserDetails.csv");
            while (null != (tmpUser = csvReader.ReadLine()))
            {
                csvWriter = new System.IO.StreamWriter(userFile, true);
                if (tmpUser.StartsWith(Convert.ToString(user.userId)))
                {
                    User replacedUser = new User();
                    replacedUser.userId = user.userId;
                    replacedUser.firstName = user.firstName;
                    replacedUser.lastName = user.lastName;
                    replacedUser.dateOfBirth = user.dateOfBirth;
                    replacedUser.address = user.address;
                    replacedUser.blocked = user.blocked;
                    replacedUser.borrowedMovies = user.borrowedMovies;
                    csvWriterTmp.WriteLine(replacedUser);
                }
                else
                {
                    csvWriterTmp.WriteLine(tmpUser);
                }
                csvWriterTmp.Close();
                System.IO.StreamReader csvReaderTmp = new System.IO.StreamReader(@"tmpFile.csv");
                csvWriter = new System.IO.StreamWriter(userFile);
                String tmp;
                while (null != (tmp = csvReader.ReadLine()))
                {
                    csvWriter.WriteLine(tmp);
                }
                csvWriter.Close();
            }
        }
        public void UpdatetMovie(Movie movie)
        {
            String tmpMovie;
            //Insert correct path to file
            System.IO.StreamWriter csvWriterTmp = new System.IO.StreamWriter("tmpFile.csv");
            csvReader = new System.IO.StreamReader(@"MovieDetails.csv");
            while (null != (tmpMovie = csvReader.ReadLine()))
            {
                csvWriter = new System.IO.StreamWriter(movieFile, true);
                if (tmpMovie.StartsWith(Convert.ToString(movie.id)))
                {
                    Movie replacedMovie = new Movie();
                    replacedMovie.id = movie.id;
                    replacedMovie.title = movie.title;
                    replacedMovie.genre = movie.genre;
                    replacedMovie.director = movie.director;
                    replacedMovie.description = movie.description;
                    csvWriterTmp.WriteLine(replacedMovie);
                }
                else
                {
                    csvWriterTmp.WriteLine(tmpMovie);
                }
                csvWriterTmp.Close();
                System.IO.StreamReader csvReaderTmp = new System.IO.StreamReader(@"tmpFile.csv");
                csvWriter = new System.IO.StreamWriter(movieFile);
                String tmp;
                while (null != (tmp = csvReader.ReadLine()))
                {
                    csvWriter.WriteLine(tmp);
                }
                csvWriter.Close();
            }
        }
        public void DeleteUser(String userId)
        {
            String tmpUser;
            //Insert correct path to file
            System.IO.StreamWriter csvWriterTmp = new System.IO.StreamWriter("tmpFile.csv");
            csvReader = new System.IO.StreamReader(@"UserDetails.csv");
            while (null != (tmpUser = csvReader.ReadLine()))
            {
                csvWriter = new System.IO.StreamWriter(userFile, true);
                if (!(tmpUser.StartsWith(userId)))
                {
                    csvWriterTmp.WriteLine(tmpUser);
                }
                csvWriterTmp.Close();
                System.IO.StreamReader csvReaderTmp = new System.IO.StreamReader(@"tmpFile.csv");
                csvWriter = new System.IO.StreamWriter(userFile);
                String tmp;
                while (null != (tmp = csvReader.ReadLine()))
                {
                    csvWriter.WriteLine(tmp);
                }
                csvWriter.Close();
            }
        }
        public void DeleteMovie(String movieId)
        {
            String tmpMovie;
            //Insert correct path to file
            System.IO.StreamWriter csvWriterTmp = new System.IO.StreamWriter("tmpFile.csv");
            csvReader = new System.IO.StreamReader(@"MovieDetails.csv");
            while (null != (tmpMovie = csvReader.ReadLine()))
            {
                csvWriter = new System.IO.StreamWriter(movieFile, true);
                if (!(tmpMovie.StartsWith(movieId)))
                {
                    csvWriterTmp.WriteLine(tmpMovie);
                }
                csvWriterTmp.Close();
                System.IO.StreamReader csvReaderTmp = new System.IO.StreamReader(@"tmpFile.csv");
                csvWriter = new System.IO.StreamWriter(movieFile);
                String tmp;
                while (null != (tmp = csvReader.ReadLine()))
                {
                    csvWriter.WriteLine(tmp);
                }
                csvWriter.Close();
            }
        }
    }
}

