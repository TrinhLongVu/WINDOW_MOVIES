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
    class AccountDB
    {
        private Connection _dbInstance;
        private SqlConnection _connect;
        public AccountDB()
        {
            _dbInstance = Connection.Instance();
            _connect = _dbInstance.Connect;
        }

        public ArrayList GetAllUser()
        {
            ArrayList account = new ArrayList();

            string query = "SELECT * FROM Account";

            SqlCommand command = new SqlCommand(query, _connect);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var Id = reader.GetInt32(0);
                string Role = reader.GetString(1);
                string BirthDate = reader.GetString(2);
                string Username = reader.GetString(3);
                string Password = reader.GetString(4);
                account.Add(new Account { Id = Id, Date = BirthDate, Role = Role, Username = Username, Password = Password });
            }

            reader.Close();
            return account;
        }

        public void Register(string role, string birthday, string username, string password)
        {
            string query = "INSERT INTO Account(Role, Birthday, Username, Password) VALUES (@Role, @Birthday, @Username, @Password)";
            using (SqlCommand command = new SqlCommand(query, _connect))
            {
                command.Parameters.AddWithValue("@Role", role);
                command.Parameters.AddWithValue("@Birthday", birthday);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                try
                {
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Data inserted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No rows affected.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error inserting data: " + ex.Message);
                }
            }
        }
    }
}
