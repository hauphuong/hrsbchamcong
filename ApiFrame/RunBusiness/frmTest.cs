using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ApiFrame.Bussiness;

namespace RunBusiness
{
    public partial class frmTest : Form
    {
        public CheckInOut.UpdateProgessBar objUpdateProgessBarValues;
        public CheckInOut.UpdateProgessBar objUpdateProgessBarMaxValues;
        public frmTest()
        {
            InitializeComponent();
            dtpFromDate.Value = new DateTime(2019, 10, 01).Date;
            dtpToDate.Value = new DateTime(2019, 11, 01).Date;
            dtpFromDate.Format = DateTimePickerFormat.Custom;
            dtpFromDate.CustomFormat = "dd-MM-yyyy";
            dtpToDate.Format = DateTimePickerFormat.Custom;
            dtpToDate.CustomFormat = "dd-MM-yyyy";
            
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtpFromDate.Value.Date;
            DateTime toDate = dtpToDate.Value.Date;
            objUpdateProgessBarValues = new CheckInOut.UpdateProgessBar(UpdateProgessBarValues);
            objUpdateProgessBarMaxValues = new CheckInOut.UpdateProgessBar(UpdateProgessBarMaxValues);
            CheckInOut.Sync(fromDate, toDate, objUpdateProgessBarMaxValues, objUpdateProgessBarValues);
            

        }
        void UpdateProgessBarValues(int values)
        {
            pgbTienDo.Value = values;
            lblProgress.Text = "Complete: " + values + "/" + pgbTienDo.Maximum;
        }
        void UpdateProgessBarMaxValues(int values)
        {
            pgbTienDo.Minimum = 0;
            pgbTienDo.Maximum = values;
            lblProgress.Text = "Complete: 0/" + values;
        }

        private void btnExeData_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtpFromDate.Value.Date;
            DateTime toDate = dtpToDate.Value.Date;
            objUpdateProgessBarValues = new CheckInOut.UpdateProgessBar(UpdateProgessBarValues);
            objUpdateProgessBarMaxValues = new CheckInOut.UpdateProgessBar(UpdateProgessBarMaxValues);
            CheckInOut.TongHopCongTho(fromDate, toDate, objUpdateProgessBarMaxValues, objUpdateProgessBarValues);
        }
    }
}
