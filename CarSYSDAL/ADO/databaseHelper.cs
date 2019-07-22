using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CarSYSDAL
{ 
    public  class databaseHelper
    {
        public static readonly string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["CarSYS"].ConnectionString;
     

        #region ExecutrNoQuert 增、删、改
        /// <summary>
        /// 增、删、改操作，返回受影响的行数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql)
        {
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 执行SQL命令
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="commandType">命令类型</param>
        /// <param name="commandText">SQL语句/参数化SQL语句/储存过程名</param>
        /// <param name="commandParameters">参数</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQuery(string connectionString,CommandType commandType,string commandText,params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn=new SqlConnection())
            {
                PrepareCommand(cmd, commandType, conn, commandText, commandParameters);

                int val = cmd.ExecuteNonQuery();

                return val;
            }
        }

        /// <summary>
        /// 执行SQL储存过程
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="spName">储存过程名</param>
        /// <param name="parameterValues">对象参数</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQuery(string connectionString,string spName,params object[] parameterValues)
        {
            using (SqlConnection conn=new SqlConnection())
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn, spName, parameterValues);

                var val = cmd.ExecuteNonQuery();

                return val;
            }

        }

        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, SqlParameter[] cmdParaters)
        {
            using (SqlConnection conn=new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, cmdType, conn, cmdText, cmdParaters);
                int val = cmd.ExecuteNonQuery();
                return val;
            }
        }

        public static int ExecuteNonQuery(string spName,params object[] parameterValues)
        {
            using (SqlConnection conn=new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn, spName, parameterValues);
                int val = cmd.ExecuteNonQuery();
                return val;
            }
        }

        //执行带有输出参数的储存过程
        public static int ExecuteNonQuery(SqlCommand cmd,CommandType cmdType,string spName,SqlParameter[] cmdParamerValues)
        {
            using (SqlConnection conn=new SqlConnection(connStr))
            {
                PrepareCommand(cmd, cmdType, conn, spName, cmdParamerValues);
                int val = cmd.ExecuteNonQuery();
                return val;
            }
        }



        #endregion

        #region ExecuteReader  

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="commandType">命令类型</param>
        /// <param name="commandText">SQL语句/参数化的SQL语句/储存过程名</param>
        /// <param name="commandParameter">参数</param>
        /// <returns>返回SqlDataReader对象</returns>
        public static SqlDataReader ExecuteReader(string connectionString,CommandType commandType,string commandText,params SqlParameter[] commandParameter)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, commandType, conn, commandText, commandParameter);

                SqlDataReader val = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return val;
            }
            catch (Exception)
            {
                conn.Close();
                throw;
            }
        }

        /// <summary>
        /// 执行SQL储存过程
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="spName">储存过程参数</param>
        /// <param name="parameterValues">对象参数</param>
        /// <returns>返回 SqlDataReader对象</returns>
        public static SqlDataReader ExecuteReader(string connectionString,string spName,params object[] parameterValues)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn, spName, parameterValues);

                SqlDataReader val = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return val;
            }
            catch (Exception)
            {
                conn.Close();
                throw;
            }
        }

        public static SqlDataReader ExecuteReader(CommandType cmdType,string cmdText,SqlParameter[] cmdParameters)
        {
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, cmdType, conn, cmdText, cmdParameters);
                SqlDataReader val = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return val;
            }
            catch (Exception)
            {
                conn.Close();
                throw;
            }         
        }

        public static SqlDataReader ExecuteReader(string spName,params object[] parameterValues)
        {
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn, spName, parameterValues);
                SqlDataReader val = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return val;
            }
            catch (Exception)
            {
                conn.Close();
                throw;
            }
        }

        #endregion

        #region ExecuteScalar 返回第一行第一列

        /// <summary>
        /// 返回第一行第一列
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteScalar(string sql)
        {
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql,conn);
                object obj = cmd.ExecuteScalar();
                if (obj!=null)
                {
                    return Convert.ToInt32(obj);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public static object ExecuteScalar(string connectionString,CommandType commandType,string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn=new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, commandType, conn, commandText, commandParameters);

                object val = cmd.ExecuteScalar();
                return val;
            }
        }

        public static object ExecuteScalar(string connectionString,string spName,params object[] parameterValues)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn=new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, spName, parameterValues);
                object val = cmd.ExecuteScalar();
                return val;
            }
        }

        public static object ExecuteScalar(CommandType cmdType,string cmdText,params SqlParameter[] cmdParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn=new SqlConnection(connStr))
            {
                PrepareCommand(cmd, cmdType, conn, cmdText,cmdParameters);
                object val = cmd.ExecuteScalar();
                return val;
            }
        }

        public static object ExecuteScalar(string spName,params object[] cmdParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn=new SqlConnection(connStr))
            {
                PrepareCommand(cmd, conn, spName, cmdParameters);
                object val = cmd.ExecuteScalar();
                return val;
            }

        }

        #endregion

        #region ExecuteDataSet 数据集
        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string sql)
        {
            SqlConnection conn = new SqlConnection(connStr);
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                sda.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取数据集填充的DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string sql)
        {
            SqlConnection conn = new SqlConnection(connStr);
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                sda.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }

        public static DataSet ExecuteDataSet(string connectionString,CommandType commandTyep,string commandText,params SqlParameter[] commandParameters)
        {
            using (SqlConnection conn=new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, commandTyep, conn,commandText, commandParameters);

                using (SqlDataAdapter sda=new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    return ds;
                }
            }
        }

        public static DataSet ExecuteDataSet(string connectionString,string spName,params object[] parameterValues)
        {
            using (SqlConnection conn=new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn, spName, parameterValues);
                using (SqlDataAdapter sda=new SqlDataAdapter())
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    return ds;
                }
            }
        }

        public static DataSet ExecuteDataSet(CommandType cmdType,string cmdText,params SqlParameter[] cmdParameters)
        {
            using (SqlConnection conn=new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, cmdType, conn, cmdText, cmdParameters);
                using (SqlDataAdapter sda=new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    return ds;
                }
            }
        }

        public static DataSet ExecuteDataSet(string spName,params object[] parameterValues)
        {
            using (SqlConnection conn=new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn, spName, parameterValues);
                using (SqlDataAdapter sda=new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    return ds;
                }
            }
        }

        //执行含有返回值的储存过程
        public static DataSet ExecuteDataSet(SqlCommand cmd, CommandType cmdType, string spName, SqlParameter[] cmdParams)
        {
            using (SqlConnection conn=new SqlConnection(connStr))
            {
                PrepareCommand(cmd, cmdType, conn, spName, cmdParams);
                using (SqlDataAdapter sda=new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    return ds;
                }
            }
        }

        #endregion

        #region 设置一个等待执行的SqlCommand对象

        /// <summary>
        /// 设置一个等待执行的SqlCommand对象
        /// </summary>
        /// <param name="cmd">SqlCommand对象，不允许为空</param>
        /// <param name="commandType">命令类型</param>
        /// <param name="conn">SqlConnection对象，不允许为空</param>
        /// <param name="commandText">sql语句</param>
        /// <param name="cmdParams">sqlParameter对象，允许为空对象</param>
        private static void PrepareCommand(SqlCommand cmd, CommandType commandType,SqlConnection conn,string commandText,SqlParameter[] cmdParams)
        {
            //打开连接
            if (conn.State!=ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            if (cmdParams!=null)
            {
                foreach (SqlParameter para in cmdParams)
                {
                    cmd.Parameters.Add(para);
                }
            }
        }

        /// <summary>
        /// 设置一个等待储存过程执行的SqlCommand对象
        /// </summary>
        /// <param name="cmd">SqlCommand对象，不允许为空</param>
        /// <param name="conn">SqlConnection对象，不允许为空</param>
        /// <param name="spName">储存过程名称</param>
        /// <param name="parmeterValues">不定个数的储存过程参数，允许为空</param>
        private static void PrepareCommand(SqlCommand cmd,SqlConnection conn,string spName,params object[] parmeterValues)
        {
            //打开链接
            if (conn.State!=ConnectionState.Open)
            {
                conn.Open();
            }
            //设置SqlCommand对象
            cmd.Connection = conn;
            cmd.CommandText = spName;
            cmd.CommandType = CommandType.StoredProcedure;

            //获取储存过程参数
            SqlCommandBuilder.DeriveParameters(cmd);

            //移除RETURN_VALUE参数
            cmd.Parameters.RemoveAt(0);

            //设置参数
            if (parmeterValues != null)
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
