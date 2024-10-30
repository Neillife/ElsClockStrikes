using ElsClockStrikes.Core;
using ElsClockStrikes.Forms;
using System;
using System.Windows.Forms;

namespace ElsClockStrikes
{
    public partial class ElsClockStrikesForm
    {
        public CustomizeTaskTimer customizeTaskTimer;
        private void AddCustomizeTimer_Click(object sender, EventArgs e)
        {
            customizeTaskTimer = new CustomizeTaskTimer(this.components);

            using (ElsClockStrikesFormCustomizeSetting elsClockStrikesFormCustomizeSetting = new ElsClockStrikesFormCustomizeSetting())
            {
                if (elsClockStrikesFormCustomizeSetting.ShowDialog() == DialogResult.OK)
                {
                    string inputData = elsClockStrikesFormCustomizeSetting.inputData;
                    if (inputData != null && inputData.Trim() != "")
                    {
                        FormCustomizeUtils.StartAddCustomize(this.TabPageCustomize, inputData);
                    }
                }
            }

            if (FormCustomizeUtils.getTimerByCustomizeIndex(this.TabPageCustomize.Parent.Parent, "3") == null)
            {
                Testlabel.Text = $"null {FormCustomizeUtils.LastRetrievedTimeLeftLabelName}";
            } else
            {
                Testlabel.Text = "!!!!!!!!!";
            }
            //Testlabel.Text = FormCustomizeUtils.getTimerByCustomizeIndex(this.TabPageCustomize).Tag.ToString();

            //Testlabel.Text = "10";
            //customizeTaskTimer.Start();
        }

        private void TopMostCustomizeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
        }

        private void WindowsSettingCustomize_Click(object sender, EventArgs e)
        {
        }
    }
}
