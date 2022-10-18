using System;
using Domain;
using System.Windows.Forms;
using System.Collections.Generic;
using GUI.Exceptions;
using DataAccess;

namespace GUI
{
    public partial class MenuAdmin : Form, IWindowsChangeable
    {
        private SketchItApp program;
        public MenuAdmin(SketchItApp programContinuation)
        {
            InitializeComponent();
            this.program = programContinuation;
            InitializeWindow();
        }

        public void InitializeWindow()
        {
            this.ListDesigners();
            this.ListClients();
            this.ListArchitects();
        }

        public bool ClosingProtocol()
        {
            if (this.Visible) {
                DialogResult userWish = MessageBox.Show("Are you sure you want to exit?", "EXIT MenuAdmin", MessageBoxButtons.YesNo);
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

        public void ChangeToPreviousForm(Form currentForm)
        {
            currentForm.Visible = false;
            this.Refresh();
            this.Visible = true;
        }

        public void AskArchitectToSignChartOrDefault(Form currentForm, Chart currentChart)
        {
            ChangeToPreviousForm(currentForm);
        }

        public void ChangeWindowForm(Form previousForm, Form newForm)
        {
            previousForm.Visible = false;
            newForm.Show();
        }

        private void MenuAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ClosingProtocol())
            {
                e.Cancel = true;
            }
        }

        private void Configure_Click(object sender, EventArgs e)
        {
            ChangeWindowForm(this, new MaterialConfiguration(this.program));
        }

        private void RegisterUser_Click(object sender, EventArgs e)
        {
            ChangeWindowForm(this, new Registration(this.program));
        }

        private void EditUser_Click(object sender, EventArgs e)
        {  //JUSTIFY PROBLEM WITH LISTBOX INDEXES
            bool onlyClientSelected = this.clientsListed.SelectedItem != null && this.designersListed.SelectedItem == null && this.architectsListed.SelectedItem == null;
            this.CheckClientEditingCondition(onlyClientSelected, this.program.GetClientFromList((Client)this.clientsListed.SelectedItem));

            bool onlyDesignerSelected = this.clientsListed.SelectedItem == null && this.designersListed.SelectedItem != null && this.architectsListed.SelectedItem == null;
            this.CheckDesignerEditingCondition(onlyDesignerSelected, this.program.GetDesignerFromList((Designer)this.designersListed.SelectedItem));

            bool onlyArchitectSelected = this.clientsListed.SelectedItem == null && this.designersListed.SelectedItem == null && this.architectsListed.SelectedItem != null;
            this.CheckArchitectEditingCondition(onlyArchitectSelected, this.program.GetArchitectFromList((Architect)this.architectsListed.SelectedItem));


            if ((!onlyClientSelected && !onlyDesignerSelected && !onlyArchitectSelected) || (onlyClientSelected && onlyDesignerSelected && onlyArchitectSelected))
            {
                MessageBox.Show("Please, select a Designer OR a Client to EDIT. Thank you!");
            }
        }

        private void CheckClientEditingCondition(bool aCondition, Client clientToEdit)
        {
            if (aCondition)
            {
                DataEditing clientEditingForm = new DataEditing(this.program, clientToEdit, this);
                ChangeWindowForm(this, clientEditingForm);
            }
        }

        private void CheckDesignerEditingCondition(bool aCondition, Designer designerToEdit)
        {
            if (aCondition)
            {
                DataEditing designerEditingForm = new DataEditing(this.program, designerToEdit, this);
                ChangeWindowForm(this, designerEditingForm);
            }
        }

        private void CheckArchitectEditingCondition(bool aCondition, Architect architectToEdit)
        {
            if (aCondition)
            {
                DataEditing architectEditingForm = new DataEditing(this.program, architectToEdit, this);
                ChangeWindowForm(this, architectEditingForm);
            }
        }

        private void CheckIfUserSelected()
        {
            if(this.clientsListed.SelectedItem == null && this.designersListed.SelectedItem == null && this.architectsListed.SelectedItem == null)
            {
                throw new NoUserSelectedException();
            }
        }

