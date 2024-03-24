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

        // get all booked seats for a movie with a schedule
        public List<string> GetAllBookedSeats(int movieId, DateTime date, string schedule) {
            List<string> result = new List<string>();
            string sqlDate = date.ToString("MM/dd/yyyy");
            string query =  "SELECT Seat.Position FROM Ticket JOIN MovieSchedule ms ON MovieScheduleId = ms.Id " +
                            " JOIN Schedule sc ON ms.IdSchedule = sc.Id " +
                            " JOIN Seat ON Seat.Id = Ticket.SeatId" +
                           $" WHERE ms.Date = '{sqlDate}' AND sc.Time = '{schedule}' AND ms.IdMovie = {movieId} ";

            SqlCommand command = new SqlCommand(query, _connect);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                string seat = reader.GetString(0);
                result.Add(seat);
            }
            reader.Close();

            return result;
        }

        public List<Ticket> GetAllTickets(int userId) {
            List<Ticket> result = new List<Ticket>();

            string query = $@"
            select tk.Id, tk.UserId, ms.IdMovie, ms.Date, sc.Time from Ticket tk
            join MovieSchedule ms on ms.Id = tk.MovieScheduleId
            join Schedule sc on sc.Id = ms.IdSchedule
            where tk.UserId = {userId}";

            SqlCommand command = new SqlCommand(query, _connect);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                string date_str = reader.GetDateTime(3).ToString("dd/MM/yyyy");
                string time = reader.GetString(4);

                result.Add(new Ticket {
                    Id = reader.GetInt32(0),
                    UserId = reader.GetInt32(1),
                    MovieId = reader.GetInt32(2),
                    Schedule = DateTime.ParseExact($"{date_str} {time}", "dd/MM/yyyy HH:mm:ss", null)
                });
            }

            reader.Close();
            return result;
        }
    }
}
