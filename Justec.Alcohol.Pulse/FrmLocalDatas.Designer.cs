
namespace Justec.Alcohol.Pulse
{
    partial class FrmLocalDatas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLocalDatas));
            this.topPanel = new System.Windows.Forms.Panel();
            this.endTime = new System.Windows.Forms.DateTimePicker();
            this.cxType = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.startTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbData = new CCWin.SkinControl.SkinGroupBox();
            this.dataGridPager1 = new Justec.Alcohol.Pulse.DataGridPager();
            this.checkPhoto = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.checkBox = new System.Windows.Forms.GroupBox();
            this.resultAlcohol = new System.Windows.Forms.Label();
            this.resultTime = new System.Windows.Forms.Label();
            this.resultJobNumber = new System.Windows.Forms.Label();
            this.resultName = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.userPhoto = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvAlcohol = new CCWin.SkinControl.SkinDataGridView();
            this.PID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JobNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Identity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SendTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlcoholStrength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sbp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dbp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pulses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BlodPhoto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FaceFeature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.topPanel.SuspendLayout();
            this.gbData.SuspendLayout();
            this.checkPhoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.checkBox.SuspendLayout();
            this.userPhoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlcohol)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.LightGray;
            this.topPanel.Controls.Add(this.endTime);
            this.topPanel.Controls.Add(this.cxType);
            this.topPanel.Controls.Add(this.btnReset);
            this.topPanel.Controls.Add(this.btnSearch);
            this.topPanel.Controls.Add(this.startTime);
            this.topPanel.Controls.Add(this.label2);
            this.topPanel.Controls.Add(this.label5);
            this.topPanel.Controls.Add(this.label4);
            this.topPanel.Controls.Add(this.textName);
            this.topPanel.Controls.Add(this.label1);
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1121, 49);
            this.topPanel.TabIndex = 0;
            // 
            // endTime
            // 
            this.endTime.CalendarFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.endTime.CustomFormat = "yyyy-MM-dd";
            this.endTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.endTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endTime.Location = new System.Drawing.Point(496, 10);
            this.endTime.Name = "endTime";
            this.endTime.Size = new System.Drawing.Size(150, 25);
            this.endTime.TabIndex = 31;
            this.endTime.ValueChanged += new System.EventHandler(this.endTime_ValueChanged);
            // 
            // cxType
            // 
            this.cxType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cxType.FormattingEnabled = true;
            this.cxType.Items.AddRange(new object[] {
            "全部",
            "正常",
            "饮酒",
            "酗酒"});
            this.cxType.Location = new System.Drawing.Point(729, 10);
            this.cxType.Name = "cxType";
            this.cxType.Size = new System.Drawing.Size(90, 25);
            this.cxType.TabIndex = 23;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(34)))), ((int)(((byte)(44)))));
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(992, 9);
            this.btnReset.Margin = new System.Windows.Forms.Padding(2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(96, 28);
            this.btnReset.TabIndex = 27;
            this.btnReset.Text = "重置条件";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(144)))), ((int)(((byte)(246)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(861, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(96, 28);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // startTime
            // 
            this.startTime.CustomFormat = "yyyy-MM-dd";
            this.startTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.startTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startTime.Location = new System.Drawing.Point(263, 10);
            this.startTime.Name = "startTime";
            this.startTime.Size = new System.Drawing.Size(150, 25);
            this.startTime.TabIndex = 30;
            this.startTime.Value = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            this.startTime.ValueChanged += new System.EventHandler(this.startTime_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label2.Location = new System.Drawing.Point(186, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "起始时间:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label5.Location = new System.Drawing.Point(652, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "测酒类型:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label4.Location = new System.Drawing.Point(419, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "结束时间:";
            // 
            // textName
            // 
            this.textName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textName.Location = new System.Drawing.Point(90, 10);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(90, 25);
            this.textName.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "人员姓名:";
            // 
            // gbData
            // 
            this.gbData.BackColor = System.Drawing.Color.Transparent;
            this.gbData.BorderColor = System.Drawing.Color.White;
            this.gbData.Controls.Add(this.dataGridPager1);
            this.gbData.Controls.Add(this.checkPhoto);
            this.gbData.Controls.Add(this.checkBox);
            this.gbData.Controls.Add(this.userPhoto);
            this.gbData.Controls.Add(this.dgvAlcohol);
            this.gbData.ForeColor = System.Drawing.Color.Blue;
            this.gbData.Location = new System.Drawing.Point(14, 55);
            this.gbData.Name = "gbData";
            this.gbData.RectBackColor = System.Drawing.Color.White;
            this.gbData.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.gbData.Size = new System.Drawing.Size(1107, 458);
            this.gbData.TabIndex = 1;
            this.gbData.TabStop = false;
            this.gbData.TitleBorderColor = System.Drawing.Color.Red;
            this.gbData.TitleRectBackColor = System.Drawing.Color.White;
            this.gbData.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // dataGridPager1
            // 
            this.dataGridPager1.BackColor = System.Drawing.Color.MistyRose;
            this.dataGridPager1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridPager1.Location = new System.Drawing.Point(-1, 423);
            this.dataGridPager1.Name = "dataGridPager1";
            this.dataGridPager1.PageCurrent = 1;
            this.dataGridPager1.PageSize = 10;
            this.dataGridPager1.Size = new System.Drawing.Size(1108, 35);
            this.dataGridPager1.TabIndex = 29;
            this.dataGridPager1.EventPaging += new Justec.Alcohol.Pulse.EventPagingHandler(this.dataGridPager1_EventPaging);
            this.dataGridPager1.BtnFirstClick += new Justec.Alcohol.Pulse.BtnClickHandler(this.dataGridPager1_BtnFirstClick);
            this.dataGridPager1.BtnNextClick += new Justec.Alcohol.Pulse.BtnClickHandler(this.dataGridPager1_BtnNextClick);
            this.dataGridPager1.BtnPreviousClick += new Justec.Alcohol.Pulse.BtnClickHandler(this.dataGridPager1_BtnPreviousClick);
            this.dataGridPager1.BtnLastClick += new Justec.Alcohol.Pulse.BtnClickHandler(this.dataGridPager1_BtnLastClick);
            // 
            // checkPhoto
            // 
            this.checkPhoto.Controls.Add(this.pictureBox2);
            this.checkPhoto.Location = new System.Drawing.Point(902, 275);
            this.checkPhoto.Margin = new System.Windows.Forms.Padding(2);
            this.checkPhoto.Name = "checkPhoto";
            this.checkPhoto.Padding = new System.Windows.Forms.Padding(2);
            this.checkPhoto.Size = new System.Drawing.Size(205, 146);
            this.checkPhoto.TabIndex = 28;
            this.checkPhoto.TabStop = false;
            this.checkPhoto.Text = "吹气照片";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.LightGray;
            this.pictureBox2.Location = new System.Drawing.Point(10, 22);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(190, 120);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // checkBox
            // 
            this.checkBox.Controls.Add(this.resultAlcohol);
            this.checkBox.Controls.Add(this.resultTime);
            this.checkBox.Controls.Add(this.resultJobNumber);
            this.checkBox.Controls.Add(this.resultName);
            this.checkBox.Controls.Add(this.label10);
            this.checkBox.Controls.Add(this.label9);
            this.checkBox.Controls.Add(this.label8);
            this.checkBox.Controls.Add(this.label7);
            this.checkBox.Location = new System.Drawing.Point(906, 146);
            this.checkBox.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox.Name = "checkBox";
            this.checkBox.Padding = new System.Windows.Forms.Padding(2);
            this.checkBox.Size = new System.Drawing.Size(201, 125);
            this.checkBox.TabIndex = 27;
            this.checkBox.TabStop = false;
            this.checkBox.Text = "吹气结果";
            // 
            // resultAlcohol
            // 
            this.resultAlcohol.AutoSize = true;
            this.resultAlcohol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultAlcohol.Location = new System.Drawing.Point(87, 94);
            this.resultAlcohol.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.resultAlcohol.Name = "resultAlcohol";
            this.resultAlcohol.Size = new System.Drawing.Size(81, 18);
            this.resultAlcohol.TabIndex = 7;
            this.resultAlcohol.Text = "0mg/100ml";
            // 
            // resultTime
            // 
            this.resultTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultTime.Location = new System.Drawing.Point(87, 52);
            this.resultTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.resultTime.Name = "resultTime";
            this.resultTime.Size = new System.Drawing.Size(90, 42);
            this.resultTime.TabIndex = 6;
            this.resultTime.Text = "2021-05-18\r\n18:23:06";
            // 
            // resultJobNumber
            // 
            this.resultJobNumber.AutoSize = true;
            this.resultJobNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultJobNumber.Location = new System.Drawing.Point(87, 31);
            this.resultJobNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.resultJobNumber.Name = "resultJobNumber";
            this.resultJobNumber.Size = new System.Drawing.Size(56, 18);
            this.resultJobNumber.TabIndex = 5;
            this.resultJobNumber.Text = "123456";
            // 
            // resultName
            // 
            this.resultName.AutoSize = true;
            this.resultName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultName.Location = new System.Drawing.Point(87, 13);
            this.resultName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.resultName.Name = "resultName";
            this.resultName.Size = new System.Drawing.Size(38, 18);
            this.resultName.TabIndex = 4;
            this.resultName.Text = "张三";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(11, 94);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 18);
            this.label10.TabIndex = 3;
            this.label10.Text = "酒精浓度:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(11, 52);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 18);
            this.label9.TabIndex = 2;
            this.label9.Text = "测试时间:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(11, 31);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 18);
            this.label8.TabIndex = 1;
            this.label8.Text = "工号:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(11, 13);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 18);
            this.label7.TabIndex = 0;
            this.label7.Text = "姓名:";
            // 
            // userPhoto
            // 
            this.userPhoto.Controls.Add(this.pictureBox1);
            this.userPhoto.Location = new System.Drawing.Point(902, 0);
            this.userPhoto.Margin = new System.Windows.Forms.Padding(2);
            this.userPhoto.Name = "userPhoto";
            this.userPhoto.Padding = new System.Windows.Forms.Padding(2);
            this.userPhoto.Size = new System.Drawing.Size(200, 142);
            this.userPhoto.TabIndex = 28;
            this.userPhoto.TabStop = false;
            this.userPhoto.Text = "注册照片";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightGray;
            this.pictureBox1.Location = new System.Drawing.Point(4, 16);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 122);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dgvAlcohol
            // 
            this.dgvAlcohol.AllowUserToAddRows = false;
            this.dgvAlcohol.AllowUserToDeleteRows = false;
            this.dgvAlcohol.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.dgvAlcohol.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAlcohol.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvAlcohol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvAlcohol.ColumnFont = null;
            this.dgvAlcohol.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAlcohol.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAlcohol.ColumnHeadersHeight = 26;
            this.dgvAlcohol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAlcohol.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PID,
            this.UseName,
            this.JobNumber,
            this.DeptName,
            this.Identity,
            this.SendTime,
            this.AlcoholStrength,
            this.Sbp,
            this.Dbp,
            this.Pulses,
            this.BlodPhoto,
            this.FaceFeature});
            this.dgvAlcohol.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAlcohol.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAlcohol.EnableHeadersVisualStyles = false;
            this.dgvAlcohol.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvAlcohol.HeadFont = new System.Drawing.Font("Microsoft Sans Serif", 6.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAlcohol.HeadSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvAlcohol.LineNumber = false;
            this.dgvAlcohol.Location = new System.Drawing.Point(0, -4);
            this.dgvAlcohol.Margin = new System.Windows.Forms.Padding(2);
            this.dgvAlcohol.Name = "dgvAlcohol";
            this.dgvAlcohol.ReadOnly = true;
            this.dgvAlcohol.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvAlcohol.RowHeadersWidth = 51;
            this.dgvAlcohol.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvAlcohol.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAlcohol.RowTemplate.Height = 23;
            this.dgvAlcohol.Size = new System.Drawing.Size(898, 421);
            this.dgvAlcohol.TabIndex = 26;
            this.dgvAlcohol.TitleBack = null;
            this.dgvAlcohol.TitleBackColorBegin = System.Drawing.Color.White;
            this.dgvAlcohol.TitleBackColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(144)))), ((int)(((byte)(246)))));
            this.dgvAlcohol.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlcohol_CellClick);
            // 
            // PID
            // 
            this.PID.DataPropertyName = "PID";
            this.PID.HeaderText = "编号";
            this.PID.MinimumWidth = 6;
            this.PID.Name = "PID";
            this.PID.ReadOnly = true;
            this.PID.Width = 70;
            // 
            // UseName
            // 
            this.UseName.DataPropertyName = "UseName";
            this.UseName.HeaderText = "姓名";
            this.UseName.MinimumWidth = 6;
            this.UseName.Name = "UseName";
            this.UseName.ReadOnly = true;
            this.UseName.Width = 70;
            // 
            // JobNumber
            // 
            this.JobNumber.DataPropertyName = "JobNumber";
            this.JobNumber.HeaderText = "工号";
            this.JobNumber.MinimumWidth = 6;
            this.JobNumber.Name = "JobNumber";
            this.JobNumber.ReadOnly = true;
            this.JobNumber.Width = 70;
            // 
            // DeptName
            // 
            this.DeptName.DataPropertyName = "DeptName";
            this.DeptName.HeaderText = "单位";
            this.DeptName.MinimumWidth = 6;
            this.DeptName.Name = "DeptName";
            this.DeptName.ReadOnly = true;
            this.DeptName.Width = 150;
            // 
            // Identity
            // 
            this.Identity.DataPropertyName = "Identity";
            this.Identity.HeaderText = "身份";
            this.Identity.MinimumWidth = 6;
            this.Identity.Name = "Identity";
            this.Identity.ReadOnly = true;
            this.Identity.Width = 70;
            // 
            // SendTime
            // 
            this.SendTime.DataPropertyName = "SendTime";
            this.SendTime.HeaderText = "日期时间";
            this.SendTime.MinimumWidth = 6;
            this.SendTime.Name = "SendTime";
            this.SendTime.ReadOnly = true;
            this.SendTime.Width = 150;
            // 
            // AlcoholStrength
            // 
            this.AlcoholStrength.DataPropertyName = "AlcoholStrength";
            this.AlcoholStrength.HeaderText = "酒精浓度mg/100ml";
            this.AlcoholStrength.MinimumWidth = 6;
            this.AlcoholStrength.Name = "AlcoholStrength";
            this.AlcoholStrength.ReadOnly = true;
            this.AlcoholStrength.Width = 270;
            // 
            // Sbp
            // 
            this.Sbp.DataPropertyName = "Sbp";
            this.Sbp.HeaderText = "收缩压(mmHg)";
            this.Sbp.MinimumWidth = 6;
            this.Sbp.Name = "Sbp";
            this.Sbp.ReadOnly = true;
            this.Sbp.Width = 150;
            // 
            // Dbp
            // 
            this.Dbp.DataPropertyName = "Dbp";
            this.Dbp.HeaderText = "舒张压(mmHg)";
            this.Dbp.MinimumWidth = 6;
            this.Dbp.Name = "Dbp";
            this.Dbp.ReadOnly = true;
            this.Dbp.Width = 150;
            // 
            // Pulses
            // 
            this.Pulses.DataPropertyName = "Pulses";
            this.Pulses.HeaderText = "脉搏(bpm)";
            this.Pulses.MinimumWidth = 6;
            this.Pulses.Name = "Pulses";
            this.Pulses.ReadOnly = true;
            this.Pulses.Width = 150;
            // 
            // BlodPhoto
            // 
            this.BlodPhoto.DataPropertyName = "BlodPhoto";
            this.BlodPhoto.HeaderText = "BlodPhoto";
            this.BlodPhoto.MinimumWidth = 6;
            this.BlodPhoto.Name = "BlodPhoto";
            this.BlodPhoto.ReadOnly = true;
            this.BlodPhoto.Visible = false;
            this.BlodPhoto.Width = 125;
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
            // FrmLocalDatas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1121, 516);
            this.Controls.Add(this.gbData);
            this.Controls.Add(this.topPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLocalDatas";
            this.Text = "本地数据";
            this.Load += new System.EventHandler(this.FrmLocalDatas_Load);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.gbData.ResumeLayout(false);
            this.checkPhoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.checkBox.ResumeLayout(false);
            this.checkBox.PerformLayout();
            this.userPhoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlcohol)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cxType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;
        private CCWin.SkinControl.SkinGroupBox gbData;
        private CCWin.SkinControl.SkinDataGridView dgvAlcohol;
        private System.Windows.Forms.GroupBox userPhoto;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox checkBox;
        private System.Windows.Forms.Label resultAlcohol;
        private System.Windows.Forms.Label resultTime;
        private System.Windows.Forms.Label resultJobNumber;
        private System.Windows.Forms.Label resultName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox checkPhoto;
        private System.Windows.Forms.PictureBox pictureBox2;
        private DataGridPager dataGridPager1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn JobNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Identity;
        private System.Windows.Forms.DataGridViewTextBoxColumn SendTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlcoholStrength;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sbp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dbp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pulses;
        private System.Windows.Forms.DataGridViewTextBoxColumn BlodPhoto;
        private System.Windows.Forms.DataGridViewTextBoxColumn FaceFeature;
        private System.Windows.Forms.DateTimePicker startTime;
        private System.Windows.Forms.DateTimePicker endTime;
    }
}