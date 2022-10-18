namespace GUI
{
    partial class MenuClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuClient));
            this.label1 = new System.Windows.Forms.Label();
            this.windowsSizeHelper = new System.Windows.Forms.Label();
            this.selectChart = new System.Windows.Forms.Button();
            this.helpClient = new System.Windows.Forms.Button();
            this.passwordChange = new System.Windows.Forms.Button();
            this.clientData = new System.Windows.Forms.Label();
            this.titleWelcome = new System.Windows.Forms.Label();
            this.logOutOption = new System.Windows.Forms.Button();
            this.titleSignedCharts = new System.Windows.Forms.Label();
            this.signedChartsListed = new System.Windows.Forms.ListBox();
            this.titleUnsignedCharts = new System.Windows.Forms.Label();
            this.unsignedChartsListed = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1492, 1382);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 23);
            this.label1.TabIndex = 64;
            // 
            // windowsSizeHelper
            // 
            this.windowsSizeHelper.Location = new System.Drawing.Point(1798, 1382);
            this.windowsSizeHelper.Name = "windowsSizeHelper";
            this.windowsSizeHelper.Size = new System.Drawing.Size(59, 23);
            this.windowsSizeHelper.TabIndex = 63;
            // 
            // selectChart
            // 
            this.selectChart.AutoSize = true;
            this.selectChart.BackColor = System.Drawing.Color.Green;
            this.selectChart.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectChart.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.selectChart.Location = new System.Drawing.Point(501, 1354);
            this.selectChart.Name = "selectChart";
            this.selectChart.Size = new System.Drawing.Size(817, 110);
            this.selectChart.TabIndex = 62;
            this.selectChart.Text = "SELECT CHART";
            this.selectChart.UseVisualStyleBackColor = false;
            this.selectChart.Click += new System.EventHandler(this.SelectChart_Click);
            // 
            // helpClient
            // 
            this.helpClient.BackColor = System.Drawing.Color.Green;
            this.helpClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpClient.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.helpClient.Location = new System.Drawing.Point(2463, 1);
            this.helpClient.Name = "helpClient";
            this.helpClient.Size = new System.Drawing.Size(67, 80);
            this.helpClient.TabIndex = 61;
            this.helpClient.Text = "?";
            this.helpClient.UseVisualStyleBackColor = false;
            this.helpClient.Click += new System.EventHandler(this.HelpClient_Click);
            // 
            // passwordChange
            // 
            this.passwordChange.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.passwordChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordChange.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.passwordChange.Location = new System.Drawing.Point(2100, 1);
            this.passwordChange.Name = "passwordChange";
            this.passwordChange.Size = new System.Drawing.Size(366, 80);
            this.passwordChange.TabIndex = 60;
            this.passwordChange.Text = "Change PASSWORD";
            this.passwordChange.UseVisualStyleBackColor = false;
            this.passwordChange.Click += new System.EventHandler(this.PasswordChange_Click);
            // 
            // clientData
            // 
            this.clientData.AutoSize = true;
            this.clientData.Cursor = System.Windows.Forms.Cursors.Cross;
            this.clientData.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientData.Location = new System.Drawing.Point(1044, 114);
            this.clientData.Name = "clientData";
            this.clientData.Size = new System.Drawing.Size(200, 56);
            this.clientData.TabIndex = 59;
            this.clientData.Text = "Your Data:";
            // 
            // titleWelcome
            // 
            this.titleWelcome.AutoSize = true;
            this.titleWelcome.Font = new System.Drawing.Font("Segoe Print", 28.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleWelcome.ForeColor = System.Drawing.Color.Blue;
            this.titleWelcome.Location = new System.Drawing.Point(87, 125);
            this.titleWelcome.Name = "titleWelcome";
            this.titleWelcome.Size = new System.Drawing.Size(826, 132);
            this.titleWelcome.TabIndex = 58;
            this.titleWelcome.Text = "WELCOME, CLIENT!";
            // 
            // logOutOption
            // 
            this.logOutOption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.logOutOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOutOption.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.logOutOption.Location = new System.Drawing.Point(-6, 1);
            this.logOutOption.Name = "logOutOption";
            this.logOutOption.Size = new System.Drawing.Size(256, 94);
            this.logOutOption.TabIndex = 57;
            this.logOutOption.Text = "LOG OUT";
            this.logOutOption.UseVisualStyleBackColor = false;
            this.logOutOption.Click += new System.EventHandler(this.LogOutOption_Click);
            // 
            // titleSignedCharts
            // 
            this.titleSignedCharts.AutoSize = true;
            this.titleSignedCharts.Font = new System.Drawing.Font("Segoe Print", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleSignedCharts.ForeColor = System.Drawing.Color.Purple;
            this.titleSignedCharts.Location = new System.Drawing.Point(1231, 400);
            this.titleSignedCharts.Name = "titleSignedCharts";
            this.titleSignedCharts.Size = new System.Drawing.Size(784, 112);
            this.titleSignedCharts.TabIndex = 56;
            this.titleSignedCharts.Text = "Your SIGNED CHARTS";
            // 
            // signedChartsListed
            // 
            this.signedChartsListed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signedChartsListed.FormattingEnabled = true;
            this.signedChartsListed.HorizontalScrollbar = true;
            this.signedChartsListed.ItemHeight = 31;
            this.signedChartsListed.Location = new System.Drawing.Point(1054, 525);
            this.signedChartsListed.Name = "signedChartsListed";
            this.signedChartsListed.Size = new System.Drawing.Size(1449, 810);
            this.signedChartsListed.TabIndex = 55;
            this.signedChartsListed.Click += new System.EventHandler(this.SignedChartsListed_Click);
            this.signedChartsListed.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.SignedChartsListed_DrawItem);
            // 
            // titleUnsignedCharts
            // 
            this.titleUnsignedCharts.AutoSize = true;
            this.titleUnsignedCharts.Font = new System.Drawing.Font("Segoe Print", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleUnsignedCharts.ForeColor = System.Drawing.Color.Maroon;
            this.titleUnsignedCharts.Location = new System.Drawing.Point(47, 400);
            this.titleUnsignedCharts.Name = "titleUnsignedCharts";
            this.titleUnsignedCharts.Size = new System.Drawing.Size(885, 112);
            this.titleUnsignedCharts.TabIndex = 66;
            this.titleUnsignedCharts.Text = "Your UNSIGNED CHARTS";
            // 
            // unsignedChartsListed
            // 
            this.unsignedChartsListed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unsignedChartsListed.FormattingEnabled = true;
            this.unsignedChartsListed.HorizontalScrollbar = true;
            this.unsignedChartsListed.ItemHeight = 31;
            this.unsignedChartsListed.Location = new System.Drawing.Point(101, 525);
            this.unsignedChartsListed.Name = "unsignedChartsListed";
            this.unsignedChartsListed.Size = new System.Drawing.Size(812, 810);
            this.unsignedChartsListed.TabIndex = 65;
            this.unsignedChartsListed.Click += new System.EventHandler(this.UnsignedChartsListed_Click);
            // 
            // MenuClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(2533, 1476);
            this.Controls.Add(this.titleUnsignedCharts);
            this.Controls.Add(this.unsignedChartsListed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.windowsSizeHelper);
            this.Controls.Add(this.selectChart);
            this.Controls.Add(this.helpClient);
            this.Controls.Add(this.passwordChange);
            this.Controls.Add(this.clientData);
            this.Controls.Add(this.titleWelcome);
            this.Controls.Add(this.logOutOption);
            this.Controls.Add(this.titleSignedCharts);
            this.Controls.Add(this.signedChartsListed);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MenuClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SKETCHIT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuClient_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label windowsSizeHelper;
        private System.Windows.Forms.Button selectChart;
        private System.Windows.Forms.Button helpClient;
        private System.Windows.Forms.Button passwordChange;
        private System.Windows.Forms.Label clientData;
        private System.Windows.Forms.Label titleWelcome;
        private System.Windows.Forms.Button logOutOption;
        private System.Windows.Forms.Label titleSignedCharts;
        private System.Windows.Forms.ListBox signedChartsListed;
        private System.Windows.Forms.Label titleUnsignedCharts;
        private System.Windows.Forms.ListBox unsignedChartsListed;
    }
}