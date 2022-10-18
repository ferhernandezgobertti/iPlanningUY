namespace GUI
{
    partial class ChartShowing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartShowing));
            this.help = new System.Windows.Forms.Button();
            this.backOption = new System.Windows.Forms.Button();
            this.jpgSaving = new System.Windows.Forms.Button();
            this.pngSaving = new System.Windows.Forms.Button();
            this.bmpSaving = new System.Windows.Forms.Button();
            this.windowsSizeHelper = new System.Windows.Forms.Label();
            this.backPanel = new System.Windows.Forms.Panel();
            this.chartShow = new System.Windows.Forms.Panel();
            this.gifSaving = new System.Windows.Forms.Button();
            this.wallMeters = new System.Windows.Forms.Label();
            this.beamQuantity = new System.Windows.Forms.Label();
            this.windowQuantity = new System.Windows.Forms.Label();
            this.doorQuantity = new System.Windows.Forms.Label();
            this.columnQuantity = new System.Windows.Forms.Label();
            this.differentStylesOptions = new System.Windows.Forms.CheckedListBox();
            this.backPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // help
            // 
            this.help.BackColor = System.Drawing.Color.Green;
            this.help.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.help.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.help.Location = new System.Drawing.Point(1437, -4);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(67, 80);
            this.help.TabIndex = 14;
            this.help.Text = "?";
            this.help.UseVisualStyleBackColor = false;
            this.help.Click += new System.EventHandler(this.Help_Click);
            // 
            // backOption
            // 
            this.backOption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.backOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backOption.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.backOption.Location = new System.Drawing.Point(1, -4);
            this.backOption.Name = "backOption";
            this.backOption.Size = new System.Drawing.Size(256, 94);
            this.backOption.TabIndex = 28;
            this.backOption.Text = "BACK";
            this.backOption.UseVisualStyleBackColor = false;
            this.backOption.Click += new System.EventHandler(this.BackOption_Click);
            // 
            // jpgSaving
            // 
            this.jpgSaving.AutoSize = true;
            this.jpgSaving.BackColor = System.Drawing.Color.Olive;
            this.jpgSaving.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jpgSaving.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.jpgSaving.Location = new System.Drawing.Point(1054, 290);
            this.jpgSaving.Name = "jpgSaving";
            this.jpgSaving.Size = new System.Drawing.Size(396, 110);
            this.jpgSaving.TabIndex = 53;
            this.jpgSaving.Text = "SAVE AS .JPG";
            this.jpgSaving.UseVisualStyleBackColor = false;
            this.jpgSaving.Click += new System.EventHandler(this.JpgSaving_Click);
            // 
            // pngSaving
            // 
            this.pngSaving.AutoSize = true;
            this.pngSaving.BackColor = System.Drawing.Color.Navy;
            this.pngSaving.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pngSaving.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pngSaving.Location = new System.Drawing.Point(1054, 460);
            this.pngSaving.Name = "pngSaving";
            this.pngSaving.Size = new System.Drawing.Size(393, 110);
            this.pngSaving.TabIndex = 54;
            this.pngSaving.Text = "SAVE AS .PNG";
            this.pngSaving.UseVisualStyleBackColor = false;
            this.pngSaving.Click += new System.EventHandler(this.PngSaving_Click);
            // 
            // bmpSaving
            // 
            this.bmpSaving.AutoSize = true;
            this.bmpSaving.BackColor = System.Drawing.Color.Maroon;
            this.bmpSaving.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bmpSaving.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bmpSaving.Location = new System.Drawing.Point(1054, 129);
            this.bmpSaving.Name = "bmpSaving";
            this.bmpSaving.Size = new System.Drawing.Size(396, 110);
            this.bmpSaving.TabIndex = 55;
            this.bmpSaving.Text = "SAVE AS .BMP";
            this.bmpSaving.UseVisualStyleBackColor = false;
            this.bmpSaving.Click += new System.EventHandler(this.BmpSaving_Click);
            // 
            // windowsSizeHelper
            // 
            this.windowsSizeHelper.Location = new System.Drawing.Point(1418, 1322);
            this.windowsSizeHelper.Name = "windowsSizeHelper";
            this.windowsSizeHelper.Size = new System.Drawing.Size(59, 23);
            this.windowsSizeHelper.TabIndex = 56;
            // 
            // backPanel
            // 
            this.backPanel.AutoScroll = true;
            this.backPanel.Controls.Add(this.chartShow);
            this.backPanel.Location = new System.Drawing.Point(58, 126);
            this.backPanel.Name = "backPanel";
            this.backPanel.Size = new System.Drawing.Size(938, 835);
            this.backPanel.TabIndex = 57;
            // 
            // chartShow
            // 
            this.chartShow.AutoSize = true;
            this.chartShow.Location = new System.Drawing.Point(3, 3);
            this.chartShow.Name = "chartShow";
            this.chartShow.Size = new System.Drawing.Size(818, 640);
            this.chartShow.TabIndex = 0;
            this.chartShow.Paint += new System.Windows.Forms.PaintEventHandler(this.ShowingChart_Paint);
            // 
            // gifSaving
            // 
            this.gifSaving.AutoSize = true;
            this.gifSaving.BackColor = System.Drawing.Color.Green;
            this.gifSaving.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gifSaving.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gifSaving.Location = new System.Drawing.Point(1051, 640);
            this.gifSaving.Name = "gifSaving";
            this.gifSaving.Size = new System.Drawing.Size(396, 110);
            this.gifSaving.TabIndex = 58;
            this.gifSaving.Text = "SAVE AS .GIF";
            this.gifSaving.UseVisualStyleBackColor = false;
            this.gifSaving.Click += new System.EventHandler(this.GifSaving_Click);
            // 
            // wallMeters
            // 
            this.wallMeters.AutoSize = true;
            this.wallMeters.Font = new System.Drawing.Font("Tahoma", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wallMeters.Location = new System.Drawing.Point(53, 1008);
            this.wallMeters.Name = "wallMeters";
            this.wallMeters.Size = new System.Drawing.Size(301, 45);
            this.wallMeters.TabIndex = 59;
            this.wallMeters.Text = "Meters of Wall:";
            // 
            // beamQuantity
            // 
            this.beamQuantity.AutoSize = true;
            this.beamQuantity.Font = new System.Drawing.Font("Tahoma", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beamQuantity.Location = new System.Drawing.Point(53, 1131);
            this.beamQuantity.Name = "beamQuantity";
            this.beamQuantity.Size = new System.Drawing.Size(308, 45);
            this.beamQuantity.TabIndex = 60;
            this.beamQuantity.Text = "Beam Quantity:";
            // 
            // windowQuantity
            // 
            this.windowQuantity.AutoSize = true;
            this.windowQuantity.Font = new System.Drawing.Font("Tahoma", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowQuantity.Location = new System.Drawing.Point(630, 1131);
            this.windowQuantity.Name = "windowQuantity";
            this.windowQuantity.Size = new System.Drawing.Size(356, 45);
            this.windowQuantity.TabIndex = 61;
            this.windowQuantity.Text = "Window Quantity:";
            // 
            // doorQuantity
            // 
            this.doorQuantity.AutoSize = true;
            this.doorQuantity.Font = new System.Drawing.Font("Tahoma", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doorQuantity.Location = new System.Drawing.Point(630, 1008);
            this.doorQuantity.Name = "doorQuantity";
            this.doorQuantity.Size = new System.Drawing.Size(294, 45);
            this.doorQuantity.TabIndex = 62;
            this.doorQuantity.Text = "Door Quantity:";
            // 
            // columnQuantity
            // 
            this.columnQuantity.AutoSize = true;
            this.columnQuantity.Font = new System.Drawing.Font("Tahoma", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnQuantity.Location = new System.Drawing.Point(630, 1245);
            this.columnQuantity.Name = "columnQuantity";
            this.columnQuantity.Size = new System.Drawing.Size(335, 45);
            this.columnQuantity.TabIndex = 63;
            this.columnQuantity.Text = "ColumnQuantity:";
            // 
            // differentStylesOptions
            // 
            this.differentStylesOptions.Font = new System.Drawing.Font("Segoe Print", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.differentStylesOptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.differentStylesOptions.FormattingEnabled = true;
            this.differentStylesOptions.Location = new System.Drawing.Point(1036, 795);
            this.differentStylesOptions.Name = "differentStylesOptions";
            this.differentStylesOptions.Size = new System.Drawing.Size(431, 166);
            this.differentStylesOptions.TabIndex = 64;
            this.differentStylesOptions.SelectedIndexChanged += new System.EventHandler(this.DifferentStylesOptions_SelectedIndexChanged);
            // 
            // ChartShowing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1504, 1336);
            this.Controls.Add(this.differentStylesOptions);
            this.Controls.Add(this.columnQuantity);
            this.Controls.Add(this.doorQuantity);
            this.Controls.Add(this.windowQuantity);
            this.Controls.Add(this.beamQuantity);
            this.Controls.Add(this.wallMeters);
            this.Controls.Add(this.gifSaving);
            this.Controls.Add(this.backPanel);
            this.Controls.Add(this.windowsSizeHelper);
            this.Controls.Add(this.bmpSaving);
            this.Controls.Add(this.pngSaving);
            this.Controls.Add(this.jpgSaving);
            this.Controls.Add(this.backOption);
            this.Controls.Add(this.help);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ChartShowing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YOUR CHART";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChartShowing_FormClosing);
            this.backPanel.ResumeLayout(false);
            this.backPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button help;
        private System.Windows.Forms.Button backOption;
        private System.Windows.Forms.Button jpgSaving;
        private System.Windows.Forms.Button pngSaving;
        private System.Windows.Forms.Button bmpSaving;
        private System.Windows.Forms.Label windowsSizeHelper;
        private System.Windows.Forms.Panel backPanel;
        private System.Windows.Forms.Panel chartShow;
        private System.Windows.Forms.Button gifSaving;
        private System.Windows.Forms.Label wallMeters;
        private System.Windows.Forms.Label beamQuantity;
        private System.Windows.Forms.Label windowQuantity;
        private System.Windows.Forms.Label doorQuantity;
        private System.Windows.Forms.Label columnQuantity;
        private System.Windows.Forms.CheckedListBox differentStylesOptions;
    }
}