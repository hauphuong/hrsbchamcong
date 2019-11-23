using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using ApiFrame.Common;
using ApiFrame.Bussiness;
using log4net;

namespace ChamCongWinservices
{
    public partial class TongHopCong : ServiceBase
    {
        #region Variable
        private Timer TmrSyncChamCong = new Timer();
        public static readonly ILog ChamCongLog = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Event
        public TongHopCong()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            try
            {
                ChamCongLog.Info("<<<--- Start Services at: " + DateTime.Now + " --->>>");
                TmrSyncChamCong.Interval = GetSyncChamCongElapse() * 1000;
                TmrSyncChamCong.Elapsed += new ElapsedEventHandler(TmrSyncChamCong_Elapsed);
                TmrSyncChamCong.Start();
            }
            catch (Exception ex)
            {

                string errMsg = "==========================================================================="
                                + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name
                                + Environment.NewLine + ex.Message;
                ChamCongLog.Error(errMsg);
            }
        }

        void TmrSyncChamCong_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                TmrSyncChamCong.Enabled = false;
                DateTime fromDate = DateTime.Now.AddDays(-1); ;
                DateTime toDate = DateTime.Now;
                CheckInOut.Sync(fromDate, toDate);
                for (int i = 0; i < 3; i++)
                {
                    try
                    {
                        CheckInOut.TongHopCongTho(fromDate, toDate);
                        return;
                    }
                    catch (Exception ex)
                    {
                        string errMsg = "==========================================================================="
                                + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name
                                + Environment.NewLine + ex.Message;
                        ChamCongLog.Error(errMsg);
                        System.Threading.Thread.Sleep((i + 1) * 1000);
                    }

                }
            }
            catch (Exception ex)
            {
                string errMsg = "==========================================================================="
                                + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name
                                + Environment.NewLine + ex.Message;
                ChamCongLog.Error(errMsg);
            }
            finally
            {
                TmrSyncChamCong.Interval = GetSyncChamCongElapse() * 1000;
                TmrSyncChamCong.Enabled = true;
            }
        }



        protected override void OnStop()
        {
            ChamCongLog.Info("<<<--- Stop Services at: " + DateTime.Now + " --->>>");
        }

        #endregion

        #region Function
        private static long GetSyncChamCongElapse()
        {
            DateTime currentTime = DateTime.Now;
            DateTime scheduleTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, Constants.Configuration.PointAtTime_SyncChamCong, 0, 0);
            long intervalToElapse = 86400;
            if (currentTime <= scheduleTime)
                intervalToElapse = (long)scheduleTime.Subtract(currentTime).TotalSeconds;
            else
                intervalToElapse = (long)scheduleTime.AddDays(1).Subtract(currentTime).TotalSeconds;
            return intervalToElapse;
        }
        #endregion
    }
}
