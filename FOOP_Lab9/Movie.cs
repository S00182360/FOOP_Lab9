using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOP_Lab9
{
    class Movie
    {
        private string _title;
        private string _genre;
        private int _rating;

        public string Title { get => _title; set => _title = value; }
        public string Genre { get => _genre; set => _genre = value; }
        public int Rating { get => _rating; set => _rating = value; }

        public Movie(string title): this(title, "Unknown", 0)
        {
        }

        public Movie():this("Unknown")
        {
        }

        public Movie(string title, string genre, int rating)
        {
            Title = title;
            Genre = genre;
            Rating = rating;
        }

        public override string ToString()
        {
            return string.Format("{0}, Genre: {1}, Rating: {2}", Title, Genre, Rating); 
        }

        //public enum GENRE { }
    }
}
