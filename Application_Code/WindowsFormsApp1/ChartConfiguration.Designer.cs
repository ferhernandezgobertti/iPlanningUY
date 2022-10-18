namespace GUI
{
    partial class ChartConfiguration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartConfiguration));
            this.titleChart = new System.Windows.Forms.Label();
            this.confirm = new System.Windows.Forms.Button();
            this.windowSizeHelper = new System.Windows.Forms.Label();
            this.length = new System.Windows.Forms.Label();
            this.width = new System.Windows.Forms.Label();
            this.lengthTyped = new System.Windows.Forms.TextBox();
            this.lengthFailure = new System.Windows.Forms.Label();
            this.widthFailure = new System.Windows.Forms.Label();
            this.widthTyped = new System.Windows.Forms.TextBox();
            this.nameFailure = new System.Windows.Forms.Label();
            this.nameTyped = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.Label();
            this.help = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleChart
            // 
            this.titleChart.AutoSize = true;
            this.titleChart.Font = new System.Drawing.Font("Segoe Print", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleChart.ForeColor = System.Drawing.Color.Olive;
            this.titleChart.Location = new System.Drawing.Point(163, 26);
            this.titleChart.Name = "titleChart";
            this.titleChart.Size = new System.Drawing.Size(470, 112);
            this.titleChart.TabIndex = 37;
            this.titleChart.Text = "NEW CHART";
            // 
            // confirm
            // 
            this.confirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirm.ForeColor = System.Drawing.Color.White;
            this.confirm.Location = new System.Drawing.Point(353, 732);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(352, 108);
            this.confirm.TabIndex = 4;
            this.confirm.Text = "CONFIRM";
            this.confirm.UseVisualStyleBackColor = false;
            this.confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // windowSizeHelper
            // 
            this.windowSizeHelper.Location = new System.Drawing.Point(755, 852);
            this.windowSizeHelper.Name = "windowSizeHelper";
            this.windowSizeHelper.Size = new System.Drawing.Size(40, 42);
            this.windowSizeHelper.TabIndex = 39;
            // 
            // length
            // 
            this.length.AutoSize = true;
            this.length.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.length.Location = new System.Drawing.Point(55, 360);
            this.length.Name = "length";
            this.length.Size = new System.Drawing.Size(143, 42);
            this.length.TabIndex = 40;
            this.length.Text = "Length:";
            // 
            // width
            // 
            this.width.AutoSize = true;
            this.width.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.width.Location = new System.Drawing.Point(55, 538);
            this.width.Name = "width";
            this.width.Size = new System.Drawing.Size(123, 42);
            this.width.TabIndex = 41;
            this.width.Text = "Width:";
            // 
            // lengthTyped
            // 
            this.lengthTyped.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lengthTyped.Location = new System.Drawing.Point(62, 405);
            this.lengthTyped.Name = "lengthTyped";
            this.lengthTyped.Size = new System.Drawing.Size(643, 44);
            this.lengthTyped.TabIndex = 2;
            // 
            // lengthFailure
            // 
            this.lengthFailure.ForeColor = System.Drawing.Color.Red;
            this.lengthFailure.Location = new System.Drawing.Point(402, 456);
            this.lengthFailure.Name = "lengthFailure";
            this.lengthFailure.Size = new System.Drawing.Size(303, 65);
            this.lengthFailure.TabIndex = 43;
            // 
            // widthFailure
            // 
            this.widthFailure.ForeColor = System.Drawing.Color.Red;
            this.widthFailure.Location = new System.Drawing.Point(402, 634);
            this.widthFailure.Name = "widthFailure";
            this.widthFailure.Size = new System.Drawing.Size(303, 65);
            this.widthFailure.TabIndex = 45;
            // 
            // widthTyped
            // 
            this.widthTyped.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.widthTyped.Location = new System.Drawing.Point(62, 583);
            this.widthTyped.Name = "widthTyped";
            this.widthTyped.Size = new System.Drawing.Size(643, 44);
            this.widthTyped.TabIndex = 3;
            // 
            // nameFailure
            // 
            this.nameFailure.ForeColor = System.Drawing.Color.Red;
            this.nameFailure.Location = new System.Drawing.Point(402, 272);
            this.nameFailure.Name = "nameFailure";
            this.nameFailure.Size = new System.Drawing.Size(303, 65);
            this.nameFailure.TabIndex = 48;
            // 
            // nameTyped
            // 
            this.nameTyped.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTyped.Location = new System.Drawing.Point(62, 221);
            this.nameTyped.Name = "nameTyped";
            this.nameTyped.Size = new System.Drawing.Size(643, 44);
            this.nameTyped.TabIndex = 1;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(55, 176);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(127, 42);
            this.name.TabIndex = 46;
            this.name.Text = "Name:";
            // 
            // help
            // 
            this.help.BackColor = System.Drawing.Color.Green;
            this.help.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.help.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.help.Location = new System.Drawing.Point(728, -4);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(67, 80);
            this.help.TabIndex = 49;
            this.help.Text = "?";
            this.help.UseVisualStyleBackColor = false;
            this.help.Click += new System.EventHandler(this.Help_Click);
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.Teal;
            this.back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.ForeColor = System.Drawing.Color.White;
            this.back.Location = new System.Drawing.Point(62, 732);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(258, 108);
            this.back.TabIndex = 5;
            this.back.Text = "<- BACK";
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.Back_Click);
            // 
            // ChartConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(795, 903);
            this.Controls.Add(this.back);
            this.Controls.Add(this.help);
            this.Controls.Add(this.nameFailure);
            this.Controls.Add(this.nameTyped);
            this.Controls.Add(this.name);
            this.Controls.Add(this.widthFailure);
            this.Controls.Add(this.widthTyped);
            this.Controls.Add(this.lengthFailure);
            this.Controls.Add(this.lengthTyped);
            this.Controls.Add(this.width);
            this.Controls.Add(this.length);
            this.Controls.Add(this.windowSizeHelper);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.titleChart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ChartConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChartConfiguration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChartConfiguration_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleChart;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Label windowSizeHelper;
        private System.Windows.Forms.Label length;
        private System.Windows.Forms.Label width;
        private System.Windows.Forms.TextBox lengthTyped;
        private System.Windows.Forms.Label lengthFailure;
        private System.Windows.Forms.Label widthFailure;
        private System.Windows.Forms.TextBox widthTyped;
        private System.Windows.Forms.Label nameFailure;
        private System.Windows.Forms.TextBox nameTyped;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Button help;
        private System.Windows.Forms.Button back;
    }
}