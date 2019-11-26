using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using ApiFrame.Common.Enums;

namespace ApiFrame.Common
{
    public class BaseProvider<T> where T : class, new()
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
    }
}
