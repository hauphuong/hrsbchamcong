using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApiFrame.Common.Requests;
using ApiFrame.Common.Responses;
using ApiFrame.Common;
using Npgsql;
using ApiFrame.DataAccess;

namespace ApiFrame.Bussiness
{
    public class Category
    {
        #region leavetype
        public static SeabRes<BodyRes> CreateLeaveTypeProcess(SeabReq<LeaveTypeCreateRequest> request)
        {
            NpgsqlConnection conn = ScopeConnection.Instance.GetConnection();
            if (request.body.rows != null && request.body.rows.Count > 0)
            {
                NpgsqlTransaction tongHopCongTransaction = conn.BeginTransaction();
                string sqlCmd = @"Insert Into";
            }
            return null;
        }
        #endregion
    }
}
