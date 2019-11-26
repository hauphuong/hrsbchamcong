using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json;
using log4net;
using ApiFrame.Common.Responses;
using ApiFrame.Common.Enums;
using ApiFrame.Common;

namespace ApiFrame.Connection.HrsbServices
{
    public class Employee : BaseConnection<Employee>
    {
        public Tuple<string, string, EmployeeRes> GetEmployeeInfo(string userId, string sbCode)
        {
            string requestIn = string.Empty;
            try
            {
                requestIn = string.Format("<seabReq>"
                + "<header>"
                    + "<api>api_hrsb</api>"
                    + "<apiKey>HBQ1327611AAAHML8XD083KAFKAM</apiKey>"
                    + "<command>GetEmployeeInfoForTS</command>"
                    + "<sender>VIETED</sender>"
                    + "<sync>nosign</sync>"
                    + "<traceid>" + Common.Utils.GenTraceID() + "</traceid>"
                    + "<req_time>20171004000000</req_time>"
                + "</header>"
                + "<body>"
                    + "<GetEmployeeInfoForTS>"
                    + "<userId>{0}</userId>"
                    + "<sbCode>{1}</sbCode>"
                    + "</GetEmployeeInfoForTS>"
                    + "</body> </seabReq>", string.IsNullOrEmpty(userId) ? string.Empty : userId, string.IsNullOrEmpty(sbCode) ? string.Empty : sbCode);

                Api_HRSB.ApiframeClient apiGetEmployee = new Api_HRSB.ApiframeClient();
                string responseLog = apiGetEmployee.process(requestIn);

                XDocument xdoclog = XDocument.Parse(responseLog);
                XElement header = xdoclog.Root.Element("header");

                string res_code = header.Element("res_code").Value;
                string res_desc = header.Element("res_desc").Value;

                IEnumerable<EmployeeInfoForTS> xmlEmployees = null;
                Tuple<string, string, EmployeeRes> Result = null;
                if (res_code.Equals(Utils.GetErrorCode(Error.E000)))
                {
                    XElement ArrayOfEmployeeInfoForTS = xdoclog.Root.Element("body").Element("ArrayOfEmployeeInfoForTS");
                    IEnumerable<XElement> data = ArrayOfEmployeeInfoForTS.Elements("EmployeeInfoForTS");

                    xmlEmployees = ApiFrame.Common.XmlHelper.Deserialize<EmployeeInfoForTS>(data);
                    Result = ApplyResponse<EmployeeRes>(Error.E000, new EmployeeRes(xmlEmployees.Select(x => new EmployeeInfo(x))));
                }
                else
                {
                    Result = ApplyResponse<EmployeeRes>(null, errCode: res_code, errDesc: res_desc);
                }

                return Result;
            }
            catch (Exception ex)
            {
                string errMsg = "==========================================================================="
                        + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name
                        + Environment.NewLine + ex.Message;
                LogProvider.Error(errMsg);
                return ApplyResponse<EmployeeRes>(Error.E106);
            }
        }
    }
}
