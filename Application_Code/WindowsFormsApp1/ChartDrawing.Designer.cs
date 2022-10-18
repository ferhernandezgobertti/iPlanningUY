namespace GUI
{
    partial class ChartDrawing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartDrawing));
            this.chartDraw = new System.Windows.Forms.Panel();
            this.help = new System.Windows.Forms.Button();
            this.titleHoles = new System.Windows.Forms.Label();
            this.door = new System.Windows.Forms.Panel();
            this.titleDoor = new System.Windows.Forms.Label();
            this.titleWindow = new System.Windows.Forms.Label();
            this.window = new System.Windows.Forms.Panel();
            this.confirmChanges = new System.Windows.Forms.Button();
            this.chartPrice = new System.Windows.Forms.Label();
            this.currentCost = new System.Windows.Forms.Label();
            this.removeLine = new System.Windows.Forms.Button();
            this.removeHole = new System.Windows.Forms.Button();
            this.rotateDoor = new System.Windows.Forms.Button();
            this.rotateWindow = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.backOption = new System.Windows.Forms.Button();
            this.titleChart = new System.Windows.Forms.Label();
            this.windowSizeHelper = new System.Windows.Forms.Label();
            this.currentEarnings = new System.Windows.Forms.Label();
            this.earnings = new System.Windows.Forms.Label();
            this.backPanel = new System.Windows.Forms.Panel();
            this.column = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.differentStylesOptions = new System.Windows.Forms.CheckedListBox();
            this.doorSelector = new System.Windows.Forms.DomainUpDown();
            this.windowSelector = new System.Windows.Forms.DomainUpDown();
            this.backPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartDraw
            // 
            this.chartDraw.AutoSize = true;
            this.chartDraw.Location = new System.Drawing.Point(4, 4);
            this.chartDraw.Margin = new System.Windows.Forms.Padding(4);
            this.chartDraw.Name = "chartDraw";
            this.chartDraw.Size = new System.Drawing.Size(748, 683);
            this.chartDraw.TabIndex = 0;
            this.chartDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.ChartDraw_Paint);
            this.chartDraw.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChartDraw_MouseClick);
            this.chartDraw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChartDraw_MouseDown);
            this.chartDraw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ChartDraw_MouseUp);
            // 
            // help
            // 
            this.help.BackColor = System.Drawing.Color.Green;
            this.help.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.help.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.help.Location = new System.Drawing.Point(1816, -2);
            this.help.Margin = new System.Windows.Forms.Padding(4);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(68, 81);
            this.help.TabIndex = 13;
            this.help.Text = "?";
            this.help.UseVisualStyleBackColor = false;
            this.help.Click += new System.EventHandler(this.Help_Click);
            // 
            // titleHoles
            // 
            this.titleHoles.AutoSize = true;
            this.titleHoles.Font = new System.Drawing.Font("Segoe Script", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleHoles.ForeColor = System.Drawing.Color.Purple;
            this.titleHoles.Location = new System.Drawing.Point(1324, 131);
            this.titleHoles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleHoles.Name = "titleHoles";
            this.titleHoles.Size = new System.Drawing.Size(195, 87);
            this.titleHoles.TabIndex = 14;
            this.titleHoles.Text = "Holes:";
            // 
            // door
            // 
            this.door.Location = new System.Drawing.Point(1090, 242);
            this.door.Margin = new System.Windows.Forms.Padding(4);
            this.door.Name = "door";
            this.door.Size = new System.Drawing.Size(198, 173);
            this.door.TabIndex = 15;
            this.door.Paint += new System.Windows.Forms.PaintEventHandler(this.Door_Paint);
            this.door.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Door_MouseDoubleClick);
            // 
            // titleDoor
            // 
            this.titleDoor.AutoSize = true;
            this.titleDoor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleDoor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.titleDoor.Location = new System.Drawing.Point(1314, 312);
            this.titleDoor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleDoor.Name = "titleDoor";
            this.titleDoor.Size = new System.Drawing.Size(99, 42);
            this.titleDoor.TabIndex = 16;
            this.titleDoor.Text = "Door";
            // 
            // titleWindow
            // 
            this.titleWindow.AutoSize = true;
            this.titleWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleWindow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.titleWindow.Location = new System.Drawing.Point(1294, 531);
            this.titleWindow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleWindow.Name = "titleWindow";
            this.titleWindow.Size = new System.Drawing.Size(151, 42);
            this.titleWindow.TabIndex = 18;
            this.titleWindow.Text = "Window";
            // 
            // window
            // 
            this.window.Location = new System.Drawing.Point(1090, 477);
            this.window.Margin = new System.Windows.Forms.Padding(4);
            this.window.Name = "window";
            this.window.Size = new System.Drawing.Size(198, 179);
            this.window.TabIndex = 17;
            this.window.Paint += new System.Windows.Forms.PaintEventHandler(this.Window_Paint);
            this.window.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Window_MouseDoubleClick);
            // 
            // confirmChanges
            // 
            this.confirmChanges.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.confirmChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmChanges.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.confirmChanges.Location = new System.Drawing.Point(76, 1161);
            this.confirmChanges.Margin = new System.Windows.Forms.Padding(4);
            this.confirmChanges.Name = "confirmChanges";
            this.confirmChanges.Size = new System.Drawing.Size(440, 123);
            this.confirmChanges.TabIndex = 19;
            this.confirmChanges.Text = "CONFIRM CHANGES";
            this.confirmChanges.UseVisualStyleBackColor = false;
            this.confirmChanges.Click += new System.EventHandler(this.ConfirmChanges_Click);
            // 
            // chartPrice
            // 
            this.chartPrice.AutoSize = true;
            this.chartPrice.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartPrice.ForeColor = System.Drawing.Color.Red;
            this.chartPrice.Location = new System.Drawing.Point(554, 1151);
            this.chartPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.chartPrice.Name = "chartPrice";
            this.chartPrice.Size = new System.Drawing.Size(218, 53);
            this.chartPrice.TabIndex = 20;
            this.chartPrice.Text = "Chart Cost:";
            // 
            // currentCost
            // 
            this.currentCost.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentCost.ForeColor = System.Drawing.Color.Red;
            this.currentCost.Location = new System.Drawing.Point(810, 1151);
            this.currentCost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentCost.Name = "currentCost";
            this.currentCost.Size = new System.Drawing.Size(218, 54);
            this.currentCost.TabIndex = 21;
            this.currentCost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // removeLine
            // 
            this.removeLine.BackColor = System.Drawing.Color.Blue;
            this.removeLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeLine.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.removeLine.Location = new System.Drawing.Point(1146, 950);
            this.removeLine.Margin = new System.Windows.Forms.Padding(4);
            this.removeLine.Name = "removeLine";
            this.removeLine.Size = new System.Drawing.Size(267, 97);
            this.removeLine.TabIndex = 22;
            this.removeLine.Text = "Remove LINE";
            this.removeLine.UseVisualStyleBackColor = false;
            this.removeLine.Click += new System.EventHandler(this.RemoveLine_Click);
            // 
            // removeHole
            // 
            this.removeHole.BackColor = System.Drawing.Color.Green;
            this.removeHole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeHole.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.removeHole.Location = new System.Drawing.Point(1505, 950);
            this.removeHole.Margin = new System.Windows.Forms.Padding(4);
            this.removeHole.Name = "removeHole";
            this.removeHole.Size = new System.Drawing.Size(267, 97);
            this.removeHole.TabIndex = 23;
            this.removeHole.Text = "Remove HOLE";
            this.removeHole.UseVisualStyleBackColor = false;
            this.removeHole.Click += new System.EventHandler(this.RemoveHole_Click);
            // 
            // rotateDoor
            // 
            this.rotateDoor.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rotateDoor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rotateDoor.Location = new System.Drawing.Point(1454, 304);
            this.rotateDoor.Margin = new System.Windows.Forms.Padding(4);
            this.rotateDoor.Name = "rotateDoor";
            this.rotateDoor.Size = new System.Drawing.Size(132, 67);
            this.rotateDoor.TabIndex = 24;
            this.rotateDoor.Text = "ROTATE";
            this.rotateDoor.UseVisualStyleBackColor = false;
            this.rotateDoor.Click += new System.EventHandler(this.RotateDoor_Click);
            // 
            // rotateWindow
            // 
            this.rotateWindow.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rotateWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rotateWindow.Location = new System.Drawing.Point(1454, 523);
            this.rotateWindow.Margin = new System.Windows.Forms.Padding(4);
            this.rotateWindow.Name = "rotateWindow";
            this.rotateWindow.Size = new System.Drawing.Size(132, 67);
            this.rotateWindow.TabIndex = 25;
            this.rotateWindow.Text = "ROTATE";
            this.rotateWindow.UseVisualStyleBackColor = false;
            this.rotateWindow.Click += new System.EventHandler(this.RotateWindow_Click);
            // 
            // clear
            // 
            this.clear.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.clear.Location = new System.Drawing.Point(1570, -2);
            this.clear.Margin = new System.Windows.Forms.Padding(4);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(250, 81);
            this.clear.TabIndex = 26;
            this.clear.Text = "CLEAR";
            this.clear.UseVisualStyleBackColor = false;
            this.clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // backOption
            // 
            this.backOption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.backOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backOption.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.backOption.Location = new System.Drawing.Point(0, -2);
            this.backOption.Margin = new System.Windows.Forms.Padding(4);
            this.backOption.Name = "backOption";
            this.backOption.Size = new System.Drawing.Size(256, 94);
            this.backOption.TabIndex = 27;
            this.backOption.Text = "BACK";
            this.backOption.UseVisualStyleBackColor = false;
            this.backOption.Click += new System.EventHandler(this.BackOption_Click);
            // 
            // titleChart
            // 
            this.titleChart.AutoSize = true;
            this.titleChart.Font = new System.Drawing.Font("Segoe Print", 28.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleChart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.titleChart.Location = new System.Drawing.Point(304, 44);
            this.titleChart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleChart.Name = "titleChart";
            this.titleChart.Size = new System.Drawing.Size(382, 132);
            this.titleChart.TabIndex = 28;
            this.titleChart.Text = "CHART: ";
            // 
            // windowSizeHelper
            // 
            this.windowSizeHelper.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowSizeHelper.ForeColor = System.Drawing.Color.Red;
            this.windowSizeHelper.Location = new System.Drawing.Point(1852, 1271);
            this.windowSizeHelper.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.windowSizeHelper.Name = "windowSizeHelper";
            this.windowSizeHelper.Size = new System.Drawing.Size(32, 54);
            this.windowSizeHelper.TabIndex = 29;
            // 
            // currentEarnings
            // 
            this.currentEarnings.Font = new System.Drawing.Font("Segoe Script", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentEarnings.ForeColor = System.Drawing.Color.Red;
            this.currentEarnings.Location = new System.Drawing.Point(807, 1230);
            this.currentEarnings.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentEarnings.Name = "currentEarnings";
            this.currentEarnings.Size = new System.Drawing.Size(218, 54);
            this.currentEarnings.TabIndex = 31;
            this.currentEarnings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // earnings
            // 
            this.earnings.AutoSize = true;
            this.earnings.Font = new System.Drawing.Font("Segoe Script", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.earnings.ForeColor = System.Drawing.Color.Red;
            this.earnings.Location = new System.Drawing.Point(551, 1222);
            this.earnings.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.earnings.Name = "earnings";
            this.earnings.Size = new System.Drawing.Size(248, 71);
            this.earnings.TabIndex = 30;
            this.earnings.Text = "Earnings:";
            // 
            // backPanel
            // 
            this.backPanel.AutoScroll = true;
            this.backPanel.AutoScrollMargin = new System.Drawing.Size(5, 5);
            this.backPanel.AutoScrollMinSize = new System.Drawing.Size(5, 5);
            this.backPanel.Controls.Add(this.chartDraw);
            this.backPanel.Location = new System.Drawing.Point(52, 242);
            this.backPanel.Margin = new System.Windows.Forms.Padding(4);
            this.backPanel.Name = "backPanel";
            this.backPanel.Size = new System.Drawing.Size(960, 862);
            this.backPanel.TabIndex = 32;
            // 
            // column
            // 
            this.column.Location = new System.Drawing.Point(1090, 707);
            this.column.Margin = new System.Windows.Forms.Padding(4);
            this.column.Name = "column";
            this.column.Size = new System.Drawing.Size(198, 179);
            this.column.TabIndex = 26;
            this.column.Paint += new System.Windows.Forms.PaintEventHandler(this.Column_Paint);
            this.column.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Column_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Olive;
            this.label1.Location = new System.Drawing.Point(1294, 762);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 42);
            this.label1.TabIndex = 27;
            this.label1.Text = "Decorative Column";
            // 
            // differentStylesOptions
            // 
            this.differentStylesOptions.Font = new System.Drawing.Font("Segoe Print", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.differentStylesOptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.differentStylesOptions.FormattingEnabled = true;
            this.differentStylesOptions.Location = new System.Drawing.Point(1233, 1118);
            this.differentStylesOptions.Name = "differentStylesOptions";
            this.differentStylesOptions.Size = new System.Drawing.Size(431, 166);
            this.differentStylesOptions.TabIndex = 33;
            this.differentStylesOptions.SelectedIndexChanged += new System.EventHandler(this.DifferentStylesOptions_SelectedIndexChanged);
            // 
            // doorSelector
            // 
            this.doorSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doorSelector.Location = new System.Drawing.Point(1613, 319);
            this.doorSelector.Name = "doorSelector";
            this.doorSelector.Size = new System.Drawing.Size(248, 35);
            this.doorSelector.TabIndex = 34;
            this.doorSelector.Text = "SELECT DOOR";
            // 
            // windowSelector
            // 
            this.windowSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowSelector.Location = new System.Drawing.Point(1613, 538);
            this.windowSelector.Name = "windowSelector";
            this.windowSelector.Size = new System.Drawing.Size(248, 35);
            this.windowSelector.TabIndex = 35;
            this.windowSelector.Text = "SELECT WINDOW";
            // 
            // ChartDrawing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1883, 1322);
            this.Controls.Add(this.windowSelector);
            this.Controls.Add(this.doorSelector);
            this.Controls.Add(this.differentStylesOptions);
            this.Controls.Add(this.column);
            this.Controls.Add(this.currentEarnings);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.earnings);
            this.Controls.Add(this.window);
            this.Controls.Add(this.door);
            this.Controls.Add(this.windowSizeHelper);
            this.Controls.Add(this.titleChart);
            this.Controls.Add(this.backOption);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.rotateWindow);
            this.Controls.Add(this.rotateDoor);
            this.Controls.Add(this.removeHole);
            this.Controls.Add(this.removeLine);
            this.Controls.Add(this.currentCost);
            this.Controls.Add(this.chartPrice);
            this.Controls.Add(this.confirmChanges);
            this.Controls.Add(this.titleWindow);
            this.Controls.Add(this.titleDoor);
            this.Controls.Add(this.titleHoles);
            this.Controls.Add(this.help);
            this.Controls.Add(this.backPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ChartDrawing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DRAW YOUR CHART!";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChartDrawing_FormClosing);
            this.backPanel.ResumeLayout(false);
            this.backPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel chartDraw;
        private System.Windows.Forms.Button help;
        private System.Windows.Forms.Label titleHoles;
        private System.Windows.Forms.Panel door;
        private System.Windows.Forms.Label titleDoor;
        private System.Windows.Forms.Label titleWindow;
        private System.Windows.Forms.Panel window;
        private System.Windows.Forms.Button confirmChanges;
        private System.Windows.Forms.Label chartPrice;
        private System.Windows.Forms.Label currentCost;
        private System.Windows.Forms.Button removeLine;
        private System.Windows.Forms.Button removeHole;
        private System.Windows.Forms.Button rotateDoor;
        private System.Windows.Forms.Button rotateWindow;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Button backOption;
        private System.Windows.Forms.Label titleChart;
        private System.Windows.Forms.Label windowSizeHelper;
        private System.Windows.Forms.Label currentEarnings;
        private System.Windows.Forms.Label earnings;
        private System.Windows.Forms.Panel backPanel;
        private System.Windows.Forms.Panel column;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox differentStylesOptions;
        private System.Windows.Forms.DomainUpDown doorSelector;
        private System.Windows.Forms.DomainUpDown windowSelector;
    }
}

