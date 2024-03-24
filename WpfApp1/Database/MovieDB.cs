using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
                double Rating = reader.GetDouble(4);
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

        public List<Movie> GetAllAiringMovies() {
            List<Movie> movies = new List<Movie>();
            string query = "SELECT * FROM Movie WHERE Id in (SELECT IdMovie FROM MovieSchedule)";

            SqlCommand command = new SqlCommand(query, _connect);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                var Id = reader.GetInt32(0);
                Int32 IdGener = reader.GetInt32(1);
                string Title = reader.GetString(2);
                string Runtime = reader.GetString(3);
                double Rating = reader.GetDouble(4);
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

        public void InsertMovie(Movie m, int idStar, int idDirector)
        {
            ArrayList movies = new ArrayList();

            string queryMovie = @"
            INSERT INTO Movie (Title, IdGener, Runtime, Detail, Release, Rating, Poster, Landscape, Certification)
            VALUES (@Title, @IdGener, @Runtime, @Detail, @Release, @Rating, @Poster, @Landscape, @Certification);
            SELECT SCOPE_IDENTITY();";
            string insertMovieStarQuery = "INSERT INTO MovieStar (MovieId, StarId) VALUES (@MovieId, @StarId);";
            string insertMovieDirectorQuery = "INSERT INTO MovieDirector (MovieId, DirectorId) VALUES (@MovieId, @DirectorId);";

            SqlCommand command = new SqlCommand();
            command.Connection = _connect;

            // movie
            command.CommandText = queryMovie;
            command.Parameters.AddWithValue("@Title", m.Title);
            command.Parameters.AddWithValue("@IdGener", m.IdGener);
            command.Parameters.AddWithValue("@Runtime", m.Runtime);
            command.Parameters.AddWithValue("@Detail", m.Detail);
            command.Parameters.AddWithValue("@Release", m.Release);
            command.Parameters.AddWithValue("@Rating", m.Rating);
            command.Parameters.AddWithValue("@Poster", m.Poster);
            command.Parameters.AddWithValue("@Landscape", m.Landscape);
            command.Parameters.AddWithValue("@Certification", "");
            decimal insertedId = Convert.ToDecimal(command.ExecuteScalar());


            command.CommandText = insertMovieStarQuery;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@MovieId", insertedId);
            command.Parameters.AddWithValue("@StarId", idStar);
            command.ExecuteNonQuery();

            command.CommandText = insertMovieDirectorQuery;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@MovieId", insertedId); 
            command.Parameters.AddWithValue("@DirectorId", idDirector); 
            command.ExecuteNonQuery();
        }
    
        public ArrayList SearchMovie(string stringSearch)
        {
            ArrayList movies = new ArrayList();

            string query = "SELECT * FROM Movie, Genre WHERE Title LIKE @SearchTerm and Movie.IdGener = Genre.Id";

            SqlCommand command = new SqlCommand(query, _connect);
            command.Parameters.AddWithValue("@SearchTerm", $"%{stringSearch}%");

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var Id = reader.GetInt32(0);
                Int32 IdGener = reader.GetInt32(1);
                string Title = reader.GetString(2);
                string Runtime = reader.GetString(3);
                double Rating = reader.GetDouble(4);
                string Poster = reader.GetString(5);
                string Landscape = reader.GetString(6);
                string Certification = reader.GetString(7);
                string Release = reader.GetString(8);
                string Detail = reader.GetString(9);
                string GenreName = reader.GetString(11);
                movies.Add(new Movie { Id = Id, IdGener = IdGener, Title = Title, Runtime = Runtime, Rating = Rating, Poster = Poster, Landscape = Landscape, Certification = Certification, Release = Release, Detail = Detail, GenreName = GenreName });
            }

            reader.Close();
            return movies;
        }

        public ArrayList FilterMovieGenre(Genre genre, Filter sort)
        {
            ArrayList movies = new ArrayList();

            string query = "";
            SqlCommand command = null;
            if (genre != null && sort != null)
            {
                if (sort.Name == "Ascending Rating")
                    query = "SELECT * FROM Movie, Genre WHERE Movie.IdGener = Genre.Id AND Genre.Name = @SearchTerm order by Rating";
                else
                    query = "SELECT * FROM Movie, Genre WHERE Movie.IdGener = Genre.Id AND Genre.Name = @SearchTerm order by Rating DESC";
                command = new SqlCommand(query, _connect);
                command.Parameters.AddWithValue("@SearchTerm", genre.Name);
            }
            else if(genre != null)
            {
                query = "SELECT * FROM Movie, Genre WHERE Movie.IdGener = Genre.Id AND Genre.Name = @SearchTerm";
                command = new SqlCommand(query, _connect);
                command.Parameters.AddWithValue("@SearchTerm", genre.Name);
            }
            else if (sort != null)
            {
                if(sort.Name == "Ascending Rating")
                    query = "select* from movie order by Rating";
                else
                    query = "select* from movie order by Rating DESC";
                command = new SqlCommand(query, _connect);
            }

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var Id = reader.GetInt32(0);
                Int32 IdGener = reader.GetInt32(1);
                string Title = reader.GetString(2);
                string Runtime = reader.GetString(3);
                double Rating = reader.GetDouble(4);
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

        // Input: 'n' rows or null to select all
        public List<Movie> GetTopN_HotMovies(int? n) {
            var movies = new List<Movie>();
            string top_selector = n == null ? "" : $"top {n}";
            string query = $@"
select {top_selector} mv.Id, mv.IdGener, mv.Title, mv.Runtime, mv.Rating, mv.Poster, mv.Landscape, mv.Certification, mv.Release, mv.Detail from Movie mv
join MovieSchedule ms on mv.Id = ms.IdMovie
left join Ticket tk on tk.MovieScheduleId = ms.Id
group by mv.Id, mv.IdGener, mv.Title, mv.Runtime, mv.Rating, mv.Poster, mv.Landscape, mv.Certification, mv.Release, mv.Detail
order by count(tk.Id) desc";


            SqlCommand command = new SqlCommand(query, _connect);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                var Id = reader.GetInt32(0);
                Int32 IdGener = reader.GetInt32(1);
                string Title = reader.GetString(2);
                string Runtime = reader.GetString(3);
                double Rating = reader.GetDouble(4);
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

        public Movie GetMovieRaw(int movieId) {
            SqlCommand command = new SqlCommand($"SELECT * FROM Movie WHERE Id = {movieId}", _connect);
            SqlDataReader reader = command.ExecuteReader();
            Movie result = null;
            if (reader.Read()) {
                var Id = reader.GetInt32(0);
                Int32 IdGener = reader.GetInt32(1);
                string Title = reader.GetString(2);
                string Runtime = reader.GetString(3);
                double Rating = reader.GetDouble(4);
                string Poster = reader.GetString(5);
                string Landscape = reader.GetString(6);
                string Certification = reader.GetString(7);
                string Release = reader.GetString(8);
                string Detail = reader.GetString(9);
                result = new Movie { Id = Id, IdGener = IdGener, Title = Title, Runtime = Runtime, Rating = Rating, Poster = Poster, Landscape = Landscape, Certification = Certification, Release = Release, Detail = Detail };
            }

            reader.Close();
            return result;
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
                double Rating = reader.GetDouble(4);
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


        public Int32 QuantityMovie()
        {
            InfoPageMovie movie = new InfoPageMovie();

            string query = "select count(*) from Movie";

            SqlCommand command = new SqlCommand(query, _connect);

            SqlDataReader reader = command.ExecuteReader();

            Int32 quantity = 0;
            if (reader.Read())
            {
                quantity = reader.GetInt32(0);
            }

            reader.Close();
            return quantity;
        }



    }
}
