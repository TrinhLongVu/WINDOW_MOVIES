using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Database
{
    class MovieDB
    {
        private Connection _dbInstance;
        private SqlConnection _connect;
        public MovieDB()
        {
            _dbInstance = Connection.Instance();
            _connect = _dbInstance.Connect;
        }

        public ArrayList GetAllMovie()
        {
            ArrayList movies = new ArrayList();

            string query = "SELECT * FROM Movie";

            SqlCommand command = new SqlCommand(query, _connect);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var Id = reader.GetInt32(0);
                string IdGener = reader.GetString(1);
                string Title = reader.GetString(2);
                string Runtime = reader.GetString(3);
                string Rating = reader.GetString(4);
                string Poster = reader.GetString(5);
                string Landscape = reader.GetString(6);
                string Certification = reader.GetString(7);
                string Release = reader.GetString(8);
                string Detail = reader.GetString(9);
                movies.Add(new Movie { Id = Id, IdGener = IdGener, Title = Title, Runtime = Runtime, Rating = Rating, Poster = Poster, Landscape = Landscape, Certification = Certification, Release = Release, Detail = Detail });
            }

            reader.Close();
            return movies;
        }

        public ArrayList SearchMovie(string stringSearch)
        {
            ArrayList movies = new ArrayList();

            string query = "SELECT * FROM Movie WHERE Title LIKE @SearchTerm";

            SqlCommand command = new SqlCommand(query, _connect);
            command.Parameters.AddWithValue("@SearchTerm", $"%{stringSearch}%");

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var Id = reader.GetInt32(0);
                string IdGener = reader.GetString(1);
                string Title = reader.GetString(2);
                string Runtime = reader.GetString(3);
                string Rating = reader.GetString(4);
                string Poster = reader.GetString(5);
                string Landscape = reader.GetString(6);
                string Certification = reader.GetString(7);
                string Release = reader.GetString(8);
                string Detail = reader.GetString(9);
                movies.Add(new Movie { Id = Id, IdGener = IdGener, Title = Title, Runtime = Runtime, Rating = Rating, Poster = Poster, Landscape = Landscape, Certification = Certification, Release = Release, Detail = Detail });
            }

            reader.Close();
            return movies;
        }
    }
}
