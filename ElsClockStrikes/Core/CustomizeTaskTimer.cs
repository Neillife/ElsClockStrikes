using System;
using Guna.UI.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace ElsClockStrikes.Core
{
    public class CustomizeTaskTimer : Timer
    {
        private Label timeLeftLabel;
        private GunaLineTextBox customTimeGunaLineTextBox;
        private int customTime;
        private AudioPlayer audioPlayer;

        public CustomizeTaskTimer(string LastRetrievedTimerName) : base()
        {
            this.Interval = 1000;
            this.Tick += OnTick;
            this.Tag = LastRetrievedTimerName;
            this.audioPlayer = new AudioPlayer(Properties.Resources.荊棘延遲翻桌陰陽陣DefultSound);
        }

        public AudioPlayer getAudioPlayer()
        {
            return audioPlayer;
        }

        public CustomizeTaskTimer setCustomTimeGunaLineTextBox(GunaLineTextBox textBox)
        {
            this.customTimeGunaLineTextBox = textBox;
            return this;
        }

        public CustomizeTaskTimer setCustomTimeLabel(string customTimeLabel)
        {
            this.customTime = Int32.Parse(customTimeLabel);
            return this;
        }

        public CustomizeTaskTimer setTimeLeftLabel(Label timeLeftLabel)
        {
            this.timeLeftLabel = timeLeftLabel;
            return this;
        }

        private void OnTick(object sender, EventArgs e)
        {
            timeLeftLabel.Text = customTime == 0 ? "0" : (--customTime).ToString();

            if (customTime <= 10)
            {
                timeLeftLabel.ForeColor = Color.FromArgb(185, 45, 45);
            }
            else if (Int32.Parse(timeLeftLabel.Text) == Int32.Parse(customTimeGunaLineTextBox.Text) / 2)
            {
                timeLeftLabel.ForeColor = Color.FromArgb(185, 145, 52);
            }

            if (customTime == 0)
            {
                this.setCustomTimeLabel(customTimeGunaLineTextBox.Text);
                this.Stop();
                //if (預設音效RadioButton.Checked || 自訂音效RadioButton.Checked)
                //{
                audioPlayer.Play();
                //}
            }
        }
    }
}
