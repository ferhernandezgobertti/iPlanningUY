using Domain;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class PasswordEditing : Form
    {
        private SketchItApp program;
        private IRegistrable userLogged;
        private IWindowsChangeable previousForm;
        public PasswordEditing(SketchItApp programContinuation, Object currentUser, IWindowsChangeable previousWindow)
        {
            InitializeComponent();
            this.program = programContinuation;
            this.userLogged = (IRegistrable)currentUser;
            this.previousForm = previousWindow;
        }

        private bool ClosingProtocol() {
            if (this.Visible) {
                DialogResult userWish = MessageBox.Show("Are you sure you want to exit?", "EXIT PasswordEditing", MessageBoxButtons.YesNo);
                if (userWish == DialogResult.Yes) {
                    this.program.OnClosingProgram();
                    Application.Exit();
                }
                return userWish == DialogResult.Yes;
            } else {
                return true;
            }
        }

        private void PasswordEditing_FormClosing(object sender, FormClosingEventArgs e) {
            
             if(!ClosingProtocol()) {
                e.Cancel = true;
            }
        }

        private void Help_Click(object sender, EventArgs e) {
            MessageBox.Show("Fill the Password Parameters and Change your Password!\nRemember that your PASSWORD must have " +
                "between 6 and 13 characters, with at least one Capital Letter, one Number and a Symbol", "PASSWORD EDITING");
        }

        private void EditConfirm_Click(object sender, EventArgs e) {
            bool correctInputs = this.currentPassConfirm.Text.Equals("OK") && this.newPassConfirm.Text.Equals("OK") && this.confirmPassConfirm.Text.Equals("OK");
            if (correctInputs) {
                this.userLogged.ChangePassword(this.program, this.newPassTyped.Text);
                MessageBox.Show("Password SUCCESFULLY Changed!!!");
                this.previousForm.ChangeToPreviousForm(this);
            }
        }

        private void CheckPassword (bool condition, Label confirmation) {
            if (condition) {
                confirmation.ForeColor = Color.ForestGreen;
                confirmation.Text = "OK";
            } else {
                confirmation.ForeColor = Color.Red;
                confirmation.Text = "WRONG";
            }
        }

        private void CurrentPassTyped_TextChanged(object sender, EventArgs e) {
            this.CheckPassword(this.userLogged.PasswordEquals(this.currentPassTyped.Text), this.currentPassConfirm);
        }

        private void NewPassTyped_TextChanged(object sender, EventArgs e) {
            User userSample = new User();
            userSample.Password = this.newPassTyped.Text;
            this.CheckPassword(userSample.IsPasswordRight(), this.newPassConfirm);
        }

        private void ConfirmPassTyped_TextChanged(object sender, EventArgs e) {
            this.CheckPassword(this.newPassTyped.Text.Equals(this.confirmPassTyped.Text), this.confirmPassConfirm);
        }
    }
}
