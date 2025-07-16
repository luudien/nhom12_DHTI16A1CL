namespace QuanLyCafe
{
    partial class frmLichSuHoaDon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtDTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtDFrom = new System.Windows.Forms.DateTimePicker();
            this.dtgvHD = new System.Windows.Forms.DataGridView();
            this.dtgvCTHD = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCTHD)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(896, 15);
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(195, 37);
            this.btnThanhToan.TabIndex = 579;
            this.btnThanhToan.Text = "Lọc dữ liệu";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(512, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 21);
            this.label2.TabIndex = 578;
            this.label2.Text = "Đến ngày";
            // 
            // dtDTo
            // 
            this.dtDTo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDTo.Location = new System.Drawing.Point(611, 18);
            this.dtDTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtDTo.Name = "dtDTo";
            this.dtDTo.Size = new System.Drawing.Size(237, 27);
            this.dtDTo.TabIndex = 577;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(127, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 21);
            this.label1.TabIndex = 576;
            this.label1.Text = "Từ ngày";
            // 
            // dtDFrom
            // 
            this.dtDFrom.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDFrom.Location = new System.Drawing.Point(211, 18);
            this.dtDFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtDFrom.Name = "dtDFrom";
            this.dtDFrom.Size = new System.Drawing.Size(221, 27);
            this.dtDFrom.TabIndex = 575;
            // 
            // dtgvHD
            // 
            this.dtgvHD.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtgvHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvHD.Location = new System.Drawing.Point(16, 82);
            this.dtgvHD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtgvHD.Name = "dtgvHD";
            this.dtgvHD.RowHeadersWidth = 51;
            this.dtgvHD.Size = new System.Drawing.Size(1172, 343);
            this.dtgvHD.TabIndex = 580;
            this.dtgvHD.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvHD_CellClick);
            // 
            // dtgvCTHD
            // 
            this.dtgvCTHD.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtgvCTHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvCTHD.Location = new System.Drawing.Point(16, 453);
            this.dtgvCTHD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtgvCTHD.Name = "dtgvCTHD";
            this.dtgvCTHD.RowHeadersWidth = 51;
            this.dtgvCTHD.Size = new System.Drawing.Size(1172, 358);
            this.dtgvCTHD.TabIndex = 581;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 21);
            this.label3.TabIndex = 582;
            this.label3.Text = "Danh sách hóa đơn";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 430);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(209, 21);
            this.label4.TabIndex = 583;
            this.label4.Text = "Danh sách chi tiết hóa đơn";
            // 
            // frmLichSuHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1204, 826);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtgvCTHD);
            this.Controls.Add(this.dtgvHD);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtDTo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtDFrom);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmLichSuHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lịch sử hóa đơn";
            this.Load += new System.EventHandler(this.frmLichSuHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCTHD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtDTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtDFrom;
        private System.Windows.Forms.DataGridView dtgvHD;
        private System.Windows.Forms.DataGridView dtgvCTHD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}