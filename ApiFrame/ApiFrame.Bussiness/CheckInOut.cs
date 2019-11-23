using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Data.SqlClient;
using ApiFrame.Common;
using ApiFrame.DataAccess;

namespace ApiFrame.Bussiness
{
    public class CheckInOut
    {
        public delegate void UpdateProgessBar(int value);

        #region For Services

        //public static void Sync(DateTime fromDate, DateTime toDate)
        //{
        //    NpgsqlConnection conn = ScopeConnection.Instance.GetConnection();
        //    SqlConnection zkConn = ScopeConnection.Instance.GetZKConnection();
        //    List<ThongTinChamCong> lstChamCong = DS_CheckInOut.getChamCongFromZK(zkConn, fromDate, toDate);
        //    if (lstChamCong != null && lstChamCong.Count > 0)
        //    {
        //        if (conn.State == System.Data.ConnectionState.Closed) conn.Open(); //Do chưa làm được transacion và singleton
        //        NpgsqlTransaction chamCongTransaction = conn.BeginTransaction();
        //        try
        //        {
        //            DS_CheckInOut.DeleteOldChamCong(conn, chamCongTransaction, fromDate, toDate);
        //            foreach (var itemChamCong in lstChamCong)
        //            {
        //                DS_CheckInOut.InsertChamCong(conn, chamCongTransaction, itemChamCong);
        //            }
        //            chamCongTransaction.Commit();
        //        }
        //        catch (Exception ex)
        //        {
        //            chamCongTransaction.Rollback();
        //            throw ex;
        //        }

        //    }
        //}

        //public static void TongHopCongTho(DateTime fromDate, DateTime toDate)
        //{
        //    NpgsqlConnection conn = ScopeConnection.Instance.GetConnection();
        //    SqlConnection zkConn = ScopeConnection.Instance.GetZKConnection();
        //    List<ThongTinCongTho_TongHopDTO> lstCongThoTongHopDTO = DS_CheckInOut.getTongHopCongTho(conn, fromDate, toDate);
        //    if (lstCongThoTongHopDTO != null && lstCongThoTongHopDTO.Count > 0)
        //    {
        //        List<ThongTinCongTho_TongHop> lstCongThoTongHop = new List<ThongTinCongTho_TongHop>();
        //        if (conn.State == System.Data.ConnectionState.Closed) conn.Open(); //Do chưa làm được transacion và singleton
        //        NpgsqlTransaction tongHopCongTransaction = conn.BeginTransaction();
        //        foreach (var itemCongThoTongHopDTO in lstCongThoTongHopDTO)
        //        {
        //            string[] arrChamCong = itemCongThoTongHopDTO.lstChamCong.Split(',');
        //            ThongTinCongTho_TongHop itemCongThoTongHop = new ThongTinCongTho_TongHop()
        //            {
        //                Emp_Code = itemCongThoTongHopDTO.Emp_Code,
        //                Check_Date = itemCongThoTongHopDTO.Check_Date
        //            };
        //            switch (arrChamCong.Length)
        //            {
        //                case 0:
        //                    itemCongThoTongHop.CheckIn = null;
        //                    itemCongThoTongHop.CheckOut = null;
        //                    break;
        //                case 1:
        //                    itemCongThoTongHop.CheckIn = DateTime.ParseExact(arrChamCong[0], "yyyy-MM-dd HH':'mm':'ss", System.Globalization.CultureInfo.InvariantCulture);
        //                    itemCongThoTongHop.CheckOut = null;
        //                    break;
        //                default:
        //                    itemCongThoTongHop.CheckIn = DateTime.ParseExact(arrChamCong[0], "yyyy-MM-dd HH':'mm':'ss", System.Globalization.CultureInfo.InvariantCulture);
        //                    itemCongThoTongHop.CheckOut = DateTime.ParseExact(arrChamCong[arrChamCong.Length - 1], "yyyy-MM-dd HH':'mm':'ss", System.Globalization.CultureInfo.InvariantCulture);
        //                    break;
        //            }
        //            lstCongThoTongHop.Add(itemCongThoTongHop);
        //        }

        //        try
        //        {
        //            DS_CheckInOut.DeleteOldTongHopCong(conn, tongHopCongTransaction, fromDate, toDate);
        //            foreach (var itemChamCong in lstCongThoTongHop)
        //            {
        //                DS_CheckInOut.InsertTongHopCong(conn, tongHopCongTransaction, itemChamCong);
        //            }
        //            tongHopCongTransaction.Commit();
        //        }
        //        catch (Exception ex)
        //        {
        //            tongHopCongTransaction.Rollback();
        //            throw ex;
        //        }

        //    }
        //}

        #endregion

        #region For Winform Test

