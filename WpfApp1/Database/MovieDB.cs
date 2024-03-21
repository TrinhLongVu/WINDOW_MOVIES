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
                Int32 IdGener = reader.GetInt32(1);
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
                Int32 IdGener = reader.GetInt32(1);
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

        public InfoPageMovie GetMovie(Int32 IdMovie)
        {
            InfoPageMovie movie = new InfoPageMovie();

            //string query = "SELECT * FROM Movie where Id=@Id";
            string query = @"
            SELECT m.*, g.Name AS 'Genre', 
                   s.Name AS NameStar, s.Image AS imageStar, 
                   s.Story AS StoryStar, d.Name AS NameDirector, 
                   d.Image AS Imagedirector, d.Story AS StoryDirector
            FROM Movie m
            JOIN MovieStar ms ON m.Id = ms.MovieId
            JOIN MovieDirector md ON m.Id = md.MovieId
            JOIN Genre g ON m.IdGener = g.Id
            JOIN Star s ON s.Id = ms.StarId
            JOIN Director d ON d.Id = md.DirectorId
            WHERE m.Id = @Id";

            SqlCommand command = new SqlCommand(query, _connect);
            command.Parameters.AddWithValue("@Id", $"{IdMovie}");
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var Id = reader.GetInt32(0);
                Int32 IdGener = reader.GetInt32(1);
                string Title = reader.GetString(2);
                string Runtime = reader.GetString(3);
                string Rating = reader.GetString(4);
                string Poster = reader.GetString(5);
                string Landscape = reader.GetString(6);
                string Certification = reader.GetString(7);
                string Release = reader.GetString(8);
                string Detail = reader.GetString(9);
                string Genre = reader.GetString(10);
                string NameStar = reader.GetString(11);
                string ImageStar = reader.GetString(12);
                string StoryStar = reader.GetString(13);
                string NameDirector = reader.GetString(14);
                string Imagedirector = reader.GetString(15);
                string StoryDirector = reader.GetString(16);
                movie = new InfoPageMovie { Id = Id, IdGener = IdGener, Title = Title, Runtime = Runtime, Rating = Rating, Poster = Poster, Landscape = Landscape, Certification = Certification, Release = Release, Detail = Detail, NameGenre = Genre, AvatarDirector = Imagedirector, BioDirector = StoryDirector, NameStar = NameStar, NameDirector = NameDirector, BioStar = StoryStar, AvatarStar = ImageStar};
                break;
            }

            reader.Close();
            return movie;
        }
    }
}
