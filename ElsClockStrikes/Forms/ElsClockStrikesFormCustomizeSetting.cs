using MetroSuite;
using System;
using System.Windows.Forms;

namespace ElsClockStrikes.Forms
{
    public partial class ElsClockStrikesFormCustomizeSetting : MetroForm
    {
        public string inputData { get; set; }

        public ElsClockStrikesFormCustomizeSetting()
        {
            InitializeComponent();
        }

        private void AddFeatureNameButton_Click(object sender, EventArgs e)
        {
            inputData = FeatureNameTextBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
