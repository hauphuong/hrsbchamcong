using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using ApiFrame.Common;
using ApiFrame.Common.Enums;

namespace ApiFrame.Connection
{
    public class BaseConn<T> where T : class, new()
    {
        private static T instance = null;
        public static T Instance
        {
            get
            {
                return instance == null ? new T() : instance;
            }
        }

        public static readonly ILog LogProvider = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BodyRes<TEntity> ApplyBodyRes<TEntity>(Error err, IEnumerable<TEntity> data) where TEntity : class
        {
            return new BodyRes<TEntity>(err, data);
        }
    }
}
