using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiSinhVien.DataLayer
{
    internal class UserDao
    {
        Database database;
        public UserDao(string path)
        {
            database = new Database(path);
        }

        public bool KiemTraDangNhap(string taiKhoan, string matKhau)
        {
            bool result = false;
            List<User> users = database.ReadUserFromFileINI();
            foreach (User item in users)
            {
                if (item.TaiKhoan.Equals(taiKhoan) && item.MatKhau.Equals(matKhau))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public List<User> GetUsers()
        {
            return database.ReadUserFromFileINI();
        }

        public bool CapNhatDuLieu(string path, List<User> users)
        {
            return database.GhiFile(path, users);
        }
    }
}
