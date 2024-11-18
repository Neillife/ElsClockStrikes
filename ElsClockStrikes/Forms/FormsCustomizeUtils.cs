using ElsClockStrikes.Core;
using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ElsClockStrikes.Forms
{
    public class FormsCustomizeUtils
    {
        public static string GetRemoveIndexCharOfStrgin(string str)
        {
            string[] prefixes = {
                FormsConstant.timeLeftLabelBaseName,
                FormsConstant.hotKeyLabelBaseName,
                FormsConstant.mechanicLabelBaseName,
                FormsConstant.comboBoxBaseName,
                FormsConstant.textBoxBaseName,
                FormsConstant.buttonBaseName,
                FormsConstant.timerBaseName
            };

            foreach (string prefix in prefixes)
            {
                if (str.StartsWith(prefix))
                {
                    return prefix;
                }
            }

            return str;
        }

        public static string GetIndexOfString(string name)
        {
            // Extract index logic in names
            return new string(name.Where(char.IsDigit).ToArray());
        }

        public static void ProcessComponentDisplaySettings(TabPage tabPage, bool isBackToOriginCheck)
        {
            List<Label> labels = new List<Label>();
            if (isBackToOriginCheck)
            {
                foreach (Control control in tabPage.Parent.Parent.Controls)
                {
                    if (control is Label label &&
                        (GetRemoveIndexCharOfStrgin(label.Name) == FormsConstant.timeLeftLabelBaseName ||
                        GetRemoveIndexCharOfStrgin(label.Name) == FormsConstant.hotKeyLabelBaseName ||
                        GetRemoveIndexCharOfStrgin(label.Name) == FormsConstant.mechanicLabelBaseName))
                    {
                        labels.Add(label);
                    }
                }
                foreach (Label label in labels)
                {
                    tabPage.Parent.Parent.Controls.Remove(label);
                    tabPage.Controls.Add(label);
                }
            }
            else
            {
                foreach (Control control in tabPage.Controls)
                {
                    if (control is Label label &&
                        (GetRemoveIndexCharOfStrgin(label.Name) == FormsConstant.timeLeftLabelBaseName ||
                        GetRemoveIndexCharOfStrgin(label.Name) == FormsConstant.hotKeyLabelBaseName ||
                        GetRemoveIndexCharOfStrgin(label.Name) == FormsConstant.mechanicLabelBaseName))
                    {
                        labels.Add(label);
                    }
                }
                foreach (Label label in labels)
                {
                    tabPage.Controls.Remove(label);
                    tabPage.Parent.Parent.Controls.Add(label);
                }
            }
        }

        public static void ProcessVisible(TabPage tabPage, bool isBackToOriginCheck)
        {
            if (isBackToOriginCheck)
            {
                foreach (Control control in tabPage.Parent.Parent.Controls)
                {
                    if (control is Label label &&
                        (GetRemoveIndexCharOfStrgin(label.Name) == FormsConstant.timeLeftLabelBaseName ||
                        GetRemoveIndexCharOfStrgin(label.Name) == FormsConstant.hotKeyLabelBaseName))
                    {
                        label.Visible = !label.Visible;
                    }
                }
            }
            else
            {
                foreach (Control control in tabPage.Controls)
                {
                    if (control is Label label &&
                        (GetRemoveIndexCharOfStrgin(label.Name) == FormsConstant.timeLeftLabelBaseName ||
                        GetRemoveIndexCharOfStrgin(label.Name) == FormsConstant.hotKeyLabelBaseName))
                    {
                        label.Visible = !label.Visible;
                    }
                }
            }
        }

        public static void ProcessSettingText(TabPage tabPage)
        {
            Dictionary<string, Label> hotKeyLabelMap = GetTheSetControlMap<Label>(tabPage, FormsConstant.hotKeyLabelBaseName);
            Dictionary<string, Label> timeLeftLabelMap = GetTheSetControlMap<Label>(tabPage, FormsConstant.timeLeftLabelBaseName);
            Dictionary<string, GunaComboBox> gunaComboBoxMap = GetTheSetControlMap<GunaComboBox>(tabPage, FormsConstant.comboBoxBaseName);
            Dictionary<string, GunaLineTextBox> gunaLineTextBoxMap = GetTheSetControlMap<GunaLineTextBox>(tabPage, FormsConstant.textBoxBaseName);

            foreach (string index in hotKeyLabelMap.Keys)
            {
                hotKeyLabelMap[index].Text = FormsUtils.ProcessLayoutString(gunaComboBoxMap[index].Text);
                timeLeftLabelMap[index].Text = gunaLineTextBoxMap[index].Text;
            }
        }

        public static Dictionary<string, T> GetTheSetControlMap<T>(TabPage tabPage, string controlNamePrefix) where T : Control
        {
            Dictionary<string, T> controlMap = new Dictionary<string, T>();

            foreach (Control control in tabPage.Controls)
            {
                if (control is T typedControl && GetRemoveIndexCharOfStrgin(control.Name) == controlNamePrefix)
                {
                    controlMap.Add(GetIndexOfString(control.Name), typedControl);

                    if (GetIndexOfString(control.Name) == FormsConstant.indexForCustomizeName.ToString())
                    {
                        break;
                    }
                }
            }

            return controlMap;
        }

        public static Dictionary<string, CustomizeTaskTimer> getCustomizeTaskTimerMap(List<CustomizeTaskTimer> customizeTaskTimerList)
        {
            Dictionary<string, CustomizeTaskTimer> customizeTaskTimerMap = new Dictionary<string, CustomizeTaskTimer>();

            foreach (CustomizeTaskTimer timer in customizeTaskTimerList)
            {
                string timerTagStr = timer.Tag.ToString();
                customizeTaskTimerMap.Add(GetIndexOfString(timerTagStr), timer);
            }

            return customizeTaskTimerMap;
        }

        public static Label getLabelByCustomizeIndex(Control parent, string findLabelName, int customizeIndex)
        {
            Label result = null;
            foreach (Control control in parent.Controls)
            {
                if (control is Label label)
                {
                    if (GetIndexOfString(label.Name) == customizeIndex.ToString() && GetRemoveIndexCharOfStrgin(label.Name) == findLabelName)
                    {
                        result = label;
                        break;
                    }
                }
            }
            return result;
        }

        public static GunaLineTextBox getGunaLineTextBoxByCustomizeIndex(Control parent, int customizeIndex)
        {
            GunaLineTextBox result = null;
            foreach (Control control in parent.Controls)
            {
                if (control is GunaLineTextBox textBox)
                {
                    if (GetIndexOfString(textBox.Name) == customizeIndex.ToString())
                    {
                        result = textBox;
                        break;
                    }
                }
            }
            return result;
        }

        public static GunaComboBox getGunaComboBoxByCustomizeIndex(Control parent, int customizeIndex)
        {
            GunaComboBox result = null;
            foreach (Control control in parent.Controls)
            {
                if (control is GunaComboBox textBox)
                {
                    if (GetIndexOfString(textBox.Name) == customizeIndex.ToString())
                    {
                        result = textBox;
                        break;
                    }
                }
            }
            return result;
        }

        public static void ProcessComponentLayout(TabPage tabPage, GunaButton gunaButton)
        {
            int currentButtonNameIndex = Int32.Parse(GetIndexOfString(gunaButton.Name));

            if (currentButtonNameIndex == FormsConstant.indexForCustomizeName)
            {
                return;
            }

            foreach (Control control in tabPage.Controls)
            {
                if (control is GunaButton GButton && 
                    GetRemoveIndexCharOfStrgin(GButton.Name) == FormsConstant.buttonBaseName && 
                    Int32.Parse(GetIndexOfString(GButton.Name)) > currentButtonNameIndex)
                {
                    int findIndex = Int32.Parse(GetIndexOfString(GButton.Name));
                    Label customizeTimeLeftLabel = getLabelByCustomizeIndex(tabPage, FormsConstant.timeLeftLabelBaseName, findIndex);
                    Label customizeHotKeyLabel = getLabelByCustomizeIndex(tabPage, FormsConstant.hotKeyLabelBaseName, findIndex);
                    Label customizeMechanicLabel = getLabelByCustomizeIndex(tabPage, FormsConstant.mechanicLabelBaseName, findIndex);
                    GunaLineTextBox gunaLineTextBox = getGunaLineTextBoxByCustomizeIndex(tabPage, findIndex);
                    GunaComboBox gunaComboBox = getGunaComboBoxByCustomizeIndex(tabPage, findIndex);

                    customizeTimeLeftLabel.Location = new Point(customizeTimeLeftLabel.Location.X, customizeTimeLeftLabel.Location.Y - FormsConstant.ControlLayoutOffset);
                    customizeHotKeyLabel.Location = new Point(customizeHotKeyLabel.Location.X, customizeHotKeyLabel.Location.Y - FormsConstant.ControlLayoutOffset);
                    customizeMechanicLabel.Location = new Point(customizeMechanicLabel.Location.X, customizeMechanicLabel.Location.Y - FormsConstant.ControlLayoutOffset);
                    GButton.Location = new Point(GButton.Location.X, GButton.Location.Y - FormsConstant.ControlLayoutOffset);
                    gunaLineTextBox.Location = new Point(gunaLineTextBox.Location.X, gunaLineTextBox.Location.Y - FormsConstant.ControlLayoutOffset);
                    gunaComboBox.Location = new Point(gunaComboBox.Location.X, gunaComboBox.Location.Y - FormsConstant.ControlLayoutOffset);
                }
            }
        }
    }
}
