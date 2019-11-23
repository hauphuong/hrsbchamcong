using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApiFrame.Common.Attributes;

namespace ApiFrame.Common.Enums
{
    public enum Error
    {
        [ErrorAttr("000", "Successfully completed")]
        E000,

        [ErrorAttr("001", "Command không hợp lệ")]
        E001,
        
        [ErrorAttr("002", "Type không hợp lệ")]
        E002,
        
        [ErrorAttr("003", "Dữ liệu danh mục không có mã (Details-> name = code)")]
        E003,
        
        [ErrorAttr("004", "Dữ liệu danh mục có nhiều hơn 1 mã (Details-> name = code)")]
        E004,
        
        [ErrorAttr("005", "Đã tồn tại dữ liệu có cùng code trong danh mục")]
        E005,
        
        [ErrorAttr("006", "Không tồn tại dữ liệu trong danh mục")]
        E006,
        
        [ErrorAttr("103", "Sai định dạng dữ liệu truyền vào")]
        E103,
        
        [ErrorAttr("106", "Lỗi hệ thống")]
        E106,
        
        [ErrorAttr("161", "Request khong hop le – kiem tra tham so:")]
        E161
    }
}