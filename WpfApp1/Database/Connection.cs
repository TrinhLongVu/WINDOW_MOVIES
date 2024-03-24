using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// using singleton.
namespace WpfApp1.Database
{
    class Connection
    {
        private static Connection _instance = null;
        private string _connectionString = @"Server=localhost,1433;Database=Movie;Trusted_Connection=yes;Encrypt=True;TrustServerCertificate=True";
        private SqlConnection _connection;
        private Connection()
        {
            _connection = new SqlConnection(_connectionString);
            try
            {
                _connection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Error connecting to the database.", ex);
            }
        }

        public static Connection Instance()
        {
            if(_instance == null)
            {
                _instance = new Connection();
            }
            return _instance;
        }

        public SqlConnection Connect => _connection;

        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Dispose();
            }
        }
    }
}
