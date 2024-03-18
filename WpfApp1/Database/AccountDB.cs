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
                string Id = reader.GetString(0);
                string Role = reader.GetString(1);
                string Username = reader.GetString(2);
                string Password = reader.GetString(3);
                account.Add(new Account { Id = Id, Role = Role, Username = Username, Password = Password });
            }

            reader.Close();
            return account;
        }
    }
}
