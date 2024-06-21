using ElsClockStrikes.Core;
using Guna.UI.WinForms;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace ElsClockStrikes.Forms
{
    public class FormsUtils
    {
        public static Timer getTimerByNamingPattern(string namePattern, ComponentCollection components)
        {
            Timer result = null;
            foreach (IComponent component in components)
            {
                if (component is Timer timer)
                {
                    int subStringIndex = namePattern.Length;
                    for (int i = 1; i < subStringIndex; i++)
                    {
                        if (timer.Tag.ToString().StartsWith(namePattern.Substring(0, subStringIndex - i)))
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
                        if (label.Name.StartsWith(namePattern.Substring(0, subStringIndex - i)))
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
                        if (textBox.Name.StartsWith(namePattern.Substring(0, subStringIndex - i)))
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
                    if (method.Name.Substring(3).StartsWith(namePattern.Substring(0, subStringIndex - i)))
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
    }
}
