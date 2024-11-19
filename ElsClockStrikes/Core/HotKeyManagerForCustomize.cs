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

        public HotKeyManagerForCustomize(Control parent, Type type, List<CustomizeTaskTimer> customizeTaskTimerList, string resetHotKey) : base(parent, type)
        {
            this.customizeTaskTimerList = customizeTaskTimerList;
            this.resetHotKey = resetHotKey;
            this.InitializeKeyMapWithContainer(parent, type);
        }

        protected override Dictionary<string, List<HotKeyContainer>> GetKeyMapWithContainerByComboBoxSelect(Control parent, Type type)
        {
            Dictionary<string, List<HotKeyContainer>> keyMapWithContainer = new Dictionary<string, List<HotKeyContainer>>();
            Dictionary<string, GunaComboBox> gunaComboBoxMap = FormsCustomizeUtils.GetTheSetControlMap<GunaComboBox>((TabPage)parent, FormsConstant.comboBoxBaseName);
            Dictionary<string, Label> timeLeftLabelMap = FormsCustomizeUtils.GetTheSetControlMap<Label>((TabPage)parent, FormsConstant.timeLeftLabelBaseName);
            Dictionary<string, GunaLineTextBox> gunaLineTextBoxMap = FormsCustomizeUtils.GetTheSetControlMap<GunaLineTextBox>((TabPage)parent, FormsConstant.textBoxBaseName);
            Dictionary<string, CustomizeTaskTimer> customizeTaskTimerMap = FormsCustomizeUtils.getCustomizeTaskTimerMap(this.customizeTaskTimerList);

            List<HotKeyContainer> hotKeyContainerList = new List<HotKeyContainer>();
            keyMapWithContainer.Add(resetHotKey, hotKeyContainerList);
            hotKeyContainerList.Add(new HotKeyContainer());

            foreach (string index in gunaComboBoxMap.Keys)
            {
                string selectKey = gunaComboBoxMap[index].Text;
                if (keyMapWithContainer.ContainsKey(selectKey))
                {
                    keyMapWithContainer.TryGetValue(selectKey, out List<HotKeyContainer> value);
                    HotKeyContainer hotKeyContainer = new HotKeyContainer();
                    hotKeyContainer.label = timeLeftLabelMap[index];
                    hotKeyContainer.textBox = gunaLineTextBoxMap[index];
                    hotKeyContainer.timer = customizeTaskTimerMap[index];
                    hotKeyContainer.invokeObj = customizeTaskTimerMap[index]; // Set the object for the timer invoke setCustomTimeLabel method.
                    hotKeyContainer.method = customizeTaskTimerMap[index].GetType().GetMethod("setCustomTimeLabel");
                    customizeTaskTimerMap[index].setCustomTimeLabel(gunaLineTextBoxMap[index].Text); // init timeleft
                    hotKeyContainer.audioPlayer = customizeTaskTimerMap[index].getAudioPlayer();
                    value.Add(hotKeyContainer);
                }
                else
                {
                    HotKeyContainer hotKeyContainer = new HotKeyContainer();
                    hotKeyContainer.label = timeLeftLabelMap[index];
                    hotKeyContainer.textBox = gunaLineTextBoxMap[index];
                    hotKeyContainer.timer = customizeTaskTimerMap[index];
                    hotKeyContainer.invokeObj = customizeTaskTimerMap[index]; // Set the object for the timer invoke setCustomTimeLabel method.
                    hotKeyContainer.method = customizeTaskTimerMap[index].GetType().GetMethod("setCustomTimeLabel");
                    customizeTaskTimerMap[index].setCustomTimeLabel(gunaLineTextBoxMap[index].Text); // init timeleft
                    hotKeyContainer.audioPlayer = customizeTaskTimerMap[index].getAudioPlayer();
                    hotKeyContainerList = new List<HotKeyContainer>();
                    keyMapWithContainer.Add(selectKey, hotKeyContainerList);
                    hotKeyContainerList.Add(hotKeyContainer);
                }
            }
            return keyMapWithContainer;
        }
    }
}
