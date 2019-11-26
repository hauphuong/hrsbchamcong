using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApiFrame.Common;
using ApiFrame.Common.Enums;

namespace ApiFrame.Connection
{
    public class BaseConnection<T> : BaseProvider<T> where T : class, new()
    {
        public Tuple<string, string, TEntity> ApplyResponse<TEntity>(Error? err, TEntity data = null, string errCode = null, string errDesc = null) where TEntity : class
        {
            errCode = err.HasValue ? Utils.GetErrorCode(err.Value) : errCode;
            errDesc = err.HasValue ? Utils.GetErrorDesc(err.Value) : errDesc;

            return Tuple.Create(errCode, errDesc, data);
        }
    }
}
