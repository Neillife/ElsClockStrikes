using ElsClockStrikes.Core;
using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            gunaButton.Location = ProcessButtonLayout(lastGunaButton, 20);
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
                    this.ProcessRemoveComponent(controlStrategyParameters, gunaButton);
                    this.ProcessComponentNameIndex(controlStrategyParameters, gunaButton);
                }
            );
            controlStrategyParameters.tabPage.Controls.Add(gunaButton);
        }

        private string GetRemoveIndex(GunaButton removeGunaButton)
        {
            return FormsCustomizeUtils.GetIndexOfString(removeGunaButton.Name);
        }

        private void ProcessComponentNameIndex(ControlStrategyParameters controlStrategyParameters, GunaButton gunaButton)
        {
            int currentButtonNameIndex = Int32.Parse(this.GetRemoveIndex(gunaButton));

            if (currentButtonNameIndex == FormsConstant.indexForCustomizeName)
            {
                FormsConstant.indexForCustomizeName--; // Update last index.
                return;
            }

            FormsConstant.indexForCustomizeName--; // Update last index.
            int parseNum;

            foreach (CustomizeTaskTimer customizeTaskTimer in controlStrategyParameters.customizeTaskTimerList)
            {
                int tagIndex;
                if (Int32.TryParse(FormsCustomizeUtils.GetIndexOfString(customizeTaskTimer.Tag.ToString()), out tagIndex) && tagIndex > currentButtonNameIndex)
                {
                    customizeTaskTimer.Tag = $"{FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(customizeTaskTimer.Tag.ToString())}{tagIndex - 1}";
                }
            }

            foreach (Control control in controlStrategyParameters.tabPage.Controls)
            {
                if (control is Label label && Int32.TryParse(FormsCustomizeUtils.GetIndexOfString(label.Name), out parseNum) && parseNum > currentButtonNameIndex)
                {
                    label.Name = $"{FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(label.Name)}{parseNum - 1}";
                }
                else if (control is GunaComboBox gunaComboBox && Int32.TryParse(FormsCustomizeUtils.GetIndexOfString(gunaComboBox.Name), out parseNum) && parseNum > currentButtonNameIndex)
                {
                    gunaComboBox.Name = $"{FormsConstant.comboBoxBaseName}{parseNum - 1}";
                }
                else if (control is GunaLineTextBox gunaLineTextBox && Int32.TryParse(FormsCustomizeUtils.GetIndexOfString(gunaLineTextBox.Name), out parseNum) && parseNum > currentButtonNameIndex)
                {
                    gunaLineTextBox.Name = $"{FormsConstant.textBoxBaseName}{parseNum - 1}";
                }
                else if (control is GunaButton GButton && Int32.TryParse(FormsCustomizeUtils.GetIndexOfString(GButton.Name), out parseNum) && parseNum > currentButtonNameIndex)
                {
                    GButton.Name = $"{FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(GButton.Name)}{parseNum - 1}";
                }
                else if (control is GunaPanel GPanel && Int32.TryParse(FormsCustomizeUtils.GetIndexOfString(GPanel.Name), out parseNum) && parseNum > currentButtonNameIndex)
                {
                    GPanel.Name = $"{FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(GPanel.Name)}{parseNum - 1}";
                    int isCanBreak = 0;
                    foreach (Control panelControl in GPanel.Controls)
                    {
                        if (panelControl is GunaButton audioPlayerButton && Int32.TryParse(FormsCustomizeUtils.GetIndexOfString(audioPlayerButton.Name), out parseNum) && parseNum > currentButtonNameIndex)
                        {
                            audioPlayerButton.Name = $"{FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(audioPlayerButton.Name)}{parseNum - 1}";
                            isCanBreak++;
                        }
                        else if (panelControl is GunaCheckBox formInstanceCheckBox && Int32.TryParse(FormsCustomizeUtils.GetIndexOfString(formInstanceCheckBox.Name), out parseNum) && parseNum > currentButtonNameIndex)
                        {
                            formInstanceCheckBox.Name = $"{FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(formInstanceCheckBox.Name)}{parseNum - 1}";
                            isCanBreak++;
                        }
                        if (isCanBreak == 2) break;
                    }
                }
            }
        }

        private void ProcessRemoveComponent(ControlStrategyParameters controlStrategyParameters, GunaButton gunaButton)
        {
            int breakCheck = 0;
            List<Control> controls = new List<Control>();
            controlStrategyParameters.tabPage.Controls.Remove(gunaButton);
            string currentButtonNameIndex = this.GetRemoveIndex(gunaButton);

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
                else if (control is GunaButton settingButton && FormsCustomizeUtils.GetIndexOfString(settingButton.Name) == currentButtonNameIndex)
                {
                    controls.Add(settingButton);
                    breakCheck++;
                }
                else if (control is GunaPanel panel && FormsCustomizeUtils.GetIndexOfString(panel.Name) == currentButtonNameIndex)
                {
                    controls.Add(panel);
                    breakCheck++;
                }
                if (breakCheck == 7) { break; } // Increase execution performance and avoid excessive invalid loops...
            }

            foreach (Control control in controls)
            {
                controlStrategyParameters.tabPage.Controls.Remove(control);
            }

            if (controlStrategyParameters.customizeTaskTimerList.Any())
            {
                controlStrategyParameters.customizeTaskTimerList.RemoveAt(Int32.Parse(currentButtonNameIndex) - 1);
            }
        }
    }
}
