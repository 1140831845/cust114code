namespace search
{
    partial class StartForm
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
            this.query = new System.Windows.Forms.RichTextBox();
            this.jiebaSegText = new System.Windows.Forms.RichTextBox();
            this.foolSegText = new System.Windows.Forms.RichTextBox();
            this.foolKeywordText = new System.Windows.Forms.RichTextBox();
            this.jiebaKeywordText = new System.Windows.Forms.RichTextBox();
            this.jiebaGridview = new System.Windows.Forms.DataGridView();
            this.foolGridview = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.playBtn = new System.Windows.Forms.Button();
            this.autoendBtn = new System.Windows.Forms.Button();
            this.successLabel = new System.Windows.Forms.CheckBox();
            this.unsuccessLabel = new System.Windows.Forms.CheckBox();
            this.reasonLabel = new System.Windows.Forms.Label();
            this.reasonText = new System.Windows.Forms.RichTextBox();
            this.callerLabel1 = new System.Windows.Forms.Label();
            this.QCellCoreLabel1 = new System.Windows.Forms.Label();
            this.durationLabel1 = new System.Windows.Forms.Label();
            this.callTimeLabel1 = new System.Windows.Forms.Label();
            this.callTimeLabel2 = new System.Windows.Forms.Label();
            this.callerLabel2 = new System.Windows.Forms.Label();
            this.durationLabel2 = new System.Windows.Forms.Label();
            this.QCellCoreLabel2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.QAGridView = new System.Windows.Forms.DataGridView();
            this.manualTransfer = new System.Windows.Forms.Button();
            this.autoTransfer = new System.Windows.Forms.Button();
            this.unclearLabel = new System.Windows.Forms.CheckBox();
            this.clearLabel = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.jiebaGridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.foolGridview)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QAGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // query
            // 
            this.query.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.query.Location = new System.Drawing.Point(668, 56);
            this.query.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.query.Name = "query";
            this.query.Size = new System.Drawing.Size(600, 66);
            this.query.TabIndex = 0;
            this.query.Text = "";
            // 
            // jiebaSegText
            // 
            this.jiebaSegText.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.jiebaSegText.Location = new System.Drawing.Point(668, 171);
            this.jiebaSegText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.jiebaSegText.Name = "jiebaSegText";
            this.jiebaSegText.Size = new System.Drawing.Size(275, 78);
            this.jiebaSegText.TabIndex = 1;
            this.jiebaSegText.Text = "";
            // 
            // foolSegText
            // 
            this.foolSegText.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.foolSegText.Location = new System.Drawing.Point(995, 171);
            this.foolSegText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.foolSegText.Name = "foolSegText";
            this.foolSegText.Size = new System.Drawing.Size(272, 78);
            this.foolSegText.TabIndex = 2;
            this.foolSegText.Text = "";
            // 
            // foolKeywordText
            // 
            this.foolKeywordText.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.foolKeywordText.Location = new System.Drawing.Point(995, 305);
            this.foolKeywordText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.foolKeywordText.Name = "foolKeywordText";
            this.foolKeywordText.Size = new System.Drawing.Size(272, 82);
            this.foolKeywordText.TabIndex = 4;
            this.foolKeywordText.Text = "";
            // 
            // jiebaKeywordText
            // 
            this.jiebaKeywordText.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.jiebaKeywordText.Location = new System.Drawing.Point(668, 305);
            this.jiebaKeywordText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.jiebaKeywordText.Name = "jiebaKeywordText";
            this.jiebaKeywordText.Size = new System.Drawing.Size(275, 82);
            this.jiebaKeywordText.TabIndex = 3;
            this.jiebaKeywordText.Text = "";
            // 
            // jiebaGridview
            // 
            this.jiebaGridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jiebaGridview.Location = new System.Drawing.Point(668, 448);
            this.jiebaGridview.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.jiebaGridview.Name = "jiebaGridview";
            this.jiebaGridview.RowHeadersWidth = 55;
            this.jiebaGridview.RowTemplate.Height = 27;
            this.jiebaGridview.Size = new System.Drawing.Size(274, 273);
            this.jiebaGridview.TabIndex = 10;
            this.jiebaGridview.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.jiebaGridview_RowStateChanged);
            // 
            // foolGridview
            // 
            this.foolGridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.foolGridview.Location = new System.Drawing.Point(995, 448);
            this.foolGridview.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.foolGridview.Name = "foolGridview";
            this.foolGridview.RowHeadersWidth = 55;
            this.foolGridview.RowTemplate.Height = 27;
            this.foolGridview.Size = new System.Drawing.Size(272, 273);
            this.foolGridview.TabIndex = 11;
            this.foolGridview.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.foolGridview_RowStateChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(665, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "查询：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(992, 134);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "fool   分词：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(665, 134);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "jieba   分词：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(665, 268);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "jieba 关键词：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(992, 268);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "fool 关键词：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(665, 406);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "jieba   结果：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(992, 406);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "fool   结果：";
            // 
            // playBtn
            // 
            this.playBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F);
            this.playBtn.Location = new System.Drawing.Point(35, 134);
            this.playBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(557, 37);
            this.playBtn.TabIndex = 20;
            this.playBtn.Text = "播放器";
            this.playBtn.UseVisualStyleBackColor = true;
            // 
            // autoendBtn
            // 
            this.autoendBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F);
            this.autoendBtn.Location = new System.Drawing.Point(35, 746);
            this.autoendBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.autoendBtn.Name = "autoendBtn";
            this.autoendBtn.Size = new System.Drawing.Size(165, 43);
            this.autoendBtn.TabIndex = 21;
            this.autoendBtn.Text = "自动结束";
            this.autoendBtn.UseVisualStyleBackColor = true;
            this.autoendBtn.Click += new System.EventHandler(this.queryBtn_Click);
            // 
            // successLabel
            // 
            this.successLabel.AutoSize = true;
            this.successLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F);
            this.successLabel.Location = new System.Drawing.Point(668, 746);
            this.successLabel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.successLabel.Name = "successLabel";
            this.successLabel.Size = new System.Drawing.Size(56, 24);
            this.successLabel.TabIndex = 23;
            this.successLabel.Text = "成功";
            this.successLabel.UseVisualStyleBackColor = true;
            // 
            // unsuccessLabel
            // 
            this.unsuccessLabel.AutoSize = true;
            this.unsuccessLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F);
            this.unsuccessLabel.Location = new System.Drawing.Point(748, 746);
            this.unsuccessLabel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.unsuccessLabel.Name = "unsuccessLabel";
            this.unsuccessLabel.Size = new System.Drawing.Size(70, 24);
            this.unsuccessLabel.TabIndex = 24;
            this.unsuccessLabel.Text = "不成功";
            this.unsuccessLabel.UseVisualStyleBackColor = true;
            // 
            // reasonLabel
            // 
            this.reasonLabel.AutoSize = true;
            this.reasonLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.reasonLabel.Location = new System.Drawing.Point(665, 786);
            this.reasonLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.reasonLabel.Name = "reasonLabel";
            this.reasonLabel.Size = new System.Drawing.Size(65, 20);
            this.reasonLabel.TabIndex = 26;
            this.reasonLabel.Text = "原因分析";
            // 
            // reasonText
            // 
            this.reasonText.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.reasonText.Location = new System.Drawing.Point(668, 816);
            this.reasonText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.reasonText.Name = "reasonText";
            this.reasonText.Size = new System.Drawing.Size(600, 91);
            this.reasonText.TabIndex = 25;
            this.reasonText.Text = "";
            // 
            // callerLabel1
            // 
            this.callerLabel1.AutoSize = true;
            this.callerLabel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.callerLabel1.Location = new System.Drawing.Point(32, 54);
            this.callerLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.callerLabel1.Name = "callerLabel1";
            this.callerLabel1.Size = new System.Drawing.Size(79, 20);
            this.callerLabel1.TabIndex = 27;
            this.callerLabel1.Text = "来电号码：";
            // 
            // QCellCoreLabel1
            // 
            this.QCellCoreLabel1.AutoSize = true;
            this.QCellCoreLabel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QCellCoreLabel1.Location = new System.Drawing.Point(352, 54);
            this.QCellCoreLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.QCellCoreLabel1.Name = "QCellCoreLabel1";
            this.QCellCoreLabel1.Size = new System.Drawing.Size(65, 20);
            this.QCellCoreLabel1.TabIndex = 28;
            this.QCellCoreLabel1.Text = "归属地：";
            // 
            // durationLabel1
            // 
            this.durationLabel1.AutoSize = true;
            this.durationLabel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.durationLabel1.Location = new System.Drawing.Point(339, 102);
            this.durationLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.durationLabel1.Name = "durationLabel1";
            this.durationLabel1.Size = new System.Drawing.Size(79, 20);
            this.durationLabel1.TabIndex = 30;
            this.durationLabel1.Text = "通话时长：";
            // 
            // callTimeLabel1
            // 
            this.callTimeLabel1.AutoSize = true;
            this.callTimeLabel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.callTimeLabel1.Location = new System.Drawing.Point(32, 102);
            this.callTimeLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.callTimeLabel1.Name = "callTimeLabel1";
            this.callTimeLabel1.Size = new System.Drawing.Size(79, 20);
            this.callTimeLabel1.TabIndex = 29;
            this.callTimeLabel1.Text = "呼入时间：";
            // 
            // callTimeLabel2
            // 
            this.callTimeLabel2.AutoSize = true;
            this.callTimeLabel2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.callTimeLabel2.Location = new System.Drawing.Point(108, 102);
            this.callTimeLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.callTimeLabel2.Name = "callTimeLabel2";
            this.callTimeLabel2.Size = new System.Drawing.Size(0, 20);
            this.callTimeLabel2.TabIndex = 32;
            // 
            // callerLabel2
            // 
            this.callerLabel2.AutoSize = true;
            this.callerLabel2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.callerLabel2.Location = new System.Drawing.Point(108, 54);
            this.callerLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.callerLabel2.Name = "callerLabel2";
            this.callerLabel2.Size = new System.Drawing.Size(0, 20);
            this.callerLabel2.TabIndex = 31;
            // 
            // durationLabel2
            // 
            this.durationLabel2.AutoSize = true;
            this.durationLabel2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.durationLabel2.Location = new System.Drawing.Point(415, 102);
            this.durationLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.durationLabel2.Name = "durationLabel2";
            this.durationLabel2.Size = new System.Drawing.Size(0, 20);
            this.durationLabel2.TabIndex = 34;
            // 
            // QCellCoreLabel2
            // 
            this.QCellCoreLabel2.AutoSize = true;
            this.QCellCoreLabel2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QCellCoreLabel2.Location = new System.Drawing.Point(415, 54);
            this.QCellCoreLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.QCellCoreLabel2.Name = "QCellCoreLabel2";
            this.QCellCoreLabel2.Size = new System.Drawing.Size(0, 20);
            this.QCellCoreLabel2.TabIndex = 33;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.QAGridView);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F);
            this.groupBox1.Location = new System.Drawing.Point(35, 196);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(557, 525);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "历史信息";
            // 
            // QAGridView
            // 
            this.QAGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.QAGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.QAGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.QAGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QAGridView.Location = new System.Drawing.Point(2, 20);
            this.QAGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.QAGridView.Name = "QAGridView";
            this.QAGridView.RowHeadersWidth = 55;
            this.QAGridView.RowTemplate.Height = 27;
            this.QAGridView.Size = new System.Drawing.Size(553, 503);
            this.QAGridView.TabIndex = 38;
            this.QAGridView.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.QAGridView_RowStateChanged);
            // 
            // manualTransfer
            // 
            this.manualTransfer.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F);
            this.manualTransfer.Location = new System.Drawing.Point(428, 746);
            this.manualTransfer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.manualTransfer.Name = "manualTransfer";
            this.manualTransfer.Size = new System.Drawing.Size(165, 43);
            this.manualTransfer.TabIndex = 36;
            this.manualTransfer.Text = "自动转人工";
            this.manualTransfer.UseVisualStyleBackColor = true;
            this.manualTransfer.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // autoTransfer
            // 
            this.autoTransfer.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F);
            this.autoTransfer.Location = new System.Drawing.Point(230, 746);
            this.autoTransfer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.autoTransfer.Name = "autoTransfer";
            this.autoTransfer.Size = new System.Drawing.Size(165, 43);
            this.autoTransfer.TabIndex = 37;
            this.autoTransfer.Text = "手动转人工";
            this.autoTransfer.UseVisualStyleBackColor = true;
            this.autoTransfer.Click += new System.EventHandler(this.autoTransfer_Click);
            // 
            // unclearLabel
            // 
            this.unclearLabel.AutoSize = true;
            this.unclearLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F);
            this.unclearLabel.Location = new System.Drawing.Point(35, 858);
            this.unclearLabel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.unclearLabel.Name = "unclearLabel";
            this.unclearLabel.Size = new System.Drawing.Size(98, 24);
            this.unclearLabel.TabIndex = 39;
            this.unclearLabel.Text = "意图不明确";
            this.unclearLabel.UseVisualStyleBackColor = true;
            // 
            // clearLabel
            // 
            this.clearLabel.AutoSize = true;
            this.clearLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F);
            this.clearLabel.Location = new System.Drawing.Point(38, 816);
            this.clearLabel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clearLabel.Name = "clearLabel";
            this.clearLabel.Size = new System.Drawing.Size(98, 24);
            this.clearLabel.TabIndex = 38;
            this.clearLabel.Text = "明确查电话";
            this.clearLabel.UseVisualStyleBackColor = true;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1304, 849);
            this.Controls.Add(this.unclearLabel);
            this.Controls.Add(this.clearLabel);
            this.Controls.Add(this.autoTransfer);
            this.Controls.Add(this.manualTransfer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.durationLabel2);
            this.Controls.Add(this.QCellCoreLabel2);
            this.Controls.Add(this.callTimeLabel2);
            this.Controls.Add(this.callerLabel2);
            this.Controls.Add(this.durationLabel1);
            this.Controls.Add(this.callTimeLabel1);
            this.Controls.Add(this.QCellCoreLabel1);
            this.Controls.Add(this.callerLabel1);
            this.Controls.Add(this.reasonLabel);
            this.Controls.Add(this.reasonText);
            this.Controls.Add(this.unsuccessLabel);
            this.Controls.Add(this.successLabel);
            this.Controls.Add(this.autoendBtn);
            this.Controls.Add(this.playBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.foolGridview);
            this.Controls.Add(this.jiebaGridview);
            this.Controls.Add(this.foolKeywordText);
            this.Controls.Add(this.jiebaKeywordText);
            this.Controls.Add(this.foolSegText);
            this.Controls.Add(this.jiebaSegText);
            this.Controls.Add(this.query);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "114查询";
            this.Load += new System.EventHandler(this.StartForm_Load);
            this.SizeChanged += new System.EventHandler(this.StartForm_SizeChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartForm_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.jiebaGridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.foolGridview)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.QAGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox query;
        private System.Windows.Forms.RichTextBox jiebaSegText;
        private System.Windows.Forms.RichTextBox foolSegText;
        private System.Windows.Forms.RichTextBox foolKeywordText;
        private System.Windows.Forms.RichTextBox jiebaKeywordText;
        private System.Windows.Forms.DataGridView jiebaGridview;
        private System.Windows.Forms.DataGridView foolGridview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Button autoendBtn;
        private System.Windows.Forms.CheckBox successLabel;
        private System.Windows.Forms.CheckBox unsuccessLabel;
        private System.Windows.Forms.Label reasonLabel;
        private System.Windows.Forms.RichTextBox reasonText;
        private System.Windows.Forms.Label callerLabel1;
        private System.Windows.Forms.Label QCellCoreLabel1;
        private System.Windows.Forms.Label durationLabel1;
        private System.Windows.Forms.Label callTimeLabel1;
        private System.Windows.Forms.Label callTimeLabel2;
        private System.Windows.Forms.Label callerLabel2;
        private System.Windows.Forms.Label durationLabel2;
        private System.Windows.Forms.Label QCellCoreLabel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button manualTransfer;
        private System.Windows.Forms.Button autoTransfer;
        private System.Windows.Forms.DataGridView QAGridView;
        private System.Windows.Forms.CheckBox unclearLabel;
        private System.Windows.Forms.CheckBox clearLabel;
    }
}

