using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ApiFrame.Common.Responses
{
    [DataContract]
    public class ApprovalLevelRes : BodyRes
    {
        public ApprovalLevelRes(IEnumerable<ApprovalLevelInfo> data)
        {
            DataRes = data;
        }

        public ApprovalLevelRes()
        {
            DataRes = new List<ApprovalLevelInfo>();
        }

        [DataMember(IsRequired = false, EmitDefaultValue = false, Name = "DataRes")]
        public IEnumerable<ApprovalLevelInfo> DataRes { get; set; }
    }

    [DataContract]
    public class ApprovalLevelInfo
    {
        [DataMember(IsRequired = false, EmitDefaultValue = false, Name = "id")]
        public string id { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false, Name = "name")]
        public string name { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false, Name = "description")]
        public string description { get; set; }
    }
}
