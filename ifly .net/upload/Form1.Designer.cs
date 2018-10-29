namespace upload
{
    partial class form
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.gridview = new System.Windows.Forms.DataGridView();
            this.title = new System.Windows.Forms.ComboBox();
            this.searchText = new System.Windows.Forms.TextBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.searchLabel = new System.Windows.Forms.Label();
            this.uploadBtn = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLable = new System.Windows.Forms.ToolStripStatusLabel();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.uploadLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridview)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridview
            // 
            this.gridview.Location = new System.Drawing.Point(12, 135);
            this.gridview.Name = "gridview";
            this.gridview.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.gridview.RowTemplate.Height = 27;
            this.gridview.Size = new System.Drawing.Size(647, 586);
            this.gridview.TabIndex = 0;
            this.gridview.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridview_CellValueChanged);
            this.gridview.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridview_RowStateChanged);
            // 
            // title
            // 
            this.title.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.title.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F);
            this.title.FormattingEnabled = true;
            this.title.Location = new System.Drawing.Point(82, 16);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(290, 31);
            this.title.TabIndex = 1;
            this.title.SelectedIndexChanged += new System.EventHandler(this.title_SelectedIndexChanged);
            // 
            // searchText
            // 
            this.searchText.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.searchText.Location = new System.Drawing.Point(82, 83);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(290, 29);
            this.searchText.TabIndex = 2;
            // 
            // searchBtn
            // 
            this.searchBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F);
            this.searchBtn.Location = new System.Drawing.Point(399, 83);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(114, 31);
            this.searchBtn.TabIndex = 3;
            this.searchBtn.Text = "搜索";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.searchLabel.Location = new System.Drawing.Point(12, 84);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(61, 24);
            this.searchLabel.TabIndex = 4;
            this.searchLabel.Text = "查询：";
            // 
            // uploadBtn
            // 
            this.uploadBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F);
            this.uploadBtn.Location = new System.Drawing.Point(399, 14);
            this.uploadBtn.Name = "uploadBtn";
            this.uploadBtn.Size = new System.Drawing.Size(114, 31);
            this.uploadBtn.TabIndex = 5;
            this.uploadBtn.Text = "上传";
            this.uploadBtn.UseVisualStyleBackColor = true;
            this.uploadBtn.Click += new System.EventHandler(this.uploadBtn_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLable});
            this.statusStrip1.Location = new System.Drawing.Point(0, 722);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(679, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLable
            // 
            this.statusLable.Name = "statusLable";
            this.statusLable.Size = new System.Drawing.Size(0, 17);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F);
            this.deleteBtn.Location = new System.Drawing.Point(545, 12);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(114, 31);
            this.deleteBtn.TabIndex = 7;
            this.deleteBtn.Text = "删除选中";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F);
            this.addBtn.Location = new System.Drawing.Point(545, 84);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(114, 31);
            this.addBtn.TabIndex = 8;
            this.addBtn.Text = "添加";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // uploadLabel
            // 
            this.uploadLabel.AutoSize = true;
            this.uploadLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uploadLabel.Location = new System.Drawing.Point(12, 19);
            this.uploadLabel.Name = "uploadLabel";
            this.uploadLabel.Size = new System.Drawing.Size(61, 24);
            this.uploadLabel.TabIndex = 9;
            this.uploadLabel.Text = "上传：";
            // 
            // form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 744);
            this.Controls.Add(this.uploadLabel);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.uploadBtn);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.searchText);
            this.Controls.Add(this.title);
            this.Controls.Add(this.gridview);
            this.Name = "form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件上传";
            ((System.ComponentModel.ISupportInitialize)(this.gridview)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridview;
        private System.Windows.Forms.ComboBox title;
        private System.Windows.Forms.TextBox searchText;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.Button uploadBtn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLable;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Label uploadLabel;
    }
}

