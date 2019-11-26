using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApiFrame.Connection.HrsbServices;
using ApiFrame.Common.Responses;
using ApiFrame.Common.Requests;
using ApiFrame.Common;

namespace ApiFrame.Bussiness
{
    public static class GetOrganization
    {
        public static SeabRes<OrganizationRes> process(SeabReq<OrganizationReq> request)
        {
            var Data = Organization.Instance.GetOrganizationInfo(request.body.orgId);
            return Utils.ApplyResponse<OrganizationRes>(request.header, Data.Item1, Data.Item2, Data.Item3, request.sign);
        }
    }
}
