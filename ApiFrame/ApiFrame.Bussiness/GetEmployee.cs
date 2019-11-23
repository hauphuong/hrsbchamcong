using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json;
using ApiFrame.Connection;
using ApiFrame.Common.Requests;
using ApiFrame.Common.Responses;
using ApiFrame.Common;

namespace ApiFrame.Bussiness
{
    public static class GetEmployee
    {
        public static GetEmployeeInfoResponse process(EmployeeRequest request)
        {
            var bodyRes = Employee.Instance.GetEmployeeInfo(request.userID, request.sbCode);
            var response = Utils.ApplyDataDefaultRes<GetEmployeeInfoResponse, EmployeeInfo>(request.header, bodyRes, request.sign);
            response.emloyees = bodyRes.dataRes; 
            return response;
        }
    }
}
