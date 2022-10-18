using System;
using Domain;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;

namespace GUI
{

    public partial class Introduction : Form
    {

        private List<Color> colorWords = new List<Color> { Color.SaddleBrown, Color.Navy, Color.PaleGreen, Color.OrangeRed };
        private List<Color> colorLabels = new List<Color> { Color.Blue, Color.Red, Color.Green, Color.Orange };
        private SketchItApp programBeginning;
        private ClientDataAccess clientContext = new ClientDataAccess();
        private DesignerDataAccess designerContext = new DesignerDataAccess();
        private ArchitectDataAccess architectContext = new ArchitectDataAccess();
        private ChartDataAccess chartContext = new  ChartDataAccess();
        public Introduction()
        {
            InitializeComponent();
            InitializeWindow();

        }

        public void InitializeWindow()
        {
            StringBuilder rootDirectory = new StringBuilder();
            rootDirectory.Append(Application.StartupPath);
            rootDirectory.Append("/SketchItData");
            String root = rootDirectory.ToString();
            programBeginning = SketchItApp.GetInstance();


            foreach (Client c in clientContext.GetClients())
            {
                programBeginning.Users.Add(c);
            }
            foreach (Designer d in designerContext.GetDesigners())
            {
                programBeginning.Users.Add(d);
            }
            foreach (Architect a in architectContext.GetArchitects())
            {
                programBeginning.Users.Add(a);
            }
            foreach (Chart c in chartContext.GetCharts())
            {
                c.tableGrid = new Grid();
                c.Signatures = new List<Signature>();
                programBeginning.Charts.Add(c);   
            }

            List<Label> labels = new List<Label>() { this.labelLeft, this.labelRight };
            this.ChangeLabelsColor(labels);
        }

        public bool ClosingProtocol()
        {
            if (this.Visible)
            {
                DialogResult userWish = MessageBox.Show("Are you sure you want to exit?", "EXIT Introduction", MessageBoxButtons.YesNo);
                if (userWish == DialogResult.Yes)
                {
                    Application.Exit();
                }
                return userWish == DialogResult.Yes;
            } else
            {
                return true;
            }
        }

        public void ChangeWindowForm(Form previousForm, Form newForm)
        {
            previousForm.Visible = false;
            newForm.Show();
        }

        private void Start_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
            this.ChangeWordColorAsync();
        }

        private void Start_MouseClick(object sender, MouseEventArgs e)
        {
            ChangeWindowForm(this, new LogIn(this.programBeginning));
        }

        private void Start_MouseLeave(object sender, EventArgs e)
        {
            this.sketch.ForeColor = Color.Black;
            ChangeWordWelcomeAsync();
        }

        private async Task ChangeWordWelcomeAsync()
        {
            int times = 3;
            while (times > 0)
            {
                this.welcome.Text = "COME BACK!";
                Font previous = this.welcome.Font;
                this.welcome.Font = new Font("Arial", this.welcome.Font.Size);
                await Task.Delay(500);
                this.welcome.Text = "Welcome to";
                this.welcome.Font = previous;
                await Task.Delay(500);
                times--;
            }
        }

        private async Task ChangeWordColorAsync()
        {
            foreach (Color oneColor in this.colorWords)
            {
                this.sketch.ForeColor = oneColor;
                await Task.Delay(500);
            }
        }

        private async Task ChangeLabelsColor(List<Label> someLabels)
        {
            int colorPosition = 0;
            while (true)
            {
                foreach (Label oneLabel in someLabels)
                {
                    oneLabel.BackColor = this.colorLabels.ElementAt<Color>(colorPosition);
                    colorPosition++;
                    if (colorPosition == colorLabels.Count)
                    {
                        colorPosition = 0;
                    }
                    await Task.Delay(200);
                }
            }
        }

        private void Introduction2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ClosingProtocol())
            {
                e.Cancel = true;
            }
        }
    }

}
