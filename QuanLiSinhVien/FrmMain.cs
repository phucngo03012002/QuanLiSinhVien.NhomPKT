using QuanLiSinhVien.BusinessLayer;
using QuanLiSinhVien.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLiSinhVien
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        BLLUser bd;

        private void FrmMain_Load(object sender, EventArgs e)
        {
            bd = new BLLUser(ClsMain.pathUser);
            HienThiDanhSachUsers();
        }

        User user;
        int index = -1;

        private void dgvUsers_Click(object sender, EventArgs e)
        {
            if (dgvUsers.Rows.Count > 0)
            {
                user = new User()
                {
                    ID = Convert.ToInt32(dgvUsers.CurrentRow.Cells["colID"].Value.ToString()),
                    HoVaTen = dgvUsers.CurrentRow.Cells["colHoVaTen"].Value.ToString(),
                    TaiKhoan = dgvUsers.CurrentRow.Cells["colTaiKhoan"].Value.ToString(),
                    MatKhau = dgvUsers.CurrentRow.Cells["colMatKhau"].Value.ToString(),
                    NhoMatKhau = Convert.ToBoolean(dgvUsers.CurrentRow.Cells["colNhoMatKhau"].Value.ToString()),
                };
                index = dgvUsers.CurrentRow.Index;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Frm_QuanLyNguoiDung_Modified frm_QuanLyNguoiDung_Modified = new Frm_QuanLyNguoiDung_Modified();
            frm_QuanLyNguoiDung_Modified.isAdd = true;
            frm_QuanLyNguoiDung_Modified.ShowDialog();
            HienThiDanhSachUsers();
        }

        private void HienThiDanhSachUsers()
        {
            if (txtSearch.Text.Trim().Length > 0)
            {
                ClsMain.users = bd.GetUsers();
                var bindingList = new BindingList<User>(ClsMain.users.Where(m => m.HoVaTen.Contains(txtSearch.Text)==true).ToList());
                var source = new BindingSource(bindingList, null);
                dgvUsers.DataSource = source;

            }
            else
            {
                ClsMain.users = bd.GetUsers();
                var bindingList = new BindingList<User>(ClsMain.users);
                var source = new BindingSource(bindingList, null);
                dgvUsers.DataSource = source;
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            HienThiDanhSachUsers();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            HienThiDanhSachUsers();
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3) //edit
            {
                if (user != null)
                {
                    Frm_QuanLyNguoiDung_Modified frm_QuanLyNguoiDung_Modified = new Frm_QuanLyNguoiDung_Modified();
                    frm_QuanLyNguoiDung_Modified.isAdd = false;
                    frm_QuanLyNguoiDung_Modified.user = user;
                    frm_QuanLyNguoiDung_Modified.ShowDialog();
                    HienThiDanhSachUsers();
                    user = null;
                }
            }
            if (e.ColumnIndex == 4) //delete
            {
                if (user != null)
                {
                    if (MessageBox.Show("Bạn muốn xóa người dùng này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ClsMain.users.RemoveAt(index);
                        bd.CapNhatDuLieu(ClsMain.pathUser, ClsMain.users);
                        HienThiDanhSachUsers();
                    }    
                }
                else
                {
                    MessageBox.Show("Chưa chọn");
                }
            }
        }
    }
}
