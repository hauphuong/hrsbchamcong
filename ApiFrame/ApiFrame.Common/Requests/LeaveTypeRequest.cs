using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ApiFrame.Common.Requests
{
    [DataContract]
    public class LeaveTypeCreateRequest : BodyReq
    {
        [DataMember(IsRequired = false, EmitDefaultValue = false, Name = "rows")]
        public List<LeaveTypeDetails> rows { get; set; }
    }
    public class LeaveTypeDetails
    {
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public string code { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public string name { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public int numberday { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public int status { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public string active { get; set; }

    }
}
