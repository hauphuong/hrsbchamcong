using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ApiFrame.Common.Requests
{
    [DataContract]
    public class EmployeeRequest : SeabReq
    {
        #region employee
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public string userID { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public string sbCode { get; set; }
        #endregion
    }
}
