using ElsClockStrikes.Forms;
using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ElsClockStrikes.Core
{
    public abstract class BaseHotKeyManager : IDisposable
    {
        private IKeyboardMouseEvents globalHook;
        protected Dictionary<string, List<HotKeyContainer>> keyMapWithContainer;
        private Control formsInstance;

        protected BaseHotKeyManager(Control parent, Type type)
        {
            globalHook = Hook.GlobalEvents();
            globalHook.KeyDown += GlobalHookKeyDown;
            formsInstance = parent;
        }

        public void InitializeKeyMapWithContainer(Control parent, Type type)
        {
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
                            hotKeyContainer.method.Invoke(hotKeyContainer.invokeObj, new object[] { hotKeyContainer.textBox.Text });
                            hotKeyContainer.label.ForeColor = Color.FromArgb(245, 245, 245);
                            if (hotKeyContainer.audioPlayer != null)
                            {
                                hotKeyContainer.audioPlayer.Stop();
                            }
                            if (hotKeyContainer.actionMethod != null)
                            {
                                hotKeyContainer.actionMethod.Invoke(formsInstance.Parent.Parent, null);
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
                            if (hotKeyContainer.actionMethod != null)
                            {
                                hotKeyContainer.actionMethod.Invoke(formsInstance.Parent.Parent, null);
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
                                        nonResetHotKeyContainer.method.Invoke(nonResetHotKeyContainer.invokeObj, new object[] { nonResetHotKeyContainer.textBox.Text });
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

        protected abstract Dictionary<string, List<HotKeyContainer>> GetKeyMapWithContainerByComboBoxSelect(Control parent, Type type);
    }
}
