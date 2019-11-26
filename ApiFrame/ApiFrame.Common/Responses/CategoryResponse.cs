using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using ApiFrame.Common.Requests;

namespace ApiFrame.Common.Responses
{
    [DataContract]
    public class CategoryRes : BodyRes
    {
        public CategoryRes(CategoryInfo data)
        {
            DataRes = data;
        }

        public CategoryRes()
        {
            DataRes = new CategoryInfo();
        }

        [DataMember(IsRequired = false, EmitDefaultValue = false, Name = "DataRes")]
        public CategoryInfo DataRes { get; set; }
    }

    #region CategoryResponse
    [DataContract]
    public class CategoryInfo
    {
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public string category { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false, Name = "DataRes")]
        public IEnumerable<ListCategory> categories { get; set; }
    }

    [DataContract]
    public class ListCategory
    {
        [DataMember(IsRequired = false, EmitDefaultValue = false, Name = "data")]
        public List<CategoryDetails> details { get; set; }
    }
    #endregion
}
