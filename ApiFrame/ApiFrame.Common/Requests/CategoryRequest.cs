using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ApiFrame.Common.Requests
{
    [DataContract]
    public class CategoryReq : BodyReq
    {
        #region CategoryBody
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public string command { get; set; }

        #region category
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public string category { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public string type { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public string status { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public string active { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false, Name = "details")]
        public List<CategoryDetails> details { get; set; }
        #endregion

        #region verifytimekeeping
        public string ma_nhanvien { get; set; }
        public List<VerifyTimeKeepingData> datas { get; set; }
        #endregion
        #endregion
    }

    #region CateforyDetails
    [DataContract]
    public class CategoryDetails
    {
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public string name { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public string value { get; set; }

        [IgnoreDataMember]
        public string code { get; set; }
    }
    #endregion

    #region VerifyTimeKeepingData
    [DataContract]
    public class VerifyTimeKeepingData
    {
        public string ngay_chamcong { get; set; }
        public string thu_tuan { get; set; }
        public string thoi_gianden { get; set; }
        public string thoi_gianve { get; set; }
        public string xacnhan_giove { get; set; }
        public string socong_xacnhan { get; set; }
        public string lydo { get; set; }
    }
    #endregion
}
