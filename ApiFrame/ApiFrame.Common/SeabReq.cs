using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ApiFrame.Common
{
    [DataContract]
    public class SeabReq
    {
        [DataMember(Order = 0, IsRequired = true, EmitDefaultValue = false)]
        public HeaderReq header { get; set; }

        [DataMember(Order = 1, IsRequired = true, EmitDefaultValue = false)]
        public string sign { get; set; }
    }

    #region HeaderReq
    [DataContract]
    public class HeaderReq
    {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string reqType { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string api { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string apiKey { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string priority { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string channel { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string subChannel { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string location { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string context { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string trusted { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string userID { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string dn { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string requestAPI { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string requestNode { get; set; }

        [IgnoreDataMember]
        public int requestID { get; set; }
    }
    #endregion
}
