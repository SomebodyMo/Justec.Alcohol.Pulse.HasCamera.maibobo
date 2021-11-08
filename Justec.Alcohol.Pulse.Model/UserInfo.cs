using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justec.Alcohol.Pulse.Model
{
    /// <summary>
    /// 用户信息类
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 标识符
        /// </summary>
        public string GID { get; set; }
        /// <summary>
        /// 工号
        /// </summary>
        public string JobNumber { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }
        /// <summary>
        /// 部门id
        /// </summary>

        public string DeptId { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>

        public string DeptName { get; set; }
        /// <summary>
        /// 是否有指纹
        /// </summary>
        public string HasFingerFeature { get; set; }
        /// <summary>
        /// 指纹数据
        /// </summary>

        public string FingerFeature { get; set; }
        /// <summary>
        /// 是否有面部数据
        /// </summary>

        public string HasFaceFeature { get; set; }
        /// <summary>
        /// 面部数据
        /// </summary>

        public string FaceFeature { get; set; }
    }
}
