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
    class GenreDB
    {
        private Connection _dbInstance;
        private SqlConnection _connect;
        public GenreDB()
        {
            _dbInstance = Connection.Instance();
            _connect = _dbInstance.Connect;
        }

        public ArrayList GetAllGenre()
        {
            ArrayList genres = new ArrayList();

            string query = "SELECT * FROM Genre";

            SqlCommand command = new SqlCommand(query, _connect);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var Id = reader.GetInt32(0);
                string Name = reader.GetString(1);
                genres.Add(new Genre { Id = Id, Name = Name});
            }

            reader.Close();
            return genres;
        }
    }
}
