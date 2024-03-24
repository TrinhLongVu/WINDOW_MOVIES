using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Database {
    class SeatDB {
        private Connection _dbInstance;
        private SqlConnection _connect;
        public SeatDB() {
            _dbInstance = Connection.Instance();
            _connect = _dbInstance.Connect;
        }

        public List<(string Position, int Id)> GetAllSeats() {
            List<(string, int)> seats = new List<(string, int)>();
            string query = "SELECT * FROM Seat";
            SqlCommand command = new SqlCommand(query, _connect);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                int id = reader.GetInt32(0);
                string position = reader.GetString(1);
                seats.Add((position, id));
            }
            reader.Close();
            return seats;
        }
    }
}
