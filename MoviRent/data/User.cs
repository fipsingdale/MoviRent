using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviRent.data
{
    public class User
    {
        public String userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public List<Movie> borrowedMovies { get; set; }
        public string address { get; set; }
        public bool blocked { get; set; }

        public User()
        {
            firstName = "";
            lastName = "";
            address = "";
            dateOfBirth = DateTime.MaxValue;
            borrowedMovies = new List<Movie>();
            blocked = false;
        }
    }
}

