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
        public static SeabRes CreateReponse(SeabReq reqs, Error err)
        {
            SeabRes seabres = new SeabRes();
            seabres.header = new HeaderRes(reqs.header, err);
            return seabres;
        }

        public static SeabRes CreateCommonError(SeabRes seabres, string errorCode, string err)
        {
            seabres.header.res_code = errorCode;
            seabres.header.res_desc = err;
            return seabres;
        }

        public static SeabRes CreateCommonError(SeabRes seabres, Error err)
        {
            seabres.header.res_code = GetErrorCode(err);
            seabres.header.res_desc = GetErrorDesc(err);
            return seabres;
        }

        public static SeabRes CreateBlankError(SeabRes seabres, string fileName)
        {
            seabres.header.res_code = GetErrorCode(Error.E161);
            seabres.header.res_desc = GetErrorDesc(Error.E161) + fileName;
            return seabres;
        }

        public static SeabRes CreateInvalidValueError(SeabRes seabres, string fileName)
        {
            seabres.header.res_code = GetErrorCode(Error.E161);
            seabres.header.res_desc = GetErrorDesc(Error.E161) + fileName;
            return seabres;
        }

        public static string GenTraceID(string TraceID = "")
        {
            int number = new Random().Next(11, 999);
            return TraceID.Length < 6 ? GenTraceID(number.ToString() + TraceID) : TraceID;
        }

        // HieuLT.ITSol
        #region ApplyDataDefaultRes
        public static T ApplyDataDefaultRes<T, TInfo>(HeaderReq head, BodyRes<TInfo> body, string sign) where T : SeabRes, new()
        {
            T response = new T();
            response.header = new HeaderRes(head, body.error);
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

        public static string GetErrorDesc(Error gender)
        {
            ErrorAttr genderAttr = GetAttr(gender);
            return genderAttr.Desc;
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

        private static MemberInfo GetMemberInfo(Error gender)
        {
            MemberInfo memberInfo
                = typeof(Error).GetField(Enum.GetName(typeof(Error), gender));

            return memberInfo;
        }
        #endregion
    }
}
