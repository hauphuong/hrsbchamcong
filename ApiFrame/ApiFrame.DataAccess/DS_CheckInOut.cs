using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApiFrame.Common;
using System.Data.SqlClient;
using System.Data;
using Npgsql;

namespace ApiFrame.DataAccess
{
    public class DS_CheckInOut
    {
        public static List<ThongTinChamCong> getChamCongFromZK(SqlConnection conn, DateTime fromDate, DateTime toDate)
        {
            if (conn.State == System.Data.ConnectionState.Closed) conn.Open(); //Do chưa làm được transacion và singleton
            List<ThongTinChamCong> lstThongTinChamCong = new List<ThongTinChamCong>();
            DataTable dt = new DataTable();
            try
            {
                string cmdText = @"Select B1.id AS ID, B2.identitycard AS Emp_Code, B2.name AS Emp_Name,B1.pin AS Emp_Pin,
	                                B1.checktime AS Check_Time, B5.areaid AS Check_Area_Code, B5.areaname AS Check_Area_Name, 
                                    B3.alias AS Sn_Alias ,B1.sn_name AS Sn_Name ";
                cmdText += @" from (Select * from CHECKINOUT where checktime >= @fromDate and checktime < @toDate) B1
                                    inner join USERINFO B2 on B2.badgenumber = B1.pin
                                    left join ICLOCK B3 on B3.sn = B1.sn_name
                                    inner join USERINFO_ATTAREA B4 on B4.employee_id = B2.userid
                                    inner join PERSONNEL_AREA B5 on B5.id = B4.area_id
                                    order by B1.id ";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = fromDate;
                cmd.Parameters.Add("@toDate", SqlDbType.DateTime).Value = toDate;
                cmd.CommandTimeout = 30;
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                lstThongTinChamCong = dt.ToList<ThongTinChamCong>();

                return lstThongTinChamCong;
            }
            catch (Exception ex)
            {
                // Rollback toàn bộ nếu có lỗi
                throw ex;
                //throw new HaiQuan247.Common.UnknownException(ex.Message);
            }
            finally
            {
                //Do chưa làm được transacion và singleton
                if (conn.State == System.Data.ConnectionState.Open) conn.Close();
            }
        }

