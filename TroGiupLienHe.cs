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
    public partial class TroGiupLienHe : Form
    {
        public TroGiupLienHe()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void TroGiupLienHe_Load(object sender, EventArgs e)
        {

        }

        private void btnCauHoiThuongGap_Click(object sender, EventArgs e)
        {
            // Cập nhật trạng thái chọn
            btnPhanHoiHoTro.BackColor = Color.DarkKhaki;
            btnCauHoiThuongGap.BackColor = SystemColors.Control;

            // Hiển thị nội dung phản hồi
            MessageBox.Show("Đang hiển thị nội dung: Phản hồi và Hỗ trợ.");
        }

        private void btnPhanHoiHoTro_Click(object sender, EventArgs e)
        {
            // Đổi màu để thể hiện đang được chọn
            btnPhanHoiHoTro.BackColor = Color.DarkKhaki;
            btnCauHoiThuongGap.BackColor = SystemColors.Control;

            // Hiển thị nội dung tab hỗ trợ
            MessageBox.Show("Đang hiển thị nội dung Phản hồi và Hỗ trợ.");
        }

        private void btnTongDai_Click(object sender, EventArgs e)
        {
            // Hiển thị thông tin tổng đài
            DialogResult result = MessageBox.Show(
                "Gọi tổng đài: (028) 7300 1009\nBạn có muốn gọi ngay không?",
                "Tổng đài hỗ trợ",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Trên Windows, không thể thực hiện gọi điện trực tiếp, nhưng bạn có thể mở Skype nếu cài:
                System.Diagnostics.Process.Start("https://web.skype.com/");

                // Hoặc chỉ mở link tel: nếu có ứng dụng mặc định
                // System.Diagnostics.Process.Start("tel:02873001009");
            }
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            try
            {
                // Mở ứng dụng email mặc định với địa chỉ sẵn
                string mailto = "mailto:cs@katinat.vn?subject=HoTroKhachHang&body=Toi%20can%20duoc%20tu%20van";
                System.Diagnostics.Process.Start(mailto);
            }
            catch (Exception ex)
            {
                // Nếu không mở được, hiển thị thông báo
                MessageBox.Show("Không thể mở trình gửi email. Vui lòng liên hệ: cs@katinat.vn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnWebsite_Click(object sender, EventArgs e)
        {
            try
            {
                // Mở website bằng trình duyệt mặc định
                System.Diagnostics.Process.Start("http://katinat.vn/");
            }
            catch (Exception ex)
            {
                // Nếu lỗi, hiện thông báo
                MessageBox.Show("Không thể mở trình duyệt. Vui lòng truy cập: http://katinat.vn/",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFacebook_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://facebook.com/katinat.vn");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở Facebook. Bạn có thể truy cập: https://facebook.com/katinat.vn",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPhanHoiVaHoTro_Click(object sender, EventArgs e)
        {
            Form formPhanHoi = new Form();
            formPhanHoi.Text = "Gửi phản hồi và hỗ trợ";
            formPhanHoi.Size = new Size(400, 300);
            formPhanHoi.StartPosition = FormStartPosition.CenterParent;
            formPhanHoi.FormBorderStyle = FormBorderStyle.FixedDialog;

            Label lbl = new Label()
            {
                Text = "Vui lòng nhập phản hồi hoặc yêu cầu hỗ trợ:",
                Location = new Point(20, 20),
                AutoSize = true
            };

            TextBox txt = new TextBox()
            {
                Multiline = true,
                Location = new Point(20, 50),
                Size = new Size(340, 150)
            };

            Button btnGui = new Button()
            {
                Text = "Gửi",
                Location = new Point(100, 220),
                Width = 80
            };

            Button btnHuy = new Button()
            {
                Text = "Hủy",
                Location = new Point(200, 220),
                Width = 80
            };

            btnGui.Click += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    MessageBox.Show("Bạn chưa nhập nội dung phản hồi!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("Cảm ơn bạn đã phản hồi. Chúng tôi sẽ liên hệ lại sớm nhất!",
                                "Đã gửi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                formPhanHoi.Close();
            };

            btnHuy.Click += (s, ev) => formPhanHoi.Close();

            formPhanHoi.Controls.Add(lbl);
            formPhanHoi.Controls.Add(txt);
            formPhanHoi.Controls.Add(btnGui);
            formPhanHoi.Controls.Add(btnHuy);

            formPhanHoi.ShowDialog();
        }
    }
}
