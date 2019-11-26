using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ApiFrame.Common.Responses;
using System.Data;
using ApiFrame.Common;
using ApiFrame.Common.Requests;
using ApiFrame.Common.Enums;

namespace ApiFrame.DataAccess
{
    public class DS_ApprovalLevel : BaseDataAccess<DS_ApprovalLevel>
    {
        public IEnumerable<ApprovalLevelInfo> GetApprovalLevel(ApprovalLevelReq dataReq)
        {
            string cmdText = @"SELECT id, name, description FROM hrsb_chamcong.tbl_loaicauhinhcappheduyet;";

            DataTable data = ExcuteQueryByText(TypeQuery.get, cmdText);
            return data.ToList<ApprovalLevelInfo>();
        }
    }
}
