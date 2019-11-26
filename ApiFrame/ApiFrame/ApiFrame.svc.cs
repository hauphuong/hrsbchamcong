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

        public SeabRes<EmployeeRes> GetEmployeeProcess(SeabReq<EmployeeReq> request)
        {
            return GetEmployee.process(request);
        }

        public SeabRes<OrganizationRes> GetOrganizationProcess(SeabReq<OrganizationReq> request)
        {
            return GetOrganization.process(request);
        }

        public SeabRes<ApprovalLevelRes> GetApprovalLevelProcess(SeabReq<ApprovalLevelReq> request)
        {
            return GetApprovalLevel.process(request);
        }
    }
}
