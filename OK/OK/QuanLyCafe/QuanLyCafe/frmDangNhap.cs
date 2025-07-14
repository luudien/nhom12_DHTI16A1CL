using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class frmDangNhap: Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        public static string MatKhau;
        public static string MaNV;
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtMaDangNhap.Text))
            {
                MessageBox.Show("Chưa nhập thông tin mã đăng nhập");
                txtMaDangNhap.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Chưa nhập thông tin mật khẩu");
                txtMaDangNhap.Focus();
                return;
            }
            string strSQL = $@"SELECT * FROM NhanVien WHERE MaNV = '{txtMaDangNhap.Text}' AND MatKhau = '{txtMatKhau.Text}'";
            bool check = ConnectSQL.ExcuteReader_bool(strSQL);
            if(check)
            {
                MaNV = txtMaDangNhap.Text;
                MatKhau = txtMatKhau.Text;
                //frmManHinhChinh frm = new frmManHinhChinh();
                // frm.ShowDialog();
                this.Hide(); // Ẩn form đăng nhập
                frmManHinhChinh frm = new frmManHinhChinh();
                frm.Show(); // Mở form chính

            }
            else
            {
                MessageBox.Show("Sai thông tin mã đăng nhập hoặc mật khẩu");
                txtMaDangNhap.Focus();
                return;
            }    
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
