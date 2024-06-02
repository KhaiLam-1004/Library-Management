using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if(instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public bool Login(string username, string password)
        {
            string query = "USP_Login @userName , @password";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] {username, password});

            return result.Rows.Count > 0;
        }

        public int GetRoleId(string username, string password)
        {
            string query = "SELECT RoleId FROM Account WHERE userName = @userName AND password = @password";
            object[] parameters = new object[] { username, password };
            object result = DataProvider.Instance.ExecuteScalar(query, parameters);

            if (result != null)
            {
                return Convert.ToInt32(result);
            }
            return 0; // Trả về 0 nếu không tìm thấy hoặc có lỗi
        }
    }
}
