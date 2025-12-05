using ElsClockStrikes.Core;
using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace ElsClockStrikes.Forms
{
    public class FormsUtils
    {
        public static Timer getTimerByNamingPattern(Control parent, string namePattern)
        {
            Timer result = null;
            FieldInfo[] fields = parent.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                if (field.FieldType == typeof(Timer))
                {
                    Timer timer = (Timer)field.GetValue(parent);
                    if (timer != null)
                    {
                        int subStringIndex = namePattern.Length;
                        for (int i = 1; i < subStringIndex; i++)
                        {
                            if (timer.Tag.ToString().StartsWith(namePattern.Substring(0, subStringIndex - i) + "Timer"))
                            {
                                result = timer;
                                break;
                            }
                        }
                        if (result != null)
                        {
                            break;
                        }
                    }
                }
            }
            return result;
        }

        public static Label getLabelByNamingPattern(Control parent, string namePattern)
        {
            Label result = null;
            foreach (Control control in parent.Controls)
            {
                if (control is Label label)
                {
                    int subStringIndex = namePattern.Length;
                    for (int i = 1; i < subStringIndex; i++)
                    {
                        if (label.Name.StartsWith(namePattern.Substring(0, subStringIndex - i) + "CDLabel"))
                        {
                            result = label;
                            break;
                        }
                    }
                    if (result != null)
                    {
                        break;
                    }
                }
            }
            return result;
        }

        public static GunaLineTextBox getGunaLineTextBoxByNamingPattern(Control parent, string namePattern)
        {
            GunaLineTextBox result = null;
            foreach (Control control in parent.Controls)
            {
                if (control is GunaLineTextBox textBox)
                {
                    int subStringIndex = namePattern.Length;
                    for (int i = 1; i < subStringIndex; i++)
                    {
                        if (textBox.Name.StartsWith(namePattern.Substring(0, subStringIndex - i) + "TextBox"))
                        {
                            result = textBox;
                            break;
                        }
                    }
                    if (result != null)
                    {
                        break;
                    }
                }
            }
            return result;
        }

        public static List<GunaCheckBox> GetFormInstanceCheckBoxListByMechanicNames(TabPage tabPage, List<string> mechanicNames)
        {
            List<GunaCheckBox> result = new List<GunaCheckBox>();
            GunaCheckBox cb = null;
            foreach (string name in mechanicNames)
            {
                foreach (Control control in tabPage.Controls)
                {
                    if (control is GunaPanel gunaPanel && control.Name == $"{name}GunaPanel")
                    {
                        foreach (Control gunaPanelControl in gunaPanel.Controls)
                        {
                            if (gunaPanelControl is GunaCheckBox checkBox && gunaPanelControl.Name == $"{name}分離視窗CheckBox")
                            {
                                cb = checkBox;
                                break;
                            }
                        }
                        if (cb != null)
                        {
                            result.Add(cb);
                            cb = null;
                            break;
                        }
                    }
                }
            }

            return result;
        }

        public static Dictionary<string, FormInstanceParameters> GetFIPMapByMechanicNames(Control parent, List<string> mechanicNames)
        {
            Dictionary<string, FormInstanceParameters> controlMap = new Dictionary<string, FormInstanceParameters>();
            foreach (string name in mechanicNames)
            {
                FormInstanceParameters param = new FormInstanceParameters();

                foreach (Control control in parent.Controls)
                {
                    if (control is Label keyLabel && control.Name == $"{name}按鍵Label")
                        param.keyLabel = keyLabel;

                    else if (control is Label nameLabel && control.Name == $"{name}Label")
                        param.nameLabel = nameLabel;

                    else if (control is Label timeLeftLabel && control.Name == $"{name}CDLabel")
                        param.timeLeftLabel = timeLeftLabel;

                    if (param.keyLabel != null &&
                        param.nameLabel != null &&
                        param.timeLeftLabel != null)
                    {
                        controlMap.Add(name, param);
                        break;
                    }
                }
            }

            return controlMap;
        }

        public static MethodInfo getMethodInfoByNamingPattern(string namePattern)
        {
            MethodInfo result = null;
            Type type = typeof(FormsConstant);
            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (MethodInfo method in methods)
            {
                int subStringIndex = namePattern.Length;
                for (int i = 1; i < subStringIndex; i++)
                {
                    if (method.Name.Substring(3).StartsWith(namePattern.Substring(0, subStringIndex - i) + "Time"))
                    {
                        result = method;
                        break;
                    }
                }
                if (result != null)
                {
                    break;
                }
            }
            return result;
        }

        public static AudioPlayer getAudioPlayerFieldByNamingPattern(Type type, Control parent, string namePattern)
        {
            AudioPlayer result = null;
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (FieldInfo field in fields)
            {
                int subStringIndex = namePattern.Length;
                for (int i = 1; i < subStringIndex; i++)
                {
                    if (field.Name.StartsWith(namePattern.Substring(0, subStringIndex - i) + "TimeupAudioPlayer") && field.GetValue(parent) is AudioPlayer ap)
                    {
                        result = ap;
                        break;
                    }
                }
                if (result != null)
                {
                    break;
                }
            }
            return result;
        }

        public static int GetLabelMaxWidth(Control parent)
        {
            int maxWidth = 0;
            foreach (Control control in parent.Controls)
            {
                if (control is Label && maxWidth < control.Width && control.Text != FormsConstant.copyrightTag)
                {
                    maxWidth = control.Width;
                }
            }
            return maxWidth;
        }

        public static void ProcessKeyPress(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        public static void ProcessSoundTextBoxLeave(GunaLineTextBox soundTextBox)
        {
            if (soundTextBox.Text.Trim() == "" || Int32.Parse(soundTextBox.Text.Trim()) > 100 || Int32.Parse(soundTextBox.Text.Trim()) < 0)
            {
                soundTextBox.Text = "100";
            }
        }

        public static AudioPlayer ProcessSelectSoundFile(UnmanagedMemoryStream defaultSound)
        {
            AudioPlayer ap = new AudioPlayer(defaultSound);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "請選擇音效檔";
            openFileDialog.Filter = "MP3 Files (*.mp3)|*.mp3|WAV Files (*.wav)|*.wav";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ap = new AudioPlayer(openFileDialog.FileName);
            }
            return ap;
        }

        public static string ProcessLayoutString(string comboBoxText)
        {
            return comboBoxText.Replace("鍵盤", "").Replace("LCtrl", "LC").Replace("RCtrl", "RC").Replace("LShift", "LShi").Replace("RShift", "RShi");
        }

        public static void ProcessSettingBtnClick(Panel targetPanel, GunaButton targetButton)
        {
            targetPanel.Visible = !targetPanel.Visible;
            if (targetPanel.Visible)
            {
                targetButton.BaseColor = Color.FromArgb(44, 149, 180);
                targetButton.OnHoverBaseColor = Color.FromArgb(20, 120, 170);
                targetButton.Image = Properties.Resources.cross;
            }
            else
            {
                targetButton.BaseColor = Color.FromArgb(143, 138, 149);
                targetButton.OnHoverBaseColor = Color.FromArgb(120, 120, 120);
                targetButton.Image = Properties.Resources.setimg;
            }
        }

        public static void StartExpandAnimation(Panel targetPanel)
        {
            Timer t = new Timer();
            t.Interval = 15;

            int targetHeight = targetPanel.Visible ? FormsConstant.targetPanelHeight : 0;
            int adjHeightNum = 10;
            bool expanding = targetPanel.Visible;
            targetPanel.BringToFront();

            t.Tick += (s, e) =>
            {
                if (expanding)
                {
                    targetPanel.Height += adjHeightNum;
                    if (targetPanel.Height >= targetHeight)
                    {
                        targetPanel.Height = targetHeight;
                        t.Stop();
                        t.Dispose();
                    }
                }
                else
                {
                    targetPanel.Height -= adjHeightNum;
                    if (targetPanel.Height <= 0)
                    {
                        targetPanel.Height = 0;
                        targetPanel.Visible = false;
                        t.Stop();
                        t.Dispose();
                    }
                }
            };

            targetPanel.Visible = true;
            t.Start();
        }

        public static HotKeySet.KeySet TryParseHotKeySet(string keyName)
        {
            if (Enum.TryParse<HotKeySet.KeySet>(keyName, out var result))
                return result;

            return ArrowKeySymbolToHotKeySet(keyName);
        }

        public static List<string> GetHotKeySetStrings()
        {
            FieldInfo[] fields = typeof(HotKeySet.KeySet).GetFields(BindingFlags.Public | BindingFlags.Static);
            List<string> keys = new List<string>();
            foreach (FieldInfo fieldInfo in fields)
            {
                HotKeySet.KeySet key = (HotKeySet.KeySet)fieldInfo.GetValue(null);
                if (key == HotKeySet.KeySet.None)
                    continue;

                keys.Add(ArrowKeyToSymbol(key));
            }
            return keys;
        }

        public static void GetComboBoxItemsFormHotKeySet(GunaComboBox gunaComboBox, string defaultKey)
        {
            gunaComboBox.DataSource = GetHotKeySetStrings();
            gunaComboBox.Text = defaultKey;
        }

        public static string ArrowKeyToSymbol(HotKeySet.KeySet key)
        {
            switch(key)
            {
                case HotKeySet.KeySet.Up: return "↑";
                case HotKeySet.KeySet.Down: return "↓";
                case HotKeySet.KeySet.Left: return "←";
                case HotKeySet.KeySet.Right: return "→";
                default: return key.ToString();
            }
        }

        public static HotKeySet.KeySet ArrowKeySymbolToHotKeySet(string key)
        {
            switch (key)
            {
                case "↑": return HotKeySet.KeySet.Up;
                case "↓": return HotKeySet.KeySet.Down;
                case "←": return HotKeySet.KeySet.Left;
                case "→": return HotKeySet.KeySet.Right;
                default: return HotKeySet.KeySet.None;
            }
        }
    }
}
