using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;
using WpfApp1.ViewModel;

namespace WpfApp1.Database
{
    class MovieScheduleDB {
        private Connection _dbInstance;
        private SqlConnection _connect;
        public MovieScheduleDB() {
            _dbInstance = Connection.Instance();
            _connect = _dbInstance.Connect;
        }

        public List<MovieSchedule> GetSchedules(int movieId) {
            List<MovieSchedule> schedules = new List<MovieSchedule>();

            string query = $"SELECT * FROM MovieSchedule WHERE IdMovie = {movieId}";
            SqlCommand command = new SqlCommand(query, _connect);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                schedules.Add(new MovieSchedule {
                    Id = reader.GetInt32(0),
                    IdSchedule = reader.GetInt32(1),
                    IdMovie = reader.GetInt32(2),
                    Date = reader.GetDateTime(3),
                });
            }
            reader.Close();

            return schedules;
        }

        public List<Schedule> GetAllTimes(int movieId, DateTime date) {
            List<Schedule> times = new List<Schedule>();

            string query = "SELECT Schedule.* FROM MovieSchedule JOIN Schedule ON IdSchedule = Schedule.Id " +
                           $"WHERE IdMovie = {movieId} AND Date = '{date.ToString("MM/dd/yyyy")}'";
            SqlCommand command = new SqlCommand(query, _connect);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                int id = reader.GetInt32(0);
                string time = reader.GetString(1);
                times.Add(new Schedule(id, time));
            }
            reader.Close();

            return times;
        }
    }
}
