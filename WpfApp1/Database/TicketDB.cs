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

        public void AddTicket(Account user, Seat seat, MovieSchedule schedule, DateTime date, double price) {
            string queryMovie = $@"
INSERT INTO Ticket(SeatId, MovieScheduleId, UserId, Date, Price)
VALUES({seat.Id}, {schedule.Id}, {user.Id}, '{date.ToString()}', {price})";

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
            select tk.Id, tk.UserId, ms.IdMovie, ms.Date, sc.Time, tk.Date, tk.Price from Ticket tk
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
                    Schedule = DateTime.ParseExact($"{date_str} {time}", "dd/MM/yyyy HH:mm:ss", null),
                    Date = reader.GetDateTime(5),
                    Price = reader.GetDouble(6),
                });
            }

            reader.Close();
            return result;
        }

        public double GetDayTicket()
        {

            string query = $"select COALESCE(SUM(price), 0)  from ticket where date = {DateTime.Now.ToString("MM/dd/yyyy")}";

            SqlCommand command = new SqlCommand(query, _connect);

            SqlDataReader reader = command.ExecuteReader();


            double result = 0.0;
            while (reader.Read())
            {
                result = reader.GetDouble(0);   
            }
            reader.Close();
            return result;
        }

        public double GetMonthTicket()
        {

            string query = $"select  COALESCE(SUM(price), 0) from ticket where MONTH(date) = {DateTime.Now.Month.ToString()}";

            SqlCommand command = new SqlCommand(query, _connect);

            SqlDataReader reader = command.ExecuteReader();


            double result = 0.0;
            while (reader.Read())
            {
                result = reader.GetDouble(0);
            }
            reader.Close();
            return result;
        }
    }
}
