using Justec.Alcohol.Pulse.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justec.Alcohol.Pulse.BLL
{
    public class DeptManage
    {
        /// <summary>
        /// 查询所有部门
        /// </summary>
        /// <returns></returns>
        public DataTable GetDeptData()
        {
            DataTable dept = SqliteHelper.SelectTable("select DEPTID,DEPTNAME from tbdept");
            return dept;
        }

        public DeptInfo getDeptInfoByDeptId(string deptId)
        {
            string commStr = $"select DEPTID,DEPTNAME from tbdept where DEPTID='{deptId}'";
            string connectingStr = "data source=" + SqliteHelper.dbPath;
            SQLiteCommand cmd = new SQLiteCommand(commStr);
            DataSet ds = SqliteHelper.ExecuteDataSet(connectingStr, cmd);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DeptInfo info = new DeptInfo
                {
                    DEPTID = ds.Tables[0].Rows[0]["DEPTID"].ToString(),
                    DEPTNAME = ds.Tables[0].Rows[0]["DEPTNAME"].ToString()
                };
                return info;
            }
            return null;
        }
    }
}
