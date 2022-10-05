using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiSinhVien.DataLayer
{
    public class User
    {
        //field-Bien thanh vien
        private int iD;
        private string taiKhoan;
        private string matKhau;
        private string hoVaTen;

        public int ID { get { return iD; } set { iD = value; } }
        public string TaiKhoan { get { return taiKhoan; } set { taiKhoan = value; } }
        public string MatKhau { get { return matKhau; } set { matKhau = value; } }
        public string HoVaTen { get { return hoVaTen; } set { hoVaTen = value; } }

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3}", ID, TaiKhoan, MatKhau, HoVaTen);
        }

        public override bool Equals(object obj)
        {
            if (obj is User)
            {
                return ((User)obj).ID.ToString().Equals(this.ID.ToString());
            }
            return false;
        }

        public int CompareTo(object obj)
        {
            if (obj is User)
            {
                return ((User)obj).ID.CompareTo(this.ID);
            }
            return -1;
        }
    }
}
