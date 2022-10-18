using System;
using Domain;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Domain.Exceptions;
using DataAccess;

namespace GUI
{

    public partial class Registration : Form
    {
        private SketchItApp program;
        public Registration(SketchItApp programContinuation)
        {
            InitializeComponent();
            this.program = programContinuation;
            this.InitializeSeparation();
            this.usernameTypedClient.MaxLength = 13;
            this.usernameTypedDesigner.MaxLength = 13;
        }

        private void InitializeSeparation()
        {
            StringBuilder separation = new StringBuilder();
            for (int times = 0; times < 60; times++)
            {
                separation.Append("-|-\n");
            }
            this.designerClientSeparation.Text = separation.ToString();
            this.designerClientSeparation.ForeColor = Color.Red;
            this.clientArchitectSeparation.Text = separation.ToString();
            this.clientArchitectSeparation.ForeColor = Color.Blue;
        }

        private void UserNameTypedClient_Paint(Object sender, PaintEventArgs e)
        {
            this.usernameTypedClient.BorderStyle = BorderStyle.None;
            Graphics g = e.Graphics;
            Pen selectedFormat = new Pen(Color.Blue, 5);
            Rectangle selectedBorder = new Rectangle(usernameTypedClient.Location.X - 200, usernameTypedClient.Location.Y - 20, usernameTypedClient.Location.X + 200, usernameTypedClient.Location.Y + 20);
            g.DrawRectangle(selectedFormat, selectedBorder);
        }

        private bool ClosingProtocol() {
            if (this.Visible) {
                DialogResult userWish = MessageBox.Show("Are you sure you want to exit?", "EXIT Registration", MessageBoxButtons.YesNo);
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

        private void Registration_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!ClosingProtocol()) {
                e.Cancel = true;
            }
        }

        private Client LoadClient()
        {
            Client aClient = new Client();
            aClient.UserName = this.usernameTypedClient.Text;
            aClient.Password = this.passwordTypedClient.Text;
            aClient.Name = this.nameTypedClient.Text;
            aClient.Surname = this.surnameTypedClient.Text;
            aClient.NumberID = this.numberIDTypedClient.Text;
            aClient.Telephone = this.telephoneTypedClient.Text;
            aClient.Address = this.addressTypedClient.Text;
            return aClient;
        }

        private Designer LoadDesigner()
        {
            Designer aDesigner = new Designer();
            aDesigner.UserName = this.usernameTypedDesigner.Text;
            aDesigner.Password = this.passwordTypedDesigner.Text;
            aDesigner.Name = this.nameTypedDesigner.Text;
            aDesigner.Surname = this.surnameTypedDesigner.Text;
            return aDesigner;
        }

        private Architect LoadArchitect()
        {
            Architect anArchitect = new Architect();
            anArchitect.UserName = this.usernameTypedArchitect.Text;
            anArchitect.Password = this.passwordTypedArchitect.Text;
            anArchitect.Name = this.nameTypedArchitect.Text;
            anArchitect.Surname = this.surnameTypedArchitect.Text;
            return anArchitect;
        }

        private void RegisterClient_Click(object sender, EventArgs e)
        {
            Client clientToRegister = LoadClient();
            try
            {
                if (this.program.IsClientAvailableToAdd(clientToRegister))
                {
                    this.program.Users.Add(clientToRegister);
                    ClientDataAccess context = new ClientDataAccess();
                    context.AddClient(clientToRegister);
                    MessageBox.Show("CLIENT Registered");
                    
                    this.CleanClientBoxes();
                }
            }
            catch (AlreadyExistingUserException)
            {
                MessageBox.Show("This user already exists.Please change your username");
            }
            catch (InvalidFormatException)
            {
                MessageBox.Show("The format is not correct please try again");
            }
        }


        private void CleanClientBoxes()
        {
            this.nameTypedClient.Clear();
            this.surnameTypedClient.Clear();
            this.usernameTypedClient.Clear();
            this.passwordTypedClient.Clear();
            this.numberIDTypedClient.Clear();
            this.telephoneTypedClient.Clear();
            this.addressTypedClient.Clear();
        }

        private void RegisterDesigner_Click(object sender, EventArgs e)
        {
            Designer designerToRegister = LoadDesigner();
            try
            {
                if (this.program.IsDesignerAvailableToAdd(designerToRegister))
                {
                    this.program.Users.Add(designerToRegister);
                    DesignerDataAccess designerContext = new DesignerDataAccess();
                    designerContext.AddDesigner(designerToRegister);
                    MessageBox.Show("DESIGNER Registered");
                    this.CleanDesignerBoxes();
                }
            }
            catch (AlreadyExistingUserException)
            {
                MessageBox.Show("This user already exists.Please change your username");
            }
            catch (InvalidFormatException)
            {
                MessageBox.Show("The format is not correct please try again");
            }
        }

        private void CleanDesignerBoxes()
        {
            this.nameTypedDesigner.Clear();
            this.surnameTypedDesigner.Clear();
            this.usernameTypedDesigner.Clear();
            this.passwordTypedDesigner.Clear();
        }

        private void RegisterArchitect_Click(object sender, EventArgs e) {
            Architect architectToRegister = LoadArchitect();
            try
            {
                if (this.program.IsArchitectAvailableToAdd(architectToRegister))
                {
                    this.program.Users.Add(architectToRegister);
                    ArchitectDataAccess architectContext = new ArchitectDataAccess();
                    architectContext.AddArchitect(architectToRegister);
                    MessageBox.Show("ARCHITECT Registered");
                    this.CleanArchitectBoxes();
                }
            }
            catch (AlreadyExistingUserException)
            {
                MessageBox.Show("This user already exists.Please change your username");
            }
            catch (InvalidFormatException)
            {
                MessageBox.Show("The format is not correct please try again");
            }
        }

        private void CleanArchitectBoxes() {
            this.nameTypedArchitect.Clear();
            this.surnameTypedArchitect.Clear();
            this.usernameTypedArchitect.Clear();
            this.passwordTypedArchitect.Clear();
        }

        private void ShowFailureDialog(String userType)
        {
            StringBuilder newString = new StringBuilder();
            newString.Append("Please check all parameters: The ");
            newString.Append(userType);
            newString.Append("might be already registered \nVerify the correct format of inputs typed, guided by the format in ?");
            MessageBox.Show(newString.ToString());
        }

        private void BackOption_Click(object sender, EventArgs e)
        {
            DialogResult userWish = MessageBox.Show("Are you sure you want to Go Back?", "BACK", MessageBoxButtons.YesNo);
            if (userWish == DialogResult.Yes) {
                ChangeWindowForm(this, new MenuAdmin(this.program));
            }
        }

        private void Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add a new Designer or Client\nFORMAT:\nUserName: Between 4 and 10 characters" +
                "\nPassword: Between 6 and 13 characters, with at least one Capital Letter, one Number and a Symbol" +
                "\nName and Surname: With No Spaces\nNumberID: i.e. 4.851.112-6\nTelephone: i.e. 098742547", "REGISTRATION");
        }

        private void ChangeWindowForm(Form previousForm, Form newForm)
        {
            previousForm.Visible = false;
            newForm.Show();
        }

        
    }
}
