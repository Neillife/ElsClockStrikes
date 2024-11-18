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
                    this.ProcessRemoveComponent(controlStrategyParameters, gunaButton);
                    this.ProcessComponentNameIndex(controlStrategyParameters, gunaButton);
            }
                );
            controlStrategyParameters.tabPage.Controls.Add(gunaButton);
        }

        private Point ProcessButtonLayout(GunaButton lastGunaButton)
        {
            return new Point(20, lastGunaButton == null ? 29 : lastGunaButton.Location.Y + FormsConstant.ControlLayoutOffset);
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
            }
            else
            {
                int parseNum;
                foreach (Control control in controlStrategyParameters.tabPage.Controls)
                {
                    if (control is Label label && Int32.TryParse(FormsCustomizeUtils.GetIndexOfString(label.Name), out parseNum) && parseNum > currentButtonNameIndex)
                    {
                        FormsConstant.indexForCustomizeName = parseNum - 1; // Update last index.
                        string labelName = FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(label.Name);
                        label.Name = $"{labelName}{parseNum - 1}";
                        if (labelName == FormsConstant.timeLeftLabelBaseName) {
                            foreach (CustomizeTaskTimer customizeTaskTimer in controlStrategyParameters.customizeTaskTimerList)
                            {
                                int tagIndex;
                                if (Int32.TryParse(FormsCustomizeUtils.GetIndexOfString(customizeTaskTimer.Tag.ToString()), out tagIndex) && tagIndex == (parseNum - 1))
                                {
                                    customizeTaskTimer.setTimeLeftLabel(label);
                                    break;
                                }
                            }
                        }
                    }
                    else if (control is GunaComboBox gunaComboBox && Int32.TryParse(FormsCustomizeUtils.GetIndexOfString(gunaComboBox.Name), out parseNum) && parseNum > currentButtonNameIndex)
                    {
                        gunaComboBox.Name = $"{FormsConstant.comboBoxBaseName}{parseNum - 1}";
                    }
                    else if (control is GunaLineTextBox gunaLineTextBox && Int32.TryParse(FormsCustomizeUtils.GetIndexOfString(gunaLineTextBox.Name), out parseNum) && parseNum > currentButtonNameIndex)
                    {
                        gunaLineTextBox.Name = $"{FormsConstant.textBoxBaseName}{parseNum - 1}";
                        foreach (CustomizeTaskTimer customizeTaskTimer in controlStrategyParameters.customizeTaskTimerList)
                        {
                            int tagIndex;
                            if (Int32.TryParse(FormsCustomizeUtils.GetIndexOfString(customizeTaskTimer.Tag.ToString()), out tagIndex) && tagIndex == (parseNum - 1))
                            {
                                customizeTaskTimer.setCustomTimeGunaLineTextBox(gunaLineTextBox);
                                break;
                            }
                        }
                    }
                    else if (control is GunaButton GButton && Int32.TryParse(FormsCustomizeUtils.GetIndexOfString(GButton.Name), out parseNum) && parseNum > currentButtonNameIndex)
                    {
                        GButton.Name = $"{FormsConstant.buttonBaseName}{parseNum - 1}";
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
                if (breakCheck == 5) { break; } // Increase execution performance and avoid excessive invalid loops...
            }

            foreach (Control control in controls)
            {
                controlStrategyParameters.tabPage.Controls.Remove(control);
            }
            
            if (controlStrategyParameters.customizeTaskTimerList.Any())
            {
                controlStrategyParameters.customizeTaskTimerList.RemoveAt(controlStrategyParameters.customizeTaskTimerList.Count - 1);
            }
        }
    }
}
