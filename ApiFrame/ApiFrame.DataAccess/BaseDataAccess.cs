using System;
using Npgsql;
using System.Data;
using System.Linq;
using System.Text;
using ApiFrame.Common;
using System.Collections.Generic;
using ApiFrame.Common.Enums;

namespace ApiFrame.DataAccess
{
    public class BaseDataAccess<T> : BaseProvider<T> where T : class, new()
    {
        #region ExcuteQuery
        public DataTable ExcuteQueryByText(TypeQuery type, string sql)
        {
            DataTable dt = null;
            switch (type) {
                case TypeQuery.insert:
                    break;
                case TypeQuery.update:
                    break;
                case TypeQuery.delete:
                    break;
                case TypeQuery.filter:
                    break;
                default:
                    dt = Get(dt, sql);
                    break;
            }
            return dt;
        }

        public DataTable ExcuteQueryByStoredProcedure(TypeQuery type, Dictionary<string, string> data)
        {
            DataTable dt = null;
            switch (type)
            {
                case TypeQuery.insert:
                    break;
                case TypeQuery.update:
                    break;
                case TypeQuery.delete:
                    break;
                case TypeQuery.filter:
                    break;
                default:
                    break;
            }
            return dt;
        }
        #endregion

        #region Get
        private static DataTable Get(DataTable dt, string sql)
        {
            NpgsqlConnection conn = null;
            try
            {
                conn = ScopeConnection.Instance.GetConnection();
                if (conn.State == System.Data.ConnectionState.Closed) conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                cmd.CommandTimeout = 6000;
                NpgsqlDataReader reader = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                // handle error and roleback
            }
            finally
            {
                ScopeConnection.Instance.CloseConnection(conn);
            }

            return dt;
        }
        #endregion
    }
}
