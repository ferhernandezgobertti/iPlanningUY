using System;
using Domain;
using System.Drawing;
using System.Windows.Forms;
using Domain.Exceptions;
using GUI.Exceptions;
using DataAccess;

namespace GUI
{
    public partial class LogIn : Form, IWindowsChangeable {

        private SketchItApp program;
        
         public LogIn(SketchItApp programContinuation) {
            InitializeComponent();
            this.program = programContinuation;
            InitializeWindow();
         }

         public void InitializeWindow() {
            this.passwordTyped.UseSystemPasswordChar = true;
            this.passwordTyped.MaxLength = 13;
            this.showPassword.BackColor = this.passwordTyped.BackColor;
            this.Size = new Size(this.Size.Width, 420);
         }

        public bool ClosingProtocol() {
            if (this.Visible) {
                DialogResult userWish = MessageBox.Show("Are you sure you want to exit?", "EXIT LogIn", MessageBoxButtons.YesNo);
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

            public void ChangeToPreviousForm(Form currentForm) {
                currentForm.Visible = false;
                this.Refresh();
                this.Visible = true;
            }

        public void AskArchitectToSignChartOrDefault(Form currentForm, Chart currentChart)
        {
            ChangeToPreviousForm(currentForm);
        }

        public void ChangeWindowForm(Form previousForm, Form newForm) {
                previousForm.Visible = false;
                newForm.Show();
            }

            private bool IsBoxBlanck() {
                if(this.usernameTyped.Text.Equals("") || this.passwordTyped.Text.Equals(""))
                {
                throw new BlankSpaceError();
            }
            return this.usernameTyped.Text.Equals("") || this.passwordTyped.Text.Equals("");
            }

            private void ShowFailureLabel() {
                this.logInFailed.Text = "User NOT Existant. \nPlease type ANOTHER USER";
                this.logInFailed.ForeColor = Color.Red;
                this.logInFailed.TextAlign = ContentAlignment.MiddleCenter;
                this.usernameTyped.Text = this.usernameTyped.Text;
                this.usernameTyped.SelectionStart = 0;
                this.usernameTyped.SelectionLength = this.usernameTyped.Text.Length;
                this.usernameTyped.SelectionBackColor = Color.Blue;
                this.usernameTyped.SelectionColor = Color.White;
                this.passwordTyped.Clear();
            }

            private bool CheckAdministrator() {
                bool registryDone = false;
                Administrator adminTyped = new Administrator();
                adminTyped.CheckLogIn(this.program, this.usernameTyped.Text, this.passwordTyped.Text);
                if (adminTyped != null) {
                    ChangeWindowForm(this, new MenuAdmin(this.program));
                    registryDone = true;
                } else {
                    this.ShowFailureLabel();
                }
            return registryDone;
        }


            private bool CheckDesigner() {
                bool registryDone = false;
                Designer designerFound = new Designer();
                designerFound = (Designer)designerFound.CheckLogIn(this.program, this.usernameTyped.Text, this.passwordTyped.Text);
                if (registryDone = (designerFound != null)) {
                    NextFormDesigner(designerFound);
                }
                return registryDone;
            }

            private void NextFormDesigner(Designer designerToContinue) {
                if (designerToContinue.FirstEntry) {
                    designerToContinue.FirstEntry = false;
                    ChangeWindowForm(this, new DataEditing(this.program, designerToContinue, this));
                } else {
                ChangeWindowForm(this, new MenuDesigner(program, designerToContinue));
                }
            }

            private bool CheckClient() {
                bool registryDone = false;
                Client clientFound = new Client();
                clientFound = (Client)clientFound.CheckLogIn(this.program, this.usernameTyped.Text, this.passwordTyped.Text);
                if (registryDone = (clientFound != null)) {
                    NextFormClient(clientFound);
                }
                return registryDone;
            }

            

            private void NextFormClient(Client clientToContinue) {
                if (clientToContinue.FirstEntry) {
                    clientToContinue.FirstEntry = false;
                    ChangeWindowForm(this, new DataEditing(this.program, clientToContinue, this));
                } else {
                    ChangeWindowForm(this, new MenuClient(program, clientToContinue));
                }
            }

        private bool CheckArchitect() {
            bool registryDone = false;
            Architect architectFound = new Architect();
            architectFound = (Architect)architectFound.CheckLogIn(this.program, this.usernameTyped.Text, this.passwordTyped.Text);
            if (registryDone = (architectFound != null))
            {
                NextFormArchitect(architectFound);
            }
            return registryDone;
        }

        private void NextFormArchitect(Architect architectToContinue) {
            if (architectToContinue.FirstEntry)
            {
                architectToContinue.FirstEntry = false;
                ChangeWindowForm(this, new DataEditing(this.program, architectToContinue, this));
            }
            else
            {
                ChangeWindowForm(this, new MenuArchitect(program, architectToContinue));
            }
        }

        private bool CheckUsers()
        {
            bool checkedCorrect = CheckDesigner() || CheckClient() || CheckArchitect();
            if (!checkedCorrect) {
                this.ShowFailureLabel();
            }
            return checkedCorrect;
        }

        private void LogIn_Click(object sender, EventArgs e) {

                bool IsRegistryRight = false;
                User newUser = new User();
                newUser.Password = this.passwordTyped.Text;
                bool passwordRight = newUser.IsPasswordRight();
                Administrator anAdmin = new Administrator();
                anAdmin.Password = this.passwordTyped.Text;
                anAdmin.UserName = this.usernameTyped.Text;
                try
                {
                if (!IsBoxBlanck())
                {
                    if (anAdmin.IsPasswordRight() && anAdmin.IsUserNameRight())
                    {
                        IsRegistryRight = this.CheckAdministrator();
                    } else {
                        if (passwordRight)
                        {
                            IsRegistryRight = this.CheckUsers();
                        }
                    }
                    
                    if (!IsRegistryRight)
                    {
                        MessageBox.Show("Please check parameters. \nYou must have an Username previously registered by the Administrator " +
                            "\nand you password must have at least one Capital Letter, one Number and a Symbol ");
                    }
                }
            }
            catch (BlankSpaceError)
            {
                MessageBox.Show("Please verify all parameters are filled");
            }
               
            }

            private void Help_Click(object sender, EventArgs e) {
                MessageBox.Show("The password must have at least one Capital Letter, one Number and a Symbol", "LOG IN");
            }

            private void LogIn_FormClosing(object sender, FormClosingEventArgs e) {
                if (!ClosingProtocol()) {
                    e.Cancel = true;
                }
            }

            private void ShowPassword_Click(object sender, EventArgs e) {
                if (this.passwordTyped.UseSystemPasswordChar) {
                    this.passwordTyped.UseSystemPasswordChar = false;
                } else {
                    this.passwordTyped.UseSystemPasswordChar = true;
                }
            }

        private void UsernameTyped_Click(object sender, EventArgs e) {
                this.usernameTyped.SelectionStart = 0;
                this.usernameTyped.SelectionLength = this.usernameTyped.Text.Length;
                this.usernameTyped.SelectionBackColor = Color.White;
                this.usernameTyped.SelectionColor = Color.Black;
            }

            private void TestCases_Click(object sender, EventArgs e) {
                this.Size = new Size(this.Size.Width, 550);
            }

            private void AdminTestCase_Click(object sender, EventArgs e) {
                ChangeWindowForm(this, new MenuAdmin(this.program));
            }
            
            private void CheckTestingData(Object objectToCheck)
        {
            if (objectToCheck == null)
            {
                throw new TestDataLoadException();
            }
        }

            private void DesignerTestCase_Click(object sender, EventArgs e) {
            try {
                Designer designerToContinue = new Designer();
                designerToContinue = (Designer)designerToContinue.CheckLogIn(this.program, "Fer5050", "Fer.5050");
                CheckTestingData(designerToContinue);
                ChangeWindowForm(this, new MenuDesigner(this.program, designerToContinue));
            }
            catch (TestDataLoadException) {
                MessageBox.Show("Sorry, you have erased our Test Designer. Reload our Designers.txt File and Try again!");
                }
            }

            private void ClientTestCase_Click(object sender, EventArgs e) {
           try{
                Client clientToContinue = new Client();
                clientToContinue = (Client)clientToContinue.CheckLogIn(this.program, "CaroRod3", "Caro.Rod3");
                CheckTestingData(clientToContinue);
                ChangeWindowForm(this, new MenuClient(this.program, clientToContinue));
            }
            catch (TestDataLoadException) {
                    MessageBox.Show("Sorry, you have erased our Test Client. Reload our Clients.txt File and Try again!");
                }
            }

            private void ChartTestCase_Click(object sender, EventArgs e) {
            try {
                Designer designerToContinue = new Designer();
                designerToContinue.UserName = "Fer5050";
                designerToContinue = this.program.GetDesignerFromList(designerToContinue);
                Client clientToContinue = new Client();
                clientToContinue.UserName = "CaroRod3";
                clientToContinue = this.program.GetClientFromList(clientToContinue);
                Chart chartToContinue = new Chart(designerToContinue, clientToContinue);
                chartToContinue = this.program.GetChartFromList((Chart)this.program.Charts[0]);
                CheckTestingData(chartToContinue);
                ChangeWindowForm(this, new ChartDrawing(this.program, chartToContinue, designerToContinue, this));
            }
            catch (TestDataLoadException) {
                MessageBox.Show("Sorry, you have erased our Test Chart. Reload our Charts.txt File and Try again!");
                }
            }

        private void ArchitectTestCase_Click(object sender, EventArgs e) {
            try {
                Architect architectToContinue = new Architect();
                architectToContinue = (Architect)architectToContinue.CheckLogIn(this.program, "Fer55", "Fer.55");
                CheckTestingData(architectToContinue);
                ChangeWindowForm(this, new MenuArchitect(this.program, architectToContinue));
                
            }
            catch (TestDataLoadException) {
                MessageBox.Show("Sorry, you have erased our Test Architect. Reload our Architects.txt File and Try again!");
            }
        }
    }
    }

