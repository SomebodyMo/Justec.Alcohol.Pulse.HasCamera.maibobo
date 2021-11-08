
namespace Justec.Alcohol.Pulse
{
    partial class FrmAddUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddUser));
            this.userInfo = new CCWin.SkinControl.SkinGroupBox();
            this.btnClosed = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textRes = new System.Windows.Forms.TextBox();
            this.picFPImg = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.cxType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtJobNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.userInfo.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFPImg)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // userInfo
            // 
            this.userInfo.BackColor = System.Drawing.Color.White;
            this.userInfo.BorderColor = System.Drawing.Color.White;
            this.userInfo.Controls.Add(this.btnClosed);
            this.userInfo.Controls.Add(this.btnAdd);
            this.userInfo.Controls.Add(this.bottomPanel);
            this.userInfo.Controls.Add(this.panel1);
            this.userInfo.Controls.Add(this.leftPanel);
            this.userInfo.ForeColor = System.Drawing.Color.Blue;
            this.userInfo.Location = new System.Drawing.Point(0, 0);
            this.userInfo.Margin = new System.Windows.Forms.Padding(4);
            this.userInfo.Name = "userInfo";
            this.userInfo.Padding = new System.Windows.Forms.Padding(4);
            this.userInfo.RectBackColor = System.Drawing.Color.White;
            this.userInfo.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.userInfo.Size = new System.Drawing.Size(695, 565);
            this.userInfo.TabIndex = 0;
            this.userInfo.TabStop = false;
            this.userInfo.TitleBorderColor = System.Drawing.Color.Red;
            this.userInfo.TitleRectBackColor = System.Drawing.Color.White;
            this.userInfo.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // btnClosed
            // 
            this.btnClosed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(34)))), ((int)(((byte)(44)))));
            this.btnClosed.FlatAppearance.BorderSize = 0;
            this.btnClosed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClosed.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClosed.ForeColor = System.Drawing.Color.White;
            this.btnClosed.Location = new System.Drawing.Point(409, 494);
            this.btnClosed.Margin = new System.Windows.Forms.Padding(4);
            this.btnClosed.Name = "btnClosed";
            this.btnClosed.Size = new System.Drawing.Size(160, 54);
            this.btnClosed.TabIndex = 20;
            this.btnClosed.Text = "关闭";
            this.btnClosed.UseVisualStyleBackColor = false;
            this.btnClosed.Click += new System.EventHandler(this.btnClosed_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(144)))), ((int)(((byte)(246)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(165, 496);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(160, 51);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.Text = "确定";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.groupBox2);
            this.bottomPanel.Location = new System.Drawing.Point(0, 266);
            this.bottomPanel.Margin = new System.Windows.Forms.Padding(4);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(692, 220);
            this.bottomPanel.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightGray;
            this.groupBox2.Controls.Add(this.textRes);
            this.groupBox2.Controls.Add(this.picFPImg);
            this.groupBox2.Location = new System.Drawing.Point(5, 8);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(675, 212);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "指纹数据";
            // 
            // textRes
            // 
            this.textRes.BackColor = System.Drawing.Color.White;
            this.textRes.Location = new System.Drawing.Point(324, 26);
            this.textRes.Multiline = true;
            this.textRes.Name = "textRes";
            this.textRes.Size = new System.Drawing.Size(340, 170);
            this.textRes.TabIndex = 1;
            // 
            // picFPImg
            // 
            this.picFPImg.Location = new System.Drawing.Point(40, 25);
            this.picFPImg.Name = "picFPImg";
            this.picFPImg.Size = new System.Drawing.Size(230, 171);
            this.picFPImg.TabIndex = 0;
            this.picFPImg.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(423, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(269, 255);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.videoSourcePlayer1);
            this.groupBox1.Location = new System.Drawing.Point(5, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(252, 242);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "注册照片";
            // 
            // videoSourcePlayer1
            // 
            this.videoSourcePlayer1.Location = new System.Drawing.Point(12, 32);
            this.videoSourcePlayer1.Margin = new System.Windows.Forms.Padding(4);
            this.videoSourcePlayer1.Name = "videoSourcePlayer1";
            this.videoSourcePlayer1.Size = new System.Drawing.Size(229, 194);
            this.videoSourcePlayer1.TabIndex = 0;
            this.videoSourcePlayer1.Text = "videoSourcePlayer1";
            this.videoSourcePlayer1.VideoSource = null;
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.LightGray;
            this.leftPanel.Controls.Add(this.cxType);
            this.leftPanel.Controls.Add(this.label5);
            this.leftPanel.Controls.Add(this.textUserName);
            this.leftPanel.Controls.Add(this.label2);
            this.leftPanel.Controls.Add(this.txtJobNumber);
            this.leftPanel.Controls.Add(this.label1);
            this.leftPanel.Location = new System.Drawing.Point(0, 2);
            this.leftPanel.Margin = new System.Windows.Forms.Padding(4);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(415, 255);
            this.leftPanel.TabIndex = 0;
            // 
            // cxType
            // 
            this.cxType.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cxType.FormattingEnabled = true;
            this.cxType.Location = new System.Drawing.Point(112, 180);
            this.cxType.Margin = new System.Windows.Forms.Padding(4);
            this.cxType.Name = "cxType";
            this.cxType.Size = new System.Drawing.Size(212, 38);
            this.cxType.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label5.Location = new System.Drawing.Point(37, 191);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 24);
            this.label5.TabIndex = 14;
            this.label5.Text = "部门:";
            // 
            // textUserName
            // 
            this.textUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textUserName.Location = new System.Drawing.Point(112, 95);
            this.textUserName.Margin = new System.Windows.Forms.Padding(4);
            this.textUserName.Name = "textUserName";
            this.textUserName.Size = new System.Drawing.Size(212, 37);
            this.textUserName.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label2.Location = new System.Drawing.Point(41, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "姓名:";
            // 
            // txtJobNumber
            // 
            this.txtJobNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtJobNumber.Location = new System.Drawing.Point(112, 12);
            this.txtJobNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtJobNumber.Name = "txtJobNumber";
            this.txtJobNumber.Size = new System.Drawing.Size(212, 37);
            this.txtJobNumber.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(41, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "工号:";
            // 
            // FrmAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 562);
            this.Controls.Add(this.userInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmAddUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加用户";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAddUser_FormClosed);
            this.Load += new System.EventHandler(this.FrmAddUser_Load);
            this.userInfo.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFPImg)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinGroupBox userInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.TextBox txtJobNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cxType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClosed;
        private System.Windows.Forms.PictureBox picFPImg;
        private System.Windows.Forms.TextBox textRes;
    }
}