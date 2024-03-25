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
    class StarDB
    {
        private Connection _dbInstance;
        private SqlConnection _connect;
        public StarDB()
        {
            _dbInstance = Connection.Instance();
            _connect = _dbInstance.Connect;
        }

        public ArrayList GetAllStar()
        {
            ArrayList stars = new ArrayList();

            string query = "SELECT * FROM Star";

            SqlCommand command = new SqlCommand(query, _connect);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var Id = reader.GetInt32(0);
                string Name = reader.GetString(1);
                string Image = reader.GetString(2);
                string Story = reader.GetString(3);
                stars.Add(new Star { Id = Id, Name = Name, Avatar=Image, Bio = Story});
            }

            reader.Close();
            return stars;
        }

        public void insertStar(string name, string image, string story)
        {
            string insertStarQuery = "INSERT INTO Star(Name, Image, Story) VALUES (@Name, @Image, @Story);";
            SqlCommand command = new SqlCommand(insertStarQuery, _connect);

            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Image", image);
            command.Parameters.AddWithValue("@Story", story);
            command.ExecuteNonQuery();
        }

        public Star GetStar(int id) {
            SqlCommand command = new SqlCommand($"SELECT * FROM Star WHERE Id = {id}", _connect);
            SqlDataReader reader = command.ExecuteReader();
            Star result = null;
            if (reader.Read()) {
                var Id = reader.GetInt32(0);
                string Name = reader.GetString(1);
                string Image = reader.GetString(2);
                string Story = reader.GetString(3);
                result = new Star { Id = Id, Name = Name, Avatar = Image, Bio = Story };
            }
            reader.Close();
            return result;
        }
        public void Update(Star star) {
            SqlCommand command = new SqlCommand(@$"
UPDATE Star SET
Name = '{star.Name}',
Image = '{star.Avatar}',
Story = @Story
WHERE Id = {star.Id}
", _connect);
            command.Parameters.AddWithValue("@Story", star.Bio);
            command.ExecuteNonQuery();
        }
    }
}
