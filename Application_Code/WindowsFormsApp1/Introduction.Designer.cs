namespace GUI
{
    partial class Introduction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Introduction));
            this.labelLeft = new System.Windows.Forms.Label();
            this.labelRight = new System.Windows.Forms.Label();
            this.sketch = new System.Windows.Forms.Label();
            this.welcome = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelLeft
            // 
            this.labelLeft.Location = new System.Drawing.Point(-2, -4);
            this.labelLeft.Name = "labelLeft";
            this.labelLeft.Size = new System.Drawing.Size(230, 669);
            this.labelLeft.TabIndex = 9;
            // 
            // labelRight
            // 
            this.labelRight.Location = new System.Drawing.Point(977, -4);
            this.labelRight.Name = "labelRight";
            this.labelRight.Size = new System.Drawing.Size(230, 669);
            this.labelRight.TabIndex = 8;
            // 
            // sketch
            // 
            this.sketch.AutoSize = true;
            this.sketch.Font = new System.Drawing.Font("Sitka Small", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sketch.Location = new System.Drawing.Point(272, 175);
            this.sketch.Name = "sketch";
            this.sketch.Size = new System.Drawing.Size(699, 189);
            this.sketch.TabIndex = 7;
            this.sketch.Text = "SketchIt!";
            // 
            // welcome
            // 
            this.welcome.AutoSize = true;
            this.welcome.Font = new System.Drawing.Font("Segoe Print", 28.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcome.ForeColor = System.Drawing.Color.Green;
            this.welcome.Location = new System.Drawing.Point(355, 32);
            this.welcome.Name = "welcome";
            this.welcome.Size = new System.Drawing.Size(492, 132);
            this.welcome.TabIndex = 6;
            this.welcome.Text = "Welcome to";
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.start.Font = new System.Drawing.Font("Courier New", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.start.Location = new System.Drawing.Point(412, 425);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(396, 130);
            this.start.TabIndex = 5;
            this.start.Text = "START";
            this.start.UseVisualStyleBackColor = false;
            this.start.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Start_MouseClick);
            this.start.MouseLeave += new System.EventHandler(this.Start_MouseLeave);
            this.start.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Start_MouseMove);
            // 
            // Introduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1210, 667);
            this.Controls.Add(this.labelLeft);
            this.Controls.Add(this.labelRight);
            this.Controls.Add(this.sketch);
            this.Controls.Add(this.welcome);
            this.Controls.Add(this.start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Introduction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SKETCHIT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Introduction2_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLeft;
        private System.Windows.Forms.Label labelRight;
        private System.Windows.Forms.Label sketch;
        private System.Windows.Forms.Label welcome;
        private System.Windows.Forms.Button start;
    }
}