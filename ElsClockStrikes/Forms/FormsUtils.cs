﻿using ElsClockStrikes.Core;
using Guna.UI.WinForms;
using System;
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
                        if(result != null)
                        {
                            break;
                        }
                    }
                }
            }
            return result;
        }

        public static System.Windows.Forms.Label getLabelByNamingPattern(Control parent, string namePattern)
        {
            System.Windows.Forms.Label result = null;
            foreach (Control control in parent.Controls)
            {
                if (control is System.Windows.Forms.Label label)
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
                if (control is System.Windows.Forms.Label && maxWidth < control.Width && control.Text != FormsConstant.copyrightTag)
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
            string[] keySet = {
                nameof(HotKeySet.KeySet.主鍵盤0),
                nameof(HotKeySet.KeySet.主鍵盤1),
                nameof(HotKeySet.KeySet.主鍵盤2),
                nameof(HotKeySet.KeySet.主鍵盤3),
                nameof(HotKeySet.KeySet.主鍵盤4),
                nameof(HotKeySet.KeySet.主鍵盤5),
                nameof(HotKeySet.KeySet.主鍵盤6),
                nameof(HotKeySet.KeySet.主鍵盤7),
                nameof(HotKeySet.KeySet.主鍵盤8),
                nameof(HotKeySet.KeySet.主鍵盤9),
                nameof(HotKeySet.KeySet.小鍵盤0),
                nameof(HotKeySet.KeySet.小鍵盤1),
                nameof(HotKeySet.KeySet.小鍵盤2),
                nameof(HotKeySet.KeySet.小鍵盤3),
                nameof(HotKeySet.KeySet.小鍵盤4),
                nameof(HotKeySet.KeySet.小鍵盤5),
                nameof(HotKeySet.KeySet.小鍵盤6),
                nameof(HotKeySet.KeySet.小鍵盤7),
                nameof(HotKeySet.KeySet.小鍵盤8),
                nameof(HotKeySet.KeySet.小鍵盤9)
            };

            foreach (string key in keySet)
            {
                if (key == comboBoxText)
                {
                    comboBoxText = comboBoxText.Replace("鍵盤", "");
                    break;
                }
            }

            return comboBoxText;
        }
    }
}
