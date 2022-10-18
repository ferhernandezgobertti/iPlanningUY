namespace GUI
{
    partial class MaterialConfiguration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialConfiguration));
            this.back = new System.Windows.Forms.Button();
            this.help = new System.Windows.Forms.Button();
            this.wallCostTyped = new System.Windows.Forms.TextBox();
            this.titleWall = new System.Windows.Forms.Label();
            this.confirm = new System.Windows.Forms.Button();
            this.titleMaterial = new System.Windows.Forms.Label();
            this.perMeter = new System.Windows.Forms.Label();
            this.titlePrice = new System.Windows.Forms.Label();
            this.titleCost = new System.Windows.Forms.Label();
            this.wallPriceTyped = new System.Windows.Forms.TextBox();
            this.beamPriceTyped = new System.Windows.Forms.TextBox();
            this.beamCostTyped = new System.Windows.Forms.TextBox();
            this.titleBeam = new System.Windows.Forms.Label();
            this.doorPriceTyped = new System.Windows.Forms.TextBox();
            this.doorCostTyped = new System.Windows.Forms.TextBox();
            this.titleDoor = new System.Windows.Forms.Label();
            this.windowPriceTyped = new System.Windows.Forms.TextBox();
            this.windowCostTyped = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.currentWallCost = new System.Windows.Forms.Label();
            this.currentWallPrice = new System.Windows.Forms.Label();
            this.currentBeamCost = new System.Windows.Forms.Label();
            this.currentBeamPrice = new System.Windows.Forms.Label();
            this.currentDoorCost = new System.Windows.Forms.Label();
            this.currentDoorPrice = new System.Windows.Forms.Label();
            this.currentWindowCost = new System.Windows.Forms.Label();
            this.currentWindowPrice = new System.Windows.Forms.Label();
            this.windowsSizeHelper = new System.Windows.Forms.Label();
            this.currentColumnPrice = new System.Windows.Forms.Label();
            this.currentColumnCost = new System.Windows.Forms.Label();
            this.columnPriceTyped = new System.Windows.Forms.TextBox();
            this.columnCostTyped = new System.Windows.Forms.TextBox();
            this.titleColumn = new System.Windows.Forms.Label();
            this.windowSelector = new System.Windows.Forms.DomainUpDown();
            this.doorSelector = new System.Windows.Forms.DomainUpDown();
            this.windowSizeHelper = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.Teal;
            this.back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.ForeColor = System.Drawing.Color.White;
            this.back.Location = new System.Drawing.Point(162, 941);
            this.back.Margin = new System.Windows.Forms.Padding(4);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(258, 108);
            this.back.TabIndex = 54;
            this.back.Text = "<- BACK";
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.Back_Click);
            // 
            // help
            // 
            this.help.BackColor = System.Drawing.Color.Green;
            this.help.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.help.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.help.Location = new System.Drawing.Point(1295, -3);
            this.help.Margin = new System.Windows.Forms.Padding(4);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(68, 81);
            this.help.TabIndex = 59;
            this.help.Text = "?";
            this.help.UseVisualStyleBackColor = false;
            this.help.Click += new System.EventHandler(this.Help_Click);
            // 
            // wallCostTyped
            // 
            this.wallCostTyped.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wallCostTyped.Location = new System.Drawing.Point(324, 250);
            this.wallCostTyped.Margin = new System.Windows.Forms.Padding(4);
            this.wallCostTyped.Name = "wallCostTyped";
            this.wallCostTyped.Size = new System.Drawing.Size(328, 44);
            this.wallCostTyped.TabIndex = 50;
            // 
            // titleWall
            // 
            this.titleWall.AutoSize = true;
            this.titleWall.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleWall.Location = new System.Drawing.Point(52, 246);
            this.titleWall.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleWall.Name = "titleWall";
            this.titleWall.Size = new System.Drawing.Size(100, 42);
            this.titleWall.TabIndex = 58;
            this.titleWall.Text = "Wall:";
            // 
            // confirm
            // 
            this.confirm.BackColor = System.Drawing.Color.Maroon;
            this.confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirm.ForeColor = System.Drawing.Color.White;
            this.confirm.Location = new System.Drawing.Point(531, 941);
            this.confirm.Margin = new System.Windows.Forms.Padding(4);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(420, 108);
            this.confirm.TabIndex = 53;
            this.confirm.Text = "$ CONFIRM $";
            this.confirm.UseVisualStyleBackColor = false;
            this.confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // titleMaterial
            // 
            this.titleMaterial.AutoSize = true;
            this.titleMaterial.Font = new System.Drawing.Font("Segoe Print", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleMaterial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.titleMaterial.Location = new System.Drawing.Point(164, 27);
            this.titleMaterial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleMaterial.Name = "titleMaterial";
            this.titleMaterial.Size = new System.Drawing.Size(733, 112);
            this.titleMaterial.TabIndex = 55;
            this.titleMaterial.Text = "$$$$ MATERIAL $$$$";
            // 
            // perMeter
            // 
            this.perMeter.AutoSize = true;
            this.perMeter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.perMeter.ForeColor = System.Drawing.Color.Black;
            this.perMeter.Location = new System.Drawing.Point(24, 298);
            this.perMeter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.perMeter.Name = "perMeter";
            this.perMeter.Size = new System.Drawing.Size(183, 33);
            this.perMeter.TabIndex = 60;
            this.perMeter.Text = "($ per Meter)";
            // 
            // titlePrice
            // 
            this.titlePrice.AutoSize = true;
            this.titlePrice.Font = new System.Drawing.Font("Segoe Print", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titlePrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.titlePrice.Location = new System.Drawing.Point(784, 150);
            this.titlePrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titlePrice.Name = "titlePrice";
            this.titlePrice.Size = new System.Drawing.Size(167, 76);
            this.titlePrice.TabIndex = 62;
            this.titlePrice.Text = "PRICE";
            // 
            // titleCost
            // 
            this.titleCost.AutoSize = true;
            this.titleCost.Font = new System.Drawing.Font("Segoe Print", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.titleCost.Location = new System.Drawing.Point(410, 150);
            this.titleCost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleCost.Name = "titleCost";
            this.titleCost.Size = new System.Drawing.Size(153, 76);
            this.titleCost.TabIndex = 63;
            this.titleCost.Text = "COST";
            // 
            // wallPriceTyped
            // 
            this.wallPriceTyped.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wallPriceTyped.Location = new System.Drawing.Point(704, 250);
            this.wallPriceTyped.Margin = new System.Windows.Forms.Padding(4);
            this.wallPriceTyped.Name = "wallPriceTyped";
            this.wallPriceTyped.Size = new System.Drawing.Size(328, 44);
            this.wallPriceTyped.TabIndex = 51;
            // 
            // beamPriceTyped
            // 
            this.beamPriceTyped.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beamPriceTyped.Location = new System.Drawing.Point(704, 388);
            this.beamPriceTyped.Margin = new System.Windows.Forms.Padding(4);
            this.beamPriceTyped.Name = "beamPriceTyped";
            this.beamPriceTyped.Size = new System.Drawing.Size(328, 44);
            this.beamPriceTyped.TabIndex = 53;
            // 
            // beamCostTyped
            // 
            this.beamCostTyped.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beamCostTyped.Location = new System.Drawing.Point(324, 388);
            this.beamCostTyped.Margin = new System.Windows.Forms.Padding(4);
            this.beamCostTyped.Name = "beamCostTyped";
            this.beamCostTyped.Size = new System.Drawing.Size(328, 44);
            this.beamCostTyped.TabIndex = 52;
            // 
            // titleBeam
            // 
            this.titleBeam.AutoSize = true;
            this.titleBeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleBeam.Location = new System.Drawing.Point(52, 385);
            this.titleBeam.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleBeam.Name = "titleBeam";
            this.titleBeam.Size = new System.Drawing.Size(125, 42);
            this.titleBeam.TabIndex = 66;
            this.titleBeam.Text = "Beam:";
            // 
            // doorPriceTyped
            // 
            this.doorPriceTyped.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doorPriceTyped.Location = new System.Drawing.Point(704, 529);
            this.doorPriceTyped.Margin = new System.Windows.Forms.Padding(4);
            this.doorPriceTyped.Name = "doorPriceTyped";
            this.doorPriceTyped.Size = new System.Drawing.Size(328, 44);
            this.doorPriceTyped.TabIndex = 55;
            // 
            // doorCostTyped
            // 
            this.doorCostTyped.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doorCostTyped.Location = new System.Drawing.Point(324, 529);
            this.doorCostTyped.Margin = new System.Windows.Forms.Padding(4);
            this.doorCostTyped.Name = "doorCostTyped";
            this.doorCostTyped.Size = new System.Drawing.Size(328, 44);
            this.doorCostTyped.TabIndex = 54;
            // 
            // titleDoor
            // 
            this.titleDoor.AutoSize = true;
            this.titleDoor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleDoor.Location = new System.Drawing.Point(52, 525);
            this.titleDoor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleDoor.Name = "titleDoor";
            this.titleDoor.Size = new System.Drawing.Size(109, 42);
            this.titleDoor.TabIndex = 69;
            this.titleDoor.Text = "Door:";
            // 
            // windowPriceTyped
            // 
            this.windowPriceTyped.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowPriceTyped.Location = new System.Drawing.Point(704, 665);
            this.windowPriceTyped.Margin = new System.Windows.Forms.Padding(4);
            this.windowPriceTyped.Name = "windowPriceTyped";
            this.windowPriceTyped.Size = new System.Drawing.Size(328, 44);
            this.windowPriceTyped.TabIndex = 57;
            // 
            // windowCostTyped
            // 
            this.windowCostTyped.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowCostTyped.Location = new System.Drawing.Point(324, 665);
            this.windowCostTyped.Margin = new System.Windows.Forms.Padding(4);
            this.windowCostTyped.Name = "windowCostTyped";
            this.windowCostTyped.Size = new System.Drawing.Size(328, 44);
            this.windowCostTyped.TabIndex = 56;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(52, 662);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 42);
            this.label5.TabIndex = 72;
            this.label5.Text = "Window:";
            // 
            // currentWallCost
            // 
            this.currentWallCost.AutoSize = true;
            this.currentWallCost.ForeColor = System.Drawing.Color.Red;
            this.currentWallCost.Location = new System.Drawing.Point(408, 308);
            this.currentWallCost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentWallCost.Name = "currentWallCost";
            this.currentWallCost.Size = new System.Drawing.Size(109, 25);
            this.currentWallCost.TabIndex = 74;
            this.currentWallCost.Text = "(Current: )";
            // 
            // currentWallPrice
            // 
            this.currentWallPrice.AutoSize = true;
            this.currentWallPrice.ForeColor = System.Drawing.Color.Red;
            this.currentWallPrice.Location = new System.Drawing.Point(788, 308);
            this.currentWallPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentWallPrice.Name = "currentWallPrice";
            this.currentWallPrice.Size = new System.Drawing.Size(109, 25);
            this.currentWallPrice.TabIndex = 75;
            this.currentWallPrice.Text = "(Current: )";
            // 
            // currentBeamCost
            // 
            this.currentBeamCost.AutoSize = true;
            this.currentBeamCost.ForeColor = System.Drawing.Color.Red;
            this.currentBeamCost.Location = new System.Drawing.Point(408, 444);
            this.currentBeamCost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentBeamCost.Name = "currentBeamCost";
            this.currentBeamCost.Size = new System.Drawing.Size(109, 25);
            this.currentBeamCost.TabIndex = 76;
            this.currentBeamCost.Text = "(Current: )";
            // 
            // currentBeamPrice
            // 
            this.currentBeamPrice.AutoSize = true;
            this.currentBeamPrice.ForeColor = System.Drawing.Color.Red;
            this.currentBeamPrice.Location = new System.Drawing.Point(788, 444);
            this.currentBeamPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentBeamPrice.Name = "currentBeamPrice";
            this.currentBeamPrice.Size = new System.Drawing.Size(109, 25);
            this.currentBeamPrice.TabIndex = 77;
            this.currentBeamPrice.Text = "(Current: )";
            // 
            // currentDoorCost
            // 
            this.currentDoorCost.AutoSize = true;
            this.currentDoorCost.ForeColor = System.Drawing.Color.Red;
            this.currentDoorCost.Location = new System.Drawing.Point(408, 585);
            this.currentDoorCost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentDoorCost.Name = "currentDoorCost";
            this.currentDoorCost.Size = new System.Drawing.Size(109, 25);
            this.currentDoorCost.TabIndex = 78;
            this.currentDoorCost.Text = "(Current: )";
            // 
            // currentDoorPrice
            // 
            this.currentDoorPrice.AutoSize = true;
            this.currentDoorPrice.ForeColor = System.Drawing.Color.Red;
            this.currentDoorPrice.Location = new System.Drawing.Point(788, 585);
            this.currentDoorPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentDoorPrice.Name = "currentDoorPrice";
            this.currentDoorPrice.Size = new System.Drawing.Size(109, 25);
            this.currentDoorPrice.TabIndex = 79;
            this.currentDoorPrice.Text = "(Current: )";
            // 
            // currentWindowCost
            // 
            this.currentWindowCost.AutoSize = true;
            this.currentWindowCost.ForeColor = System.Drawing.Color.Red;
            this.currentWindowCost.Location = new System.Drawing.Point(408, 723);
            this.currentWindowCost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentWindowCost.Name = "currentWindowCost";
            this.currentWindowCost.Size = new System.Drawing.Size(109, 25);
            this.currentWindowCost.TabIndex = 80;
            this.currentWindowCost.Text = "(Current: )";
            // 
            // currentWindowPrice
            // 
            this.currentWindowPrice.AutoSize = true;
            this.currentWindowPrice.ForeColor = System.Drawing.Color.Red;
            this.currentWindowPrice.Location = new System.Drawing.Point(788, 723);
            this.currentWindowPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentWindowPrice.Name = "currentWindowPrice";
            this.currentWindowPrice.Size = new System.Drawing.Size(109, 25);
            this.currentWindowPrice.TabIndex = 81;
            this.currentWindowPrice.Text = "(Current: )";
            // 
            // windowsSizeHelper
            // 
            this.windowsSizeHelper.Location = new System.Drawing.Point(1018, 969);
            this.windowsSizeHelper.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.windowsSizeHelper.Name = "windowsSizeHelper";
            this.windowsSizeHelper.Size = new System.Drawing.Size(60, 23);
            this.windowsSizeHelper.TabIndex = 82;
            // 
            // currentColumnPrice
            // 
            this.currentColumnPrice.AutoSize = true;
            this.currentColumnPrice.ForeColor = System.Drawing.Color.Red;
            this.currentColumnPrice.Location = new System.Drawing.Point(788, 857);
            this.currentColumnPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentColumnPrice.Name = "currentColumnPrice";
            this.currentColumnPrice.Size = new System.Drawing.Size(109, 25);
            this.currentColumnPrice.TabIndex = 87;
            this.currentColumnPrice.Text = "(Current: )";
            // 
            // currentColumnCost
            // 
            this.currentColumnCost.AutoSize = true;
            this.currentColumnCost.ForeColor = System.Drawing.Color.Red;
            this.currentColumnCost.Location = new System.Drawing.Point(408, 857);
            this.currentColumnCost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentColumnCost.Name = "currentColumnCost";
            this.currentColumnCost.Size = new System.Drawing.Size(109, 25);
            this.currentColumnCost.TabIndex = 86;
            this.currentColumnCost.Text = "(Current: )";
            // 
            // columnPriceTyped
            // 
            this.columnPriceTyped.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnPriceTyped.Location = new System.Drawing.Point(704, 801);
            this.columnPriceTyped.Margin = new System.Windows.Forms.Padding(4);
            this.columnPriceTyped.Name = "columnPriceTyped";
            this.columnPriceTyped.Size = new System.Drawing.Size(328, 44);
            this.columnPriceTyped.TabIndex = 84;
            // 
            // columnCostTyped
            // 
            this.columnCostTyped.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnCostTyped.Location = new System.Drawing.Point(324, 801);
            this.columnCostTyped.Margin = new System.Windows.Forms.Padding(4);
            this.columnCostTyped.Name = "columnCostTyped";
            this.columnCostTyped.Size = new System.Drawing.Size(328, 44);
            this.columnCostTyped.TabIndex = 83;
            // 
            // titleColumn
            // 
            this.titleColumn.AutoSize = true;
            this.titleColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleColumn.Location = new System.Drawing.Point(52, 798);
            this.titleColumn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleColumn.Name = "titleColumn";
            this.titleColumn.Size = new System.Drawing.Size(156, 42);
            this.titleColumn.TabIndex = 85;
            this.titleColumn.Text = "Column:";
            // 
            // windowSelector
            // 
            this.windowSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowSelector.Location = new System.Drawing.Point(1068, 672);
            this.windowSelector.Name = "windowSelector";
            this.windowSelector.Size = new System.Drawing.Size(248, 35);
            this.windowSelector.TabIndex = 89;
            this.windowSelector.Text = "SELECT WINDOW";
            this.windowSelector.SelectedItemChanged += new System.EventHandler(this.WindowSelector_SelectedItemChanged);
            // 
            // doorSelector
            // 
            this.doorSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doorSelector.Location = new System.Drawing.Point(1068, 535);
            this.doorSelector.Name = "doorSelector";
            this.doorSelector.Size = new System.Drawing.Size(248, 35);
            this.doorSelector.TabIndex = 88;
            this.doorSelector.Text = "SELECT DOOR";
            this.doorSelector.SelectedItemChanged += new System.EventHandler(this.DoorSelector_SelectedItemChanged);
            // 
            // windowSizeHelper
            // 
            this.windowSizeHelper.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowSizeHelper.ForeColor = System.Drawing.Color.Red;
            this.windowSizeHelper.Location = new System.Drawing.Point(1331, 1040);
            this.windowSizeHelper.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.windowSizeHelper.Name = "windowSizeHelper";
            this.windowSizeHelper.Size = new System.Drawing.Size(32, 54);
            this.windowSizeHelper.TabIndex = 90;
            // 
            // MaterialConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1361, 1093);
            this.Controls.Add(this.windowSizeHelper);
            this.Controls.Add(this.windowSelector);
            this.Controls.Add(this.doorSelector);
            this.Controls.Add(this.currentColumnPrice);
            this.Controls.Add(this.currentColumnCost);
            this.Controls.Add(this.columnPriceTyped);
            this.Controls.Add(this.columnCostTyped);
            this.Controls.Add(this.titleColumn);
            this.Controls.Add(this.windowsSizeHelper);
            this.Controls.Add(this.currentWindowPrice);
            this.Controls.Add(this.currentWindowCost);
            this.Controls.Add(this.currentDoorPrice);
            this.Controls.Add(this.currentDoorCost);
            this.Controls.Add(this.currentBeamPrice);
            this.Controls.Add(this.currentBeamCost);
            this.Controls.Add(this.currentWallPrice);
            this.Controls.Add(this.currentWallCost);
            this.Controls.Add(this.windowPriceTyped);
            this.Controls.Add(this.windowCostTyped);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.doorPriceTyped);
            this.Controls.Add(this.doorCostTyped);
            this.Controls.Add(this.titleDoor);
            this.Controls.Add(this.beamPriceTyped);
            this.Controls.Add(this.beamCostTyped);
            this.Controls.Add(this.titleBeam);
            this.Controls.Add(this.wallPriceTyped);
            this.Controls.Add(this.titleCost);
            this.Controls.Add(this.titlePrice);
            this.Controls.Add(this.perMeter);
            this.Controls.Add(this.back);
            this.Controls.Add(this.help);
            this.Controls.Add(this.wallCostTyped);
            this.Controls.Add(this.titleWall);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.titleMaterial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MaterialConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MATERIAL";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MaterialConfiguration_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button help;
        private System.Windows.Forms.TextBox wallCostTyped;
        private System.Windows.Forms.Label titleWall;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Label titleMaterial;
        private System.Windows.Forms.Label perMeter;
        private System.Windows.Forms.Label titlePrice;
        private System.Windows.Forms.Label titleCost;
        private System.Windows.Forms.TextBox wallPriceTyped;
        private System.Windows.Forms.TextBox beamPriceTyped;
        private System.Windows.Forms.TextBox beamCostTyped;
        private System.Windows.Forms.Label titleBeam;
        private System.Windows.Forms.TextBox doorPriceTyped;
        private System.Windows.Forms.TextBox doorCostTyped;
        private System.Windows.Forms.Label titleDoor;
        private System.Windows.Forms.TextBox windowPriceTyped;
        private System.Windows.Forms.TextBox windowCostTyped;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label currentWallCost;
        private System.Windows.Forms.Label currentWallPrice;
        private System.Windows.Forms.Label currentBeamCost;
        private System.Windows.Forms.Label currentBeamPrice;
        private System.Windows.Forms.Label currentDoorCost;
        private System.Windows.Forms.Label currentDoorPrice;
        private System.Windows.Forms.Label currentWindowCost;
        private System.Windows.Forms.Label currentWindowPrice;
        private System.Windows.Forms.Label windowsSizeHelper;
        private System.Windows.Forms.Label currentColumnPrice;
        private System.Windows.Forms.Label currentColumnCost;
        private System.Windows.Forms.TextBox columnPriceTyped;
        private System.Windows.Forms.TextBox columnCostTyped;
        private System.Windows.Forms.Label titleColumn;
        private System.Windows.Forms.DomainUpDown windowSelector;
        private System.Windows.Forms.DomainUpDown doorSelector;
        private System.Windows.Forms.Label windowSizeHelper;
    }
}