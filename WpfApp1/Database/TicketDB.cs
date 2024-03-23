using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Database
{
    class TicketDB
    {
        private Connection _dbInstance;
        private SqlConnection _connect;
        public TicketDB() {
            _dbInstance = Connection.Instance();
            _connect = _dbInstance.Connect;
        }

        public void AddTicket(Account user, Seat seat, MovieSchedule schedule) {
            string queryMovie = $"INSERT INTO Ticket(SeatId, MovieScheduleId, UserId) VALUES({seat.Id}, {schedule.Id}, {user.Id})";

            SqlCommand command = new SqlCommand(queryMovie, _connect);
            command.ExecuteNonQuery();
        }

        public List<string> GetAllTickets(int movieId, DateTime date, string schedule) {
            List<string> result = new List<string>();
            string sqlDate = date.ToString("MM/dd/yyyy");
            string query =  "SELECT Seat.Chair FROM Ticket JOIN MovieSchedule ms ON MovieScheduleId = ms.Id " +
                            " JOIN Schedule sc ON ms.IdSchedule = sc.Id " +
                            " JOIN Seat ON Seat.Id = Ticket.SeatId" +
                           $" WHERE ms.Date = '{sqlDate}' AND sc.Time = '{schedule}' ";

            SqlCommand command = new SqlCommand(query, _connect);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                string seat = reader.GetString(0);
                result.Add(seat);
            }
            reader.Close();

            return result;
        }
    }
}
