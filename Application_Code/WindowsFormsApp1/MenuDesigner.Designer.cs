namespace GUI
{
    partial class MenuDesigner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuDesigner));
            this.label1 = new System.Windows.Forms.Label();
            this.showChart = new System.Windows.Forms.Button();
            this.windowsSizeHelper = new System.Windows.Forms.Label();
            this.passwordChange = new System.Windows.Forms.Button();
            this.designerData = new System.Windows.Forms.Label();
            this.alternativeOR2 = new System.Windows.Forms.Label();
            this.alternativeOR1 = new System.Windows.Forms.Label();
            this.titleWelcome = new System.Windows.Forms.Label();
            this.logOutOption = new System.Windows.Forms.Button();
            this.help = new System.Windows.Forms.Button();
            this.titleCharts = new System.Windows.Forms.Label();
            this.titleClients = new System.Windows.Forms.Label();
            this.eraseChart = new System.Windows.Forms.Button();
            this.modifyChart = new System.Windows.Forms.Button();
            this.clientsListed = new System.Windows.Forms.ListBox();
            this.chartsListed = new System.Windows.Forms.ListBox();
            this.newChart = new System.Windows.Forms.Button();
            this.holeCreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(917, 1067);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 37);
            this.label1.TabIndex = 63;
            this.label1.Text = "---------------- or ----------------";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // showChart
            // 
            this.showChart.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showChart.Location = new System.Drawing.Point(924, 1163);
            this.showChart.Name = "showChart";
            this.showChart.Size = new System.Drawing.Size(358, 110);
            this.showChart.TabIndex = 62;
            this.showChart.Text = "SHOW Chart";
            this.showChart.UseVisualStyleBackColor = true;
            this.showChart.Click += new System.EventHandler(this.ShowChart_Click);
            // 
            // windowsSizeHelper
            // 
            this.windowsSizeHelper.Location = new System.Drawing.Point(1880, 1318);
            this.windowsSizeHelper.Name = "windowsSizeHelper";
            this.windowsSizeHelper.Size = new System.Drawing.Size(59, 23);
            this.windowsSizeHelper.TabIndex = 61;
            // 
            // passwordChange
            // 
            this.passwordChange.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.passwordChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordChange.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.passwordChange.Location = new System.Drawing.Point(1703, 0);
            this.passwordChange.Name = "passwordChange";
            this.passwordChange.Size = new System.Drawing.Size(366, 80);
            this.passwordChange.TabIndex = 60;
            this.passwordChange.Text = "Change PASSWORD";
            this.passwordChange.UseVisualStyleBackColor = false;
            this.passwordChange.Click += new System.EventHandler(this.PasswordChange_Click);
            // 
            // designerData
            // 
            this.designerData.AutoSize = true;
            this.designerData.Cursor = System.Windows.Forms.Cursors.Cross;
            this.designerData.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.designerData.Location = new System.Drawing.Point(1082, 87);
            this.designerData.Name = "designerData";
            this.designerData.Size = new System.Drawing.Size(200, 56);
            this.designerData.TabIndex = 59;
            this.designerData.Text = "Your Data:";
            // 
            // alternativeOR2
            // 
            this.alternativeOR2.AutoSize = true;
            this.alternativeOR2.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.alternativeOR2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alternativeOR2.Location = new System.Drawing.Point(917, 829);
            this.alternativeOR2.Name = "alternativeOR2";
            this.alternativeOR2.Size = new System.Drawing.Size(384, 37);
            this.alternativeOR2.TabIndex = 58;
            this.alternativeOR2.Text = "---------------- or ----------------";
            this.alternativeOR2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // alternativeOR1
            // 
            this.alternativeOR1.AutoSize = true;
            this.alternativeOR1.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.alternativeOR1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alternativeOR1.Location = new System.Drawing.Point(917, 591);
            this.alternativeOR1.Name = "alternativeOR1";
            this.alternativeOR1.Size = new System.Drawing.Size(384, 37);
            this.alternativeOR1.TabIndex = 57;
            this.alternativeOR1.Text = "---------------- or ----------------";
            this.alternativeOR1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleWelcome
            // 
            this.titleWelcome.AutoSize = true;
            this.titleWelcome.Font = new System.Drawing.Font("Segoe Print", 28.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleWelcome.ForeColor = System.Drawing.Color.Green;
            this.titleWelcome.Location = new System.Drawing.Point(46, 137);
            this.titleWelcome.Name = "titleWelcome";
            this.titleWelcome.Size = new System.Drawing.Size(948, 132);
            this.titleWelcome.TabIndex = 56;
            this.titleWelcome.Text = "WELCOME, DESIGNER!";
            // 
            // logOutOption
            // 
            this.logOutOption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.logOutOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOutOption.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.logOutOption.Location = new System.Drawing.Point(-5, 0);
            this.logOutOption.Name = "logOutOption";
            this.logOutOption.Size = new System.Drawing.Size(256, 94);
            this.logOutOption.TabIndex = 55;
            this.logOutOption.Text = "LOG OUT";
            this.logOutOption.UseVisualStyleBackColor = false;
            this.logOutOption.Click += new System.EventHandler(this.LogOutOption_Click);
            // 
            // help
            // 
            this.help.BackColor = System.Drawing.Color.Green;
            this.help.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.help.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.help.Location = new System.Drawing.Point(2075, 0);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(67, 80);
            this.help.TabIndex = 54;
            this.help.Text = "?";
            this.help.UseVisualStyleBackColor = false;
            this.help.Click += new System.EventHandler(this.Help_Click);
            // 
            // titleCharts
            // 
            this.titleCharts.AutoSize = true;
            this.titleCharts.Font = new System.Drawing.Font("Segoe Print", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleCharts.ForeColor = System.Drawing.Color.Olive;
            this.titleCharts.Location = new System.Drawing.Point(228, 334);
            this.titleCharts.Name = "titleCharts";
            this.titleCharts.Size = new System.Drawing.Size(436, 112);
            this.titleCharts.TabIndex = 53;
            this.titleCharts.Text = "All CHARTS";
            // 
            // titleClients
            // 
            this.titleClients.AutoSize = true;
            this.titleClients.Font = new System.Drawing.Font("Segoe Print", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleClients.ForeColor = System.Drawing.Color.Navy;
            this.titleClients.Location = new System.Drawing.Point(1495, 334);
            this.titleClients.Name = "titleClients";
            this.titleClients.Size = new System.Drawing.Size(444, 112);
            this.titleClients.TabIndex = 52;
            this.titleClients.Text = "All CLIENTS";
            // 
            // eraseChart
            // 
            this.eraseChart.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eraseChart.Location = new System.Drawing.Point(924, 909);
            this.eraseChart.Name = "eraseChart";
            this.eraseChart.Size = new System.Drawing.Size(358, 110);
            this.eraseChart.TabIndex = 51;
            this.eraseChart.Text = "ERASE Chart";
            this.eraseChart.UseVisualStyleBackColor = true;
            this.eraseChart.Click += new System.EventHandler(this.EraseChart_Click);
            // 
            // modifyChart
            // 
            this.modifyChart.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyChart.Location = new System.Drawing.Point(924, 669);
            this.modifyChart.Name = "modifyChart";
            this.modifyChart.Size = new System.Drawing.Size(358, 110);
            this.modifyChart.TabIndex = 50;
            this.modifyChart.Text = "MODIFY Chart";
            this.modifyChart.UseVisualStyleBackColor = true;
            this.modifyChart.Click += new System.EventHandler(this.ModifyChart_Click);
            // 
            // clientsListed
            // 
            this.clientsListed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientsListed.FormattingEnabled = true;
            this.clientsListed.HorizontalScrollbar = true;
            this.clientsListed.ItemHeight = 31;
            this.clientsListed.Location = new System.Drawing.Point(1349, 449);
            this.clientsListed.Name = "clientsListed";
            this.clientsListed.Size = new System.Drawing.Size(715, 841);
            this.clientsListed.TabIndex = 49;
            this.clientsListed.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClientsListed_MouseClick);
            // 
            // chartsListed
            // 
            this.chartsListed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartsListed.FormattingEnabled = true;
            this.chartsListed.HorizontalScrollbar = true;
            this.chartsListed.ItemHeight = 31;
            this.chartsListed.Location = new System.Drawing.Point(58, 449);
            this.chartsListed.Name = "chartsListed";
            this.chartsListed.Size = new System.Drawing.Size(803, 841);
            this.chartsListed.TabIndex = 48;
            this.chartsListed.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChartsListed_MouseClick);
            this.chartsListed.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ChartsListed_DrawItem);
            // 
            // newChart
            // 
            this.newChart.AutoSize = true;
            this.newChart.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newChart.Location = new System.Drawing.Point(924, 449);
            this.newChart.Name = "newChart";
            this.newChart.Size = new System.Drawing.Size(358, 110);
            this.newChart.TabIndex = 47;
            this.newChart.Text = "CREATE Chart";
            this.newChart.UseVisualStyleBackColor = true;
            this.newChart.Click += new System.EventHandler(this.NewChart_Click);
            // 
            // holeCreate
            // 
            this.holeCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.holeCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.holeCreate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.holeCreate.Location = new System.Drawing.Point(1322, 0);
            this.holeCreate.Name = "holeCreate";
            this.holeCreate.Size = new System.Drawing.Size(366, 80);
            this.holeCreate.TabIndex = 64;
            this.holeCreate.Text = "Create NEW HOLE";
            this.holeCreate.UseVisualStyleBackColor = false;
            this.holeCreate.Click += new System.EventHandler(this.HoleCreate_Click);
            // 
            // MenuDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(2142, 1331);
            this.Controls.Add(this.holeCreate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.showChart);
            this.Controls.Add(this.windowsSizeHelper);
            this.Controls.Add(this.passwordChange);
            this.Controls.Add(this.designerData);
            this.Controls.Add(this.alternativeOR2);
            this.Controls.Add(this.alternativeOR1);
            this.Controls.Add(this.titleWelcome);
            this.Controls.Add(this.logOutOption);
            this.Controls.Add(this.help);
            this.Controls.Add(this.titleCharts);
            this.Controls.Add(this.titleClients);
            this.Controls.Add(this.eraseChart);
            this.Controls.Add(this.modifyChart);
            this.Controls.Add(this.clientsListed);
            this.Controls.Add(this.chartsListed);
            this.Controls.Add(this.newChart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MenuDesigner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SKETCHIT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuDesigner_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.MenuDesigner_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button showChart;
        private System.Windows.Forms.Label windowsSizeHelper;
        private System.Windows.Forms.Button passwordChange;
        private System.Windows.Forms.Label designerData;
        private System.Windows.Forms.Label alternativeOR2;
        private System.Windows.Forms.Label alternativeOR1;
        private System.Windows.Forms.Label titleWelcome;
        private System.Windows.Forms.Button logOutOption;
        private System.Windows.Forms.Button help;
        private System.Windows.Forms.Label titleCharts;
        private System.Windows.Forms.Label titleClients;
        private System.Windows.Forms.Button eraseChart;
        private System.Windows.Forms.Button modifyChart;
        private System.Windows.Forms.ListBox clientsListed;
        private System.Windows.Forms.ListBox chartsListed;
        private System.Windows.Forms.Button newChart;
        private System.Windows.Forms.Button holeCreate;
    }
}