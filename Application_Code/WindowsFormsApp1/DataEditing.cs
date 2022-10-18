using System;
using Domain;
using System.Windows.Forms;
using GUI.Exceptions;
using DataAccess;

namespace GUI
{
    public partial class DataEditing : Form
    {
        private SketchItApp program;
        private IRegistrable userEditing;
        private IUserable typeOfUser;
        private IWindowsChangeable previousForm;

        public DataEditing(SketchItApp programContinuation, Object userToEdit, IWindowsChangeable previousWindow)
        {
            InitializeComponent();
            this.program = programContinuation;
            this.userEditing = (IRegistrable)userToEdit;
            this.typeOfUser = (IUserable)userToEdit;
            this.previousForm = previousWindow;
            InitializeWindow();
        }

        public void InitializeWindow()
        {
            String[] userData = this.userEditing.InitEditing(this);
            LoadUserToEdit(userData);
        }

        private void LoadUserToEdit(String[] userData)
        {
            this.usernameTyped.Text = userData[0];
            this.nameTyped.Text = userData[1];
            this.surnameTyped.Text = userData[2];
            this.numberIDTyped.Text = userData[3];
            this.telephoneTyped.Text = userData[4];
            this.addressTyped.Text = userData[5];
        }

        public bool ClosingProtocol() {
            if (this.Visible) {
                DialogResult userWish = MessageBox.Show("Are you sure you want to exit?", "EXIT DataEditing", MessageBoxButtons.YesNo);
                if (userWish == DialogResult.Yes)
                {
                    this.program.OnClosingProgram();
                    Application.Exit();
                }
                return userWish == DialogResult.Yes;
            } else {
                return true;
            }
        }

        private void DataEditing_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ClosingProtocol())
            {
                e.Cancel = true;
            }
        }

        private void BackOption_Click(object sender, EventArgs e)
        {
            DialogResult userWish = MessageBox.Show("Are you sure you want to Go Back?", "BACK", MessageBoxButtons.YesNo);
            if (userWish == DialogResult.Yes) {
                this.previousForm.ChangeToPreviousForm(this);
            }
        }

        private void Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Change the User Data as you will !!!", "EDIT DATA");
        }

        private void CheckUserRegistration(IRegistrable userToCheck)
        {
            if (!userToCheck.IsWellRegistered())
            {
                throw new UserRegistrationException();
            }
        }

        private void ChangeData_Click(object sender, EventArgs e)
        {
            IRegistrable userToEdit = this.userEditing;
            String[] userDataEdited = GetData();
            userToEdit.GetDataEditing(userDataEdited);
            try
            {
                CheckUserRegistration(userToEdit);
                this.userEditing.StoreData(this.program, userToEdit);
                if (this.typeOfUser.IsClient())
                {
                    ClientDataAccess clientContext = new ClientDataAccess();
                    clientContext.ModifyClient((Client)userToEdit, (Client)userEditing);
                }
                if (this.typeOfUser.IsDesigner())
                {
                    DesignerDataAccess designerContext = new DesignerDataAccess();
                    designerContext.ModifyDesigner((Designer)userToEdit, (Designer)userEditing);
                }
                if (this.typeOfUser.IsArchitect())
                {
                    ArchitectDataAccess architectContext = new ArchitectDataAccess();
                    architectContext.ModifyArchitect((Architect)userToEdit, (Architect)userEditing);
                }
                MessageBox.Show("User SUCCESFULLY Edited");
                this.previousForm.ChangeToPreviousForm(this);
            }
            catch(UserRegistrationException)
            {
                MessageBox.Show("FAILED: Check data input");
            }
        }

        private String[] GetData()
        {
            String[] dataEdited = new String[6];
            dataEdited[0] = this.usernameTyped.Text;
            dataEdited[1] = this.nameTyped.Text;
            dataEdited[2] = this.surnameTyped.Text;
            dataEdited[3] = this.numberIDTyped.Text;
            dataEdited[4] = this.telephoneTyped.Text;
            dataEdited[5] = this.addressTyped.Text;
            return dataEdited;
        }

    }

    //EXPLAIN NOT USING GENERIC & JUSTIFY INEVITABLE CIRCULAR REFERENCE
}
