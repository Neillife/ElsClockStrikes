using ElsClockStrikes.Core.Triggers;
using ElsClockStrikes.Forms;
using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ElsClockStrikes.Core
{
    public class HotKeyManagerForCustomize : BaseHotKeyManager
    {
        private List<CustomizeTaskTimer> customizeTaskTimerList = new List<CustomizeTaskTimer>();
        private string resetHotKey;

        public HotKeyManagerForCustomize(Control parent, Type type, List<CustomizeTaskTimer> customizeTaskTimerList, string resetHotKey) : base(type)
        {
            this.customizeTaskTimerList = customizeTaskTimerList;
            this.resetHotKey = resetHotKey;
            this.InitializeKeyMapWithTriggers(parent, type);
        }

        protected override List<IHotKeyTrigger> GetTriggerListByComboBoxSelect(Control parent, Type type)
        {
            List<IHotKeyTrigger> triggerList = new List<IHotKeyTrigger>();
            Dictionary<string, GunaComboBox> gunaComboBoxMap = FormsCustomizeUtils.GetTheSetControlMap<GunaComboBox>((TabPage)parent, FormsConstant.comboBoxBaseName);
            Dictionary<string, Label> timeLeftLabelMap = FormsCustomizeUtils.GetTheSetControlMap<Label>((TabPage)parent, FormsConstant.timeLeftLabelBaseName);
            Dictionary<string, GunaLineTextBox> gunaLineTextBoxMap = FormsCustomizeUtils.GetTheSetControlMap<GunaLineTextBox>((TabPage)parent, FormsConstant.textBoxBaseName);
            Dictionary<string, CustomizeTaskTimer> customizeTaskTimerMap = FormsCustomizeUtils.getCustomizeTaskTimerMap(this.customizeTaskTimerList);

            triggerList.Add(
                new SingleKeyTrigger(
                    parent,
                    new HotKeyContainer()
                    {
                        triggerKey = FormsUtils.TryParseHotKeySet(resetHotKey)
                    }
                )
            );

            foreach (string index in gunaComboBoxMap.Keys)
            {
                string selectKey = gunaComboBoxMap[index].Text;
                HotKeyContainer hotKeyContainer = new HotKeyContainer();
                hotKeyContainer.label = timeLeftLabelMap[index];
                hotKeyContainer.textBox = gunaLineTextBoxMap[index];
                hotKeyContainer.timer = customizeTaskTimerMap[index];
                hotKeyContainer.invokeObj = customizeTaskTimerMap[index]; // Set the object for the timer invoke setCustomTimeLabel method.
                hotKeyContainer.method = customizeTaskTimerMap[index].GetType().GetMethod("setCustomTimeLabel");
                customizeTaskTimerMap[index].setCustomTimeLabel(gunaLineTextBoxMap[index].Text); // init timeleft
                hotKeyContainer.audioPlayer = customizeTaskTimerMap[index].getAudioPlayer();

                string[] selectKeys = FormsCustomizeUtils.GetSeqSplitStrs(selectKey);
                IHotKeyTrigger trigger = null;
                if (selectKeys.Length == 1)
                {
                    hotKeyContainer.triggerKey = FormsUtils.TryParseHotKeySet(selectKey);
                    trigger = new SingleKeyTrigger(parent, hotKeyContainer);
                }
                else
                {
                    hotKeyContainer.triggerKey = FormsUtils.TryParseHotKeySet(selectKeys[2]);
                    trigger = new SequenceKeyTrigger(
                        parent,
                        hotKeyContainer,
                        new List<HotKeySet.KeySet>()
                        {
                            FormsUtils.TryParseHotKeySet(selectKeys[0]),
                            FormsUtils.TryParseHotKeySet(selectKeys[1]),
                            FormsUtils.TryParseHotKeySet(selectKeys[2]),
                        }
                    );
                }

                triggerList.Add(trigger);
            }
            return triggerList;
        }
    }
}
