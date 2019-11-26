using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApiFrame.Common;
using ApiFrame.Common.Requests;
using ApiFrame.Common.Responses;
using ApiFrame.DataAccess;
using ApiFrame.Common.Enums;
using Npgsql;

namespace ApiFrame.Bussiness
{
    public static class GetApprovalLevel
    {
        public static SeabRes<ApprovalLevelRes> process(SeabReq<ApprovalLevelReq> request)
        {
            var Data = DS_ApprovalLevel.Instance.GetApprovalLevel(request.body);

            return Utils.ApplyResponse<ApprovalLevelRes>(request.header, Utils.GetErrorCode(Error.E000), Utils.GetErrorDesc(Error.E000), new ApprovalLevelRes(Data), request.sign);
        }
    }
}
