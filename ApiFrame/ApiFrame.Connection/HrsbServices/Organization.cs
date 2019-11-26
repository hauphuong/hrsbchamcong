using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApiFrame.Common;
using System.Xml.Linq;
using ApiFrame.Common.Enums;
using ApiFrame.Common.Responses;

namespace ApiFrame.Connection.HrsbServices
{
    public class Organization : BaseConnection<Organization>
    {
        public Tuple<string, string, OrganizationRes> GetOrganizationInfo(string orgId)
        {
            string requestIn = string.Empty;
            try
            {
                requestIn = string.Format("<seabReq>"
                + "<header>"
                    + "<api>api_hrsb</api>"
                    + "<apiKey>HBQ1327611AAAHML8XD083KAFKAM</apiKey>"
                    + "<command>GetOrganizationInfoForTS</command>"
                    + "<sender>VIETED</sender>"
                    + "<sync>nosign</sync>"
                    + "<traceid>" + Common.Utils.GenTraceID() + "</traceid>"
                    + "<req_time>20171004000000</req_time>"
                + "</header>"
                + "<body>"
                    + "<GetOrganizationInfoForTS>"
                    + "<orgId>{0}</orgId>"
                    + "</GetOrganizationInfoForTS>"
                    + "</body> </seabReq>", string.IsNullOrEmpty(orgId) ? string.Empty : orgId);

                Api_HRSB.ApiframeClient apiGetEmployee = new Api_HRSB.ApiframeClient();
                string responseLog = apiGetEmployee.process(requestIn);

                XDocument xdoclog = XDocument.Parse(responseLog);
                XElement header = xdoclog.Root.Element("header");

                string res_code = header.Element("res_code").Value;
                string res_desc = header.Element("res_desc").Value;

                IEnumerable<OrganizationInfoForTS> xmlOrganizations = null;
                Tuple<string, string, OrganizationRes> Result = null;
                if (res_code.Equals(Utils.GetErrorCode(Error.E000)))
                {
                    XElement ArrayOfOrganizationInfoForTS = xdoclog.Root.Element("body").Element("ArrayOfOrganizationInfoForTS");
                    IEnumerable<XElement> data = ArrayOfOrganizationInfoForTS.Elements("OrganizationInfoForTS");

                    xmlOrganizations = ApiFrame.Common.XmlHelper.Deserialize<OrganizationInfoForTS>(data);
                    Result = ApplyResponse<OrganizationRes>(Error.E000, new OrganizationRes(xmlOrganizations.Select(x => new OrganizationInfo(x))));
                }
                else
                {
                    Result = ApplyResponse<OrganizationRes>(null, errCode: res_code, errDesc: res_desc);
                }

                return Result;
            }
            catch (Exception ex)
            {
                string errMsg = "==========================================================================="
                        + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name
                        + Environment.NewLine + ex.Message;
                LogProvider.Error(errMsg);
                return ApplyResponse<OrganizationRes>(Error.E106, null);
            }
        }
    }
}