        private void DeleteUser_Click(object sender, EventArgs e)
        {
            try
            {
                CheckIfUserSelected();
                bool isClientSelected = (this.clientsListed.SelectedItem != null);
                bool isDesignerSelected = (this.designersListed.SelectedItem != null);
                bool isArchitectSelected = (this.architectsListed.SelectedItem != null);
                if (isClientSelected)
                {
                    this.program.Users.Remove((Client)this.clientsListed.SelectedItem);
                    this.RemoveChartsFromClient((Client)this.clientsListed.SelectedItem);
                    ClientDataAccess clientContext = new ClientDataAccess();
                    clientContext.RemoveClient((Client)this.clientsListed.SelectedItem);
                    MessageBox.Show("Client SUCCESFULLY Deleted!");               
                    ChangeWindowForm(this, new MenuAdmin(this.program)); //Problem with this.Refresh()
                }
                if (isDesignerSelected)
                {
                    this.program.Users.Remove((Designer)this.designersListed.SelectedItem);
                    DesignerDataAccess designerContext = new DesignerDataAccess();
                    designerContext.RemoveDesigner((Designer)this.designersListed.SelectedItem);
                    MessageBox.Show("Designer SUCCESFULLY Deleted!");
                    ChangeWindowForm(this, new MenuAdmin(this.program));
                }
                if (isArchitectSelected)
                {
                    this.program.Users.Remove((Architect)this.architectsListed.SelectedItem);
                    ArchitectDataAccess architectContext = new ArchitectDataAccess();
                    architectContext.RemoveArchitect((Architect)this.architectsListed.SelectedItem);
                    MessageBox.Show("Architect SUCCESFULLY Deleted!");
                    ChangeWindowForm(this, new MenuAdmin(this.program));
                }
            }
            catch (NoUserSelectedException) { 
                MessageBox.Show("Please, select an Architect OR a Designer OR a Client to DELETE. Thank you!");
            }
        }

        private void RemoveChartsFromClient(Client clientRemoved)
        {
            if (this.program.GetChartsFromClient(clientRemoved) != null)
            {
                ChartDataAccess chartContext = new ChartDataAccess();
                foreach (Chart chartToRemove in this.program.GetChartsFromClient(clientRemoved))
                {
                    this.program.Charts.Remove(this.program.GetChartFromList(chartToRemove));
                    int chartId = chartToRemove.Id;
                    chartContext.RemoveChartBecauseOfClient(chartId);
                }
            }
           
        }

        private void Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add a new User, Edit or Remove an already created User " +
                "\nConfigure the Tools Materials Price", "MENU ADMIN");
        }

        private void LogOutOption_Click(object sender, EventArgs e)
        {
            DialogResult userWish = MessageBox.Show("Are you sure you want to Log Out?", "EXIT", MessageBoxButtons.YesNo);
            if (userWish == DialogResult.Yes) {
                ChangeWindowForm(this, new LogIn(this.program));
            }
        }

        private void ListDesigners()
        {
            List<IUserable> designersFromProgram = this.program.GetDesignersFromUsers();
            if (designersFromProgram.Count == 0) {
                this.designersListed.Items.Clear();
                this.designersListed.Items.Add(string.Join(Environment.NewLine, "NO DESIGNERS Added Yet"));
            }
            else
            {
                this.designersListed.Items.Clear();
                foreach (Designer aDesigner in designersFromProgram)
                {
                    this.designersListed.Items.Add(aDesigner);
                }
            }
        }

        private void ListArchitects() {
            List<IUserable> architectsFromProgram = this.program.GetArchitectsFromUsers();
            if (architectsFromProgram.Count == 0)
            {
                this.architectsListed.Items.Clear();
                this.architectsListed.Items.Add(string.Join(Environment.NewLine, "NO ARCHITECTS Added Yet"));
            }
            else
            {
                this.architectsListed.Items.Clear();
                foreach (Architect anArchitect in architectsFromProgram)
                {
                    this.architectsListed.Items.Add(anArchitect);
                }
            }
        }

        private void ListClients()
        {
            List<IUserable> clientsFromProgram = this.program.GetClientsFromUsers();
            if (clientsFromProgram.Count == 0)
            {
                this.clientsListed.Items.Clear();
                this.clientsListed.Items.Add(string.Join(Environment.NewLine, "NO CLIENTS Added Yet"));
            }
            else
            {
                this.clientsListed.Items.Clear();
                foreach (Client aClient in clientsFromProgram)
                {
                    this.clientsListed.Items.Add(aClient);
                }
            }
        }

        private void DesignersListed_MouseClick(object sender, MouseEventArgs e)
        {
            this.clientsListed.ClearSelected();
            this.architectsListed.ClearSelected();
        }

        private void ClientsListed_MouseClick(object sender, MouseEventArgs e)
        {
            this.designersListed.ClearSelected();
            this.architectsListed.ClearSelected();
        }

        private void ArchitectsListed_MouseClick(object sender, MouseEventArgs e)
        {
            this.designersListed.ClearSelected();
            this.clientsListed.ClearSelected();
        }
    }
}
