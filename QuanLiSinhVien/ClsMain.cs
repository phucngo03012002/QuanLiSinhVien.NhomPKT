using QuanLiSinhVien.BusinessLayer;
using QuanLiSinhVien.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiSinhVien
{
    internal class ClsMain
    {
        public static string taiKhoan = String.Empty;
        //Đường dẫn đến file users.ini
        public static string pathUser = string.Format(@"{0}\users.ini", Application.StartupPath);

        public static List<User> users = null;
    }
}
