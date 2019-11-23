using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiFrame.Common
{
    public class ThongTinChamCong
    {
        public int ID { get; set; }
        public string Emp_Code { get; set; }
        public string Emp_Name { get; set; }
        public string Emp_Pin { get; set; }
        //public DateTime Check_Date { get; set; }
        public DateTime Check_Time { get; set; }
        public string Check_Area_Code { get; set; }
        public string Check_Area_Name { get; set; }
        public string Sn_Alias { get; set; }
        public string Sn_Name { get; set; }
    }

    public class ThongTinCongTho_TongHopDTO
    {
        public string Emp_Code { get; set; }
        public DateTime Check_Date { get; set; }
        public string lstChamCong { get; set; }
    }

    public class ThongTinCongTho_TongHop
    {
        public string Emp_Code { get; set; }
        public DateTime Check_Date { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
    }
}
