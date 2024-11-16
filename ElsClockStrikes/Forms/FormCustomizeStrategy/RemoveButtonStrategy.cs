using ElsClockStrikes.Core;
using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ElsClockStrikes.Forms.FormCustomizeStrategy
{
    public class RemoveButtonStrategy : BaseControlStrategy
    {
        public override void AddControl(ControlStrategyParameters controlStrategyParameters)
        {
            GunaButton lastGunaButton = this.GetControlByName<GunaButton>(controlStrategyParameters.tabPage, $"{FormsConstant.buttonBaseName}{FormsConstant.indexForCustomizeName - 1}");
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
            gunaButton.Location = ProcessButtonLayout(lastGunaButton);
            gunaButton.Name = $"{FormsConstant.buttonBaseName}{FormsConstant.indexForCustomizeName}";
            gunaButton.OnHoverBaseColor = Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            gunaButton.OnHoverBorderColor = Color.Black;
            gunaButton.OnHoverForeColor = Color.White;
            gunaButton.OnHoverImage = null;
            gunaButton.OnPressedColor = Color.Black;
            gunaButton.Size = new Size(84, 42);
            gunaButton.Text = "移除";
            gunaButton.TextAlign = HorizontalAlignment.Center;
            gunaButton.Click += new EventHandler(
            (object sender, EventArgs e) => {
                    this.ProcessRemoveComponent(controlStrategyParameters, gunaButton, controlStrategyParameters.customizeTaskTimerList);
                }
                );
            controlStrategyParameters.tabPage.Controls.Add(gunaButton);
        }

        private Point ProcessButtonLayout(GunaButton lastGunaButton)
        {
            return new Point(20, lastGunaButton == null ? 101 : lastGunaButton.Location.Y + LayoutYAxisNum);
        }

        private void ProcessRemoveComponent(ControlStrategyParameters controlStrategyParameters, GunaButton gunaButton, List<CustomizeTaskTimer> customizeTaskTimerList)
        {
            int breakCheck = 0;
            List<Control> controls = new List<Control>();
            controlStrategyParameters.tabPage.Controls.Remove(gunaButton);
            string currentButtonNameIndex = FormsCustomizeUtils.GetIndexOfString(gunaButton.Name);

            if (currentButtonNameIndex == FormsConstant.indexForCustomizeName.ToString())
            {
                FormsConstant.indexForCustomizeName--; // Makes finding the last element Method normal.
            }

            foreach (Control control in controlStrategyParameters.tabPage.Controls)
            {
                if (control is Label label && FormsCustomizeUtils.GetIndexOfString(label.Name) == currentButtonNameIndex)
                {
                    controls.Add(label);
                    breakCheck++;
                }
                else if (control is GunaComboBox gunaComboBox && FormsCustomizeUtils.GetIndexOfString(gunaComboBox.Name) == currentButtonNameIndex)
                {
                    controls.Add(gunaComboBox);
                    breakCheck++;
                }
                else if (control is GunaLineTextBox gunaLineTextBox && FormsCustomizeUtils.GetIndexOfString(gunaLineTextBox.Name) == currentButtonNameIndex)
                {
                    controls.Add(gunaLineTextBox);
                    breakCheck++;
                }
                if (breakCheck == 5) { break; } // Increase execution performance and avoid excessive invalid loops...
            }

            foreach (Control control in controls)
            {
                controlStrategyParameters.tabPage.Controls.Remove(control);
            }
            
            foreach (CustomizeTaskTimer customizeTaskTimer in customizeTaskTimerList)
            {
                if (FormsCustomizeUtils.GetIndexOfString(customizeTaskTimer.Tag.ToString()) == currentButtonNameIndex)
                {
                    customizeTaskTimerList.Remove(customizeTaskTimer);
                    break;
                }
            }
        }
    }
}
