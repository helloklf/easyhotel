using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_DAL
{
    public class Task_DBHelper
    {

         SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlLink"].ConnectionString.ToString());

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public  void ConnOpen()
        {
            if (conn.State == ConnectionState.Closed)
            {
                try
                {
                    conn.Open();
                }
                catch { }
            }
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public  void ConnClose()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close(); conn.Dispose();
            }
        }


        /// <summary>
        /// 对连接执行 Transact-SQL 语句并返回受影响的行数。
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns>执行成功的行数</returns>
        public  int ExecuteNonQuery(string strSql, SqlParameter[] param)
        {
            int v = 0;SqlCommand comm=null;
            try
            {
                comm = new SqlCommand(strSql, conn);
                comm.Parameters.AddRange(param);
                ConnOpen();
                if (conn.State != ConnectionState.Open) { throw new Exception("数据库连接失败！"); }
                v = comm.ExecuteNonQuery();
            }
            finally
            {
                conn.Close(); comm.Dispose();
            }
            return v;
        }



        /// <summary>
        /// 对连接执行 Transact-SQL 语句并返回受影响的行数。 存储过程
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns>执行成功的行数</returns>
        public int ExecuteNonQueryProc(string strSql, params SqlParameter[] param)
        {
            int v = 0; SqlCommand comm =null;
            try
            {
                comm = new SqlCommand(strSql, conn); 
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddRange(param);
                ConnOpen();
                if (conn.State != ConnectionState.Open) { throw new Exception("数据库连接失败！"); }
                v = comm.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();comm.Dispose();
            }
            return v;
        }

        /// <summary>
        /// 得到查询数据的首行首列的值
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns>首行首列值</returns>
        public object ExecuteScalar(string strSql, params SqlParameter[] sqlp)
        {
            SqlCommand comm=null;
            object v = 0;
            try
            {
                comm= new SqlCommand(strSql, conn); comm.Parameters.AddRange(sqlp);
                ConnOpen();
                if (conn.State != ConnectionState.Open) { throw new Exception("数据库连接失败！"); }
                v = comm.ExecuteScalar();
            }
            finally
            {
                conn.Close(); comm.Dispose();
            }
            return v;
        }


        /// <summary>
        /// 获得一个数据阅读器
        /// </summary>
        /// <param name="strSql">SQL查询语句</param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string strSql, params SqlParameter[] sqlp)
        {
            SqlDataReader dr = null;
            SqlCommand comm = new SqlCommand(strSql, conn); comm.Parameters.AddRange(sqlp);
            ConnOpen();
            if (conn.State != ConnectionState.Open) { throw new Exception("数据库连接失败！"); }
            dr = comm.ExecuteReader();
            return dr;
        }

        /// <summary>
        /// 获得一个数据阅读器
        /// </summary>
        /// <param name="strSql">SQL查询语句</param>
        /// <returns></returns>
        public SqlDataReader ExecuteReaderProc(string strSql, params SqlParameter[] sqlp)
        {
            SqlDataReader dr = null;
            SqlCommand comm = new SqlCommand(strSql, conn); comm.Parameters.AddRange(sqlp); comm.CommandType = CommandType.StoredProcedure;
            ConnOpen();
            if (conn.State != ConnectionState.Open) { throw new Exception("数据库连接失败！"); }
            dr = comm.ExecuteReader();
            return dr;
        }

        /// <summary>
        /// 返回一个数据集对象
        /// </summary>
        /// <param name="strSql">查询语句</param>
        /// <returns></returns>
        public DataSet GetTable(string strSql)
        {
            SqlDataAdapter da=null;
            try
            {
                DataSet ds = new DataSet();
                da = new SqlDataAdapter(strSql, conn);
                da.Fill(ds);
                return ds; 
            }
            finally {ConnClose();da.Dispose(); }
            
        }


        /// <summary>
        /// 返回一个数据集对象
        /// </summary>
        /// <param name="strSql">查询语句</param>
        /// <returns></returns>
        public DataSet GetTable(string strSql, SqlParameter[] param)
        {
            SqlDataAdapter da=null;SqlCommand comm =null;
            try
            {
                DataSet ds = new DataSet();
                da= new SqlDataAdapter();
                comm = new SqlCommand();
                comm.CommandText = strSql;
                comm.Connection = conn;
                comm.Parameters.AddRange(param);
                da.SelectCommand = comm;
                conn.Open();
                da.Fill(ds);
                return ds;
            }
            finally
            {
                conn.Close(); da.Dispose(); comm.Dispose();
            }
        }

    }
}
