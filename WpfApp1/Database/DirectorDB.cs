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
    class DirectorDB
    {
        private Connection _dbInstance;
        private SqlConnection _connect;
        public DirectorDB()
        {
            _dbInstance = Connection.Instance();
            _connect = _dbInstance.Connect;
        }

        public ArrayList GetAllDirectors()
        {
            ArrayList directors = new ArrayList();

            string query = "SELECT * FROM Director";

            SqlCommand command = new SqlCommand(query, _connect);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var Id = reader.GetInt32(0);
                string Name = reader.GetString(1);
                string Image = reader.GetString(2);
                string Story = reader.GetString(3);
                directors.Add(new Director { Id = Id, Name = Name, Avatar=Image, Bio = Story});
            }

            reader.Close();
            return directors;
        }

        public void insertDirector(string name, string image, string story)
        {
            string insertStarQuery = "INSERT INTO Director(Name, Image, Story) VALUES (@Name, @Image, @Story);";
            SqlCommand command = new SqlCommand(insertStarQuery, _connect);

            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Image", image);
            command.Parameters.AddWithValue("@Story", story);
            command.ExecuteNonQuery();
        }
    }
}
