using CCWin;
using Justec.Alcohol.Pulse.BLL;
using Justec.Alcohol.Pulse.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Justec.Alcohol.Pulse
{
    public partial class FrmLocalDatas : Form
    {
        private int totalCount = 0;
        private int PageIndex = 0;
        private int PageSize = 0;
        bool Upload = true;
        public FrmLocalDatas()
        {
            InitializeComponent();
        }

        private void FrmLocalDatas_Load(object sender, EventArgs e)
        {
            try
            {
                dgvAlcohol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//表数据居中显示
                dgvAlcohol.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//所有列平均宽度
                dgvAlcohol.RowsDefaultCellStyle.Font = new Font("Microsoft YaHei UI", 11, FontStyle.Regular);
                dgvAlcohol.SelectionMode = DataGridViewSelectionMode.FullRowSelect;//一次选中一行
                dgvAlcohol.AutoGenerateColumns = false;
                totalCount = new PulseDataManage().GetHistoryCountBy(GetSqlWhere());
                PageIndex = dataGridPager1.PageCurrent;
                PageSize = dataGridPager1.PageSize;
                InitDataGridView();
                dataGridPager1.BindData();
                cxType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog($"Justec.Alcohol.Pulse_Load方法错误: 1.错误信息 {ex.Message}\r\n 2.错误源 {ex.Source} \r\n 3.错误详情 { ex.StackTrace}");
            }
        }


        private string GetSqlWhere()
        {
            string sqlWhere = "";

            if (!string.IsNullOrWhiteSpace(textName.Text))
            {
                sqlWhere += $" and h.UseName like '%{textName.Text}%' ";
            }
            if (cxType.Text != "全部")
            {
                if (cxType.Text == "正常")
                {
                    sqlWhere += $" and h.AlcoholStrength < '20' ";
                }

                if (cxType.Text == "饮酒")
                {
                    sqlWhere += $" and h.AlcoholStrength >= '20' and h.AlcoholStrength < '80'";
                }

                if (cxType.Text == "酗酒")
                {
                    sqlWhere += $" and h.AlcoholStrength >= '80'";
                }
            }
            if (!string.IsNullOrWhiteSpace(startTime.Text))
            {
                sqlWhere += $" and h.SendTime >= '{Convert.ToDateTime(startTime.Text).ToString("yyyy-MM-dd") + " 00:00:00"}' ";
            }
            if (!string.IsNullOrWhiteSpace(endTime.Text))
            {
                sqlWhere += $" and h.SendTime <= '{Convert.ToDateTime(endTime.Text).ToString("yyyy-MM-dd") + " 23:59:59"}' ";
            }
            return sqlWhere;
        }

        #region 时间选择
        /// <summary>
        /// 开始时间不能大于结束时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="Item"></param>
        private void startTime_SelectedValueChange(object sender, string Item)
        {
            if (!string.IsNullOrWhiteSpace(endTime.Text))
            {
                if (Convert.ToDateTime(Item) > Convert.ToDateTime(endTime.Text))
                {
                    startTime.ResetText();
                    MessageBoxEx.Show("开始时间不能大于结束时间！");
                }
            }
        }
        /// <summary>
        /// 结束时间不能大于开始时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="Item"></param>
        private void endTime_SelectedValueChange(object sender, string Item)
        {
            if (!string.IsNullOrWhiteSpace(startTime.Text))
            {
                if (Convert.ToDateTime(Item) < Convert.ToDateTime(startTime.Text))
                {
                    endTime.ResetText();
                    MessageBoxEx.Show("结束时间不能小于开始时间！");
                }
            }
        }
        #endregion


        #region 按钮
        /// <summary>
        /// 重置搜索条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            textName.Text = string.Empty;
            cxType.SelectedIndex = 0;
            startTime.Value = Convert.ToDateTime("20210101".Substring(0, 4) + "-" + "20210101".Substring(4, 2) + "-" + "20210101".Substring(6, 2));
            endTime.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        }
        #endregion


        private void InitDataGridView()
        {
            BeginInvoke(new Action(() =>
            {
                try
                {
                    ClearBind();
                    dgvAlcohol.DataSource = null;
                    string strWhere = GetSqlWhere();
                    DataTable historyTable = new PulseDataManage().GetHistoryData(strWhere, PageSize, PageIndex);
                    if (historyTable != null && historyTable.Rows.Count > 0)
                    {
                        int rowBegin = (PageIndex - 1) * PageSize;
                        dgvAlcohol.DataSource = historyTable;
                        dgvAlcohol.ClearSelection();
                        dgvAlcohol.Rows[0].Selected = true;
                        BindCheckData(0);
                    }
                    else
                    {
                        dgvAlcohol.DataSource = historyTable;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrorLog($"BindDataSource方法错误: 1.错误信息 {ex.Message}\r\n 2.错误源 {ex.Source} \r\n 3.错误详情 { ex.StackTrace}");
                }
            }));
        }

        /// <summary>
        /// 清空
        /// </summary>
        private void ClearBind()
        {
            resultName.Text = string.Empty;
            resultTime.Text = string.Empty;
            resultAlcohol.Text = string.Empty;
            resultJobNumber.Text = string.Empty;
            pictureBox1.Image = null;
            pictureBox2.Image = null;
        }

        private void BindCheckData(int rowIndex)
        {
            try
            {
                ClearBind();

                //注册照片
                string userFace = dgvAlcohol.Rows[rowIndex].Cells["FaceFeature"].Value.ToString();
                if (userFace != "")
                {
                    this.pictureBox1.Image = Image.FromFile(userFace, false);
                }
                else
                {
                    this.pictureBox1.Image = global::Justec.Alcohol.Pulse.Properties.Resources.morentouxiang拷贝1;
                }

                //吹气照片
                string checkFace = dgvAlcohol.Rows[rowIndex].Cells["BlodPhoto"].Value.ToString();
                if (checkFace != "")
                {
                    this.pictureBox2.Image = Image.FromFile(checkFace, false);
                }
                else
                {
                    this.pictureBox2.Image = global::Justec.Alcohol.Pulse.Properties.Resources.morentouxiang拷贝1;
                }

                //记录信息
                resultName.Text = dgvAlcohol.Rows[rowIndex].Cells["UseName"].Value.ToString();
                resultJobNumber.Text = dgvAlcohol.Rows[rowIndex].Cells["JobNumber"].Value.ToString();
                resultTime.Text = dgvAlcohol.Rows[rowIndex].Cells["SendTime"].Value.ToString();
                resultAlcohol.Text = dgvAlcohol.Rows[rowIndex].Cells["AlcoholStrength"].Value.ToString() + "mg/100ml";
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog($"BindCheckData方法发生错误: 1.错误信息 {ex.Message}\r\n 2.错误源 {ex.Source} \r\n 3.错误详情 { ex.StackTrace}");
            }
        }

        #region 分页控件事件
        private int dataGridPager1_EventPaging(EventPagingArg e)
        {
            return totalCount;
        }

        private void dataGridPager1_BtnFirstClick(object sender, EventArgs e)
        {
            PageIndex = dataGridPager1.PageCurrent;
            PageSize = dataGridPager1.PageSize;
            InitDataGridView();
        }

        private void dataGridPager1_BtnLastClick(object sender, EventArgs e)
        {
            PageIndex = dataGridPager1.PageCurrent;
            PageSize = dataGridPager1.PageSize;
            InitDataGridView();
        }

        private void dataGridPager1_BtnNextClick(object sender, EventArgs e)
        {
            PageIndex = dataGridPager1.PageCurrent;
            PageSize = dataGridPager1.PageSize;
            InitDataGridView();
        }

        private void dataGridPager1_BtnPreviousClick(object sender, EventArgs e)
        {
            PageIndex = dataGridPager1.PageCurrent;
            PageSize = dataGridPager1.PageSize;
            InitDataGridView();
        }
        #endregion
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PageIndex = dataGridPager1.PageCurrent = 1;
            PageSize = dataGridPager1.PageSize;
            totalCount = new PulseDataManage().GetHistoryCountBy(GetSqlWhere());
            InitDataGridView();
            dataGridPager1.BindData();
        }

        #region 表格
        private void dgvAlcohol_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >=0)
            {
                BindCheckData(e.RowIndex);
            }
        }
        #endregion

        private void startTime_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateTime = (sender as DateTimePicker).Value;
            if(endTime.Value != null)
            {
                if(dateTime > endTime.Value)
                {
                    startTime.Value = Convert.ToDateTime("20210101".Substring(0,4) + "-" + "20210101".Substring(4, 2) + "-" + "20210101".Substring(6, 2));
                    //startTime.ResetText();
                    MessageBoxEx.Show("开始时间不能大于结束时间");
                }
            }
        }

        private void endTime_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateTime = (sender as DateTimePicker).Value;
            if (startTime.Value != null)
            {
                if (dateTime < startTime.Value)
                {
                    endTime.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                    //endTime.ResetText();
                    MessageBoxEx.Show("结束时间不能小于开始时间");
                }
            }
        }
    }
}
