using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;


namespace DLL_DAL
{
    public class DBHelper01
    {
        //创建
        static string strConn = ConfigurationManager.ConnectionStrings["sqlLink"].ConnectionString.ToString();
            //"server=.;database=TavernManage;uid=sa;pwd=123456";
        static SqlConnection conn = new SqlConnection(strConn);

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public static void ConnOpen()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public static void ConnClose()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }


        /// <summary>
        /// 对连接执行 Transact-SQL 语句并返回受影响的行数。
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns>执行成功的行数</returns>
        public static int ExecuteNonQuery(string strSql, SqlParameter[] param)
        {
            int v = 0;
            try
            {
                SqlCommand comm = new SqlCommand(strSql, conn);
                comm.Parameters.AddRange(param);
                ConnOpen();
                v = comm.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
            return v;
        }



        /// <summary>
        /// 对连接执行 Transact-SQL 语句并返回受影响的行数。 存储过程
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns>执行成功的行数</returns>
        public static int ExecuteNonQueryProc(string strSql, params SqlParameter[] param)
        {
            int v = 0;
            try
            {
                SqlCommand comm = new SqlCommand(strSql, conn); comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddRange(param);
                ConnOpen();
                v = comm.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
            return v;
        }


        /// <summary>
        /// 得到查询数据的首行首列的值
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns>首行首列值</returns>
        public static object ExecuteScalar(string strSql)
        {
            object v = 0;
            try
            {
                SqlCommand comm = new SqlCommand(strSql, conn);
                ConnOpen();
                v = comm.ExecuteScalar();
            }
            finally
            {
                conn.Close();
            }
            return v;
        }

        /// <summary>
        /// 得到查询数据的首行首列的值
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns>首行首列值</returns>
        public static object ExecuteScalar(string strSql,params SqlParameter[] sqlp)
        {
            object v = 0;
            try
            {
                SqlCommand comm = new SqlCommand(strSql, conn); comm.Parameters.AddRange(sqlp);
                ConnOpen();
                v = comm.ExecuteScalar();
            }
            finally
            {
                conn.Close();
            }
            return v;
        }


        /// <summary>
        /// 获得一个数据阅读器
        /// </summary>
        /// <param name="strSql">SQL查询语句</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string strSql, params SqlParameter[] sqlp)
        {
            SqlDataReader dr = null;
            try
            {
                SqlCommand comm = new SqlCommand(strSql, conn); comm.Parameters.AddRange(sqlp);
                ConnOpen();
                dr = comm.ExecuteReader();
            }
            finally { }
            return dr;
        }

        /// <summary>
        /// 获得一个数据阅读器
        /// </summary>
        /// <param name="strSql">SQL查询语句</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReaderProc(string strSql, params SqlParameter[] sqlp)
        {
            SqlDataReader dr = null;
            try
            {
                SqlCommand comm = new SqlCommand(strSql, conn); comm.Parameters.AddRange(sqlp); comm.CommandType = CommandType.StoredProcedure;
                ConnOpen();
                dr = comm.ExecuteReader();
            }
            finally { }
            return dr;
        }

        /// <summary>
        /// 返回一个数据集对象
        /// </summary>
        /// <param name="strSql">查询语句</param>
        /// <returns></returns>
        public static DataSet GetTable(string strSql)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(strSql, conn);
            da.Fill(ds);
            ConnClose();
            return ds;
        }


        /// <summary>
        /// 返回一个数据集对象
        /// </summary>
        /// <param name="strSql">查询语句</param>
        /// <returns></returns>
        public static DataSet GetTable(string strSql, SqlParameter[] param)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSql;
            comm.Connection = conn;
            comm.Parameters.AddRange(param);
            da.SelectCommand = comm;
            conn.Open();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

    }
}
