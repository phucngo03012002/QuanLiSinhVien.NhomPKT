using System.Collections.Generic;

namespace QuanLiSinhVien.DataLayer
{
    public class UserDao
    {
        //Contructor - ham tao
        Database database;

        public UserDao(string path)
        {
            // TODO: Complete member initialization
            database = new Database(path);
        }


        //get data
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
        //Hàm lấy danh sách user từ file users.ini

        //trả về ds user kiểu list
        public List<User> GetUsers()
        {
            return database.ReadUserFromFileINI();
        }

        public string path { get; set; }
    }
}
