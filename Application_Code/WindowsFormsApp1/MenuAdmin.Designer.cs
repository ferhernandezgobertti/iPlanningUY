namespace GUI
{
    partial class MenuAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuAdmin));
            this.windowsSizeHelper = new System.Windows.Forms.Label();
            this.alternativeOR2 = new System.Windows.Forms.Label();
            this.alternativeOR1 = new System.Windows.Forms.Label();
            this.titleWelcome = new System.Windows.Forms.Label();
            this.logOutOption = new System.Windows.Forms.Button();
            this.help = new System.Windows.Forms.Button();
            this.configure = new System.Windows.Forms.Button();
            this.titleDesigner = new System.Windows.Forms.Label();
            this.titleClients = new System.Windows.Forms.Label();
            this.deleteUser = new System.Windows.Forms.Button();
            this.editUser = new System.Windows.Forms.Button();
            this.clientsListed = new System.Windows.Forms.ListBox();
            this.designersListed = new System.Windows.Forms.ListBox();
            this.registerUser = new System.Windows.Forms.Button();
            this.titleArchitects = new System.Windows.Forms.Label();
            this.architectsListed = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // windowsSizeHelper
            // 
            this.windowsSizeHelper.Location = new System.Drawing.Point(2151, 1265);
            this.windowsSizeHelper.Name = "windowsSizeHelper";
            this.windowsSizeHelper.Size = new System.Drawing.Size(59, 23);
            this.windowsSizeHelper.TabIndex = 45;
            // 
            // alternativeOR2
            // 
            this.alternativeOR2.AutoSize = true;
            this.alternativeOR2.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.alternativeOR2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alternativeOR2.Location = new System.Drawing.Point(1367, 1180);
            this.alternativeOR2.Name = "alternativeOR2";
            this.alternativeOR2.Size = new System.Drawing.Size(384, 37);
            this.alternativeOR2.TabIndex = 44;
            this.alternativeOR2.Text = "---------------- or ----------------";
            this.alternativeOR2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // alternativeOR1
            // 
            this.alternativeOR1.AutoSize = true;
            this.alternativeOR1.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.alternativeOR1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alternativeOR1.Location = new System.Drawing.Point(540, 1180);
            this.alternativeOR1.Name = "alternativeOR1";
            this.alternativeOR1.Size = new System.Drawing.Size(384, 37);
            this.alternativeOR1.TabIndex = 43;
            this.alternativeOR1.Text = "---------------- or ----------------";
            this.alternativeOR1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleWelcome
            // 
            this.titleWelcome.AutoSize = true;
            this.titleWelcome.Font = new System.Drawing.Font("Segoe Print", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.titleWelcome.Location = new System.Drawing.Point(526, 19);
            this.titleWelcome.Name = "titleWelcome";
            this.titleWelcome.Size = new System.Drawing.Size(1044, 170);
            this.titleWelcome.TabIndex = 42;
            this.titleWelcome.Text = "WELCOME, ADMIN!";
            // 
            // logOutOption
            // 
            this.logOutOption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.logOutOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOutOption.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.logOutOption.Location = new System.Drawing.Point(-4, 1);
            this.logOutOption.Name = "logOutOption";
            this.logOutOption.Size = new System.Drawing.Size(256, 94);
            this.logOutOption.TabIndex = 41;
            this.logOutOption.Text = "LOG OUT";
            this.logOutOption.UseVisualStyleBackColor = false;
            this.logOutOption.Click += new System.EventHandler(this.LogOutOption_Click);
            // 
            // help
            // 
            this.help.BackColor = System.Drawing.Color.Green;
            this.help.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.help.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.help.Location = new System.Drawing.Point(2206, 1);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(67, 94);
            this.help.TabIndex = 40;
            this.help.Text = "?";
            this.help.UseVisualStyleBackColor = false;
            this.help.Click += new System.EventHandler(this.Help_Click);
            // 
            // configure
            // 
            this.configure.BackColor = System.Drawing.Color.Maroon;
            this.configure.Cursor = System.Windows.Forms.Cursors.UpArrow;
            this.configure.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.configure.ForeColor = System.Drawing.Color.White;
            this.configure.Location = new System.Drawing.Point(1749, 1);
            this.configure.Name = "configure";
            this.configure.Size = new System.Drawing.Size(462, 94);
            this.configure.TabIndex = 39;
            this.configure.Text = "$ CONFIGURE Cost/Profit $";
            this.configure.UseVisualStyleBackColor = false;
            this.configure.Click += new System.EventHandler(this.Configure_Click);
            // 
            // titleDesigner
            // 
            this.titleDesigner.AutoSize = true;
            this.titleDesigner.Font = new System.Drawing.Font("Segoe Print", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleDesigner.ForeColor = System.Drawing.Color.Green;
            this.titleDesigner.Location = new System.Drawing.Point(776, 214);
            this.titleDesigner.Name = "titleDesigner";
            this.titleDesigner.Size = new System.Drawing.Size(727, 112);
            this.titleDesigner.TabIndex = 38;
            this.titleDesigner.Text = "SketchIt DESIGNERS";
            // 
            // titleClients
            // 
            this.titleClients.AutoSize = true;
            this.titleClients.Font = new System.Drawing.Font("Segoe Print", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleClients.ForeColor = System.Drawing.Color.Navy;
            this.titleClients.Location = new System.Drawing.Point(1572, 214);
            this.titleClients.Name = "titleClients";
            this.titleClients.Size = new System.Drawing.Size(622, 112);
            this.titleClients.TabIndex = 37;
            this.titleClients.Text = "SketchIt CLIENTS";
            // 
            // deleteUser
            // 
            this.deleteUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.deleteUser.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteUser.Location = new System.Drawing.Point(1801, 1140);
            this.deleteUser.Name = "deleteUser";
            this.deleteUser.Size = new System.Drawing.Size(358, 110);
            this.deleteUser.TabIndex = 36;
            this.deleteUser.Text = "DELETE User";
            this.deleteUser.UseVisualStyleBackColor = false;
            this.deleteUser.Click += new System.EventHandler(this.DeleteUser_Click);
            // 
            // editUser
            // 
            this.editUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.editUser.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editUser.Location = new System.Drawing.Point(972, 1140);
            this.editUser.Name = "editUser";
            this.editUser.Size = new System.Drawing.Size(358, 110);
            this.editUser.TabIndex = 35;
            this.editUser.Text = "EDIT User";
            this.editUser.UseVisualStyleBackColor = false;
            this.editUser.Click += new System.EventHandler(this.EditUser_Click);
            // 
            // clientsListed
            // 
            this.clientsListed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientsListed.FormattingEnabled = true;
            this.clientsListed.HorizontalScrollbar = true;
            this.clientsListed.ItemHeight = 31;
            this.clientsListed.Location = new System.Drawing.Point(1557, 329);
            this.clientsListed.Name = "clientsListed";
            this.clientsListed.Size = new System.Drawing.Size(654, 779);
            this.clientsListed.TabIndex = 34;
            this.clientsListed.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClientsListed_MouseClick);
            // 
            // designersListed
            // 
            this.designersListed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.designersListed.FormattingEnabled = true;
            this.designersListed.HorizontalScrollbar = true;
            this.designersListed.ItemHeight = 31;
            this.designersListed.Location = new System.Drawing.Point(803, 329);
            this.designersListed.Name = "designersListed";
            this.designersListed.Size = new System.Drawing.Size(654, 779);
            this.designersListed.TabIndex = 33;
            this.designersListed.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DesignersListed_MouseClick);
            // 
            // registerUser
            // 
            this.registerUser.AutoSize = true;
            this.registerUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.registerUser.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerUser.Location = new System.Drawing.Point(111, 1140);
            this.registerUser.Name = "registerUser";
            this.registerUser.Size = new System.Drawing.Size(358, 110);
            this.registerUser.TabIndex = 32;
            this.registerUser.Text = "REGISTER User";
            this.registerUser.UseVisualStyleBackColor = false;
            this.registerUser.Click += new System.EventHandler(this.RegisterUser_Click);
            // 
            // titleArchitects
            // 
            this.titleArchitects.AutoSize = true;
            this.titleArchitects.Font = new System.Drawing.Font("Segoe Print", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleArchitects.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.titleArchitects.Location = new System.Drawing.Point(4, 214);
            this.titleArchitects.Name = "titleArchitects";
            this.titleArchitects.Size = new System.Drawing.Size(766, 112);
            this.titleArchitects.TabIndex = 47;
            this.titleArchitects.Text = "SketchIt ARCHITECTS";
            // 
            // architectsListed
            // 
            this.architectsListed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.architectsListed.FormattingEnabled = true;
            this.architectsListed.HorizontalScrollbar = true;
            this.architectsListed.ItemHeight = 31;
            this.architectsListed.Location = new System.Drawing.Point(48, 329);
            this.architectsListed.Name = "architectsListed";
            this.architectsListed.Size = new System.Drawing.Size(654, 779);
            this.architectsListed.TabIndex = 46;
            this.architectsListed.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ArchitectsListed_MouseClick);
            // 
            // MenuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(2270, 1280);
            this.Controls.Add(this.titleArchitects);
            this.Controls.Add(this.architectsListed);
            this.Controls.Add(this.windowsSizeHelper);
            this.Controls.Add(this.alternativeOR2);
            this.Controls.Add(this.alternativeOR1);
            this.Controls.Add(this.titleWelcome);
            this.Controls.Add(this.logOutOption);
            this.Controls.Add(this.help);
            this.Controls.Add(this.configure);
            this.Controls.Add(this.titleDesigner);
            this.Controls.Add(this.titleClients);
            this.Controls.Add(this.deleteUser);
            this.Controls.Add(this.editUser);
            this.Controls.Add(this.clientsListed);
            this.Controls.Add(this.designersListed);
            this.Controls.Add(this.registerUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MenuAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADMINISTRATOR";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuAdmin_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label windowsSizeHelper;
        private System.Windows.Forms.Label alternativeOR2;
        private System.Windows.Forms.Label alternativeOR1;
        private System.Windows.Forms.Label titleWelcome;
        private System.Windows.Forms.Button logOutOption;
        private System.Windows.Forms.Button help;
        private System.Windows.Forms.Button configure;
        private System.Windows.Forms.Label titleDesigner;
        private System.Windows.Forms.Label titleClients;
        private System.Windows.Forms.Button deleteUser;
        private System.Windows.Forms.Button editUser;
        private System.Windows.Forms.ListBox clientsListed;
        private System.Windows.Forms.ListBox designersListed;
        private System.Windows.Forms.Button registerUser;
        private System.Windows.Forms.Label titleArchitects;
        private System.Windows.Forms.ListBox architectsListed;
    }
}