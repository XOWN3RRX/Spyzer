using Spyzer.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace Spyzer.SpyForm
{
    public partial class SpyFormSettings : Form
    {
        public SpyFormSettings()
        {
            InitializeComponent();
        }

        private void SpyFormSettings_Load(object sender, System.EventArgs e)
        {
            checkBoxTop.Checked = Settings.Default.DefaultTop;
            checkBoxLandscape.Checked = Settings.Default.DefaultLandscape;
            checkBoxDrawMargin.Checked = Settings.Default.DefaultDrawMargin;

            Bitmap bmp = new Bitmap(13, 13);
            bmp.FillColor(Settings.Default.DefaultColor);

            pictureBoxDrawColor.Image = bmp;
        }

        private void checkBoxTop_CheckedChanged(object sender, System.EventArgs e)
        {
            Settings.Default.DefaultTop = (sender as CheckBox).Checked;
            Settings.Default.Save();
        }

        private void checkBoxLandscape_CheckedChanged(object sender, System.EventArgs e)
        {
            Settings.Default.DefaultLandscape = (sender as CheckBox).Checked;
            Settings.Default.Save();
        }

        private void checkBoxDrawMargin_CheckedChanged(object sender, System.EventArgs e)
        {
            Settings.Default.DefaultDrawMargin = (sender as CheckBox).Checked;
            Settings.Default.Save();
        }

        private void pictureBoxDrawColor_Click(object sender, System.EventArgs e)
        {
            SelectColor();
        }

        private void SelectColor()
        {
            if (colorDialogDraw.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(13, 13);
                bmp.FillColor(colorDialogDraw.Color);

                pictureBoxDrawColor.Image = bmp;

                Settings.Default.DefaultColor = colorDialogDraw.Color;
                Settings.Default.Save();
            }
        }

        private void label1_Click(object sender, System.EventArgs e)
        {
            SelectColor();
        }
    }
}
