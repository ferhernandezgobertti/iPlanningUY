using System;
using Domain;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace GUI
{
    public partial class  ChartShowing : Form
    {

        private SketchItApp program;
        private Chart showingChart;
        private IWindowsChangeable previousForm;
        private Graphics chartGraphic;

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        public ChartShowing(SketchItApp programContinuation, Chart chartToShow, IWindowsChangeable previousWindow) {
            InitializeComponent();
            this.program = programContinuation;
            this.previousForm = previousWindow;
            this.showingChart = chartToShow;
            SetParent(this.chartShow.Handle, this.backPanel.Handle);
            this.chartShow.Size = new Size(this.showingChart.GetPixels()[1] + 2 * ConstantsChart.BLOCKPIXELS, this.showingChart.GetPixels()[0] + 2 * ConstantsChart.BLOCKPIXELS);
            InitializeWindow();

        }

        public void InitializeWindow() {
            this.chartGraphic = this.chartShow.CreateGraphics();
            this.chartGraphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.CountChartElements();
            this.ConfigureGridStyleCheckBox();
        }

        private void CountChartElements() {
            int[] quantityOfElements = this.showingChart.CountElements();
            this.wallMeters.Text = "Meters of Wall: " + quantityOfElements[0];
            this.beamQuantity.Text = "Beam Quantity: " + quantityOfElements[1];
            this.doorQuantity.Text = "Door Quantity: " + quantityOfElements[2];
            this.windowQuantity.Text = "Window Quantity: " + quantityOfElements[3];
            this.columnQuantity.Text = "Column Quantity: " + quantityOfElements[4];
        }

        private void ConfigureGridStyleCheckBox() {
            this.differentStylesOptions.Items.Add("Solid Grid", true);
            this.differentStylesOptions.Items.Add("Dashed Grid", false);
            this.differentStylesOptions.Items.Add("Invisible Grid", false);
            this.differentStylesOptions.CheckOnClick = true;
            this.differentStylesOptions.ThreeDCheckBoxes = true;
        }

        public bool ClosingProtocol() {
            if (this.Visible) {
                DialogResult userWish = MessageBox.Show("Are you sure you want to exit?", "EXIT ChartShowing", MessageBoxButtons.YesNo);
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

        private void Help_Click(object sender, EventArgs e) {
            MessageBox.Show("Save your Chart in the format you want", "YOUR CHART");
        }

        private void BackOption_Click(object sender, EventArgs e) {
            DialogResult userWish = MessageBox.Show("Are you sure you want to Go Back?", "BACK", MessageBoxButtons.YesNo);
            if (userWish == DialogResult.Yes) {
                this.previousForm.ChangeToPreviousForm(this);
            }
        }

        private void BmpSaving_Click(object sender, EventArgs e) {
            this.SaveImage(ImageFormat.Bmp, ".bmp", ".BMP");
        }

        private void JpgSaving_Click(object sender, EventArgs e) {
            this.SaveImage(ImageFormat.Jpeg, ".jpg", ".JPG");
        }

        private void PngSaving_Click(object sender, EventArgs e) {
            this.SaveImage(ImageFormat.Png, ".png", ".PNG");
        }

        private void GifSaving_Click(object sender, EventArgs e) {
            this.SaveImage(ImageFormat.Gif, ".gif", ".GIF");
        }

        private void SaveImage(ImageFormat formatType, String formatDirectory, String formatMessage) {
            int width = this.chartShow.Size.Width;
            int length = this.chartShow.Size.Height;

            Bitmap chartBitmap = new Bitmap(width, length, this.chartGraphic);
            Graphics graphicsToSave = Graphics.FromImage(chartBitmap);
            graphicsToSave.Clear(Color.White);
            this.PaintToGraphic(ref graphicsToSave);

            String saveDirectory = GetSaveDirectory(formatDirectory);
            if (File.Exists(saveDirectory)) {
                File.Delete(saveDirectory);
            }

            chartBitmap.Save(saveDirectory.ToString(), formatType);

            MessageBox.Show(GetDirectoryMessage(formatMessage, saveDirectory.ToString()));
        }

        private String GetSaveDirectory (String formatDirectory) {
            StringBuilder saveDirectory = new StringBuilder();
            saveDirectory.Append(Application.StartupPath);
            saveDirectory.Append("/SketchItData/Chart_Images/");
            saveDirectory.Append(this.showingChart.Name);
            saveDirectory.Append(formatDirectory);
            return saveDirectory.ToString();
        }

        private String GetDirectoryMessage(String formatMessage, String saveDirectory) {
            StringBuilder directoryMessage = new StringBuilder();
            directoryMessage.Append("Chart SUCCESFULY Saved into ");
            directoryMessage.Append(formatMessage);
            directoryMessage.Append(" at ");
            directoryMessage.Append(saveDirectory);
            return directoryMessage.ToString();
        }

        private void ChartShowing_FormClosing(object sender, FormClosingEventArgs e) {
            if (!ClosingProtocol()) {
                e.Cancel = true;
            }
        }

        private void ShowingChart_Paint(object sender, PaintEventArgs e) {
            this.PaintToGraphic(ref this.chartGraphic);
        }

        private void PaintToGraphic (ref Graphics graphicOfChart) {
            this.showingChart.DrawGrid(ref graphicOfChart, this.differentStylesOptions.SelectedIndex);
            if (this.showingChart.Elements.Count != 0) {
                foreach (IDrawable element in this.showingChart.Elements) {
                    element.Draw(ref graphicOfChart);
                }
            }
        }

        private void DifferentStylesOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedItem = this.differentStylesOptions.SelectedIndex;
            if (selectedItem == -1) {
                this.differentStylesOptions.SelectedIndex = 0;
            }
            if (selectedItem == 0) {
                this.differentStylesOptions.SetItemChecked(1, false);
                this.differentStylesOptions.SetItemChecked(2, false);
            }
            if (selectedItem == 1) {
                this.differentStylesOptions.SetItemChecked(0, false);
                this.differentStylesOptions.SetItemChecked(2, false);
            }
            if (selectedItem == 2) {
                this.differentStylesOptions.SetItemChecked(0, false);
                this.differentStylesOptions.SetItemChecked(1, false);
            }
            this.chartShow.Refresh();
        }
    }
}