        #region Chấm công
        public static void InsertChamCong(NpgsqlConnection conn, NpgsqlTransaction chamCongTransaction, ThongTinChamCong thongTinChamCong)
        {
            //if (conn.State == System.Data.ConnectionState.Closed) conn.Open(); //Do chưa làm được transacion và singleton
            try
            {
                string cmdText = "INSERT INTO tbl_chamcong (id, emp_code, emp_name, emp_pin, check_time, check_area_code, check_area_name, sn_alias, sn_name)";
                cmdText += " values (:id, :emp_code, :emp_name, :emp_pin,  :check_time, :check_area_code, :check_area_name, :sn_alias, :sn_name)";
                NpgsqlCommand cmd = new NpgsqlCommand(cmdText, conn);
                cmd.Transaction = chamCongTransaction;

                cmd.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = thongTinChamCong.ID;
                cmd.Parameters.Add("emp_code", NpgsqlTypes.NpgsqlDbType.Varchar).Value = thongTinChamCong.Emp_Code;
                cmd.Parameters.Add("emp_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = thongTinChamCong.Emp_Name;
                cmd.Parameters.Add("emp_pin", NpgsqlTypes.NpgsqlDbType.Varchar).Value = thongTinChamCong.Emp_Pin;
                //cmd.Parameters.Add("check_date", NpgsqlTypes.NpgsqlDbType.Varchar).Value = thongTinChamCong.check_date;
                cmd.Parameters.Add("check_time", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = thongTinChamCong.Check_Time;
                cmd.Parameters.Add("check_area_code", NpgsqlTypes.NpgsqlDbType.Varchar).Value = thongTinChamCong.Check_Area_Code;
                cmd.Parameters.Add("check_area_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = thongTinChamCong.Check_Area_Name;
                cmd.Parameters.Add("sn_alias", NpgsqlTypes.NpgsqlDbType.Varchar).Value = thongTinChamCong.Sn_Alias;
                cmd.Parameters.Add("sn_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = thongTinChamCong.Sn_Name;

                cmd.CommandTimeout = 60;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //Log file và gửi mail
                //chamCongTransaction.Rollback();
                throw ex;
            }

        }

        public static void DeleteOldChamCong(NpgsqlConnection conn, NpgsqlTransaction chamCongTransaction, DateTime fromDate, DateTime toDate)
        {
            try
            {
                string cmdText = "Delete From tbl_chamcong Where check_time >= :fromDate and check_time < :toDate";

                NpgsqlCommand cmd = new NpgsqlCommand(cmdText, conn);
                cmd.Transaction = chamCongTransaction;

                cmd.Parameters.Add("fromDate", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = fromDate;
                cmd.Parameters.Add("toDate", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = toDate;
                cmd.CommandTimeout = 30;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new HaiQuan247.Common.UnknownException(ex.Message);
                throw ex;
            }
        }

        public static List<ThongTinCongTho_TongHopDTO> getTongHopCongTho(NpgsqlConnection conn, DateTime fromDate, DateTime toDate)
        {
            if (conn.State == System.Data.ConnectionState.Closed) conn.Open(); //Do chưa làm được transacion và singleton
            List<ThongTinCongTho_TongHopDTO> lstCongThoTongHop = new List<ThongTinCongTho_TongHopDTO>();
            DataTable dt = new DataTable();
            try
            {
                string cmdText = @"select Emp_Code, Check_Date, lstChamCong from 
                                   TongHopCongTho(:v_fromDate, :v_toDate); ";
                NpgsqlCommand cmd = new NpgsqlCommand(cmdText, conn);
                cmd.Parameters.Add("v_fromDate", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = fromDate;
                cmd.Parameters.Add("v_toDate", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = toDate;
                cmd.CommandTimeout = 30;
                NpgsqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                lstCongThoTongHop = dt.ToList<ThongTinCongTho_TongHopDTO>();

                return lstCongThoTongHop;
            }
            catch (Exception ex)
            {
                // Rollback toàn bộ nếu có lỗi
                throw ex;
                //throw new HaiQuan247.Common.UnknownException(ex.Message);
            }
            finally
            {
                //Do chưa làm được transacion và singleton
                if (conn.State == System.Data.ConnectionState.Open) conn.Close();
            }
        }
        #endregion

        #region Tổng hợp công
        public static void InsertTongHopCong(NpgsqlConnection conn, NpgsqlTransaction chamCongTransaction, ThongTinCongTho_TongHop thongTinCongTho_TongHop)
        {
            //if (conn.State == System.Data.ConnectionState.Closed) conn.Open(); //Do chưa làm được transacion và singleton
            try
            {
                string cmdText = "INSERT INTO tbl_TongHopCong (emp_code, check_date, time_in, time_out)";
                cmdText += " values (:emp_code, :check_date, :time_in, :time_out)";
                NpgsqlCommand cmd = new NpgsqlCommand(cmdText, conn);
                cmd.Transaction = chamCongTransaction;

                cmd.Parameters.Add("emp_code", NpgsqlTypes.NpgsqlDbType.Varchar).Value = thongTinCongTho_TongHop.Emp_Code;
                cmd.Parameters.Add("check_date", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = thongTinCongTho_TongHop.Check_Date;
                cmd.Parameters.Add("time_in", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = thongTinCongTho_TongHop.CheckIn;
                cmd.Parameters.Add("time_out", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = thongTinCongTho_TongHop.CheckOut;

                cmd.CommandTimeout = 60;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //Log file và gửi mail
                //chamCongTransaction.Rollback();
                throw ex;
            }

        }
        public static void DeleteOldTongHopCong(NpgsqlConnection conn, NpgsqlTransaction chamCongTransaction, DateTime fromDate, DateTime toDate)
        {
            try
            {
                string cmdText = "Delete From tbl_TongHopCong Where Check_date >= :fromDate and Check_date < :toDate";

                NpgsqlCommand cmd = new NpgsqlCommand(cmdText, conn);
                cmd.Transaction = chamCongTransaction;

                cmd.Parameters.Add("fromDate", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = fromDate;
                cmd.Parameters.Add("toDate", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = toDate;
                cmd.CommandTimeout = 30;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new HaiQuan247.Common.UnknownException(ex.Message);
                throw ex;
            }
        }
        #endregion
    }
}
