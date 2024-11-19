using Guna.UI.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ElsClockStrikes.Forms.FormCustomizeStrategy
{
    public class AudioPlayerButtonStrategy : BaseControlStrategy
    {
        private bool isVisible;

        public AudioPlayerButtonStrategy(bool isVisible)
        {
            this.isVisible = isVisible;
        }

        public override void AddControl(ControlStrategyParameters controlStrategyParameters)
        {
            GunaButton lastGunaButton = this.GetControlByName<GunaButton>(controlStrategyParameters.tabPage, $"{FormsConstant.audioPlayerButtonBaseName}{FormsConstant.indexForCustomizeName - 1}");
            GunaButton gunaButton = new GunaButton();
            gunaButton.Animated = true;
            gunaButton.AnimationHoverSpeed = 0.07F;
            gunaButton.AnimationSpeed = 0.03F;
            gunaButton.BackColor = Color.Transparent;
            gunaButton.BaseColor = Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            gunaButton.BorderColor = Color.Transparent;
            gunaButton.DialogResult = DialogResult.None;
            gunaButton.FocusedColor = Color.Empty;
            gunaButton.Font = new Font(Font, 12F, FontStyle.Bold);
            gunaButton.ForeColor = Color.WhiteSmoke;
            gunaButton.Image = null;
            gunaButton.ImageSize = new Size(24, 24);
            gunaButton.Location = ProcessButtonLayout(lastGunaButton, 429, 29);
            gunaButton.Name = $"{FormsConstant.audioPlayerButtonBaseName}{FormsConstant.indexForCustomizeName}";
            gunaButton.OnHoverBaseColor = Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            gunaButton.OnHoverBorderColor = Color.Black;
            gunaButton.OnHoverForeColor = Color.White;
            gunaButton.OnHoverImage = null;
            gunaButton.OnPressedColor = Color.Black;
            gunaButton.Size = new Size(84, 42);
            gunaButton.Text = "設定音效";
            gunaButton.TextAlign = HorizontalAlignment.Center;
            gunaButton.Visible = isVisible;
            gunaButton.Click += new EventHandler(
                (object sender, EventArgs e) => {
                    this.ProcessAudioPlayerButtonClick(controlStrategyParameters, gunaButton);
                }
            );
            controlStrategyParameters.tabPage.Controls.Add(gunaButton);
        }

        private void ProcessAudioPlayerButtonClick(ControlStrategyParameters controlStrategyParameters, GunaButton gunaButton)
        {
            controlStrategyParameters.customizeTaskTimerList[Int32.Parse(FormsCustomizeUtils.GetIndexOfString(gunaButton.Name)) - 1]
                .setAudioPlayer(FormsUtils.ProcessSelectSoundFile(Properties.Resources.荊棘延遲翻桌陰陽陣DefultSound));
        }
    }
}
