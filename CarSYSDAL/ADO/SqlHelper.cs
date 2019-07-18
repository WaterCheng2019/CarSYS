using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CarSYSDAL.ADO
{
    /// <summary>
    /// SQL 辅助类
    /// </summary>
   public abstract class SqlHelper
    {

        public static readonly string connctionString = System.Configuration.ConfigurationManager.ConnectionStrings[""].ConnectionString;

        #region ExecuteNonQuery
        /// <summary>
        /// 执行SQl命令
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="commandType">命令类型</param>
        /// <param name="commandText">语句/参数化sql语句/储存过程名</param>
        /// <param name="commandParameters">参数</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQuery(string connectionString,CommandType commandType, string commandText,params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn=new SqlConnection(connctionString))
            {
                PrepareCommand(cmd, commandType, conn, commandText, commandParameters);
                int val = cmd.ExecuteNonQuery();

                return val;
            }
        }

        /// <summary>
        /// 执行Sql Server储存过程
        /// </summary>
        /// <param name="connctionString">连接字符串</param>
        /// <param name="spName">储存过程名</param>
        /// <param name="parameterValues">对象参数</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQuery(string connctionString,string spName,params object[] parameterValues)
        {
            using (SqlConnection conn=new SqlConnection(connctionString))
            {
                SqlCommand cmd = new SqlCommand();

                PrepareCommand(cmd, conn, spName, parameterValues);
                int val = cmd.ExecuteNonQuery();

                return val;
            }
        }
        #endregion

        #region ExcuteReader
        /// <summary>
        /// 执行sql命令
        /// </summary>
        /// <param name="connctionString">连接字符串</param>
        /// <param name="commandType">命令类型</param>
        /// <param name="commandText">sql语句/参数化SQL语句/储存过程名</param>
        /// <param name="commandParameters">参数</param>
        /// <returns>SqlDdataReader对象</returns>
        public static SqlDataReader ExcuteReader(string connctionString,CommandType commandType,string commandText,params SqlParameter[] commandParameters)
        {
            SqlConnection conn = new SqlConnection();

            try
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, commandType, conn, commandText, commandParameters);

                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return rdr;
            }
            catch 
            {
                conn.Close();
                throw;
            }

        }


        /// <summary>
        /// 执行sql Server 储存过程
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="spName">储存过程名</param>
        /// <param name="parameterValues">对象参数</param>
        /// <returns>SqlDdataReader对象</returns>
        public static SqlDataReader ExcuteReader(string connectionString,string spName,params object[] parameterValues)
        {
            SqlConnection conn = new SqlConnection(connctionString);
            try
            {
                SqlCommand cmd = new SqlCommand();

                PrepareCommand(cmd, conn, spName, parameterValues);

                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return rdr;


            }
            catch 
            {
                conn.Close();
                throw;
            }
        }
        #endregion

        #region ExecuterDataset

        /// <summary>
        /// 执行sql Server储存过程
        /// 注意：不能执行有out参数的储存过程
        /// </summary>
        /// <param name="connection">连接字符串</param>
        /// <param name="spName">储存过程名</param>
        /// <param name="paramterValues">对象参数</param>
        /// <returns>DataSet参数+</returns>
        public static DataSet ExecuteDataset(string connection,string spName,params object[] paramterValues)
        {
            using (SqlConnection conn=new SqlConnection(connctionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn, spName, paramterValues);

                using (SqlDataAdapter da=new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    return ds;
                }
            }
        }

        /// <summary>
        /// 执行sql命令
        /// </summary>
        /// <param name="conntionStrig">连接字符串</param>
        /// <param name="commandType">命令类型</param>
        /// <param name="commandText">sql语句/参数化sql语句/储存过程名</param>
        /// <param name="commandParameters">参数</param>
        /// <returns>DataSet对象</returns>
        public static DataSet ExecuteDataset(string conntionStrig,CommandType commandType,string commandText,params  SqlParameter[] commandParameters)
        {
            using (SqlConnection conn=new SqlConnection(connctionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, commandType, conn, commandText, commandParameters);

                using (SqlDataAdapter sda=new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    return ds;
                }
            }
                    
        }


        #endregion

        #region ExecuteScalar
        /// <summary>
        /// 执行sql命令
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="commandType">命令类型</param>
        /// <param name="commandText">sql语句/参数化sql语句/储存过程名</param>
        /// <param name="commandParameters">参数</param>
        /// <returns>执行对象结果</returns>
        public static object ExecuteScalar(string connectionString,CommandType commandType,string commandText,params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn=new SqlConnection(connctionString))
            {
                PrepareCommand(cmd, commandType, conn, commandText, commandParameters);

                object val = cmd.ExecuteScalar();


                return val;
            }

        }
        /// <summary>
        /// 执行sql储存过程
        /// </summary>
        /// <param name="connnectionString">连接字符串</param>
        /// <param name="spNamem">储存过程名</param>
        /// <param name="parameterValues">对象参数</param>
        /// <returns>执行结果</returns>
        public static object ExecuteScalar(string connnectionString,string spNamem,params object[] parameterValues)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn=new SqlConnection(connctionString))
            {
                PrepareCommand(cmd, conn, spNamem, parameterValues);
                object val = cmd.ExecuteScalar();
                return val;
            }
                    
        }

        #endregion


        #region 设置一个等待执行的SqlCommand对象
        /// <summary>
        /// 设置一个等待执行的SqlCommand对象
        /// </summary>
        /// <param name="cmd">sqlCommand对象，不允许空对象</param>
        /// <param name="commandType">sqlConnection对象,不允许为空对象</param>
        /// <param name="commandText">sql 语句</param>
        /// <param name="cmdParms">sqlParamerters 对象，允许为空对象</param>
        private static void PrepareCommand(SqlCommand cmd, CommandType commandType, SqlConnection conn,string commandText , SqlParameter[] cmdParms)
        {
            //打开链接
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            cmd.Connection = conn;
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            if (cmdParms!=null)
            {
                foreach (SqlParameter parm in cmdParms)
                {
                    cmd.Parameters.Add(parm);
                }
            }

        }


        /// <summary>
        /// 设置一个等待执行储存过程的SqlCommand对象
        /// </summary>
        /// <param name="cmd">sqlCommand对象，不允许空对象</param>
        /// <param name="conn">sqlConnextion对象，不允许空对象</param>
        /// <param name="spName">SQL 语句</param>
        /// <param name="parmeterValues">不定个数的储存过程参数，允许为空</param>
        private static void PrepareCommand(SqlCommand cmd,SqlConnection conn,string spName,params object[] parmeterValues)
        {
            //打开链接
            if (conn.State!=ConnectionState.Open)
            {
                conn.Open();
            }
            //设置sqlCommand对象
            cmd.Connection = conn;
            cmd.CommandText = spName;
            cmd.CommandType = CommandType.StoredProcedure;

            //获取储存过程参数
            SqlCommandBuilder.DeriveParameters(cmd);

            //移除Return_Value 参数
            cmd.Parameters.RemoveAt(0);

            //设置参数
            if (parmeterValues!=null)
            {
                for (int i = 0; i < cmd.Parameters.Count; i++)
                {
                    cmd.Parameters[i].Value = parmeterValues[i];
                }
            }


        }
        #endregion




    }
}
