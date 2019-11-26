using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ApiFrame.Common.Requests
{
    [DataContract]
    public class OrganizationReq : BodyReq
    {
        #region organization
        [DataMember(EmitDefaultValue = false)]
        public string command { get; set; }
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public string orgId { get; set; }
        #endregion
    }
}
