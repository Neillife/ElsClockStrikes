using ElsClockStrikes.Forms;
using System;
using Guna.UI.WinForms;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace ElsClockStrikes.Core
{
    public class CustomizeTaskTimer : Timer
    {
        public Label timeLeftLabel;
        public GunaLineTextBox customTimeGunaLineTextBox;
        public int customTimeLabel;

        public CustomizeTaskTimer(IContainer components) : base()
        {
            this.Interval = 1000;
            this.Tick += OnTick;
            this.Tag = FormCustomizeUtils.LastRetrievedTimerName;
            components.Add(this);
        }

        public CustomizeTaskTimer setCustomTimeGunaLineTextBox(GunaLineTextBox textBox)
        {
            this.customTimeGunaLineTextBox = textBox;
            return this;
        }

        public CustomizeTaskTimer setCustomTimeLabel(int customTimeLabel)
        {
            this.customTimeLabel = customTimeLabel;
            return this;
        }

        public CustomizeTaskTimer setTimeLeftLabel(Label timeLeftLabel)
        {
            this.timeLeftLabel = timeLeftLabel;
            return this;
        }

        private void OnTick(object sender, EventArgs e)
        {
            timeLeftLabel.Text = customTimeLabel == 0 ? "0" : (--customTimeLabel).ToString();

            if (customTimeLabel <= 10)
            {
                timeLeftLabel.ForeColor = Color.FromArgb(185, 45, 45);
            }
            else if (Int32.Parse(timeLeftLabel.Text) == Int32.Parse(customTimeGunaLineTextBox.Text) / 2)
            {
                timeLeftLabel.ForeColor = Color.FromArgb(185, 145, 52);
            }

            if (customTimeLabel == 0)
            {
                this.setCustomTimeLabel(Int32.Parse(customTimeGunaLineTextBox.Text));
                this.Stop();
                //if (預設音效RadioButton.Checked || 自訂音效RadioButton.Checked)
                //{
                    //R3156控場TimeupAudioPlayer.Play();
                //}
            }
        }
    }
}