        public static void Sync(DateTime fromDate, DateTime toDate, UpdateProgessBar objUpdatePGBMaxValues = null, UpdateProgessBar objUpdatePGBValues = null)
        {
            NpgsqlConnection conn = ScopeConnection.Instance.GetConnection();
            SqlConnection zkConn = ScopeConnection.Instance.GetZKConnection();
            List<ThongTinChamCong> lstChamCong = DS_CheckInOut.getChamCongFromZK(zkConn, fromDate, toDate);
            if (lstChamCong != null && lstChamCong.Count > 0)
            {
                if (objUpdatePGBMaxValues != null) objUpdatePGBMaxValues(lstChamCong.Count);
                if (conn.State == System.Data.ConnectionState.Closed) conn.Open(); //Do chưa làm được transacion và singleton
                NpgsqlTransaction chamCongTransaction = conn.BeginTransaction();
                try
                {
                    DS_CheckInOut.DeleteOldChamCong(conn, chamCongTransaction, fromDate, toDate);
                    for (int i = 0; i < lstChamCong.Count; i++)
                    {
                        DS_CheckInOut.InsertChamCong(conn, chamCongTransaction, lstChamCong[i]);
                        if (objUpdatePGBValues != null) objUpdatePGBValues(i + 1);
                    }
                    chamCongTransaction.Commit();
                }
                catch (Exception ex)
                {
                    chamCongTransaction.Rollback();
                    throw ex;
                }

            }
        }

        public static void TongHopCongTho(DateTime fromDate, DateTime toDate, UpdateProgessBar objUpdatePGBMaxValues = null, UpdateProgessBar objUpdatePGBValues = null)
        {
            NpgsqlConnection conn = ScopeConnection.Instance.GetConnection();
            SqlConnection zkConn = ScopeConnection.Instance.GetZKConnection();
            List<ThongTinCongTho_TongHopDTO> lstCongThoTongHopDTO = DS_CheckInOut.getTongHopCongTho(conn, fromDate, toDate);
            if (lstCongThoTongHopDTO != null && lstCongThoTongHopDTO.Count > 0)
            {

                List<ThongTinCongTho_TongHop> lstCongThoTongHop = new List<ThongTinCongTho_TongHop>();
                if (conn.State == System.Data.ConnectionState.Closed) conn.Open(); //Do chưa làm được transacion và singleton
                NpgsqlTransaction tongHopCongTransaction = conn.BeginTransaction();
                foreach (var itemCongThoTongHopDTO in lstCongThoTongHopDTO)
                {
                    string[] arrChamCong = itemCongThoTongHopDTO.lstChamCong.Split(',');
                    ThongTinCongTho_TongHop itemCongThoTongHop = new ThongTinCongTho_TongHop()
                    {
                        Emp_Code = itemCongThoTongHopDTO.Emp_Code,
                        Check_Date = itemCongThoTongHopDTO.Check_Date
                    };
                    switch (arrChamCong.Length)
                    {
                        case 0:
                            itemCongThoTongHop.CheckIn = null;
                            itemCongThoTongHop.CheckOut = null;
                            break;
                        case 1:
                            itemCongThoTongHop.CheckIn = DateTime.ParseExact(arrChamCong[0].Trim(), "yyyy-MM-dd HH':'mm':'ss", System.Globalization.CultureInfo.InvariantCulture);
                            itemCongThoTongHop.CheckOut = null;
                            break;
                        default:
                            itemCongThoTongHop.CheckIn = DateTime.ParseExact(arrChamCong[0].Trim(), "yyyy-MM-dd HH':'mm':'ss", System.Globalization.CultureInfo.InvariantCulture);
                            itemCongThoTongHop.CheckOut = DateTime.ParseExact(arrChamCong[arrChamCong.Length - 1].Trim(), "yyyy-MM-dd HH':'mm':'ss", System.Globalization.CultureInfo.InvariantCulture);
                            break;
                    }
                    lstCongThoTongHop.Add(itemCongThoTongHop);
                }

                try
                {
                    if (objUpdatePGBMaxValues != null) objUpdatePGBMaxValues(lstCongThoTongHop.Count);
                    DS_CheckInOut.DeleteOldTongHopCong(conn, tongHopCongTransaction, fromDate, toDate);
                    for (int i = 0; i < lstCongThoTongHop.Count; i++)
                    {
                        DS_CheckInOut.InsertTongHopCong(conn, tongHopCongTransaction, lstCongThoTongHop[i]);
                        if (objUpdatePGBValues != null) objUpdatePGBValues(i + 1);
                    }

                    tongHopCongTransaction.Commit();
                }
                catch (Exception ex)
                {
                    tongHopCongTransaction.Rollback();
                    throw ex;
                }

            }
        }

        #endregion
    }
}
