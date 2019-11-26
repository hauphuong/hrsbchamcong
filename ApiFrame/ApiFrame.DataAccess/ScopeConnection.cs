using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Npgsql;
using System.Data;
using System.Data.SqlClient;

namespace ApiFrame.DataAccess
{
    public class ScopeConnection
    {
        private static object _lock = new object();
        private static ScopeConnection scopeConn;
        public static ScopeConnection Instance
        {
            get
            {
                if (scopeConn == null)
                {
                    lock (_lock)
                    {
                        if (scopeConn == null)
                        {
                            scopeConn = new ScopeConnection();
                            return scopeConn;
                        }
                    }
                }
                return scopeConn;
            }
        }

        #region PostGreeConnection
        readonly static string POSTGREE_CONNECTION_STRING = ConfigurationManager.ConnectionStrings["HRSBPostGreeConnect"].ConnectionString;
        NpgsqlConnection conn1 = null;

        private static object _lockConnection = new object();
        public void GetConnectionAndOpen(ref NpgsqlConnection conn)
        {
            if (conn == null)
            {
                conn = GetConnection();
            }
            if (conn.State != ConnectionState.Open)
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public NpgsqlConnection GetConnection()
        {
            if (conn1 == null)
            {
                lock (_lock)
                {
                    if (conn1 == null)
                    {
                        conn1 = new NpgsqlConnection();
                        conn1.ConnectionString = POSTGREE_CONNECTION_STRING;
                        conn1.Open();
                    }
                }
            }
            return conn1;
        }

        public NpgsqlConnection Connection
        {
            get
            {
                NpgsqlConnection conn = null;
                GetConnectionAndOpen(ref conn);
                return conn;
            }
        }

        #endregion

        #region Oracle Connection
        readonly static string ORACLE_CONNECTION_STRING = ConfigurationManager.ConnectionStrings["HRSBOracleConnect"].ConnectionString;
        IDbConnection conn2 = null;

        public void GetOracleConnectionAndOpen(ref IDbConnection conn)
        {
            if (conn == null)
            {
                conn = GetOracleConnection();
            }
            if (conn.State != ConnectionState.Open)
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public IDbConnection GetOracleConnection()
        {
            if (conn2 == null)
            {
                lock (_lock)
                {
                    if (conn2 == null)
                    {
                        conn2 = System.Data.Common.DbProviderFactories.GetFactory("Oracle.DataAccess.Client").CreateConnection();
                        conn2.ConnectionString = ORACLE_CONNECTION_STRING;
                        conn2.Open();
                    }
                }
            }
            return conn2;
        }

        public IDbConnection OracleConnection
        {
            get
            {
                IDbConnection conn = null;
                GetOracleConnectionAndOpen(ref conn);
                return conn;
            }
        }

        #endregion

        #region ZK Connection
        readonly static string ZK_CONNECTION_STRING = ConfigurationManager.ConnectionStrings["ZKConnect"].ConnectionString;
        SqlConnection conn3 = null;

        public void GetZKConnectionAndOpen(ref SqlConnection conn)
        {
            if (conn == null)
            {
                conn = GetZKConnection();
            }
            if (conn.State != ConnectionState.Open)
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public SqlConnection GetZKConnection()
        {
            if (conn3 == null)
            {
                lock (_lock)
                {
                    if (conn3 == null)
                    {
                        conn3 = new SqlConnection();
                        conn3.ConnectionString = ZK_CONNECTION_STRING;
                        conn3.Open();
                    }
                }
            }
            return conn3;
        }

        public SqlConnection ZKConnection
        {
            get
            {
                SqlConnection conn = null;
                GetZKConnectionAndOpen(ref conn);
                return conn;
            }
        }


        #endregion


        public void CloseConnection(NpgsqlConnection conn)
        {
            if (conn != null && conn.State.Equals(ConnectionState.Open))
                conn.Close();
        }

        public void CloseConnection()
        {
            conn1.Close();
            conn2.Close();
        }
    }
}
