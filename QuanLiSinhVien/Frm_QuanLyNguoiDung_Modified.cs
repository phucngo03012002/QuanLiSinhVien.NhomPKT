using QuanLiSinhVien.BusinessLayer;
using QuanLiSinhVien.DataLayer;
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
    public partial class Frm_QuanLyNguoiDung_Modified : Form
    {
        public Frm_QuanLyNguoiDung_Modified()
        {
            InitializeComponent();
        }

        BLLUser bd;
        public User user = null;
        public bool isAdd = false;
        private void Frm_QuanLyNguoiDung_Modified_Load(object sender, EventArgs e)
        {
            bd = new BLLUser(ClsMain.pathUser);
            if (isAdd == true)
            {
                lblTitle.Text = "Thêm người dùng";
                btnCapNhat.Text = "Thêm";
                txtID.Text = TangIDTuDong().ToString();
                txtID.Enabled = false;
            }
            else
            {
                lblTitle.Text = "Cập nhật thông tin";
                btnCapNhat.Text = "Cập nhật";
                txtID.Text = user.ID.ToString();
                txtID.Enabled = false;
                txtTaiKhoan.Text = user.TaiKhoan;
                txtMatKhau.Text = user.MatKhau;
                txtHoVaTen.Text = user.HoVaTen;
                ckbNhoMatKhau.Checked = user.NhoMatKhau;
            }
        }
        private int TangIDTuDong()
        {
            int maxID = 0;
            foreach (User item in ClsMain.users)
            {
                if (item.ID >= maxID)
                    maxID = item.ID;
            }
            return maxID + 1;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            //kiem tra du lieu
            if (!string.IsNullOrEmpty(txtID.Text))
            {
                if (!string.IsNullOrEmpty(txtHoVaTen.Text))
                {
                    if (!string.IsNullOrEmpty(txtTaiKhoan.Text))
                    {
                        if (!string.IsNullOrEmpty(txtMatKhau.Text))
                        {
                            user = new User()
                            {
                                ID = Convert.ToInt32(txtID.Text),
                                HoVaTen = txtHoVaTen.Text,
                                TaiKhoan = txtTaiKhoan.Text,
                                MatKhau = txtMatKhau.Text,
                                NhoMatKhau = ckbNhoMatKhau.Checked
                            };
                            if (isAdd)
                            {
                                ClsMain.users.Add(user);
                            }
                            else
                            {
                                foreach (User item in ClsMain.users)
                                {
                                    if (item.ID == user.ID)
                                    {
                                        item.ID = user.ID;
                                        item.HoVaTen = user.HoVaTen;
                                        item.TaiKhoan = user.TaiKhoan;
                                        item.MatKhau = user.MatKhau;
                                        item.NhoMatKhau = user.NhoMatKhau;
                                    }
                                }
                            }
                            //Ghi file
                            if (bd.CapNhatDuLieu(ClsMain.pathUser, ClsMain.users))
                            {
                                if (MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                                {
                                    this.Close();
                                }
                            }
                            else
                            {
                                MessageBox.Show("cập nhật không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Chưa nhập Mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtMatKhau.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chưa nhập tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTaiKhoan.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi ID", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTaiKhoan.Focus();
                }
            }
            else
            {
                MessageBox.Show("Chưa nhập họ và tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoVaTen.Focus();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
