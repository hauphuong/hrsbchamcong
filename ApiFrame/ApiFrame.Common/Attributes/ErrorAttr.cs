using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiFrame.Common.Attributes
{
    public class ErrorAttr : Attribute
    {
        internal ErrorAttr(string code, string desc)
        {
            this.Code = code;
            this.Desc = desc;
        }
 
        public string Code { get; private set; }

        public string Desc { get; private set; }  
    }
}
