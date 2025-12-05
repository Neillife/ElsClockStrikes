using MetroSuite;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ElsClockStrikes.Forms
{
    public partial class ElsClockStrikesFormSeqKeySetting : MetroForm
    {
        private bool topMost;

        public string inputData { get; set; }
        public string sequenceData { get; set; }

        public ElsClockStrikesFormSeqKeySetting(bool topMost, bool isEdit = false, string textBoxStr = "", string sequenceData = "")
        {
            this.topMost = topMost;
            InitializeComponent();
            FormsUtils.GetComboBoxItemsFormHotKeySet(FirstKeyComboBox, "F1");
            FormsUtils.GetComboBoxItemsFormHotKeySet(TwoKeyComboBox, "F2");
            FormsUtils.GetComboBoxItemsFormHotKeySet(ThreeKeyComboBox, "F3");
            if (isEdit)
            {
                AddFeatureNameButton.Text = "設定完成";
                AddFeatureNameButton.Location = new Point(250, 77);
                SinKeyFeatureButton.Visible = false;
                FeatureNameTextBox.Size = new Size(210, 42);
                FeatureNameTextBox.Text = textBoxStr;
                string[] seqStrs = FormsCustomizeUtils.GetSeqSplitStrs(sequenceData);
                FirstKeyComboBox.Text = seqStrs[0];
                TwoKeyComboBox.Text = seqStrs[1];
                ThreeKeyComboBox.Text = seqStrs[2];
            }
        }

        private void AddFeatureNameButton_Click(object sender, EventArgs e)
        {
            inputData = FeatureNameTextBox.Text;
            sequenceData = $"{FirstKeyComboBox.Text}+{TwoKeyComboBox.Text}+{ThreeKeyComboBox.Text}";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FeatureNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddFeatureNameButton.Focus();
                AddFeatureNameButton_Click(sender, e);
                FeatureNameTextBox.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void ElsClockStrikesFormSeqKeySetting_Activated(object sender, EventArgs e)
        {
            FeatureNameTextBox.Focus();
            this.TopMost = topMost;
        }

        private void SinKeyFeatureButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }

        private void ElsClockStrikesFormSeqKeySetting_Load(object sender, EventArgs e)
        {
            Image randImg = FormsConstant.FormFeatureSettingBtnImgMap.Keys.ElementAt(new Random().Next(FormsConstant.FormFeatureSettingBtnImgMap.Keys.Count));
            this.SinKeyFeatureButton.Image = randImg;
            this.SinKeyFeatureButton.ImageSize = FormsConstant.FormFeatureSettingBtnImgMap[randImg];
        }
    }
}
