
namespace Justec.Alcohol.Pulse
{
    partial class FrmUserManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserManage));
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cxType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtJobNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.userData = new CCWin.SkinControl.SkinGroupBox();
            this.dataGridPager1 = new Justec.Alcohol.Pulse.DataGridPager();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.panelDeptName = new System.Windows.Forms.Label();
            this.panelUserName = new System.Windows.Forms.Label();
            this.panelJobNumber = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvUser = new CCWin.SkinControl.SkinDataGridView();
            this.GID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JobNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEPTNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HasFingerFeature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HasFaceFeature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FaceFeature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skinPanel1.SuspendLayout();
            this.userData.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.SuspendLayout();
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.LightGray;
            this.skinPanel1.Controls.Add(this.btnAdd);
            this.skinPanel1.Controls.Add(this.btnReset);
            this.skinPanel1.Controls.Add(this.btnSearch);
            this.skinPanel1.Controls.Add(this.cxType);
            this.skinPanel1.Controls.Add(this.label5);
            this.skinPanel1.Controls.Add(this.textName);
            this.skinPanel1.Controls.Add(this.label2);
            this.skinPanel1.Controls.Add(this.txtJobNumber);
            this.skinPanel1.Controls.Add(this.label1);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(0, 0);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(1101, 61);
            this.skinPanel1.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(144)))), ((int)(((byte)(246)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(948, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 38);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(34)))), ((int)(((byte)(44)))));
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(817, 10);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 38);
            this.btnReset.TabIndex = 17;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(144)))), ((int)(((byte)(246)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(679, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 38);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cxType
            // 
            this.cxType.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cxType.FormattingEnabled = true;
            this.cxType.Items.AddRange(new object[] {
            "全部",
            "正常",
            "饮酒",
            "酗酒"});
            this.cxType.Location = new System.Drawing.Point(502, 10);
            this.cxType.Name = "cxType";
            this.cxType.Size = new System.Drawing.Size(160, 38);
            this.cxType.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label5.Location = new System.Drawing.Point(446, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "部门:";
            // 
            // textName
            // 
            this.textName.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textName.Location = new System.Drawing.Point(280, 10);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(160, 37);
            this.textName.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label2.Location = new System.Drawing.Point(224, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "姓名:";
            // 
            // txtJobNumber
            // 
            this.txtJobNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtJobNumber.Location = new System.Drawing.Point(58, 10);
            this.txtJobNumber.Name = "txtJobNumber";
            this.txtJobNumber.Size = new System.Drawing.Size(160, 37);
            this.txtJobNumber.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(5, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "工号:";
            // 
            // userData
            // 
            this.userData.BackColor = System.Drawing.Color.Transparent;
            this.userData.BorderColor = System.Drawing.Color.White;
            this.userData.Controls.Add(this.dataGridPager1);
            this.userData.Controls.Add(this.rightPanel);
            this.userData.Controls.Add(this.dgvUser);
            this.userData.ForeColor = System.Drawing.Color.Blue;
            this.userData.Location = new System.Drawing.Point(9, 65);
            this.userData.Name = "userData";
            this.userData.RectBackColor = System.Drawing.Color.White;
            this.userData.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.userData.Size = new System.Drawing.Size(1092, 510);
            this.userData.TabIndex = 1;
            this.userData.TabStop = false;
            this.userData.TitleBorderColor = System.Drawing.Color.White;
            this.userData.TitleRectBackColor = System.Drawing.Color.White;
            this.userData.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // dataGridPager1
            // 
            this.dataGridPager1.BackColor = System.Drawing.Color.MistyRose;
            this.dataGridPager1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridPager1.Location = new System.Drawing.Point(0, 469);
            this.dataGridPager1.Name = "dataGridPager1";
            this.dataGridPager1.PageCurrent = 1;
            this.dataGridPager1.PageSize = 10;
            this.dataGridPager1.Size = new System.Drawing.Size(1092, 37);
            this.dataGridPager1.TabIndex = 2;
            this.dataGridPager1.EventPaging += new Justec.Alcohol.Pulse.EventPagingHandler(this.dataGridPager1_EventPaging);
            this.dataGridPager1.BtnFirstClick += new Justec.Alcohol.Pulse.BtnClickHandler(this.dataGridPager1_BtnFirstClick);
            this.dataGridPager1.BtnNextClick += new Justec.Alcohol.Pulse.BtnClickHandler(this.dataGridPager1_BtnNextClick);
            this.dataGridPager1.BtnPreviousClick += new Justec.Alcohol.Pulse.BtnClickHandler(this.dataGridPager1_BtnPreviousClick);
            this.dataGridPager1.BtnLastClick += new Justec.Alcohol.Pulse.BtnClickHandler(this.dataGridPager1_BtnLastClick);
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.panelDeptName);
            this.rightPanel.Controls.Add(this.panelUserName);
            this.rightPanel.Controls.Add(this.panelJobNumber);
            this.rightPanel.Controls.Add(this.label7);
            this.rightPanel.Controls.Add(this.label6);
            this.rightPanel.Controls.Add(this.label4);
            this.rightPanel.Controls.Add(this.groupBox1);
            this.rightPanel.Controls.Add(this.label3);
            this.rightPanel.Location = new System.Drawing.Point(799, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(293, 469);
            this.rightPanel.TabIndex = 1;
            // 
            // panelDeptName
            // 
            this.panelDeptName.AutoSize = true;
            this.panelDeptName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.panelDeptName.Location = new System.Drawing.Point(93, 379);
            this.panelDeptName.Name = "panelDeptName";
            this.panelDeptName.Size = new System.Drawing.Size(59, 20);
            this.panelDeptName.TabIndex = 7;
            this.panelDeptName.Text = "Justec";
            // 
            // panelUserName
            // 
            this.panelUserName.AutoSize = true;
            this.panelUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.panelUserName.Location = new System.Drawing.Point(93, 329);
            this.panelUserName.Name = "panelUserName";
            this.panelUserName.Size = new System.Drawing.Size(54, 20);
            this.panelUserName.TabIndex = 6;
            this.panelUserName.Text = "admin";
            // 
            // panelJobNumber
            // 
            this.panelJobNumber.AutoSize = true;
            this.panelJobNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.panelJobNumber.Location = new System.Drawing.Point(93, 281);
            this.panelJobNumber.Name = "panelJobNumber";
            this.panelJobNumber.Size = new System.Drawing.Size(54, 20);
            this.panelJobNumber.TabIndex = 5;
            this.panelJobNumber.Text = "admin";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label7.Location = new System.Drawing.Point(32, 379);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "单位:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label6.Location = new System.Drawing.Point(32, 329);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "姓名:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label4.Location = new System.Drawing.Point(32, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "工号:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(55, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 173);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::Justec.Alcohol.Pulse.Properties.Resources.morentouxiang拷贝1;
            this.pictureBox1.Location = new System.Drawing.Point(7, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(172, 155);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label3.Location = new System.Drawing.Point(107, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "照片信息";
            // 
            // dgvUser
            // 
            this.dgvUser.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.dgvUser.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUser.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvUser.ColumnFont = null;
            this.dgvUser.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GID,
            this.UserName,
            this.JobNumber,
            this.DEPTNAME,
            this.HasFingerFeature,
            this.HasFaceFeature,
            this.FaceFeature});
            this.dgvUser.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUser.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUser.EnableHeadersVisualStyles = false;
            this.dgvUser.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvUser.HeadFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvUser.HeadSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvUser.Location = new System.Drawing.Point(0, 0);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvUser.RowHeadersWidth = 51;
            this.dgvUser.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvUser.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvUser.RowTemplate.Height = 23;
            this.dgvUser.Size = new System.Drawing.Size(792, 469);
            this.dgvUser.TabIndex = 0;
            this.dgvUser.TitleBack = null;
            this.dgvUser.TitleBackColorBegin = System.Drawing.Color.White;
            this.dgvUser.TitleBackColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(144)))), ((int)(((byte)(246)))));
            this.dgvUser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUser_CellClick);
            // 
            // GID
            // 
            this.GID.DataPropertyName = "GID";
            this.GID.HeaderText = "GID";
            this.GID.MinimumWidth = 6;
            this.GID.Name = "GID";
            this.GID.ReadOnly = true;
            this.GID.Visible = false;
            this.GID.Width = 125;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "姓名";
            this.UserName.MinimumWidth = 6;
            this.UserName.Name = "UserName";
            this.UserName.Width = 150;
            // 
            // JobNumber
            // 
            this.JobNumber.DataPropertyName = "JobNumber";
            this.JobNumber.HeaderText = "工号";
            this.JobNumber.MinimumWidth = 6;
            this.JobNumber.Name = "JobNumber";
            this.JobNumber.Width = 150;
            // 
            // DEPTNAME
            // 
            this.DEPTNAME.DataPropertyName = "DEPTNAME";
            this.DEPTNAME.HeaderText = "部门";
            this.DEPTNAME.MinimumWidth = 6;
            this.DEPTNAME.Name = "DEPTNAME";
            this.DEPTNAME.Width = 150;
            // 
            // HasFingerFeature
            // 
            this.HasFingerFeature.DataPropertyName = "HasFingerFeature";
            this.HasFingerFeature.HeaderText = "指纹特征数据";
            this.HasFingerFeature.MinimumWidth = 6;
            this.HasFingerFeature.Name = "HasFingerFeature";
            this.HasFingerFeature.Width = 150;
            // 
            // HasFaceFeature
            // 
            this.HasFaceFeature.DataPropertyName = "HasFaceFeature";
            this.HasFaceFeature.HeaderText = "人脸特征数据";
            this.HasFaceFeature.MinimumWidth = 6;
            this.HasFaceFeature.Name = "HasFaceFeature";
            this.HasFaceFeature.Width = 150;
            // 
            // FaceFeature
            // 
            this.FaceFeature.DataPropertyName = "FaceFeature";
            this.FaceFeature.HeaderText = "FaceFeature";
            this.FaceFeature.MinimumWidth = 6;
            this.FaceFeature.Name = "FaceFeature";
            this.FaceFeature.ReadOnly = true;
            this.FaceFeature.Visible = false;
            this.FaceFeature.Width = 125;
            // 
            // FrmUserManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1101, 572);
            this.Controls.Add(this.userData);
            this.Controls.Add(this.skinPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmUserManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "人员管理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmUserManage_FormClosed);
            this.Load += new System.EventHandler(this.FrmUserManage_Load);
            this.skinPanel1.ResumeLayout(false);
            this.skinPanel1.PerformLayout();
            this.userData.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinPanel skinPanel1;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtJobNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cxType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAdd;
        private CCWin.SkinControl.SkinGroupBox userData;
        private CCWin.SkinControl.SkinDataGridView dgvUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn GID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn JobNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPTNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn HasFingerFeature;
        private System.Windows.Forms.DataGridViewTextBoxColumn HasFaceFeature;
        private System.Windows.Forms.DataGridViewTextBoxColumn FaceFeature;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label panelDeptName;
        private System.Windows.Forms.Label panelUserName;
        private System.Windows.Forms.Label panelJobNumber;
        private DataGridPager dataGridPager1;
    }
}