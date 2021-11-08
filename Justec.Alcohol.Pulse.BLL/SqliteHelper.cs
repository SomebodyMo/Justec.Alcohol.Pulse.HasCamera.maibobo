using Justec.Alcohol.Pulse.Model;
using Justec.Alcohol.Pulse.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justec.Alcohol.Pulse.BLL
{
    public class SqliteHelper
    {
        public static readonly string dbPath = AppDomain.CurrentDomain.BaseDirectory + "JustecDB.db";

        #region 数据库操作处理
        /// <summary>
        /// 创建数据库文件
        /// </summary>
        /// <param name="dbPath">数据库文件路径及名称</param>
        /// <returns>新建成功，返回true，否则返回false</returns>
        public static bool CreateDBFile()
        {
            try
            {
                SQLiteConnection.CreateFile(dbPath);
                //测酒使用的表
                string createTb1Str = @"CREATE TABLE TbUser (
    UserName             VARCHAR NOT NULL,
    JobNumber         VARCHAR NOT NULL,
    GID              INTEGER NOT NULL
                             PRIMARY KEY AUTOINCREMENT,
    HasFingerFeature VARCHAR NOT NULL,
    FingerFeature    VARCHAR NOT NULL,
    HasFaceFeature   VARCHAR NOT NULL,
    FaceFeature      VARCHAR NOT NULL,
    Pwd              VARCHAR DEFAULT (123456),
    DeptId           VARCHAR NOT NULL
);";

                string createTb2Str = @"
CREATE TABLE TbDept (
    DEPTID     VARCHAR PRIMARY KEY
                       NOT NULL,
    DEPTNAME   VARCHAR
);";
                //测脉搏使用的表
                string createTb3Str = @"CREATE TABLE AlcPluData (
    PID        INTEGER NOT NULL
                             PRIMARY KEY AUTOINCREMENT,
    UseName     VARCHAR,
    JobNumber   VARCHAR,
    DeptId    VARCHAR,
    Identity    VARCHAR,
    SendTime    VARCHAR,
    AlcoholStrength VARCHAR,
    Sbp         VARCHAR,
    Dbp         VARCHAR,
    Pulses      VARCHAR,
    BlodPhoto   VARCHAR
    );";
                string createDept = @"insert into TbDept(DEPTID,DEPTNAME) values('0','全部');";
                string createDept1 = @"insert into TbDept(DEPTID,DEPTNAME) values('1','Justec');";
                OperationTable(createTb1Str + createTb2Str + createTb3Str +  createDept + createDept1);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("新建数据库文件" + dbPath + "失败：" + ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        /// <summary>
        /// 操作数据库表(创建,删除,更新)
        /// </summary>
        /// <param name="dbPath"></param>
        /// <param name="tableName"></param>
        public static int OperationTable(string commandStr)
        {
            int result = 0;
            try
            {
                SQLiteConnection sqliteConn = new SQLiteConnection("data source=" + dbPath);
                if (sqliteConn.State != ConnectionState.Open)
                {
                    sqliteConn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(commandStr, sqliteConn);
                    result = cmd.ExecuteNonQuery();
                }
                sqliteConn.Close();
                return result;
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog("SqliteHelper.OperationTable执行错误: " + ex.Message);
                return result;
            }
        }
        /// 执行数据库查询，返回DataTable对象
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="commandText">执行语句或存储过程名</param>
        /// <param name="commandType">执行类型</param>
        /// <returns>SqlDataReader对象</returns>
        public static DataTable ExecuteReaderToTable(string connectionString, string commandText, CommandType commandType)
        {
            DbDataReader reader = null;
            DataTable data = new DataTable();
            if (connectionString == null || connectionString.Length == 0)
                throw new ArgumentNullException("connectionString");
            if (commandText == null || commandText.Length == 0)
                throw new ArgumentNullException("commandText");

            SQLiteConnection conn = new SQLiteConnection(connectionString);
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteTransaction trans = null;
            PrepareCommand(cmd, conn, ref trans, false, commandType, commandText);
            try
            {
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                data.BeginLoadData();
                data.Load(reader);
                data.Constraints.Clear();
                data.EndLoadData();
                Debug.WriteLine("执行");
            }
            catch (Exception ex)
            {
                DataRow[] dr = data.GetErrors();
                throw ex;
            }
            return data;
        }

        /// <summary>
        /// 执行数据库操作(新增、更新或删除)
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="cmd">SqlCommand对象</param>
        /// <returns>所受影响的行数</returns>
        public static int ExecuteNonQuery(string connectionString, SQLiteCommand cmd)
        {
            int result = 0;
            if (connectionString == null || connectionString.Length == 0)
                throw new ArgumentNullException("connectionString");
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                SQLiteTransaction trans = null;

                PrepareCommand(cmd, con, ref trans, true, cmd.CommandType, cmd.CommandText);
                try
                {
                    result = cmd.ExecuteNonQuery();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    LogHelper.WriteErrorLog($"ExecuteNonQuery()执行错误: 1.错误信息 {ex.Message}\r\n 2.错误详情 { ex.StackTrace}");
                }
            }
            return result;
        }

        /// <summary>
        /// 查询表数据并返回DataTable
        /// </summary>
        /// <param name="dbPath"></param>
        /// <param name="sqlStr"></param>
        /// <returns></returns>
        public static DataTable SelectTable(string sqlStr)
        {
            if (!File.Exists(dbPath)) return null;
            DataTable dataTable = new DataTable();
            SQLiteConnection sqliteConn = new SQLiteConnection("data source=" + dbPath);
            if (sqliteConn.State != ConnectionState.Open)
            {
                sqliteConn.Open();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlStr, sqliteConn);
                adapter.Fill(dataTable);
            }
            sqliteConn.Close();
            return dataTable;
        }

        public static object ExecuteScalar(string connectionString, SQLiteCommand cmd)
        {
            object result = 0;
            if (connectionString == null || connectionString.Length == 0)
                throw new ArgumentNullException("connectionString");
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                SQLiteTransaction trans = null;
                PrepareCommand(cmd, con, ref trans, true, cmd.CommandType, cmd.CommandText);
                try
                {
                    result = cmd.ExecuteScalar();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            return result;
        }

        /// <summary>
        /// 执行数据库查询，返回DataSet对象
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="cmd">SqlCommand对象</param>
        /// <returns>DataSet对象</returns>
        public static DataSet ExecuteDataSet(string connectionString, SQLiteCommand cmd)
        {
            DataSet ds = new DataSet();
            SQLiteConnection con = new SQLiteConnection(connectionString);
            SQLiteTransaction trans = null;
            PrepareCommand(cmd, con, ref trans, false, cmd.CommandType, cmd.CommandText);
            try
            {
                SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
                sda.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd.Connection != null)
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                }
            }
            return ds;
        }

        #region  预处理Command对象,数据库链接,事务,需要执行的对象,参数等的初始化
        /// <summary>
        /// 预处理Command对象,数据库链接,事务,需要执行的对象,参数等的初始化
        /// </summary>
        /// <param name="cmd">Command对象</param>
        /// <param name="conn">Connection对象</param>
        /// <param name="trans">Transcation对象</param>
        /// <param name="useTrans">是否使用事务</param>
        /// <param name="cmdType">SQL字符串执行类型</param>
        /// <param name="cmdText">SQL Text</param>
        /// <param name="cmdParms">SQLiteParameters to use in the command</param>
        private static void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, ref SQLiteTransaction trans, bool useTrans, CommandType cmdType, string cmdText, params SQLiteParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (useTrans)
            {
                trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = trans;
            }


            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SQLiteParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
        #endregion

        #endregion
    }
}
