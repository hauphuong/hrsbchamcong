using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ApiFrame.Common;
using ApiFrame.Common.Requests;
using ApiFrame.Common.Responses;

namespace ApiFrame
{
    [ServiceContract(Namespace = "http://api.seabank.com.vn/")]
    public interface IApiframe
    {
        //[OperationContract]
        //[WebInvoke(Method = "POST",
        //    ResponseFormat = WebMessageFormat.Json,
        //    RequestFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.Bare,
        //    UriTemplate = "api/json")]
        //SeabRes process(SeabReq request);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetEmployeeInfo")]
        GetEmployeeInfoResponse getEmployeeProcess(EmployeeRequest request);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetApprovalLevel")]
        GetEmployeeInfoResponse getEmployeeProcess(EmployeeRequest request);
    }
}
