using System.Configuration;
using System.Data;
using System.Data.OleDb;

namespace Justec.Alcohol.Pulse.Utils
{
    public class AccessDBHelper
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private string connectionString;

        /// <summary>
        /// 存储数据库连接
        /// </summary>
        protected OleDbConnection Connection;

        /// <summary>
        /// 默认数据库连接
        /// </summary>
        public AccessDBHelper()
        {
            string connStr;
            connStr = ConfigurationManager.AppSettings["AccessDBFile"].ToString();
            connectionString = connStr;
            Connection = new OleDbConnection(connectionString);
        }

        /// <summary>
        /// 自定义数据库连接
        /// </summary>
        /// <param name="connStr"></param>
        public AccessDBHelper(string connStr)
        {
            connectionString = connStr;
            Connection = new OleDbConnection(connectionString);
        }

        public string ConnectionString
        {
            get
            {
                return connectionString;
            }
        }

        /// <summary>
        /// 执行无返回结果的SQL语句，例如增删改
        /// </summary>
        /// <param name="strSQL">执行的SQL语句</param>
        /// <returns></returns>
        public bool ExecuteSQL(string strSQL)
        {
            bool resultState = false;

            Connection.Open();
            OleDbTransaction dbTransaction = Connection.BeginTransaction();
            OleDbCommand dbCommand = new OleDbCommand(strSQL, Connection, dbTransaction);

            try
            {
                dbCommand.ExecuteNonQuery();
                dbTransaction.Commit();
                resultState = true;
            }
            catch
            {
                dbTransaction.Rollback();
                resultState = false;
            }
            finally
            {
                Connection.Close();
            }
            return resultState;
        }

        /// <summary>
        /// 执行SQL语句返回DataReader
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        private OleDbDataReader ReturnDataReader(string strSQL)
        {
            Connection.Open();
            OleDbCommand dbCommand = new OleDbCommand(strSQL, Connection);
            OleDbDataReader dbDataReader = dbCommand.ExecuteReader();
            Connection.Close();

            return dbDataReader;
        }

        public DataSet ReturnDataSet(string strSQL)
        {
            Connection.Open();
            DataSet dataSet = new DataSet();
            OleDbDataAdapter dbDataAdapter = new OleDbDataAdapter(strSQL, Connection);
            dbDataAdapter.Fill(dataSet, "objDataSet");

            Connection.Close();
            return dataSet;
        }

    }
}
