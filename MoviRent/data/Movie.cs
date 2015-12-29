using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviRent.data
{
    public class Movie
    {
        public string genre { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string director { get; set; }

        public Movie()
        {
            genre = "";
            description = "";
            title = "";
            director = "";
        }
    }
}

