namespace GUI
{
    partial class PasswordEditing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordEditing));
            this.help = new System.Windows.Forms.Button();
            this.currentPassTyped = new System.Windows.Forms.TextBox();
            this.currentPassword = new System.Windows.Forms.Label();
            this.confirmPassTyped = new System.Windows.Forms.TextBox();
            this.newPassTyped = new System.Windows.Forms.TextBox();
            this.confirmPassword = new System.Windows.Forms.Label();
            this.newPassword = new System.Windows.Forms.Label();
            this.editConfirm = new System.Windows.Forms.Button();
            this.titlePassword = new System.Windows.Forms.Label();
            this.currentPassConfirm = new System.Windows.Forms.Label();
            this.newPassConfirm = new System.Windows.Forms.Label();
            this.confirmPassConfirm = new System.Windows.Forms.Label();
            this.windowSizeHelper = new System.Windows.Forms.Label();
            this.windowsSizeHelper = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // help
            // 
            this.help.BackColor = System.Drawing.Color.Green;
            this.help.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.help.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.help.Location = new System.Drawing.Point(904, 1);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(67, 80);
            this.help.TabIndex = 5;
            this.help.Text = "?";
            this.help.UseVisualStyleBackColor = false;
            this.help.Click += new System.EventHandler(this.Help_Click);
            // 
            // currentPassTyped
            // 
            this.currentPassTyped.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPassTyped.Location = new System.Drawing.Point(89, 258);
            this.currentPassTyped.Name = "currentPassTyped";
            this.currentPassTyped.Size = new System.Drawing.Size(643, 44);
            this.currentPassTyped.TabIndex = 1;
            this.currentPassTyped.TextChanged += new System.EventHandler(this.CurrentPassTyped_TextChanged);
            // 
            // currentPassword
            // 
            this.currentPassword.AutoSize = true;
            this.currentPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPassword.Location = new System.Drawing.Point(82, 213);
            this.currentPassword.Name = "currentPassword";
            this.currentPassword.Size = new System.Drawing.Size(327, 42);
            this.currentPassword.TabIndex = 56;
            this.currentPassword.Text = "Current Password:";
            // 
            // confirmPassTyped
            // 
            this.confirmPassTyped.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmPassTyped.Location = new System.Drawing.Point(89, 557);
            this.confirmPassTyped.Name = "confirmPassTyped";
            this.confirmPassTyped.Size = new System.Drawing.Size(643, 44);
            this.confirmPassTyped.TabIndex = 3;
            this.confirmPassTyped.TextChanged += new System.EventHandler(this.ConfirmPassTyped_TextChanged);
            // 
            // newPassTyped
            // 
            this.newPassTyped.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPassTyped.Location = new System.Drawing.Point(89, 407);
            this.newPassTyped.Name = "newPassTyped";
            this.newPassTyped.Size = new System.Drawing.Size(643, 44);
            this.newPassTyped.TabIndex = 2;
            this.newPassTyped.TextChanged += new System.EventHandler(this.NewPassTyped_TextChanged);
            // 
            // confirmPassword
            // 
            this.confirmPassword.AutoSize = true;
            this.confirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmPassword.Location = new System.Drawing.Point(82, 512);
            this.confirmPassword.Name = "confirmPassword";
            this.confirmPassword.Size = new System.Drawing.Size(332, 42);
            this.confirmPassword.TabIndex = 53;
            this.confirmPassword.Text = "Confirm Password:";
            // 
            // newPassword
            // 
            this.newPassword.AutoSize = true;
            this.newPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPassword.Location = new System.Drawing.Point(82, 362);
            this.newPassword.Name = "newPassword";
            this.newPassword.Size = new System.Drawing.Size(278, 42);
            this.newPassword.TabIndex = 52;
            this.newPassword.Text = "New Password:";
            // 
            // editConfirm
            // 
            this.editConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.editConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editConfirm.ForeColor = System.Drawing.Color.White;
            this.editConfirm.Location = new System.Drawing.Point(333, 670);
            this.editConfirm.Name = "editConfirm";
            this.editConfirm.Size = new System.Drawing.Size(352, 108);
            this.editConfirm.TabIndex = 4;
            this.editConfirm.Text = "EDIT PASSWORD";
            this.editConfirm.UseVisualStyleBackColor = false;
            this.editConfirm.Click += new System.EventHandler(this.EditConfirm_Click);
            // 
            // titlePassword
            // 
            this.titlePassword.AutoSize = true;
            this.titlePassword.Font = new System.Drawing.Font("Segoe Print", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titlePassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.titlePassword.Location = new System.Drawing.Point(108, 36);
            this.titlePassword.Name = "titlePassword";
            this.titlePassword.Size = new System.Drawing.Size(756, 112);
            this.titlePassword.TabIndex = 50;
            this.titlePassword.Text = "CHANGE PASSWORD";
            // 
            // currentPassConfirm
            // 
            this.currentPassConfirm.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPassConfirm.Location = new System.Drawing.Point(751, 240);
            this.currentPassConfirm.Name = "currentPassConfirm";
            this.currentPassConfirm.Size = new System.Drawing.Size(208, 74);
            this.currentPassConfirm.TabIndex = 60;
            this.currentPassConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // newPassConfirm
            // 
            this.newPassConfirm.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPassConfirm.Location = new System.Drawing.Point(751, 389);
            this.newPassConfirm.Name = "newPassConfirm";
            this.newPassConfirm.Size = new System.Drawing.Size(208, 74);
            this.newPassConfirm.TabIndex = 61;
            this.newPassConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // confirmPassConfirm
            // 
            this.confirmPassConfirm.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmPassConfirm.Location = new System.Drawing.Point(751, 539);
            this.confirmPassConfirm.Name = "confirmPassConfirm";
            this.confirmPassConfirm.Size = new System.Drawing.Size(208, 74);
            this.confirmPassConfirm.TabIndex = 62;
            this.confirmPassConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // windowSizeHelper
            // 
            this.windowSizeHelper.AutoSize = true;
            this.windowSizeHelper.Location = new System.Drawing.Point(851, 796);
            this.windowSizeHelper.Name = "windowSizeHelper";
            this.windowSizeHelper.Size = new System.Drawing.Size(0, 25);
            this.windowSizeHelper.TabIndex = 63;
            // 
            // windowsSizeHelper
            // 
            this.windowsSizeHelper.Location = new System.Drawing.Point(912, 811);
            this.windowsSizeHelper.Name = "windowsSizeHelper";
            this.windowsSizeHelper.Size = new System.Drawing.Size(59, 23);
            this.windowsSizeHelper.TabIndex = 64;
            // 
            // PasswordEditing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(971, 833);
            this.Controls.Add(this.windowsSizeHelper);
            this.Controls.Add(this.windowSizeHelper);
            this.Controls.Add(this.confirmPassConfirm);
            this.Controls.Add(this.newPassConfirm);
            this.Controls.Add(this.currentPassConfirm);
            this.Controls.Add(this.help);
            this.Controls.Add(this.currentPassTyped);
            this.Controls.Add(this.currentPassword);
            this.Controls.Add(this.confirmPassTyped);
            this.Controls.Add(this.newPassTyped);
            this.Controls.Add(this.confirmPassword);
            this.Controls.Add(this.newPassword);
            this.Controls.Add(this.editConfirm);
            this.Controls.Add(this.titlePassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PasswordEditing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SKETCHIT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PasswordEditing_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button help;
        private System.Windows.Forms.TextBox currentPassTyped;
        private System.Windows.Forms.Label currentPassword;
        private System.Windows.Forms.TextBox confirmPassTyped;
        private System.Windows.Forms.TextBox newPassTyped;
        private System.Windows.Forms.Label confirmPassword;
        private System.Windows.Forms.Label newPassword;
        private System.Windows.Forms.Button editConfirm;
        private System.Windows.Forms.Label titlePassword;
        private System.Windows.Forms.Label currentPassConfirm;
        private System.Windows.Forms.Label newPassConfirm;
        private System.Windows.Forms.Label confirmPassConfirm;
        private System.Windows.Forms.Label windowSizeHelper;
        private System.Windows.Forms.Label windowsSizeHelper;
    }
}