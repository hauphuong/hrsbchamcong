namespace RunBusiness
{
    partial class frmTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSync = new System.Windows.Forms.Button();
            this.btnExeData = new System.Windows.Forms.Button();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.pgbTienDo = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(367, 37);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(96, 52);
            this.btnSync.TabIndex = 0;
            this.btnSync.Text = "Sync from ZK";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // btnExeData
            // 
            this.btnExeData.Location = new System.Drawing.Point(367, 106);
            this.btnExeData.Name = "btnExeData";
            this.btnExeData.Size = new System.Drawing.Size(96, 60);
            this.btnExeData.TabIndex = 1;
            this.btnExeData.Text = "Xử lý dữ liệu tổng hợp Công";
            this.btnExeData.UseVisualStyleBackColor = true;
            this.btnExeData.Click += new System.EventHandler(this.btnExeData_Click);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(33, 51);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(200, 20);
            this.dtpFromDate.TabIndex = 2;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(33, 124);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(200, 20);
            this.dtpToDate.TabIndex = 3;
            // 
            // pgbTienDo
            // 
            this.pgbTienDo.Location = new System.Drawing.Point(33, 233);
            this.pgbTienDo.Name = "pgbTienDo";
            this.pgbTienDo.Size = new System.Drawing.Size(430, 23);
            this.pgbTienDo.TabIndex = 4;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(195, 217);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(74, 13);
            this.lblProgress.TabIndex = 5;
            this.lblProgress.Text = "Complete: 0/0";
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 376);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.pgbTienDo);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.btnExeData);
            this.Controls.Add(this.btnSync);
            this.Name = "frmTest";
            this.Text = "Sync from ZK và Xử lý dữ liệu tổng hợp công";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Button btnExeData;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.ProgressBar pgbTienDo;
        private System.Windows.Forms.Label lblProgress;
    }
}

