using ElsClockStrikes.Forms;
using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ElsClockStrikes.Core
{
    public class HotKeyManager : IDisposable
    {
        private IKeyboardMouseEvents globalHook;
        private Dictionary<string, List<HotKeyContainer>> keyMapWithContainer;

        public HotKeyManager(Control parent, Type type)
        {
            globalHook = Hook.GlobalEvents();
            globalHook.KeyDown += GlobalHookKeyDown;
            keyMapWithContainer = this.GetKeyMapWithContainerByComboBoxSelect(parent, type);
        }

        public Dictionary<string, List<HotKeyContainer>> GetKeyMapWithContainer()
        {
            return keyMapWithContainer;
        }

        public static Dictionary<string, int> GetEnumMapByComboBoxSelect(Dictionary<string, List<HotKeyContainer>> keyMapWithContainer)
        {
            Dictionary<string, int> enumMap = new Dictionary<string, int>();
            foreach (string item in keyMapWithContainer.Keys)
            {
                if (Enum.TryParse<HotKeySet.KeySet>(item, out var result))
                {
                    enumMap.Add(item, (int)result);
                }
            }
            return enumMap;
        }

        public void Dispose()
        {
            if (globalHook != null)
            {
                globalHook.KeyDown -= GlobalHookKeyDown;
                globalHook.Dispose();
                globalHook = null;

                Dictionary<string, int> enumMap = GetEnumMapByComboBoxSelect(keyMapWithContainer);
                foreach (KeyValuePair<string, int> kvp in enumMap)
                {
                    foreach (HotKeyContainer hotKeyContainer in keyMapWithContainer[kvp.Key])
                    {
                        if (hotKeyContainer.timer != null)
                        {
                            hotKeyContainer.timer.Stop();
                            hotKeyContainer.label.ForeColor = Color.FromArgb(245, 245, 245);
                        }
                        if (hotKeyContainer.audioPlayer != null)
                        {
                            hotKeyContainer.audioPlayer.Stop();
                        }
                    }
                }
            }
        }

        private void GlobalHookKeyDown(object sender, KeyEventArgs e)
        {
            Dictionary<string, int> enumMap = GetEnumMapByComboBoxSelect(keyMapWithContainer);
            foreach (KeyValuePair<string, int> kvp in enumMap)
            {
                if (kvp.Value.Equals(e.KeyValue))
                {
                    foreach (HotKeyContainer hotKeyContainer in keyMapWithContainer[kvp.Key])
                    {
                        if (hotKeyContainer.timer != null && hotKeyContainer.timer.Enabled)
                        {
                            hotKeyContainer.method.Invoke(null, new object[] { hotKeyContainer.textBox.Text });
                            hotKeyContainer.label.ForeColor = Color.FromArgb(245, 245, 245);
                            if (hotKeyContainer.audioPlayer != null)
                            {
                                hotKeyContainer.audioPlayer.Stop();
                            }
                        }
                        else if (hotKeyContainer.timer != null)
                        {
                            hotKeyContainer.timer.Start();
                            hotKeyContainer.label.ForeColor = Color.FromArgb(245, 245, 245);
                            if (hotKeyContainer.audioPlayer != null)
                            {
                                hotKeyContainer.audioPlayer.Stop();
                            }
                        }
                        else
                        {
                            foreach (KeyValuePair<string, int> nonResetkvp in enumMap)
                            {
                                if (!nonResetkvp.Key.Equals(kvp.Key))
                                {
                                    foreach (HotKeyContainer nonResetHotKeyContainer in keyMapWithContainer[nonResetkvp.Key])
                                    {
                                        nonResetHotKeyContainer.label.Text = nonResetHotKeyContainer.textBox.Text;
                                        nonResetHotKeyContainer.label.ForeColor = Color.FromArgb(245, 245, 245);
                                        nonResetHotKeyContainer.method.Invoke(null, new object[] { nonResetHotKeyContainer.textBox.Text });
                                        nonResetHotKeyContainer.timer.Stop();
                                        if (nonResetHotKeyContainer.audioPlayer != null)
                                        {
                                            nonResetHotKeyContainer.audioPlayer.Stop();
                                        }
                                    }
                                }
                                else
                                {
                                    foreach (HotKeyContainer resetHotKeyContainer in keyMapWithContainer[kvp.Key])
                                    {
                                        if (resetHotKeyContainer.actionMethod != null)
                                        {
                                            resetHotKeyContainer.actionMethod.Invoke(null, null);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private Dictionary<string, List<HotKeyContainer>> GetKeyMapWithContainerByComboBoxSelect(Control parent, Type type)
        {
            Dictionary<string, List<HotKeyContainer>> keyMapWithContainer = new Dictionary<string, List<HotKeyContainer>>();
            foreach (Control control in parent.Controls)
            {
                if (control is ComboBox comboBox && comboBox.SelectedItem != null)
                {
                    string selectKey = comboBox.SelectedItem.ToString();
                    if (keyMapWithContainer.ContainsKey(selectKey))
                    {
                        keyMapWithContainer.TryGetValue(selectKey, out List<HotKeyContainer> value);
                        HotKeyContainer hotKeyContainer = new HotKeyContainer();
                        hotKeyContainer.label = FormsUtils.getLabelByNamingPattern(parent, comboBox.Name);
                        hotKeyContainer.textBox = FormsUtils.getGunaLineTextBoxByNamingPattern(parent, comboBox.Name);
                        hotKeyContainer.timer = FormsUtils.getTimerByNamingPattern(parent.Parent.Parent, comboBox.Name);
                        hotKeyContainer.method = FormsUtils.getMethodInfoByNamingPattern(comboBox.Name);
                        hotKeyContainer.audioPlayer = FormsUtils.getAudioPlayerFieldByNamingPattern(type, parent.Parent.Parent, comboBox.Name);
                        value.Add(hotKeyContainer);
                    }
                    else
                    {
                        HotKeyContainer hotKeyContainer = new HotKeyContainer();
                        hotKeyContainer.label = FormsUtils.getLabelByNamingPattern(parent, comboBox.Name);
                        hotKeyContainer.textBox = FormsUtils.getGunaLineTextBoxByNamingPattern(parent, comboBox.Name);
                        hotKeyContainer.timer = FormsUtils.getTimerByNamingPattern(parent.Parent.Parent, comboBox.Name);
                        hotKeyContainer.method = FormsUtils.getMethodInfoByNamingPattern(comboBox.Name);
                        hotKeyContainer.audioPlayer = FormsUtils.getAudioPlayerFieldByNamingPattern(type, parent.Parent.Parent, comboBox.Name);
                        List<HotKeyContainer> hotKeyContainerList = new List<HotKeyContainer>();
                        keyMapWithContainer.Add(selectKey, hotKeyContainerList);
                        hotKeyContainerList.Add(hotKeyContainer);
                    }
                }
            }
            return keyMapWithContainer;
        }
    }
}
