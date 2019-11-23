using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ApiFrame.Common.Responses
{
    [DataContract]
    public class GetEmployeeInfoResponse : SeabRes
    {
        public GetEmployeeInfoResponse ()
        {
            emloyees = new List<EmployeeInfo>();
        }

        [DataMember(IsRequired = false, EmitDefaultValue = false, Name = "DataRes")]
        public IEnumerable<EmployeeInfo> emloyees { get; set; }
    }

    #region EmployeeInfo
    [DataContract]
    public class EmployeeInfo
    {
        public EmployeeInfo(EmployeeInfoForTS info)
        {
            emp_code = info.code;
            emp_name = info.first_name + " " + info.last_name;
            email = info.email;
            ipphone = info.ip_phone;
            job_type = info.job_type;
            job_title = info.job_title;
            type = info.ishr ? "3" : info.ismanager ? "2" : "1";
            isDelegate = false;
        }

        [DataMember(IsRequired = false, EmitDefaultValue = false, Name = "emp_code")]
        public string emp_code { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false, Name = "emp_name")]
        public string emp_name { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false, Name = "email")]
        public string email { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false, Name = "ipphone")]
        public string ipphone { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false, Name = "job_type")]
        public string job_type { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false, Name = "job_title")]
        public string job_title { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false, Name = "type")]
        public string type { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false, Name = "isDelegate")]
        public bool isDelegate { get; set; }
    }
    #endregion

    #region EmployeeInfoForTS
    [DataContract]
    public class EmployeeInfoForTS
    {
        //[DataMember(IsRequired = false, EmitDefaultValue = false, Name = "code")]
        public string code { get; set; }

        //[DataMember(IsRequired = false, EmitDefaultValue = false, Name = "first_name")]
        public string first_name { get; set; }

        //[DataMember(IsRequired = false, EmitDefaultValue = false, Name = "last_name")]
        public string last_name { get; set; }

        //[DataMember(IsRequired = false, EmitDefaultValue = false, Name = "ip_phone")]
        public string ip_phone { get; set; }

        //[DataMember(IsRequired = false, EmitDefaultValue = false, Name = "accountname")]
        public string accountname { get; set; }

        //[DataMember(IsRequired = false, EmitDefaultValue = false, Name = "email")]
        public string email { get; set; }

        //[DataMember(IsRequired = false, EmitDefaultValue = false, Name = "org_name")]
        public string org_name { get; set; }

        //[DataMember(IsRequired = false, EmitDefaultValue = false, Name = "job_title")]
        public string job_title { get; set; }

        //[DataMember(IsRequired = false, EmitDefaultValue = false, Name = "job_type")]
        public string job_type { get; set; }

        //[DataMember(IsRequired = false, EmitDefaultValue = false, Name = "ismanager")]
        public bool ismanager { get; set; }

        //[DataMember(IsRequired = false, EmitDefaultValue = false, Name = "ishr")]
        public bool ishr { get; set; }
    }
    #endregion
}
