using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ApiFrame.Common.Requests
{
    [DataContract]
    public class ApprovalLevelReq : BodyReq
    {
        #region employee
        [DataMember(EmitDefaultValue = false)]
        public string command { get; set; }
        #endregion
    }
}
