
namespace Justec.Alcohol.Pulse
{
    partial class DataGridPager
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataGridPager));
            this.pageLeft = new System.Windows.Forms.Panel();
            this.labCurrentPage = new System.Windows.Forms.Label();
            this.labTotalPage = new System.Windows.Forms.Label();
            this.labTotalRecords = new System.Windows.Forms.Label();
            this.btnNext = new CCWin.SkinControl.SkinButton();
            this.btnPrevious = new CCWin.SkinControl.SkinButton();
            this.btnLast = new CCWin.SkinControl.SkinButton();
            this.btnFirst = new CCWin.SkinControl.SkinButton();
            this.pageRight = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pageLeft.SuspendLayout();
            this.pageRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // pageLeft
            // 
            this.pageLeft.BackColor = System.Drawing.Color.MistyRose;
            this.pageLeft.Controls.Add(this.labCurrentPage);
            this.pageLeft.Controls.Add(this.labTotalPage);
            this.pageLeft.Controls.Add(this.labTotalRecords);
            this.pageLeft.Location = new System.Drawing.Point(0, 0);
            this.pageLeft.Name = "pageLeft";
            this.pageLeft.Size = new System.Drawing.Size(368, 35);
            this.pageLeft.TabIndex = 1;
            // 
            // labCurrentPage
            // 
            this.labCurrentPage.AutoSize = true;
            this.labCurrentPage.Location = new System.Drawing.Point(206, 6);
            this.labCurrentPage.Name = "labCurrentPage";
            this.labCurrentPage.Size = new System.Drawing.Size(103, 25);
            this.labCurrentPage.TabIndex = 2;
            this.labCurrentPage.Text = "当前第0页";
            // 
            // labTotalPage
            // 
            this.labTotalPage.AutoSize = true;
            this.labTotalPage.Location = new System.Drawing.Point(137, 6);
            this.labTotalPage.Name = "labTotalPage";
            this.labTotalPage.Size = new System.Drawing.Size(63, 25);
            this.labTotalPage.TabIndex = 1;
            this.labTotalPage.Text = "共0页";
            // 
            // labTotalRecords
            // 
            this.labTotalRecords.AutoSize = true;
            this.labTotalRecords.Location = new System.Drawing.Point(14, 6);
            this.labTotalRecords.Name = "labTotalRecords";
            this.labTotalRecords.Size = new System.Drawing.Size(103, 25);
            this.labTotalRecords.TabIndex = 0;
            this.labTotalRecords.Text = "共0条记录";
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.BaseColor = System.Drawing.Color.Aqua;
            this.btnNext.BorderColor = System.Drawing.Color.Aqua;
            this.btnNext.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnNext.DownBack = null;
            this.btnNext.Font = new System.Drawing.Font("宋体", 9F);
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(189, 5);
            this.btnNext.MouseBack = null;
            this.btnNext.Name = "btnNext";
            this.btnNext.NormlBack = null;
            this.btnNext.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnNext.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnNext.Size = new System.Drawing.Size(63, 26);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "下页 ";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.Transparent;
            this.btnPrevious.BaseColor = System.Drawing.Color.Aqua;
            this.btnPrevious.BorderColor = System.Drawing.Color.Aqua;
            this.btnPrevious.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnPrevious.DownBack = null;
            this.btnPrevious.Font = new System.Drawing.Font("宋体", 9F);
            this.btnPrevious.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevious.Image")));
            this.btnPrevious.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrevious.Location = new System.Drawing.Point(110, 5);
            this.btnPrevious.MouseBack = null;
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.NormlBack = null;
            this.btnPrevious.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPrevious.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnPrevious.Size = new System.Drawing.Size(63, 26);
            this.btnPrevious.TabIndex = 5;
            this.btnPrevious.Text = "上页 ";
            this.btnPrevious.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnLast
            // 
            this.btnLast.BackColor = System.Drawing.Color.Transparent;
            this.btnLast.BaseColor = System.Drawing.Color.Aqua;
            this.btnLast.BorderColor = System.Drawing.Color.Aqua;
            this.btnLast.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnLast.DownBack = null;
            this.btnLast.Font = new System.Drawing.Font("宋体", 9F);
            this.btnLast.Image = ((System.Drawing.Image)(resources.GetObject("btnLast.Image")));
            this.btnLast.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLast.Location = new System.Drawing.Point(266, 5);
            this.btnLast.MouseBack = null;
            this.btnLast.Name = "btnLast";
            this.btnLast.NormlBack = null;
            this.btnLast.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLast.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnLast.Size = new System.Drawing.Size(63, 26);
            this.btnLast.TabIndex = 4;
            this.btnLast.Text = "末页";
            this.btnLast.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLast.UseVisualStyleBackColor = false;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.BackColor = System.Drawing.Color.Transparent;
            this.btnFirst.BaseColor = System.Drawing.Color.Aqua;
            this.btnFirst.BorderColor = System.Drawing.Color.Aqua;
            this.btnFirst.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnFirst.DownBack = null;
            this.btnFirst.Font = new System.Drawing.Font("宋体", 9F);
            this.btnFirst.Image = ((System.Drawing.Image)(resources.GetObject("btnFirst.Image")));
            this.btnFirst.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFirst.Location = new System.Drawing.Point(35, 5);
            this.btnFirst.MouseBack = null;
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.NormlBack = null;
            this.btnFirst.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnFirst.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnFirst.Size = new System.Drawing.Size(63, 26);
            this.btnFirst.TabIndex = 3;
            this.btnFirst.Text = "首页";
            this.btnFirst.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFirst.UseVisualStyleBackColor = false;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // pageRight
            // 
            this.pageRight.Controls.Add(this.btnLast);
            this.pageRight.Controls.Add(this.btnFirst);
            this.pageRight.Controls.Add(this.btnPrevious);
            this.pageRight.Controls.Add(this.btnNext);
            this.pageRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pageRight.Location = new System.Drawing.Point(365, 0);
            this.pageRight.Name = "pageRight";
            this.pageRight.Size = new System.Drawing.Size(330, 35);
            this.pageRight.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(695, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(201, 35);
            this.panel1.TabIndex = 8;
            // 
            // DataGridPager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.Controls.Add(this.pageRight);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pageLeft);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "DataGridPager";
            this.Size = new System.Drawing.Size(896, 35);
            this.pageLeft.ResumeLayout(false);
            this.pageLeft.PerformLayout();
            this.pageRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pageLeft;
        private System.Windows.Forms.Label labCurrentPage;
        private System.Windows.Forms.Label labTotalPage;
        private System.Windows.Forms.Label labTotalRecords;
        private CCWin.SkinControl.SkinButton btnFirst;
        private CCWin.SkinControl.SkinButton btnNext;
        private CCWin.SkinControl.SkinButton btnPrevious;
        private CCWin.SkinControl.SkinButton btnLast;
        private System.Windows.Forms.Panel pageRight;
        private System.Windows.Forms.Panel panel1;
    }
}
