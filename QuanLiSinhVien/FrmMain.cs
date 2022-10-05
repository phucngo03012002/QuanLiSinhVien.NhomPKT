using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiSinhVien
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            HienThiFormLogin();
        }

        private void HienThiFormLogin()
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ThongTin = "Đăng nhập";
            frmLogin.ShowDialog();//HIển thị form theo dạng Dialog
            //lblThoiGian.Text = DateTime.Now.ToString();
            //tmrGioHeThong.Start();
            //lblThongTinDangNhap.Text = string.Format("Hệ thống được đăng nhập bởi: {0}", ClsMain.taiKhoan);
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            HienThiFormLogin();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
