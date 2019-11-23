using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using ApiFrame.Common.Enums;

namespace ApiFrame.Common
{
    [DataContract]
    public class SeabRes
    {
        [DataMember(Order = 0, IsRequired = false, EmitDefaultValue = false)]
        public HeaderRes header { get; set; }

        [DataMember(Order = 1, IsRequired = false, EmitDefaultValue = false)]
        public string sign { get; set; }
    }

    [DataContract]
    public class HeaderRes : HeaderReq
    {
        public HeaderRes(HeaderReq header, Error err)
        {
            reqType = header.reqType;
            api = header.api;
            apiKey = header.apiKey;
            priority = header.priority;
            channel = header.channel;
            subChannel = header.subChannel;
            location = header.location;
            context = header.context;
            trusted = header.trusted;
            userID = header.userID;
            dn = header.dn;
            requestAPI = header.requestAPI;
            requestNode = header.requestNode;
            requestID = header.requestID;
            res_code = Utils.GetErrorCode(err);
            res_desc = Utils.GetErrorDesc(err);
        }

        [DataMember(Order = 6, IsRequired = false, EmitDefaultValue = false)]
        public string res_code { get; set; }

        [DataMember(Order = 7, IsRequired = false, EmitDefaultValue = false)]
        public string res_desc { get; set; }
    }

    [DataContract]
    public class BodyRes<T>
    {
        public BodyRes(Error err, IEnumerable<T> Data)
        {
            error = err;
            dataRes = Data;
        }
        [DataMember(Order = 1)]
        public Error error { get; set; }

        [DataMember(Order = 2)]
        public IEnumerable<T> dataRes { get; set; }
    }
}
