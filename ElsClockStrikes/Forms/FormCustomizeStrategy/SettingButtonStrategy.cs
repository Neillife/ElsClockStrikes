using Guna.UI.WinForms;
using System;
using System.Drawing;

namespace ElsClockStrikes.Forms.FormCustomizeStrategy
{
    public class SettingButtonStrategy : BaseControlStrategy
    {
        private readonly Image _image;

        public SettingButtonStrategy(Image image) 
        {
            _image = image;
        }

        public override void AddControl(ControlStrategyParameters controlStrategyParameters)
        {
            GunaButton lastGunaButton = this.GetControlByName<GunaButton>(controlStrategyParameters.tabPage, $"{FormsConstant.settingButtonBaseName}{FormsConstant.indexForCustomizeName - 1}");
            GunaButton gunaButton = new GunaButton();
            gunaButton.Animated = true;
            gunaButton.AnimationHoverSpeed = 0.07F;
            gunaButton.AnimationSpeed = 0.03F;
            gunaButton.BackColor = Color.Transparent;
            gunaButton.BaseColor = Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(138)))), ((int)(((byte)(149)))));
            gunaButton.BorderColor = Color.Transparent;
            gunaButton.DialogResult = System.Windows.Forms.DialogResult.None;
            gunaButton.FocusedColor = Color.Empty;
            gunaButton.Font = new Font(Font, 12F, FontStyle.Bold);
            gunaButton.ForeColor = Color.WhiteSmoke;
            gunaButton.Image = _image;
            gunaButton.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            gunaButton.ImageSize = new Size(24, 24);
            gunaButton.Location = ProcessButtonLayout(lastGunaButton, 429);
            gunaButton.Name = $"{FormsConstant.settingButtonBaseName}{FormsConstant.indexForCustomizeName}";
            gunaButton.OnHoverBaseColor = Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            gunaButton.OnHoverBorderColor = Color.Black;
            gunaButton.OnHoverForeColor = Color.White;
            gunaButton.OnHoverImage = null;
            gunaButton.OnPressedColor = Color.Black;
            gunaButton.Size = new Size(84, 42);
            gunaButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            gunaButton.Click += new EventHandler(
                (object sender, EventArgs e) => {
                    this.ProcessSettingButtonClick(controlStrategyParameters, gunaButton);
                }
            );
            controlStrategyParameters.tabPage.Controls.Add(gunaButton);
        }

        private void ProcessSettingButtonClick(ControlStrategyParameters controlStrategyParameters, GunaButton settingButton)
        {
            FormsUtils.ProcessSettingBtnClick(controlStrategyParameters.gunaPanel, settingButton);
            FormsUtils.StartExpandAnimation(controlStrategyParameters.gunaPanel);
        }
    }
}
