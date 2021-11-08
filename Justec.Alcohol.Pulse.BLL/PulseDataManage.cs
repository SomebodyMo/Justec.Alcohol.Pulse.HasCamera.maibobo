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
    public class PulseDataManage
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        readonly string connectingStr = $"data source={SqliteHelper.dbPath}";
        /// <summary>
        /// 查询检测记录总数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetHistoryCountBy(string strWhere)
        {
            string commStr = $"select count(1) from AlcPluData h where 1=1 ";
            commStr += strWhere;
            SQLiteCommand cmd = new SQLiteCommand(commStr);
            object result = SqliteHelper.ExecuteScalar(connectingStr, cmd);
            return Convert.ToInt32(result);
        }

        public int maxPid()
        {
            string commStr = $"select t.PID from( SELECT * from AlcPluData order by SendTime desc) t limit 1 ";
            SQLiteCommand cmd = new SQLiteCommand(commStr);
            object result = SqliteHelper.ExecuteScalar(connectingStr, cmd);
            string results = Convert.ToString(result);
            if (string.IsNullOrEmpty(results))
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(results);
            }
        }

        /// <summary>
        /// 查询检测记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetHistoryData(string strWhere, int pageSize, int pageIndex)
        {
            StringBuilder strBuilder = new StringBuilder($"select  h.*,d.DEPTNAME,u.FaceFeature from  AlcPluData h  inner join TbDept d on h.DeptId=d.DEPTID " +
                $" inner join TbUser u on h.JobNumber = u.JobNumber where 1=1 ");
            if (!string.IsNullOrWhiteSpace(strWhere))
            {
                strBuilder.Append(strWhere);
            }
            strBuilder.Append($" order by h.SendTime desc limit {pageSize} offset {(pageIndex - 1) * pageSize}"); //分页 
            string strSql = strBuilder.ToString();
            DataTable historyTable = SqliteHelper.ExecuteReaderToTable(connectingStr, strSql, CommandType.Text);
            return historyTable;
        }
        /// <summary>
        /// 检测记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetHistoryDataBy(string strWhere)
        {
            StringBuilder strBuilder = new StringBuilder($"select  h.*,d.DEPTNAME from  AlcPluData h  inner join TbDept d on h.DeptId=d.DEPTID where 1=1");
            if (!string.IsNullOrWhiteSpace(strWhere))
            {
                strBuilder.Append(strWhere);
            }
            string strSql = strBuilder.ToString();
            DataTable historyTable = SqliteHelper.ExecuteReaderToTable(connectingStr, strSql, CommandType.Text);

            return historyTable;
        }

        /// <summary>
        /// 新增检测记录
        /// </summary>
        /// <param name="historyInfo"></param>
        /// <returns></returns>
        public int InsertPulseHistory(AlcPluData alcPluData)
        {
            if (alcPluData == null) return 0;
            string commStr = "insert into AlcPluData(UseName,JobNumber,DeptId,Identity,SendTime,AlcoholStrength,Sbp,Dbp,Pulses,BlodPhoto) " +
                $"values('{alcPluData.UseName}','{alcPluData.JobNumber}','{alcPluData.DeptId}','{alcPluData.Identity}'," +
                $"'{alcPluData.SendTime}','{alcPluData.AlcoholStrength}','{alcPluData.Sbp}','{alcPluData.Dbp}','{alcPluData.Pulsess}','{alcPluData.BlodPhoto}')";
            SQLiteCommand cmd = new SQLiteCommand(commStr);
            return SqliteHelper.ExecuteNonQuery(connectingStr, cmd);
        }
    }
}
