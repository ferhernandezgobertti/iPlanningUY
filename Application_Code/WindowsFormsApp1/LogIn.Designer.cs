namespace GUI
{
    partial class LogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            this.chartTestCase = new System.Windows.Forms.Button();
            this.clientTestCase = new System.Windows.Forms.Button();
            this.designerTestCase = new System.Windows.Forms.Button();
            this.adminTestCase = new System.Windows.Forms.Button();
            this.testCases = new System.Windows.Forms.Button();
            this.usernameTyped = new System.Windows.Forms.RichTextBox();
            this.showPassword = new System.Windows.Forms.Button();
            this.logInOption = new System.Windows.Forms.Button();
            this.help = new System.Windows.Forms.Button();
            this.passwordTyped = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.Label();
            this.titleBegin = new System.Windows.Forms.Label();
            this.logInFailed = new System.Windows.Forms.Label();
            this.architectTestCase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chartTestCase
            // 
            this.chartTestCase.BackColor = System.Drawing.Color.Purple;
            this.chartTestCase.Font = new System.Drawing.Font("Sitka Small", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartTestCase.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chartTestCase.Location = new System.Drawing.Point(23, 885);
            this.chartTestCase.Name = "chartTestCase";
            this.chartTestCase.Size = new System.Drawing.Size(804, 88);
            this.chartTestCase.TabIndex = 34;
            this.chartTestCase.Text = "Enter CHART";
            this.chartTestCase.UseVisualStyleBackColor = false;
            this.chartTestCase.Click += new System.EventHandler(this.ChartTestCase_Click);
            // 
            // clientTestCase
            // 
            this.clientTestCase.BackColor = System.Drawing.Color.Navy;
            this.clientTestCase.Font = new System.Drawing.Font("Sitka Small", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientTestCase.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.clientTestCase.Location = new System.Drawing.Point(434, 779);
            this.clientTestCase.Name = "clientTestCase";
            this.clientTestCase.Size = new System.Drawing.Size(186, 88);
            this.clientTestCase.TabIndex = 33;
            this.clientTestCase.Text = "Enter as Client";
            this.clientTestCase.UseVisualStyleBackColor = false;
            this.clientTestCase.Click += new System.EventHandler(this.ClientTestCase_Click);
            // 
            // designerTestCase
            // 
            this.designerTestCase.BackColor = System.Drawing.Color.Green;
            this.designerTestCase.Font = new System.Drawing.Font("Sitka Small", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.designerTestCase.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.designerTestCase.Location = new System.Drawing.Point(229, 779);
            this.designerTestCase.Name = "designerTestCase";
            this.designerTestCase.Size = new System.Drawing.Size(186, 88);
            this.designerTestCase.TabIndex = 32;
            this.designerTestCase.Text = "Enter as Designer";
            this.designerTestCase.UseVisualStyleBackColor = false;
            this.designerTestCase.Click += new System.EventHandler(this.DesignerTestCase_Click);
            // 
            // adminTestCase
            // 
            this.adminTestCase.BackColor = System.Drawing.Color.Maroon;
            this.adminTestCase.Font = new System.Drawing.Font("Sitka Small", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminTestCase.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.adminTestCase.Location = new System.Drawing.Point(23, 779);
            this.adminTestCase.Name = "adminTestCase";
            this.adminTestCase.Size = new System.Drawing.Size(186, 88);
            this.adminTestCase.TabIndex = 31;
            this.adminTestCase.Text = "Enter as Admin";
            this.adminTestCase.UseVisualStyleBackColor = false;
            this.adminTestCase.Click += new System.EventHandler(this.AdminTestCase_Click);
            // 
            // testCases
            // 
            this.testCases.BackColor = System.Drawing.Color.Maroon;
            this.testCases.Font = new System.Drawing.Font("Sitka Small", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testCases.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.testCases.Location = new System.Drawing.Point(669, 678);
            this.testCases.Name = "testCases";
            this.testCases.Size = new System.Drawing.Size(186, 67);
            this.testCases.TabIndex = 30;
            this.testCases.Text = "Test Cases";
            this.testCases.UseVisualStyleBackColor = false;
            this.testCases.Click += new System.EventHandler(this.TestCases_Click);
            // 
            // usernameTyped
            // 
            this.usernameTyped.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTyped.Location = new System.Drawing.Point(146, 260);
            this.usernameTyped.Name = "usernameTyped";
            this.usernameTyped.Size = new System.Drawing.Size(575, 44);
            this.usernameTyped.TabIndex = 23;
            this.usernameTyped.Text = "";
            // 
            // showPassword
            // 
            this.showPassword.Location = new System.Drawing.Point(582, 377);
            this.showPassword.Name = "showPassword";
            this.showPassword.Size = new System.Drawing.Size(139, 45);
            this.showPassword.TabIndex = 29;
            this.showPassword.Text = "SHOW";
            this.showPassword.UseVisualStyleBackColor = true;
            this.showPassword.Click += new System.EventHandler(this.ShowPassword_Click);
            // 
            // logInOption
            // 
            this.logInOption.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logInOption.Location = new System.Drawing.Point(281, 496);
            this.logInOption.Name = "logInOption";
            this.logInOption.Size = new System.Drawing.Size(358, 110);
            this.logInOption.TabIndex = 28;
            this.logInOption.Text = "Log In";
            this.logInOption.UseVisualStyleBackColor = true;
            this.logInOption.Click += new System.EventHandler(this.LogIn_Click);
            // 
            // help
            // 
            this.help.BackColor = System.Drawing.Color.Green;
            this.help.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.help.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.help.Location = new System.Drawing.Point(788, -3);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(67, 80);
            this.help.TabIndex = 27;
            this.help.Text = "?";
            this.help.UseVisualStyleBackColor = false;
            this.help.Click += new System.EventHandler(this.Help_Click);
            // 
            // passwordTyped
            // 
            this.passwordTyped.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTyped.Location = new System.Drawing.Point(150, 378);
            this.passwordTyped.Name = "passwordTyped";
            this.passwordTyped.Size = new System.Drawing.Size(571, 44);
            this.passwordTyped.TabIndex = 24;
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(143, 333);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(183, 42);
            this.password.TabIndex = 22;
            this.password.Text = "Password";
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.Location = new System.Drawing.Point(143, 215);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(190, 42);
            this.username.TabIndex = 21;
            this.username.Text = "Username";
            // 
            // titleBegin
            // 
            this.titleBegin.AutoSize = true;
            this.titleBegin.Cursor = System.Windows.Forms.Cursors.Cross;
            this.titleBegin.Font = new System.Drawing.Font("Segoe Print", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleBegin.ForeColor = System.Drawing.Color.Green;
            this.titleBegin.Location = new System.Drawing.Point(236, 9);
            this.titleBegin.Name = "titleBegin";
            this.titleBegin.Size = new System.Drawing.Size(419, 170);
            this.titleBegin.TabIndex = 20;
            this.titleBegin.Text = "BEGIN!";
            // 
            // logInFailed
            // 
            this.logInFailed.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logInFailed.Location = new System.Drawing.Point(183, 149);
            this.logInFailed.Name = "logInFailed";
            this.logInFailed.Size = new System.Drawing.Size(510, 57);
            this.logInFailed.TabIndex = 35;
            // 
            // architectTestCase
            // 
            this.architectTestCase.BackColor = System.Drawing.Color.Gray;
            this.architectTestCase.Font = new System.Drawing.Font("Sitka Small", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.architectTestCase.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.architectTestCase.Location = new System.Drawing.Point(641, 779);
            this.architectTestCase.Name = "architectTestCase";
            this.architectTestCase.Size = new System.Drawing.Size(186, 88);
            this.architectTestCase.TabIndex = 37;
            this.architectTestCase.Text = "Enter as Architect";
            this.architectTestCase.UseVisualStyleBackColor = false;
            this.architectTestCase.Click += new System.EventHandler(this.ArchitectTestCase_Click);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(853, 993);
            this.Controls.Add(this.architectTestCase);
            this.Controls.Add(this.logInFailed);
            this.Controls.Add(this.chartTestCase);
            this.Controls.Add(this.clientTestCase);
            this.Controls.Add(this.designerTestCase);
            this.Controls.Add(this.adminTestCase);
            this.Controls.Add(this.testCases);
            this.Controls.Add(this.usernameTyped);
            this.Controls.Add(this.showPassword);
            this.Controls.Add(this.logInOption);
            this.Controls.Add(this.help);
            this.Controls.Add(this.passwordTyped);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.titleBegin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SKETCHIT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogIn_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button chartTestCase;
        private System.Windows.Forms.Button clientTestCase;
        private System.Windows.Forms.Button designerTestCase;
        private System.Windows.Forms.Button adminTestCase;
        private System.Windows.Forms.Button testCases;
        private System.Windows.Forms.RichTextBox usernameTyped;
        private System.Windows.Forms.Button showPassword;
        private System.Windows.Forms.Button logInOption;
        private System.Windows.Forms.Button help;
        private System.Windows.Forms.TextBox passwordTyped;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Label titleBegin;
        private System.Windows.Forms.Label logInFailed;
        private System.Windows.Forms.Button architectTestCase;
    }
}