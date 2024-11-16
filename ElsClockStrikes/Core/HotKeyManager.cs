using ElsClockStrikes.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ElsClockStrikes.Core
{
    public class HotKeyManager : BaseHotKeyManager
    {
        public HotKeyManager(Control parent, Type type) : base(parent, type)
        {
            this.InitializeKeyMapWithContainer(parent, type);
        }

        protected override Dictionary<string, List<HotKeyContainer>> GetKeyMapWithContainerByComboBoxSelect(Control parent, Type type)
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
