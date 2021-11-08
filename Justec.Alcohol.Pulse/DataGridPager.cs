using System;
using System.Windows.Forms;

namespace Justec.Alcohol.Pulse
{
    //委托
    public delegate int EventPagingHandler(EventPagingArg e);

    public delegate void BtnClickHandler(object sender, EventArgs e);

    delegate void BindDataCallBack();
    /// <summary>
    /// 自用分页控件
    /// </summary>
    public partial class DataGridPager : UserControl
    {
        public DataGridPager()
        {
            InitializeComponent();
        }

        public event EventPagingHandler EventPaging;

        public event BtnClickHandler BtnFirstClick;

        public event BtnClickHandler BtnNextClick;

        public event BtnClickHandler BtnPreviousClick;

        public event BtnClickHandler BtnLastClick;

        #region 字段属性和方法
        private int start = 0;

        private int end = 0;

        private int _pageSize = 10;
        /// <summary>
        /// 每页记录数
        /// </summary>
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = value;
            }
        }
        /// <summary>
        /// 总记录数
        /// </summary>
        private int TotalRecords = 0;

        /// <summary>
        /// 页数=总记录数/每页记录数
        /// </summary>
        private int PageCount = 0;


        /// <summary>
        /// 当前页号
        /// </summary>
        private int _pageCurrent = 1;

        /// <summary>
        /// 当前页号
        /// </summary>
        public int PageCurrent
        {
            get { return _pageCurrent; }
            set { _pageCurrent = value; }
        }
        /// <summary>
        /// 计算页数
        /// </summary>
        private void GetPageCount()
        {
            if (TotalRecords > 0)
            {
                PageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(TotalRecords) / Convert.ToDouble(PageSize)));
            }
            else
            {
                PageCount = 0;
            }
        }

        /// <summary>
        /// 翻页控件数据绑定
        /// </summary>
        public void BindData()
        {   
            BeginInvoke(new Action(() =>
            {
                if (EventPaging != null)
                {
                    TotalRecords = EventPaging(new EventPagingArg(PageCurrent));
                }
                GetPageCount();
                if (PageCurrent > PageCount)
                {
                    _pageCurrent = PageCount;
                }
                labTotalPage.Text = $"共{PageCount}页";
                labTotalRecords.Text = $"共{TotalRecords}条记录";
                start = PageSize * (PageCurrent - 1) + 1;
                end = (PageSize * PageCurrent > TotalRecords) ? TotalRecords : PageSize * PageCurrent;
                labCurrentPage.Text = $"当前第{PageCurrent}页/{start}-{end}";

                //总记录数为0
                if (TotalRecords == 0)
                {
                    labCurrentPage.Text = string.Empty;
                    btnFirst.Enabled = false;
                    btnPrevious.Enabled = false;
                    btnLast.Enabled = false;
                    btnNext.Enabled = false;
                }
                else
                {
                    //当前页为首页
                    if (PageCurrent == 1)
                    {
                        btnFirst.Enabled = false;
                        btnPrevious.Enabled = false;
                    }
                    else
                    {
                        btnFirst.Enabled = true;
                        btnPrevious.Enabled = true;
                    }
                    //当前页为末页
                    if (PageCurrent == PageCount)
                    {
                        btnLast.Enabled = false;
                        btnNext.Enabled = false;
                    }
                    else
                    {
                        btnLast.Enabled = true;
                        btnNext.Enabled = true;
                    }
                }
            }));             
        }

        #endregion

        #region 翻页按钮点击事件
        private void btnFirst_Click(object sender, EventArgs e)
        {
            _pageCurrent = 1;
            if (BtnFirstClick != null)
            {
                BtnFirstClick(sender, e);
            }
            BindData();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            _pageCurrent = PageCount;
            if (BtnLastClick != null)
            {
                BtnLastClick(sender, e);
            }          
            BindData();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            _pageCurrent -= 1;
            if (PageCurrent <= 0)
            {
                _pageCurrent = 1;
            }
            if (BtnPreviousClick != null)
            {
                BtnPreviousClick(sender, e);
            }       
            BindData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _pageCurrent += 1;
            if (PageCurrent > PageCount)
            {
                _pageCurrent = PageCount;
            }
            if (BtnNextClick != null)
            {
                BtnNextClick(sender, e);
            }           
            BindData();
        }
        #endregion
    }

    /// <summary>
    /// 自定义事件数据基类
    /// </summary>
    public class EventPagingArg : EventArgs
    {
        private int _intPageIndex;
        public EventPagingArg(int PageIndex)
        {
            _intPageIndex = PageIndex;
        }
    }
}
