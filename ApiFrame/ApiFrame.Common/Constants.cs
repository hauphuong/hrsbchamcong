using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ApiFrame.Common
{
    public class Constants
    {
        public struct Configuration
        {
            public static int PointAtTime_SyncChamCong
            {
                get
                {
                    int iTemp;
                    return int.TryParse(ConfigurationManager.AppSettings["PointAtTime_SyncChamCong"] + "", out iTemp) ? iTemp : 1000;
                }
            }
        }

        public struct Command
        {
            /// <summary>
            /// Danh mục
            /// </summary>
            public const string category = "category";

            /// <summary>
            /// Kỳ chấm công
            /// </summary>
            public const string open_phase = "open_phase";

            /// <summary>
            /// Thông tin làm thêm giờ
            /// </summary>
            public const string over_time = "over_time";

            /// <summary>
            /// Công tác
            /// </summary>
            public const string bussiness_time = "bussiness_time";

            /// <summary>
            /// Chấm công thủ công
            /// </summary>
            public const string timesheettimekeeping = "timesheettimekeeping";

            /// <summary>
            /// Nghỉ vắng
            /// </summary>
            public const string leavetimekeeping = "leavetimekeeping";

            /// <summary>
            /// Xác nhận công
            /// </summary>
            public const string verifytimekeeping = "verifytimekeeping";

            /// <summary>
            /// Thông tin bù công
            /// </summary>
            public const string addtimekeeping = "addtimekeeping";

            /// <summary>
            /// Tổng hợp dữ liệu chấm công
            /// </summary>
            public const string oversumtimekeeping = "oversumtimekeeping";

        }

        public struct Category
        {
            /// <summary>
            /// Loại nghỉ vắng
            /// </summary>
            public const string leavetype = "leavetype";

            /// <summary>
            /// Nghỉ lễ
            /// </summary>
            public const string holiday = "holiday";

            /// <summary>
            /// Cấu hình tham số nghỉ vắng
            /// </summary>
            public const string leaveparameter = "leaveparameter";

            /// <summary>
            /// Loại công tác
            /// </summary>
            public const string bussinesstype = "bussinesstype";

            /// <summary>
            /// Loại bù công
            /// </summary>
            public const string compensation = "compensation";

            /// <summary>
            /// Kiểu công
            /// </summary>
            public const string workingtype = "workingtype";

            /// <summary>
            /// Kỳ chấm công
            /// </summary>
            public const string timeperiod = "timeperiod";

            /// <summary>
            /// Ca làm việc
            /// </summary>
            public const string shift = "shift";

            /// <summary>
            /// Ủy quyền phê duyệt
            /// </summary>
            public const string approvaldelegate = "approvaldelegate";

            /// <summary>
            /// Quản lý loại làm thêm giờ
            /// </summary>
            public const string overtimetype = "overtimetype";

        }

        public struct Type
        {
            public const string Create = "Create";
            public const string Update = "Update";
            public const string Delete = "Delete";
            public const string Approve = "Approve";
            public const string Getlist = "Getlist";
        }

        //public static List<BodyReq> lstDanhMuc = new List<BodyReq>();
    }
}

