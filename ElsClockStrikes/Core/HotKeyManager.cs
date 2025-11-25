using ElsClockStrikes.Core.Triggers;
using ElsClockStrikes.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ElsClockStrikes.Core
{
    public class HotKeyManager : BaseHotKeyManager
    {
        public HotKeyManager(Control parent, Type type) : base(type)
        {
            this.InitializeKeyMapWithTriggers(parent, type);
        }

        protected override List<IHotKeyTrigger> GetTriggerListByComboBoxSelect(Control parent, Type type)
        {
            List<IHotKeyTrigger> triggerList = new List<IHotKeyTrigger>();
            foreach (Control control in parent.Controls)
            {
                if (control is ComboBox comboBox && comboBox.SelectedItem != null)
                {
                    string selectKey = comboBox.SelectedItem.ToString();
                    HotKeyContainer hotKeyContainer = new HotKeyContainer();
                    hotKeyContainer.label = FormsUtils.getLabelByNamingPattern(parent, comboBox.Name);
                    hotKeyContainer.textBox = FormsUtils.getGunaLineTextBoxByNamingPattern(parent, comboBox.Name);
                    hotKeyContainer.timer = FormsUtils.getTimerByNamingPattern(parent.Parent.Parent, comboBox.Name);
                    hotKeyContainer.method = FormsUtils.getMethodInfoByNamingPattern(comboBox.Name);
                    hotKeyContainer.audioPlayer = FormsUtils.getAudioPlayerFieldByNamingPattern(type, parent.Parent.Parent, comboBox.Name);
                    hotKeyContainer.triggerKey = FormsUtils.TryParseHotKeySet(selectKey);
                    SingleKeyTrigger singleKeyTrigger = new SingleKeyTrigger(parent, hotKeyContainer);
                    triggerList.Add(singleKeyTrigger);
                }
            }
            return triggerList;
        }
    }
}
