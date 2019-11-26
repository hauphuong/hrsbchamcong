using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApiFrame.Common.Enums;
using ApiFrame.Common.Attributes;
using System.Reflection;

namespace ApiFrame.Common
{
    public class Utils
    {
        public static string GenTraceID(string TraceID = "")
        {
            int number = new Random().Next(11, 999);
            return TraceID.Length < 6 ? GenTraceID(number.ToString() + TraceID) : TraceID;
        }

        // HieuLT.ITSol
        #region ApplyDataDefaultRes
        public static SeabRes<T> ApplyResponse<T>(HeaderReq head, string errCode, string errDesc, T body, string sign) where T : BodyRes, new()
        {
            SeabRes<T> response = new SeabRes<T>();
            response.header = new HeaderRes(head, errCode, errDesc);
            response.body = body;
            response.sign = sign;

            return response;
        }
        #endregion

        #region Error
        public static Error? GetErrorByCode(string code)
        {

            // Lấy hết tất cả các phần tử của Enum.
            Array allErrors = Enum.GetValues(typeof(Error));

            foreach (Error err in allErrors)
            {
                string c = GetErrorCode(err);
                if (c == code)
                {
                    return err;
                }
            }
            return null;
        }

        public static string GetErrorDesc(Error err)
        {
            ErrorAttr errorAttr = GetAttr(err);
            return errorAttr.Desc;
        }

        public static string GetErrorCode(Error err)
        {
            ErrorAttr errorAttr = GetAttr(err);
            return errorAttr.Code;
        }

        private static ErrorAttr GetAttr(Error err)
        {
            MemberInfo memberInfo = GetMemberInfo(err);
            return (ErrorAttr)Attribute.GetCustomAttribute(memberInfo, typeof(ErrorAttr));
        }

        private static MemberInfo GetMemberInfo(Error err)
        {
            MemberInfo memberInfo
                = typeof(Error).GetField(Enum.GetName(typeof(Error), err));

            return memberInfo;
        }
        #endregion
    }
}
