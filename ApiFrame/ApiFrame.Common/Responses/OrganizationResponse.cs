using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ApiFrame.Common.Responses
{
    [DataContract]
    public class OrganizationRes : BodyRes
    {
        public OrganizationRes(IEnumerable<OrganizationInfo> data)
        {
            DataRes = data;
        }
        public OrganizationRes()
        {
            DataRes = new List<OrganizationInfo>();
        }

        [DataMember(IsRequired = false, EmitDefaultValue = false, Name = "DataRes")]
        public IEnumerable<OrganizationInfo> DataRes { get; set; }
    }

    #region OrganizationInfo
    [DataContract]
    public class OrganizationInfo
    {
        public OrganizationInfo(OrganizationInfoForTS info)
        {
            orgId = info.org_id;
            parentId = info.org_parent_id;
            code = info.code;
            status = info.status;
            statusname = info.statusname;
        }

        [DataMember(IsRequired = false, EmitDefaultValue = false, Name = "orgId")]
        public string orgId { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false, Name = "parentId")]
        public string parentId { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false, Name = "code")]
        public string code { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false, Name = "name")]
        public string name { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false, Name = "status")]
        public string status { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false, Name = "statusname")]
        public string statusname { get; set; }
    }
    #endregion

    #region OrganizationInfoForTS
    [DataContract]
    public class OrganizationInfoForTS
    {
        [DataMember(IsRequired = false, EmitDefaultValue = false, Name = "org_id")]
        public string org_id { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false, Name = "org_parent_id")]
        public string org_parent_id { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false, Name = "code")]
        public string code { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false, Name = "name")]
        public string name { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false, Name = "status")]
        public string status { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false, Name = "statusname")]
        public string statusname { get; set; }
    }
    #endregion
}
