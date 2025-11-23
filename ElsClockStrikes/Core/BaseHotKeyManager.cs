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

        public static Dictionary<int, string> GetEnumMapByComboBoxSelect(Dictionary<string, List<HotKeyContainer>> keyMapWithContainer)
        {
            Dictionary<int, string> enumMap = new Dictionary<int, string>();
            foreach (string item in keyMapWithContainer.Keys)
            {
                if (Enum.TryParse<HotKeySet.KeySet>(item, out var result))
                {
                    enumMap.Add((int)result, item);
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

                Dictionary<int, string> enumMap = GetEnumMapByComboBoxSelect(keyMapWithContainer);
                foreach (KeyValuePair<int, string> kvp in enumMap)
                {
                    foreach (HotKeyContainer hotKeyContainer in keyMapWithContainer[kvp.Value])
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
            Dictionary<int, string> enumMap = GetEnumMapByComboBoxSelect(keyMapWithContainer);

            if (!enumMap.TryGetValue(e.KeyValue, out string inputKey))
                return;

            List<HotKeyContainer> hotKeyContainersList = keyMapWithContainer[inputKey];
            foreach (HotKeyContainer hotKeyContainer in  hotKeyContainersList)
            {
                if (hotKeyContainer.timer != null)
                {
                    if (hotKeyContainer.timer.Enabled)
                    {
                        hotKeyContainer.method.Invoke(hotKeyContainer.invokeObj, new object[] { hotKeyContainer.textBox.Text });
                    }
                    else
                    {
                        hotKeyContainer.timer.Start();
                    }

                    hotKeyContainer.label.ForeColor = Color.FromArgb(245, 245, 245);
                    hotKeyContainer.audioPlayer?.Stop();
                    hotKeyContainer.actionMethod?.Invoke(formsInstance.Parent.Parent, null);
                }
                else
                {
                    ResetOtherHotKeyGroups(inputKey);
                    InvokeHotKeyResetAction(hotKeyContainersList);
                }
            }
        }

        private void ResetOtherHotKeyGroups(string resetKey)
        {
            foreach (KeyValuePair<string, List<HotKeyContainer>> kvp in keyMapWithContainer)
            {
                if (kvp.Key == resetKey)
                    continue;

                foreach (HotKeyContainer hotKeyContainer in kvp.Value)
                {
                    hotKeyContainer.label.Text = hotKeyContainer.textBox.Text;
                    hotKeyContainer.label.ForeColor = Color.FromArgb(245, 245, 245);
                    hotKeyContainer.method.Invoke(hotKeyContainer.invokeObj, new object[] { hotKeyContainer.textBox.Text });
                    hotKeyContainer.timer?.Stop();
                    hotKeyContainer.audioPlayer?.Stop();
                }
            }
        }

        private void InvokeHotKeyResetAction(List<HotKeyContainer> hotKeyContainersList)
        {
            foreach (HotKeyContainer hotKeyContainer in hotKeyContainersList)
            {
                hotKeyContainer.actionMethod?.Invoke(null, null);
            }
        }

        protected abstract Dictionary<string, List<HotKeyContainer>> GetKeyMapWithContainerByComboBoxSelect(Control parent, Type type);
    }
}
