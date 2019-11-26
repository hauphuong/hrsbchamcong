using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json;
using ApiFrame.Connection.HrsbServices;
using ApiFrame.Common.Requests;
using ApiFrame.Common.Responses;
using ApiFrame.Common;

namespace ApiFrame.Bussiness
{
    public static class GetEmployee
    {
        public static SeabRes<EmployeeRes> process(SeabReq<EmployeeReq> request)
        {
            var Data = Employee.Instance.GetEmployeeInfo(request.body.userID, request.body.sbCode);
            return Utils.ApplyResponse<EmployeeRes>(request.header, Data.Item1, Data.Item2, Data.Item3, request.sign);;
        }
    }
}
