using System;
using System.Configuration;
using System.Data;
using System.Collections;
using System.Data.OleDb;
using System.Web;

namespace EasyExam
{
     public class AccessDateHelper
    {
        public static string CONN_STRING1 ="Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+ HttpContext.Current.Server.MapPath( ConfigurationSettings.AppSettings["accConn"]);

        public static int ExecuteNonQuery(string cmdText)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandTimeout = 120;
            using (OleDbConnection conn = new OleDbConnection(CONN_STRING1))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                cmd.CommandType = CommandType.Text;
                int val = cmd.ExecuteNonQuery();
                conn.Close();////////////////////
                return val;

            }

        }
        public static int ExecuteNonQuery(string cmdText, params OleDbParameter[] pa)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandTimeout = 120;
            using (OleDbConnection conn = new OleDbConnection(CONN_STRING1))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                cmd.CommandType = CommandType.Text;
                if (pa != null)
                {
                    cmd.Parameters.AddRange(pa);
                }
                int val = cmd.ExecuteNonQuery();
                conn.Close();////////////////////
                return val;

            }

        }
        public static int ExecuteNonQuery(OleDbCommand cmd)
        {
           
            cmd.CommandTimeout = 120;
            using (OleDbConnection conn = new OleDbConnection(CONN_STRING1))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd.Connection = conn;
                
                cmd.CommandType = CommandType.Text;
               
                int val = cmd.ExecuteNonQuery();
                conn.Close();////////////////////
                return val;

            }

        }
        public static int ExecuteNonQuery(string connString, CommandType cmdType, string cmdText, params OleDbParameter[] cmdParms)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandTimeout = 120;
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                conn.Close();////////////////////
                return val;
            }
        }

        public static int ExecuteNonQuery(OleDbTransaction trans, CommandType cmdType, string cmdText, params OleDbParameter[] cmdParms)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandTimeout = 120;
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, cmdParms);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        /// &lt;summary&gt;
        ///
        /// &lt;/summary&gt;
        /// &lt;param name="connString"&gt;&lt;/param&gt;
        /// &lt;param name="cmdType"&gt;&lt;/param&gt;
        /// &lt;param name="cmdText"&gt;&lt;/param&gt;
        /// &lt;param name="cmdParms"&gt;&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        public static OleDbDataReader ExecuteReader(string cmdText)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandTimeout = 120;
            OleDbConnection conn = new OleDbConnection(CONN_STRING1);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = CommandType.Text;
            try
            {
                OleDbDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }
        public static OleDbDataReader ExecuteReader(string cmdText, params OleDbParameter[] pa)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandTimeout = 120;
            OleDbConnection conn = new OleDbConnection(CONN_STRING1);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = CommandType.Text;
            if (pa != null)
            {
                cmd.Parameters.AddRange(pa);
            }
            try
            {
                OleDbDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        public static OleDbDataReader ExecuteReader(string connString, CommandType cmdType, string cmdText, params OleDbParameter[] cmdParms)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandTimeout = 120;
            OleDbConnection conn = new OleDbConnection(connString);

            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                OleDbDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        /// &lt;summary&gt;
        /// add it by jiamq 2003-08-04(返回DataSet,不用参数)
        /// &lt;/summary&gt;
        /// &lt;param name="connString"&gt;&lt;/param&gt;
        /// &lt;param name="cmdText"&gt;&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        public static DataSet ExecuteDataset(string cmdText)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandTimeout = 120;
            using (OleDbConnection conn = new OleDbConnection(CONN_STRING1))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                cmd.CommandType = CommandType.Text;

                //create the DataAdapter &amp; DataSet
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();

                //fill the DataSet using default values for DataTable names, etc.
                da.Fill(ds);
                conn.Close();////////////////////
                //return the dataset
                return ds;
            }
        }
        public static DataSet ExecuteDataset(string cmdText, params OleDbParameter[] pa)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandTimeout = 120;
            using (OleDbConnection conn = new OleDbConnection(CONN_STRING1))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                cmd.CommandType = CommandType.Text;
                if (pa != null)
                {
                    cmd.Parameters.AddRange(pa);
                }
                //create the DataAdapter &amp; DataSet
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();

                //fill the DataSet using default values for DataTable names, etc.
                da.Fill(ds);
                conn.Close();////////////////////
                //return the dataset
                return ds;
            }
        }
        /// &lt;summary&gt;
        ///
        /// &lt;/summary&gt;
        /// &lt;param name="connString"&gt;&lt;/param&gt;
        /// &lt;param name="cmdText"&gt;&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        public static DataRow ExecuteDataRow(string cmdText)
        {
            OleDbCommand cmd = new OleDbCommand(); cmd.CommandTimeout = 120;
            using (OleDbConnection conn = new OleDbConnection(CONN_STRING1))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                cmd.CommandType = CommandType.Text;

                //create the DataAdapter &amp; DataSet
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataSet myDS = new DataSet();

                da.Fill(myDS);
                conn.Close();////////////////////
                if (myDS.Tables[0].Rows.Count != 0)
                    return myDS.Tables[0].Rows[0];
                else
                    return null;
            }
        }
        public static DataRow ExecuteDataRow(string cmdText, params OleDbParameter[] pa)
        {
            OleDbCommand cmd = new OleDbCommand(); cmd.CommandTimeout = 120;
            using (OleDbConnection conn = new OleDbConnection(CONN_STRING1))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                cmd.CommandType = CommandType.Text;
                if (pa != null)
                {
                    cmd.Parameters.AddRange(pa);
                }
                //create the DataAdapter &amp; DataSet
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataSet myDS = new DataSet();

                da.Fill(myDS);
                conn.Close();////////////////////
                if (myDS.Tables[0].Rows.Count != 0)
                    return myDS.Tables[0].Rows[0];
                else
                    return null;
            }
        }
        /// &lt;summary&gt;
        ///
        /// &lt;/summary&gt;
        /// &lt;param name="cmdText"&gt;&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        public static object ExecuteScalar(string cmdText)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandTimeout = 120;
            using (OleDbConnection conn = new OleDbConnection(CONN_STRING1))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                cmd.CommandType = CommandType.Text;

                object val = cmd.ExecuteScalar();
                conn.Close();////////////////////
                return val;
            }
        }
        public static object ExecuteScalar(string cmdText, params OleDbParameter[] pa)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandTimeout = 120;
            using (OleDbConnection conn = new OleDbConnection(CONN_STRING1))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                cmd.CommandType = CommandType.Text;
                if (pa != null)
                {
                    cmd.Parameters.AddRange(pa);
                }
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                conn.Close();////////////////////
                return val;
            }
        }

        public static object ExecuteScalar(string connString, CommandType cmdType, string cmdText, params OleDbParameter[] cmdParms)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandTimeout = 120;
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                int val = (int)cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                conn.Close();////////////////////
                return val;
            }
        }

        private static void PrepareCommand(OleDbCommand cmd, OleDbConnection conn, OleDbTransaction trans, CommandType cmdType, string cmdText, OleDbParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (OleDbParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        ///&lt;summary&gt;
        ///
        ///&lt;/summary&gt;
        public static DataTable ExecuteDataTable(string cmdText)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandTimeout = 120;
            using (OleDbConnection conn = new OleDbConnection(CONN_STRING1))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                cmd.CommandType = CommandType.Text;
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();////////////////////
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0];
                else
                    return null;
            }
        }
        public static DataTable ExecuteDataTable(string cmdText, params OleDbParameter[] pa)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandTimeout = 120;
            using (OleDbConnection conn = new OleDbConnection(CONN_STRING1))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                cmd.CommandType = CommandType.Text;
                if (pa != null)
                {
                    cmd.Parameters.AddRange(pa);
                }
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();////////////////////
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0];
                else
                    return null;
            }
        }
        /// &lt;summary&gt;
        /// 按页返回固定行记录。
        /// &lt;/summary&gt;
        /// &lt;param name="cmdText"&gt;&lt;/param&gt;
        /// &lt;param name="CurrentPage"&gt;当前页&lt;/param&gt;
        /// &lt;param name="PageSize"&gt;页大小&lt;/param&gt;
        /// &lt;returns&gt;DataTable&lt;/returns&gt;
        public static DataTable ExecuteDataTableInFixedReords(string cmdText, int CurrentPage, int PageSize)
        {
            using (OleDbConnection conn = new OleDbConnection(CONN_STRING1))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                OleDbDataAdapter sdr = new OleDbDataAdapter(cmdText, conn);
                DataSet ds = new DataSet();
                int startIndex = PageSize * CurrentPage;
                sdr.Fill(ds, startIndex, PageSize, "tableName");
                conn.Close();////////////////////
                return ds.Tables["tableName"];
            }
        }
        /// &lt;summary&gt;
        /// 按页返回固定行记录。
        /// &lt;/summary&gt;
        /// &lt;param name="cmdText"&gt;&lt;/param&gt;
        /// &lt;param name="CurrentPage"&gt;当前页&lt;/param&gt;
        /// &lt;param name="PageSize"&gt;页大小&lt;/param&gt;
        /// &lt;returns&gt;DataTable&lt;/returns&gt;
        public static DataTable ExecuteDataTableInFixedReords(string cmdText, int CurrentPage, int PageSize, params OleDbParameter[] pa)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandTimeout = 120;
            using (OleDbConnection conn = new OleDbConnection(CONN_STRING1))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                cmd.CommandType = CommandType.Text;
                if (pa != null)
                {
                    cmd.Parameters.AddRange(pa);
                }
                //create the DataAdapter &amp; DataSet
                OleDbDataAdapter sdr = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                int startIndex = PageSize * CurrentPage;
                sdr.Fill(ds, startIndex, PageSize, "tableName");
                conn.Close();////////////////////
                return ds.Tables["tableName"];
            }
        }

        public static string GetValues(string strSql, string strFiled)
        {
            string strTmp="";
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandTimeout = 120;
            OleDbConnection conn = new OleDbConnection(CONN_STRING1);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = strSql;
            cmd.CommandType = CommandType.Text;
            try
            {
                OleDbDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (rdr.Read())
                {
                    strTmp = Convert.ToString(rdr[strFiled.Trim()]);
                }
                return strTmp;
            }
            catch
            {
                conn.Close();
                throw;
            }

            conn.Close();
          
        }

        public static int ExecuteSql(string strSql)
        {
            int intTmp = 1;
            
            OleDbConnection ObjConn = new OleDbConnection(CONN_STRING1);
            if (ObjConn.State != ConnectionState.Open)
                ObjConn.Open();
            OleDbTransaction myTransaction = ObjConn.BeginTransaction(IsolationLevel.ReadCommitted);
            OleDbCommand myCommand = new OleDbCommand(strSql, ObjConn);
            myTransaction.Commit();
            myCommand.ExecuteNonQuery();
            myCommand.CommandText = "select @@identity as id";
            intTmp = Convert.ToInt32(myCommand.ExecuteScalar());
           
            ObjConn.Close();
            ObjConn.Dispose();
            return intTmp;
        }
    }
}