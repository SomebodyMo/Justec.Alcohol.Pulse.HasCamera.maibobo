using Justec.Alcohol.Pulse.BLL;
using Justec.Alcohol.Pulse.Model;
using Justec.Alcohol.Pulse.Utils;
using Justec.Alcohol.Pulse.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Justec.Alcohol.Pulse
{
    public partial class FrmUserManage : Form
    {
        FormAutoSize autoSize = new FormAutoSize("UserManage");

        private int totalCount = 0;
        private int PageIndex = 0;
        private int PageSize = 0;

        public object FormHelper { get; private set; }

        public FrmUserManage()
        {
            InitializeComponent();
        }

        private void FrmUserManage_Load(object sender, EventArgs e)
        {
            //部门赋值
            DataTable dataTable = new DataTable();
            dataTable = new DeptManage().GetDeptData();
            cxType.DataSource = dataTable;
            cxType.DisplayMember = "DEPTNAME";
            cxType.ValueMember = "DEPTID";
            cxType.SelectedIndex = 0;

            //为空
            this.panelDeptName.Text = string.Empty;//单位
            this.panelJobNumber.Text = string.Empty;//工号
            this.panelUserName.Text = string.Empty;//姓名

            dgvUser.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//表数据居中显示
            dgvUser.RowsDefaultCellStyle.Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Regular);
            dgvUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUser.AutoGenerateColumns = false;
            InitDataGridView();
            totalCount = UserManage.GetUserCountBy("");
            dataGridPager1.BindData();
            dgvUser.ClearSelection();

        }

        public void InitDataGridView()
        {
            PageIndex = dataGridPager1.PageCurrent;
            PageSize = dataGridPager1.PageSize;
            string strWhere = GetSqlWhere();
            BindDataSource(strWhere);
            if (dgvUser.Rows.Count > 0)
            {
                BindCheckData();
            }
        }

        private void BindDataSource(string strWhere)
        {
            try
            {
                DataTable userTable = new UserManage().GetUserDataTable(strWhere, PageSize, PageIndex);
                int rowBegin = (PageIndex - 1) * PageSize;
                dgvUser.DataSource = userTable;
            }
            catch (Exception ex)
            {

            }
        }

        private string GetSqlWhere()
        {
            string strWhere = "";
            //工号
            if (!String.IsNullOrWhiteSpace(txtJobNumber.Text))
            {
                strWhere += $"and u.JobNumber like '%{txtJobNumber.Text}%'";
            }
            //姓名
            if (!String.IsNullOrWhiteSpace(textName.Text))
            {
                strWhere += $"and u.UserName like '%{textName.Text}%'";
            }
            //部门
            if (!String.IsNullOrWhiteSpace(cxType.Text))
            {
                DataRowView dv = cxType.Items[cxType.SelectedIndex] as DataRowView;
                //dv.Row["DEPTID"].ToString()
                //dv.Row["DEPTNAME"].ToString()
                if(dv.Row["DEPTID"].ToString() != "0")
                {
                    strWhere += $"and u.DeptId like '%{dv.Row["DEPTID"].ToString()}%'";
                }
            }
            return strWhere;
        }

        private void BindCheckData()
        {
            dgvUser.ClearSelection();
            dgvUser.Rows[0].Selected = true;
        }

        #region 分页控件事件
        private int dataGridPager1_EventPaging(EventPagingArg e)
        {
            return totalCount;
        }

        private void dataGridPager1_BtnFirstClick(object sender, EventArgs e)
        {
            InitDataGridView();
        }

        private void dataGridPager1_BtnLastClick(object sender, EventArgs e)
        {
            InitDataGridView();
        }

        private void dataGridPager1_BtnNextClick(object sender, EventArgs e)
        {
            InitDataGridView();
        }

        private void dataGridPager1_BtnPreviousClick(object sender, EventArgs e)
        {
            InitDataGridView();
        }

        #endregion

        #region
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string strWhere = GetSqlWhere();
            dataGridPager1.PageCurrent = 1;
            InitDataGridView();
            totalCount = UserManage.GetUserCountBy(strWhere);
            dataGridPager1.BindData();
        }

        /// <summary>
        /// 重置搜索条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.txtJobNumber.Text = string.Empty;
            this.textName.Text = string.Empty;
            cxType.SelectedIndex = 0;
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserInfo userInfo = new UserInfo();
            FrmAddUser frmAddUser = new FrmAddUser(userInfo);
            frmAddUser.ShowDialog();
            if (frmAddUser.DialogResult == DialogResult.OK)
            {
                InitDataGridView();
            }
        }
        #endregion

        #region 关闭界面
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmUserManage_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        #endregion

        #region 行点击事件
        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.pictureBox1.Image = null;
                string userFace = dgvUser.Rows[e.RowIndex].Cells["FaceFeature"].Value.ToString();
                if (userFace != "")
                {
                    this.pictureBox1.Image = Image.FromFile(userFace,false);
                }
                else
                {
                    this.pictureBox1.Image = global::Justec.Alcohol.Pulse.Properties.Resources.morentouxiang拷贝1;
                }

                this.panelJobNumber.Text = dgvUser.Rows[e.RowIndex].Cells["JobNumber"].Value.ToString();
                this.panelUserName.Text = dgvUser.Rows[e.RowIndex].Cells["UserName"].Value.ToString();
                this.panelDeptName.Text = dgvUser.Rows[e.RowIndex].Cells["DEPTNAME"].Value.ToString();
            }
        }
        #endregion
        #region Base64字符串转换为图片
        /// <summary>
        /// 将Base64字符串转换为图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private Image ToImage(string userFace)
        {
            Bitmap bitmap = null;
            try
            {
                byte[] arr = Convert.FromBase64String(userFace);
                MemoryStream ms = new MemoryStream(arr);
                Bitmap bmp = new Bitmap(ms);
                ms.Close();
                bitmap = bmp;
            }
            catch (Exception ex)
            {

            }
            return bitmap;
        }
        #endregion

        private void butClosed_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
