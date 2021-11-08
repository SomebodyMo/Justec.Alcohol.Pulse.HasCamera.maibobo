using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justec.Alcohol.Pulse.Model
{
    /// <summary>
    /// 酒精血压数据
    /// </summary>
    public class AlcPluData
    {
        /// <summary>
        /// ID 编号
        /// </summary>
        public string PID { get; set; }
        /// <summary>
        /// Name 用户姓名
        /// </summary>
        public string UseName { get; set; }
        /// <summary>
        /// JobNumber 工号
        /// </summary>
        public string JobNumber { get; set; }
        /// <summary>
        /// DeptId 用户所在单位
        /// </summary>
        public string DeptId { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>

        public string DeptName { get; set; }
        /// <summary>
        /// 身份
        /// </summary>
        public string Identity { get; set; }
        /// <summary>
        /// 上传时间
        /// </summary>
        public string SendTime { get; set; }
        /// <summary>
        /// 酒精浓度
        /// </summary>
        public string AlcoholStrength { get; set; }
        /// <summary>
        /// 收缩压
        /// </summary>
        public string Sbp { get; set; }
        /// <summary>
        /// 舒张压
        /// </summary>
        public string Dbp { get; set; }
        /// <summary>
        /// 脉搏
        /// </summary>
        public string Pulsess { get; set; }
        /// <summary>
        /// 吹气照片
        /// </summary>
        public string BlodPhoto { get; set; }
    }
}
