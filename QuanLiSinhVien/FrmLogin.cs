using QuanLiSinhVien.BusinessLayer;
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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        public string ThongTin = string.Empty;
        BLLUser bl;
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //txtPassword.Text = "admin";
            //textUsername.Text = "admin";
            bl = new BLLUser(ClsMain.pathUser);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textUsername.Text))
            {
                if (!string.IsNullOrEmpty(txtPassword.Text))
                {
                    if (KiemTraDangNhap(textUsername.Text, txtPassword.Text))
                    {
                        trangThaiDongForm = true;
                        ClsMain.taiKhoan = txtUsername.Text;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu không đúng\n Xin vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textUsername.ResetText();
                        txtPassword.Text = string.Empty;
                        textUsername.Focus();
                    }
                }
              
                else
                {
                    MessageBox.Show("Chưa nhập mật khẩu\n Xin vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                }
            } 
            else
            {
                MessageBox.Show("Chưa nhập tài khoản\n Xin vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
            }
        }
        bool trangThaiDongForm = false;

        private bool KiemTraDangNhap(string taiKhoan, string matKhau)
        {
            return bl.KiemTraTaiKhoan(taiKhoan, matKhau);
        }
        private void btnExit_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Chương trình sẽ được thoát.\n Hãy xác định việc này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                //this.Close();
                trangThaiDongForm = true;
                Application.Exit();
            }
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (trangThaiDongForm == true)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '●';
        }
    }
}
