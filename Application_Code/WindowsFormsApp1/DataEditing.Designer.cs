namespace GUI
{
    partial class DataEditing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataEditing));
            this.changeData = new System.Windows.Forms.Button();
            this.windowSizeHelper = new System.Windows.Forms.Label();
            this.help = new System.Windows.Forms.Button();
            this.telephoneTyped = new System.Windows.Forms.TextBox();
            this.telephone = new System.Windows.Forms.Label();
            this.surnameTyped = new System.Windows.Forms.TextBox();
            this.surname = new System.Windows.Forms.Label();
            this.addressTyped = new System.Windows.Forms.TextBox();
            this.address = new System.Windows.Forms.Label();
            this.numberIDTyped = new System.Windows.Forms.TextBox();
            this.numberID = new System.Windows.Forms.Label();
            this.nameTyped = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.Label();
            this.usernameTyped = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.Label();
            this.backOption = new System.Windows.Forms.Button();
            this.titleEditData = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // changeData
            // 
            this.changeData.BackColor = System.Drawing.Color.Maroon;
            this.changeData.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeData.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.changeData.Location = new System.Drawing.Point(247, -2);
            this.changeData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.changeData.Name = "changeData";
            this.changeData.Size = new System.Drawing.Size(128, 49);
            this.changeData.TabIndex = 62;
            this.changeData.Text = "CHANGE";
            this.changeData.UseVisualStyleBackColor = false;
            this.changeData.Click += new System.EventHandler(this.ChangeData_Click);
            // 
            // windowSizeHelper
            // 
            this.windowSizeHelper.Location = new System.Drawing.Point(364, 556);
            this.windowSizeHelper.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.windowSizeHelper.Name = "windowSizeHelper";
            this.windowSizeHelper.Size = new System.Drawing.Size(43, 24);
            this.windowSizeHelper.TabIndex = 61;
            // 
            // help
            // 
            this.help.BackColor = System.Drawing.Color.Green;
            this.help.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.help.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.help.Location = new System.Drawing.Point(374, -2);
            this.help.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(34, 49);
            this.help.TabIndex = 55;
            this.help.Text = "?";
            this.help.UseVisualStyleBackColor = false;
            this.help.Click += new System.EventHandler(this.Help_Click);
            // 
            // telephoneTyped
            // 
            this.telephoneTyped.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telephoneTyped.Location = new System.Drawing.Point(32, 449);
            this.telephoneTyped.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.telephoneTyped.Name = "telephoneTyped";
            this.telephoneTyped.Size = new System.Drawing.Size(310, 24);
            this.telephoneTyped.TabIndex = 5;
            // 
            // telephone
            // 
            this.telephone.AutoSize = true;
            this.telephone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telephone.Location = new System.Drawing.Point(34, 428);
            this.telephone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.telephone.Name = "telephone";
            this.telephone.Size = new System.Drawing.Size(88, 20);
            this.telephone.TabIndex = 60;
            this.telephone.Text = "Telephone:";
            // 
            // surnameTyped
            // 
            this.surnameTyped.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surnameTyped.Location = new System.Drawing.Point(32, 303);
            this.surnameTyped.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.surnameTyped.Name = "surnameTyped";
            this.surnameTyped.Size = new System.Drawing.Size(310, 24);
            this.surnameTyped.TabIndex = 3;
            // 
            // surname
            // 
            this.surname.AutoSize = true;
            this.surname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surname.Location = new System.Drawing.Point(34, 282);
            this.surname.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.surname.Name = "surname";
            this.surname.Size = new System.Drawing.Size(78, 20);
            this.surname.TabIndex = 59;
            this.surname.Text = "Surname:";
            // 
            // addressTyped
            // 
            this.addressTyped.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressTyped.Location = new System.Drawing.Point(32, 523);
            this.addressTyped.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addressTyped.Name = "addressTyped";
            this.addressTyped.Size = new System.Drawing.Size(310, 24);
            this.addressTyped.TabIndex = 6;
            // 
            // address
            // 
            this.address.AutoSize = true;
            this.address.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address.Location = new System.Drawing.Point(34, 502);
            this.address.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(72, 20);
            this.address.TabIndex = 58;
            this.address.Text = "Address:";
            // 
            // numberIDTyped
            // 
            this.numberIDTyped.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberIDTyped.Location = new System.Drawing.Point(32, 377);
            this.numberIDTyped.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numberIDTyped.Name = "numberIDTyped";
            this.numberIDTyped.Size = new System.Drawing.Size(310, 24);
            this.numberIDTyped.TabIndex = 4;
            // 
            // numberID
            // 
            this.numberID.AutoSize = true;
            this.numberID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberID.Location = new System.Drawing.Point(34, 356);
            this.numberID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.numberID.Name = "numberID";
            this.numberID.Size = new System.Drawing.Size(90, 20);
            this.numberID.TabIndex = 57;
            this.numberID.Text = "Number ID:";
            // 
            // nameTyped
            // 
            this.nameTyped.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTyped.Location = new System.Drawing.Point(32, 228);
            this.nameTyped.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nameTyped.Name = "nameTyped";
            this.nameTyped.Size = new System.Drawing.Size(310, 24);
            this.nameTyped.TabIndex = 2;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(34, 207);
            this.name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(55, 20);
            this.name.TabIndex = 56;
            this.name.Text = "Name:";
            // 
            // usernameTyped
            // 
            this.usernameTyped.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTyped.ForeColor = System.Drawing.Color.Navy;
            this.usernameTyped.Location = new System.Drawing.Point(32, 160);
            this.usernameTyped.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.usernameTyped.Name = "usernameTyped";
            this.usernameTyped.Size = new System.Drawing.Size(310, 26);
            this.usernameTyped.TabIndex = 1;
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.ForeColor = System.Drawing.Color.Navy;
            this.username.Location = new System.Drawing.Point(29, 139);
            this.username.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(103, 20);
            this.username.TabIndex = 54;
            this.username.Text = "User Name:";
            // 
            // backOption
            // 
            this.backOption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.backOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backOption.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.backOption.Location = new System.Drawing.Point(0, -2);
            this.backOption.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backOption.Name = "backOption";
            this.backOption.Size = new System.Drawing.Size(128, 49);
            this.backOption.TabIndex = 47;
            this.backOption.Text = "BACK";
            this.backOption.UseVisualStyleBackColor = false;
            this.backOption.Click += new System.EventHandler(this.BackOption_Click);
            // 
            // titleEditData
            // 
            this.titleEditData.AutoSize = true;
            this.titleEditData.Font = new System.Drawing.Font("Segoe Print", 22.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleEditData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.titleEditData.Location = new System.Drawing.Point(104, 57);
            this.titleEditData.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titleEditData.Name = "titleEditData";
            this.titleEditData.Size = new System.Drawing.Size(198, 54);
            this.titleEditData.TabIndex = 46;
            this.titleEditData.Text = "EDIT DATA";
            // 
            // DataEditing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(406, 549);
            this.Controls.Add(this.changeData);
            this.Controls.Add(this.windowSizeHelper);
            this.Controls.Add(this.help);
            this.Controls.Add(this.telephoneTyped);
            this.Controls.Add(this.telephone);
            this.Controls.Add(this.surnameTyped);
            this.Controls.Add(this.surname);
            this.Controls.Add(this.addressTyped);
            this.Controls.Add(this.address);
            this.Controls.Add(this.numberIDTyped);
            this.Controls.Add(this.numberID);
            this.Controls.Add(this.nameTyped);
            this.Controls.Add(this.name);
            this.Controls.Add(this.usernameTyped);
            this.Controls.Add(this.username);
            this.Controls.Add(this.backOption);
            this.Controls.Add(this.titleEditData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "DataEditing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EDITING";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataEditing_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button changeData;
        private System.Windows.Forms.Label windowSizeHelper;
        private System.Windows.Forms.Button help;
        private System.Windows.Forms.TextBox telephoneTyped;
        private System.Windows.Forms.Label telephone;
        private System.Windows.Forms.TextBox surnameTyped;
        private System.Windows.Forms.Label surname;
        private System.Windows.Forms.TextBox addressTyped;
        private System.Windows.Forms.Label address;
        private System.Windows.Forms.TextBox numberIDTyped;
        private System.Windows.Forms.Label numberID;
        private System.Windows.Forms.TextBox nameTyped;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.TextBox usernameTyped;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Button backOption;
        private System.Windows.Forms.Label titleEditData;
    }
}