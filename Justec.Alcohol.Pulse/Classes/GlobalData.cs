using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justec.Alcohol.Pulse.Classes
{
    /// <summary>
    /// 全局变量类
    /// </summary>
    public static class GlobalData
    {
        public static readonly string[] TableColumnNames = { "姓名", "工作单位", "工号", "RFID", "有无指纹", "指纹特征数据", "有无人脸", "人脸特征数据" };
        public static readonly string[] UserColumnNames = { "全选", "序号", "姓名", "工作单位", "工号", "RFID", "指纹特征数据", "人脸特征数据", "操作" };
        public static readonly string[] HistoryColumnNames = { "序号", "酒精浓度", "日期时间", "设备型号", "用户名", "工作单位", "工号", "身份验证", "测试结果" };
        public static User user;

        /// <summary>
        /// 当前登录用户
        /// </summary>
        public struct User
        {
            public string JobNo;
            public string Name;
        }

        public static string InspectionTitle = "干部巡检";

        /// <summary>
        /// 软件当前选择语言
        /// </summary>
        public static EnumLanguage Language { get; set; }

    }

    /// <summary>
    /// 全局定义常量
    /// </summary>
    public enum EnumGlobConst : int
    {
        [Description("框架最大长度")]
        FRAME_MAX_LEN = 64,
        [Description("框架最小长度")]
        FRAME_MIN_LEN = 6,
        [Description("串口缓存大小")]
        UART_BUFF = 4096,
        [Description("分隔符")]
        DIVIDER_NUM = 50,
        [Description("指纹最大数量")]
        FINGER_MAX_NUM = 80000,
        [Description("通信最大错误")]
        COMM_MAX_ERROR = 3,
        [Description("数据字段编号")]
        DATA_FIELD_NUM = 6,
        [Description("面部结构字段编号")]
        FACE_FRAME_FIELD_NUM = 3,
        [Description("信息字段编号")]
        INFO_FIELD_NUM = 3,
        [Description("面部数据长度")]
        FACE_LENGHT = 20000,
        [Description("姓名最大长度")]
        NAME_MAX_LEN = 12,
        [Description("公司最大长度")]
        COMPANY_MAX_LEN = 32,
        [Description("上传信息长度")]
        UPLOAD_INFO_LEN = FRAME_MAX_LEN - FRAME_MIN_LEN - 2 - 2,
    };

    public enum EnumLanguage
    {
        [Description("中文")]
        Chinese,
        [Description("英文")]
        English
    }

    public enum EnumFrmType
    {
        [Description("编辑")]
        Edit,
        [Description("添加")]
        Add
    }
}
