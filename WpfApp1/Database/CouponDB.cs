using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Database
{
    class CouponDB
    {
        private Connection _dbInstance;
        private SqlConnection _connect;
        public CouponDB() {
            _dbInstance = Connection.Instance();
            _connect = _dbInstance.Connect;
        }
        
        // Output: true if add
        public bool AddBirthdayCouponIfNotExist(Account user) {
            var birthday = DateTime.Parse(user.Date);
            var curMonth = DateTime.Now.Month;
            
            if (birthday.Month != curMonth) return false;

            string query = $"SELECT * FROM BirthDateCouponCache WHERE UserId = {user.Id} AND Month = {curMonth}";
            SqlCommand command = new SqlCommand(query, _connect);
            SqlDataReader reader = command.ExecuteReader();
            bool gifted = reader.Read();
            reader.Close();
            if (!gifted) {
                var endOfMonth = new DateTime(
                    DateTime.Now.Year,
                    DateTime.Now.Month,
                    DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
                AddCoupon(new Coupon {
                    Name = "Birthday voucher",
                    Discount = 0.1,
                    Expire = endOfMonth,
                    UserId = user.Id,
                });

                command = new SqlCommand($"INSERT INTO BirthDateCouponCache(UserId, Month) VALUES({user.Id}, {curMonth})",
                                         _connect);
                command.ExecuteNonQuery();
            }
            return !gifted;
        }

        public void AddCoupon(Coupon cp) {
            var expire_str = cp.Expire.ToString("MM/dd/yyyy");
            string query = $@"
INSERT INTO Coupon(Expire, Name, UserId, Discount)
VALUES('{expire_str}', '{cp.Name}', {cp.UserId}, {cp.Discount})";
            SqlCommand command = new SqlCommand(query, _connect);
            command.ExecuteNonQuery();
        }

        // Output: usable coupons
        public List<Coupon> GetAvailableCoupons(int userId) {
            List<Coupon> result = new List<Coupon>();

            string query = @"SELECT * FROM Coupon WHERE Expire > GETDATE()";
            SqlCommand command = new SqlCommand(query, _connect);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                result.Add(new Coupon {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Expire = reader.GetDateTime(2),
                    UserId = reader.GetInt32(3),
                    Discount = reader.GetDouble(4),
                });
            }

            reader.Close();
            return result;
        }

        public void RemoveCoupon(int cpId) {
            string query = $"DELETE FROM Coupon WHERE Id = {cpId};";
            SqlCommand command = new SqlCommand(query, _connect);
            command.ExecuteNonQuery();
        }
    }
}
