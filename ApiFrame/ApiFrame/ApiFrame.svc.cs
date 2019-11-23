using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ServiceModel.Activation;
using ApiFrame.Common;
using ApiFrame.Bussiness;
using ApiFrame.Common.Responses;
using ApiFrame.Common.Requests;

namespace ApiFrame
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class ApiFrame : IApiframe
    {
        ApiFrame()
        {
        }

        //public SeabRes process(SeabReq request)
        //{
        //    return TimeKeeping.process(request);
        //}

        public GetEmployeeInfoResponse getEmployeeProcess(EmployeeRequest request)
        {
            return GetEmployee.process(request);
        }
    }
}
