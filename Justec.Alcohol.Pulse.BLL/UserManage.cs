using Justec.Alcohol.Pulse.Model;
using Justec.Alcohol.Pulse.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justec.Alcohol.Pulse.BLL
{
    public class UserManage
    {

        /// <summary>
        /// 是否存在用户
        /// </summary>
        /// <param name="company"></param>
        /// <param name="jobNo"></param>
        /// <returns>否false/是true</returns>
        public bool UserIsExistOrNo(string jobNumber)
        {
            string commStr = $"select * from TbUser where JobNumber='{jobNumber}'";
            string connectingStr = "data source=" + SqliteHelper.dbPath;
            SQLiteCommand cmd = new SQLiteCommand(commStr);
            DataSet ds = SqliteHelper.ExecuteDataSet(connectingStr, cmd);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else return false;
        }


        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="jobNo"></param>
        /// <returns></returns>
        public UserInfo GetUserInfoBy(string jobNumber)
        {
            string commStr = $"select u.*,d.DEPTNAME from Tbuser u inner join TbDept d on u.DeptId=d.DEPTID where u.JobNumber='{jobNumber}'";
            string connectingStr = "data source=" + SqliteHelper.dbPath;
            SQLiteCommand cmd = new SQLiteCommand(commStr);
            DataSet ds = SqliteHelper.ExecuteDataSet(connectingStr, cmd);
            if (ds.Tables[0].Rows.Count > 0)
            {
                UserInfo info = new UserInfo
                {
                    GID = ds.Tables[0].Rows[0]["GID"].ToString(),
                    JobNumber = ds.Tables[0].Rows[0]["JobNumber"].ToString(),
                    UserName = ds.Tables[0].Rows[0]["UserName"].ToString(),
                    Pwd = ds.Tables[0].Rows[0]["Pwd"].ToString(),
                    DeptId = ds.Tables[0].Rows[0]["DeptId"].ToString(),
                    DeptName = ds.Tables[0].Rows[0]["DEPTNAME"].ToString(),
                    HasFingerFeature = ds.Tables[0].Rows[0]["HasFingerFeature"].ToString(),
                    FingerFeature = ds.Tables[0].Rows[0]["FingerFeature"].ToString(),
                    HasFaceFeature = ds.Tables[0].Rows[0]["HasFaceFeature"].ToString(),
                    FaceFeature = ds.Tables[0].Rows[0]["FaceFeature"].ToString(),
                };
                return info;
            }
            return null;
        }

        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <returns></returns>
        public UserInfo GetUserInfoByGid(int Gid)
        {
            string commStr = $"select u.*,d.DEPTNAME from Tbuser u inner join TbDept d on u.DeptId=d.DEPTID where u.GID='{Gid}'";
            string connectingStr = "data source=" + SqliteHelper.dbPath;
            SQLiteCommand cmd = new SQLiteCommand(commStr);
            DataSet ds = SqliteHelper.ExecuteDataSet(connectingStr, cmd);
            if (ds.Tables[0].Rows.Count > 0)
            {
                UserInfo info = new UserInfo
                {
                    GID = ds.Tables[0].Rows[0]["GID"].ToString(),
                    JobNumber = ds.Tables[0].Rows[0]["JobNumber"].ToString(),
                    UserName = ds.Tables[0].Rows[0]["UserName"].ToString(),
                    Pwd = ds.Tables[0].Rows[0]["Pwd"].ToString(),
                    DeptId = ds.Tables[0].Rows[0]["DeptId"].ToString(),
                    DeptName = ds.Tables[0].Rows[0]["DEPTNAME"].ToString(),
                    HasFingerFeature = ds.Tables[0].Rows[0]["HasFingerFeature"].ToString(),
                    FingerFeature = ds.Tables[0].Rows[0]["FingerFeature"].ToString(),
                    HasFaceFeature = ds.Tables[0].Rows[0]["HasFaceFeature"].ToString(),
                    FaceFeature = ds.Tables[0].Rows[0]["FaceFeature"].ToString(),
                };
                return info;
            }
            return null;
        }
        /// <summary>
        /// 查询用户总数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static int GetUserCountBy(string strWhere)
        {
            string commStr = $"select count(1) from TbUser u inner join TbDept d on u.DeptId=d.DEPTID where 1=1 ";
            commStr += strWhere;
            string connectingStr = $"data source={SqliteHelper.dbPath}";
            SQLiteCommand cmd = new SQLiteCommand(commStr);
            object result = SqliteHelper.ExecuteScalar(connectingStr, cmd);
            return Convert.ToInt32(result);
        }

        /// <summary>
        /// 登录密码验证
        /// </summary>
        /// <param name="jobMumber"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool CheckUserPwd(string jobMumber, string pwd)
        {
            string commStr = $"select * from TbUser where JobNumber='{jobMumber}' and Pwd='{pwd}'";
            string connectingStr = $"data source={SqliteHelper.dbPath}";
            SQLiteCommand cmd = new SQLiteCommand(commStr);
            DataSet ds = SqliteHelper.ExecuteDataSet(connectingStr, cmd);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else return false;
        }

        /// <summary>
        /// 分页查询用户数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserDataTable(string strWhere, int pageSize, int pageIndex)
        {
            StringBuilder strBuilder = new StringBuilder("select u.*,d.DEPTNAME from TbUser u inner join TbDept d on u.DeptId=d.DEPTID where 1=1 ");
            if (!string.IsNullOrWhiteSpace(strWhere))
            {
                strBuilder.Append(strWhere);
            }
            //strBuilder.Append($" order by u.GID limit {pageSize} offset {(pageIndex - 1) * pageSize}");
            strBuilder.Append($" limit {pageSize} offset {(pageIndex - 1) * pageSize}"); // 
            string strSql = strBuilder.ToString();
            string connectingStr = $"data source={SqliteHelper.dbPath}";
            DataTable userTable = SqliteHelper.ExecuteReaderToTable(connectingStr, strSql, CommandType.Text);
            return userTable;
        }


        /// <summary>
        /// 新增检测记录
        /// </summary>
        /// <param name="historyInfo"></param>
        /// <returns></returns>
        public int InsertUserInfo(UserInfo userInfo)
        {
            if (userInfo == null) return 0;
            string connectingStr = $"data source={SqliteHelper.dbPath}";
            string commStr = "insert into TbUser(UserName,JobNumber,DeptId,HasFingerFeature,FingerFeature,HasFaceFeature,FaceFeature) " +
                $"values('{userInfo.UserName}','{userInfo.JobNumber}','{userInfo.DeptId}','{userInfo.HasFingerFeature}','{userInfo.FingerFeature}'," +
                $"'{userInfo.HasFaceFeature}','{userInfo.FaceFeature}')";
            SQLiteCommand cmd = new SQLiteCommand(commStr);
            return SqliteHelper.ExecuteNonQuery(connectingStr, cmd);
        }

        /// <summary>
        /// 获取全部记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllUserInfo()
        {
            StringBuilder strBuilder = new StringBuilder("select u.*,d.DEPTNAME from TbUser u inner join TbDept d on u.DeptId=d.DEPTID where 1=1 ");
            string strSql = strBuilder.ToString();
            string connectingStr = $"data source={SqliteHelper.dbPath}";
            DataTable userTable = SqliteHelper.ExecuteReaderToTable(connectingStr, strSql, CommandType.Text);
            return userTable;
        }
    }
}
