﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyCafe
{
    public partial class frmManHinhChinh: Form
    {
        public static string MaHDThanhToan;
        public static string TongTienThanhToan;
        public static string MaBanThanhToan;

        public frmManHinhChinh()
        {
            InitializeComponent();
            this.btnDX.Click += new System.EventHandler(this.btnDX_Click);

        }
        private void menuNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            frm.ShowDialog();
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuThongTinCaNhan_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau();
            frm.ShowDialog();
        }

        private void menuLDU_Click(object sender, EventArgs e)
        {
            frmLoaiDoUong frm = new frmLoaiDoUong();
            frm.ShowDialog();
        }

        private void menuBan_Click(object sender, EventArgs e)
        {
            frmBan frm = new frmBan();
            frm.ShowDialog();
        }

        private void menuDoUong_Click(object sender, EventArgs e)
        {
            frmDoUong frm = new frmDoUong();
            frm.ShowDialog();
        }

        private void menuKH_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.ShowDialog();
        }
        private void LoadTable()
        {
            lstBan.Clear();
            lstBan.View = View.LargeIcon;
            lstBan.LargeImageList = imageList1;

            string strSQL = "SELECT * FROM Ban";
            if(rbYes.Checked)
            {
                strSQL += " WHERE TrangThai = '1'";
            }    
            else if (rbNo.Checked)
            {
                strSQL += " WHERE TrangThai = '0'";
            }    
            DataTable dt = new DataTable();
            dt = ConnectSQL.Load(strSQL);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem item1 = new ListViewItem(dt.Rows[i]["MaBan"].ToString());
                if(dt.Rows[i]["TrangThai"].ToString() == "0")
                {
                    item1.ImageIndex = 1;
                }  
                else
                {
                    item1.ImageIndex = 0;
                }    
                lstBan.Items.Add(item1);
            }    
        }
        private void LoadMenuDoUong()
        {
            string strSQL = $@"SELECT MaDU,TenDU,MaLoai,DonGia FROM DoUong WHERE TenDU LIKE N'%{txtTenDoUong.Text}%'";
            DataTable dt = new DataTable();
            dt = ConnectSQL.Load(strSQL);
            dtgvDoUong.DataSource = dt;
            frmNhanVien.SetupDataGridView(dtgvDoUong);
            dtgvDoUong.Columns[0].HeaderText = "Mã đồ uống";
            dtgvDoUong.Columns[1].HeaderText = "Tên đồ uống";
            dtgvDoUong.Columns[2].HeaderText = "Mã loại";
            dtgvDoUong.Columns[3].HeaderText = "Đơn giá";
        }
        private void frmManHinhChinh_Load(object sender, EventArgs e)
        {
            LoadTable();
            LoadMenuDoUong();
        }

        private void rbYes_CheckedChanged(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void rbNo_CheckedChanged(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            LoadMenuDoUong();
        }

        private void lstBan_Click(object sender, EventArgs e)
        {
            btnBanDaChon.Text = lstBan.SelectedItems[0].SubItems[0].Text;
            LoadDoUongDaGoi();
        }
        private void LoadDoUongDaGoi()
        {
            string strSQL = $@"SELECT a.MaDU,c.TenDU,a.SoLuong,a.DonGia,a.ThanhTien,b.MaHD FROM ChiTietHoaDon a 
                                INNER JOIN HoaDon b ON a.MaHD = b.MaHD 
                                INNER JOIN DoUong c ON a.MaDU = c.MaDU 
                                INNER JOIN Ban d ON b.MaBan = d.MaBan 
                                WHERE b.MaBan = '{btnBanDaChon.Text}' AND b.Trangthai = 0
                                AND d.TrangThai = 1 AND b.MaBan = '{btnBanDaChon.Text}'";
            DataTable dt = new DataTable();
            dt = ConnectSQL.Load(strSQL);
            dtgvHoaDon.DataSource = dt;
            frmNhanVien.SetupDataGridView(dtgvHoaDon);
            dtgvHoaDon.Columns[0].HeaderText = "Mã đồ uống";
            dtgvHoaDon.Columns[1].HeaderText = "Tên đồ uống";
            dtgvHoaDon.Columns[2].HeaderText = "Số lượng";
            dtgvHoaDon.Columns[3].HeaderText = "Đơn giá";
            dtgvHoaDon.Columns[4].HeaderText = "Thành tiền";
            dtgvHoaDon.Columns[5].Visible = false;
            decimal total = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                total += Convert.ToDecimal(dt.Rows[i]["ThanhTien"].ToString());
            }
            lblTongTien.Text = total.ToString() + " VNĐ";
            TongTienThanhToan = total.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(btnBanDaChon.Text == "Chưa chọn bàn")
            {
                MessageBox.Show("Bạn hãy chọn bàn trước khi gọi món");
                return;
            }
            //Hóa đơn chưa có món nào cả, thì phải thêm dữ liệu vào bảng HoaDon trước, xong thêm vào bảng
            //Chi tiết hóa đơn
            string MaDU = dtgvDoUong.CurrentRow.Cells[0].Value.ToString().Trim();
            string DonGia = dtgvDoUong.CurrentRow.Cells[3].Value.ToString().Trim();
            if (dtgvHoaDon.Rows.Count == 0) 
            {      
                string MaHD = DateTime.Now.ToString("HDssmmhhddMMyyyy");
                //Thêm vào bảng hóa đơn
                string strSQL  = $@"INSERT INTO HoaDon(MaHD,NgayLap,MaNV,MaKH,MaBan,TongTien,TrangThai)
                                     VALUES ('{MaHD}',
                                            '{DateTime.Now.ToString("yyyyMMdd")}','{frmDangNhap.MaNV}',NULL,'{btnBanDaChon.Text}',0,0) ";
                //Thêm vào bảng chi tiết hóa đơn
                strSQL += $@" INSERT INTO ChiTietHoaDon(MaHD,MaDU,SoLuong,DonGia,ThanhTien)
                             VALUES('{MaHD}','{MaDU}',{nmSoLuong.Value},{DonGia},{nmSoLuong.Value * Convert.ToDecimal(DonGia)}) ";
                
                strSQL += $@" UPDATE Ban SET TrangThai = 1 WHERE MaBan = '{btnBanDaChon.Text}'";
                ConnectSQL.RunQuery(strSQL);
                LoadDoUongDaGoi();
                LoadTable();
                MessageBox.Show("Thêm thành công");
            }   
            //Hóa đơn đã có món rồi, muốn thêm món khác, tức là bảng hóa đơn đã có dữ liệu
            //Giờ chỉ thêm vào bảng chi tiết hóa đơn
            else
            {
                string MaHD = dtgvHoaDon.CurrentRow.Cells[5].Value.ToString().Trim();
                string strSQL = $@"SELECT * FROM ChiTietHoaDon WHERE MaHD = '{MaHD}' AND MaDU = '{MaDU}'";
                if(ConnectSQL.ExcuteReader_bool(strSQL))
                {
                    //Đã có rồi thì update số lượng
                    strSQL = $@"UPDATE ChiTietHoaDon SET SoLuong = SoLuong + {nmSoLuong.Value}
                                 , ThanhTien = (SoLuong + {nmSoLuong.Value}) * {DonGia} WHERE MaDU = '{MaDU}' AND MaHD = '{MaHD}'";
                }
                else
                {
                    //Thêm vào bảng chi tiết hóa đơn
                    strSQL = $@" INSERT INTO ChiTietHoaDon(MaHD,MaDU,SoLuong,DonGia,ThanhTien)
                             VALUES('{MaHD}','{MaDU}',{nmSoLuong.Value},{DonGia},{nmSoLuong.Value * Convert.ToDecimal(DonGia)}) ";
                }
                ConnectSQL.RunQuery(strSQL);
                LoadDoUongDaGoi();
                LoadTable();
                MessageBox.Show("Thêm thành công");
            }    
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtgvHoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu để xóa");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string MaHD = dtgvHoaDon.CurrentRow.Cells["MaHD"].Value.ToString().Trim();
                string MaDU = dtgvHoaDon.CurrentRow.Cells["MaDU"].Value.ToString().Trim();
                string strSQL = $@"DELETE ChiTietHoaDon WHERE MaDU = '{dtgvHoaDon.CurrentRow.Cells["MaDU"].Value.ToString().Trim()}'";
                ConnectSQL.RunQuery(strSQL);
                MessageBox.Show("Xóa thành công");
                LoadDoUongDaGoi();
                LoadTable();
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if(dtgvHoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có hóa đơn để thanh toán");
                return;
            }
            MaHDThanhToan = dtgvHoaDon.CurrentRow.Cells["MaHD"].Value.ToString().Trim();
            MaBanThanhToan = btnBanDaChon.Text;
            frmThanhToan frm = new frmThanhToan();
            frm.ShowDialog();
            LoadTable();
            LoadDoUongDaGoi();
        }
        private void btnDX_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide(); // Ẩn form chính
                frmDangNhap frm = new frmDangNhap(); // Mở lại form đăng nhập
                frm.Show(); // Không dùng ShowDialog nếu muốn quay lại

            }
        }


        private void menuDoanhThuNgay_Click(object sender, EventArgs e)
        {
            frmDoanhThuTheoNgay frm = new frmDoanhThuTheoNgay();
            frm.ShowDialog();
        }

        private void menuThongKeDoanhThuNV_Click(object sender, EventArgs e)
        {
            frmDoanhThuTheoNhanVien frm = new frmDoanhThuTheoNhanVien();
            frm.ShowDialog();
        }

        private void menuLichSuHoaDon_Click(object sender, EventArgs e)
        {
            frmLichSuHoaDon frm = new frmLichSuHoaDon();
            frm.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dtgvDoUong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
