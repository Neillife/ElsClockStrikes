using System;
using System.Collections.Generic;
using System.Linq;
using ElsClockStrikes.Forms;
using ElsClockStrikes.Core;
using System.Windows.Forms;
using Guna.UI.WinForms;
using ElsClockStrikes.Forms.FormCustomizeStrategy;

namespace ElsClockStrikes
{
    public partial class ElsClockStrikesForm
    {
        private string autoLoadStr = "autoLoad";
        private string topMostStr = "topMost";
        private string 小荊棘SoundStr = "小荊棘Sound";
        private string 雷射SoundStr = "雷射Sound";
        private string 荊棘延遲SoundStr = "荊棘延遲Sound";
        private string 控場SoundStr = "控場Sound";
        private string 大招SoundStr = "大招Sound";
        private string 大刺SoundStr = "大刺Sound";
        private string 翻桌SoundStr = "翻桌Sound";
        private string R1156控場SoundStr = "R1156控場Sound";
        private string 大黑SoundStr = "大黑Sound";
        private string 陰陽陣SoundStr = "陰陽陣Sound";
        private string 三連SoundStr = "三連Sound";
        private string R3156控場SoundStr = "R3156控場Sound";
        private string indexForCustomizeNameStr = "indexForCustomizeName";
        private string CustomizeMechanicLabelListStr = "CustomizeMechanicLabelList";
        private string CustomizeComboBoxListStr = "CustomizeComboBoxList";
        private string CustomizeTextBoxListStr = "CustomizeTextBoxList";
        private string CustomizeSoundListStr = "CustomizeSoundList";
        private string DefaultStr = "Default";
        private string mp3Str = ".mp3";
        private string wavStr = ".wav";
        private bool isLoadCustomizeConfig = false;

        private void ProcessAutoLoadConfig()
        {
            IniManager iniManager = new IniManager();
            bool result = iniManager.GetBoolValue(FormsConstant.configGlobalSectionName, autoLoadStr);
            if (result)
            {
                AutoLoadCheckBox.Checked = result;
                this.LoadSettingButton_Click(null, null);
            }
        }

        private void LoadSettingButton_Click(object sender, EventArgs e)
        {
            IniManager iniManager = new IniManager();
            TopMostCheckBox.Checked = iniManager.GetBoolValue(FormsConstant.configGlobalSectionName, topMostStr);
            this.LoadConfig127R3(iniManager);
            this.LoadConfig156R1(iniManager);
            this.LoadConfig156R3(iniManager);
            this.LoadConfigCustomize(iniManager);
        }

        private void LoadConfig127R3(IniManager iniManager)
        {
            bool radioResult = iniManager.GetBoolValue(FormsConstant.config127R3SectionName, 預設音效RadioButton.Name);
            if (radioResult) {
                預設音效RadioButton.Checked = radioResult;
            }
            radioResult = iniManager.GetBoolValue(FormsConstant.config127R3SectionName, 自訂音效RadioButton.Name);
            if (radioResult) {
                自訂音效RadioButton.Checked = radioResult;
            }
            radioResult = iniManager.GetBoolValue(FormsConstant.config127R3SectionName, 關閉音效RadioButton.Name);
            if (radioResult) {
                關閉音效RadioButton.Checked = radioResult;
            }

            小荊棘ComboBox.Text = iniManager.GetValue(FormsConstant.config127R3SectionName, 小荊棘ComboBox.Name, 小荊棘ComboBox.SelectedItem.ToString());
            小荊棘TextBox.Text = iniManager.GetIntValue(FormsConstant.config127R3SectionName, 小荊棘TextBox.Name).ToString();

            string soundFilePath = iniManager.GetValue(FormsConstant.config127R3SectionName, 小荊棘SoundStr, 小荊棘TimeupAudioPlayer?.filePath);
            if (soundFilePath.EndsWith(mp3Str) || soundFilePath.EndsWith(wavStr)) {
                小荊棘TimeupAudioPlayer = new AudioPlayer(soundFilePath); 
            }

            雷射ComboBox.Text = iniManager.GetValue(FormsConstant.config127R3SectionName, 雷射ComboBox.Name, 雷射ComboBox.SelectedItem.ToString());
            雷射TextBox.Text = iniManager.GetIntValue(FormsConstant.config127R3SectionName, 雷射TextBox.Name).ToString();
            
            soundFilePath = iniManager.GetValue(FormsConstant.config127R3SectionName, 雷射SoundStr, 雷射TimeupAudioPlayer?.filePath);
            if (soundFilePath.EndsWith(mp3Str) || soundFilePath.EndsWith(wavStr)) {
                雷射TimeupAudioPlayer = new AudioPlayer(soundFilePath);
            }

            荊棘延遲ComboBox.Text = iniManager.GetValue(FormsConstant.config127R3SectionName, 荊棘延遲ComboBox.Name, 荊棘延遲ComboBox.SelectedItem.ToString());
            荊棘延遲TextBox.Text = iniManager.GetIntValue(FormsConstant.config127R3SectionName, 荊棘延遲TextBox.Name).ToString();
            
            soundFilePath = iniManager.GetValue(FormsConstant.config127R3SectionName, 荊棘延遲SoundStr, 荊棘延遲TimeupAudioPlayer?.filePath);
            if (soundFilePath.EndsWith(mp3Str) || soundFilePath.EndsWith(wavStr)) {
                荊棘延遲TimeupAudioPlayer = new AudioPlayer(soundFilePath);
            }

            控場ComboBox.Text = iniManager.GetValue(FormsConstant.config127R3SectionName, 控場ComboBox.Name, 控場ComboBox.SelectedItem.ToString());
            控場TextBox.Text = iniManager.GetIntValue(FormsConstant.config127R3SectionName, 控場TextBox.Name).ToString();
            
            soundFilePath = iniManager.GetValue(FormsConstant.config127R3SectionName, 控場SoundStr, 控場TimeupAudioPlayer?.filePath);
            if (soundFilePath.EndsWith(mp3Str) || soundFilePath.EndsWith(wavStr)) {
                控場TimeupAudioPlayer = new AudioPlayer(soundFilePath);
            }

            重置計時器ComboBox.Text = iniManager.GetValue(FormsConstant.config127R3SectionName, 重置計時器ComboBox.Name, 重置計時器ComboBox.SelectedItem.ToString());
        }

        private void LoadConfig156R1(IniManager iniManager)
        {
            bool radioResult = iniManager.GetBoolValue(FormsConstant.config156R1SectionName, 預設音效156R1RadioButton.Name);
            if (radioResult) {
                預設音效156R1RadioButton.Checked = radioResult;
            }
            radioResult = iniManager.GetBoolValue(FormsConstant.config156R1SectionName, 自訂音效156R1RadioButton.Name);
            if (radioResult) {
                自訂音效156R1RadioButton.Checked = radioResult;
            }
            radioResult = iniManager.GetBoolValue(FormsConstant.config156R1SectionName, 關閉音效156R1RadioButton.Name);
            if (radioResult) {
                關閉音效156R1RadioButton.Checked = radioResult;
            }

            大招ComboBox.Text = iniManager.GetValue(FormsConstant.config156R1SectionName, 大招ComboBox.Name, 大招ComboBox.SelectedItem.ToString());
            大招TextBox.Text = iniManager.GetIntValue(FormsConstant.config156R1SectionName, 大招TextBox.Name).ToString();
            
            string soundFilePath = iniManager.GetValue(FormsConstant.config156R1SectionName, 大招SoundStr, 大招TimeupAudioPlayer?.filePath);
            if (soundFilePath.EndsWith(mp3Str) || soundFilePath.EndsWith(wavStr)) {
                大招TimeupAudioPlayer = new AudioPlayer(soundFilePath);
            }

            大刺ComboBox.Text = iniManager.GetValue(FormsConstant.config156R1SectionName, 大刺ComboBox.Name, 大刺ComboBox.SelectedItem.ToString());
            大刺TextBox.Text = iniManager.GetIntValue(FormsConstant.config156R1SectionName, 大刺TextBox.Name).ToString();
            
            soundFilePath = iniManager.GetValue(FormsConstant.config156R1SectionName, 大刺SoundStr, 大刺TimeupAudioPlayer?.filePath);
            if (soundFilePath.EndsWith(mp3Str) || soundFilePath.EndsWith(wavStr)) {
                大刺TimeupAudioPlayer = new AudioPlayer(soundFilePath);
            }

            翻桌ComboBox.Text = iniManager.GetValue(FormsConstant.config156R1SectionName, 翻桌ComboBox.Name, 翻桌ComboBox.SelectedItem.ToString());
            翻桌TextBox.Text = iniManager.GetIntValue(FormsConstant.config156R1SectionName, 翻桌TextBox.Name).ToString();
            
            soundFilePath = iniManager.GetValue(FormsConstant.config156R1SectionName, 翻桌SoundStr, 翻桌TimeupAudioPlayer?.filePath);
            if (soundFilePath.EndsWith(mp3Str) || soundFilePath.EndsWith(wavStr)) {
                翻桌TimeupAudioPlayer = new AudioPlayer(soundFilePath);
            }

            R1156控場ComboBox.Text = iniManager.GetValue(FormsConstant.config156R1SectionName, R1156控場ComboBox.Name, R1156控場ComboBox.SelectedItem.ToString());
            R1156控場TextBox.Text = iniManager.GetIntValue(FormsConstant.config156R1SectionName, R1156控場TextBox.Name).ToString();
            
            soundFilePath = iniManager.GetValue(FormsConstant.config156R1SectionName, R1156控場SoundStr, R1156控場TimeupAudioPlayer?.filePath);
            if (soundFilePath.EndsWith(mp3Str) || soundFilePath.EndsWith(wavStr)) {
                R1156控場TimeupAudioPlayer = new AudioPlayer(soundFilePath);
            }

            重置計時器156R1ComboBox.Text = iniManager.GetValue(FormsConstant.config156R1SectionName, 重置計時器156R1ComboBox.Name, 重置計時器156R1ComboBox.SelectedItem.ToString());
        }

        private void LoadConfig156R3(IniManager iniManager)
        {
            bool radioResult = iniManager.GetBoolValue(FormsConstant.config156R3SectionName, 預設音效156R3RadioButton.Name);
            if (radioResult) {
                預設音效156R3RadioButton.Checked = radioResult;
            }
            radioResult = iniManager.GetBoolValue(FormsConstant.config156R3SectionName, 自訂音效156R3RadioButton.Name);
            if (radioResult) {
                自訂音效156R3RadioButton.Checked = radioResult;
            }
            radioResult = iniManager.GetBoolValue(FormsConstant.config156R3SectionName, 關閉音效156R3RadioButton.Name);
            if (radioResult) {
                關閉音效156R3RadioButton.Checked = radioResult;
            }

            大黑ComboBox.Text = iniManager.GetValue(FormsConstant.config156R3SectionName, 大黑ComboBox.Name, 大黑ComboBox.SelectedItem.ToString());
            大黑TextBox.Text = iniManager.GetIntValue(FormsConstant.config156R3SectionName, 大黑TextBox.Name).ToString();
            
            string soundFilePath = iniManager.GetValue(FormsConstant.config156R3SectionName, 大黑SoundStr, 大黑TimeupAudioPlayer?.filePath);
            if (soundFilePath.EndsWith(mp3Str) || soundFilePath.EndsWith(wavStr)) {
                大黑TimeupAudioPlayer = new AudioPlayer(soundFilePath);
            }

            陰陽陣ComboBox.Text = iniManager.GetValue(FormsConstant.config156R3SectionName, 陰陽陣ComboBox.Name, 陰陽陣ComboBox.SelectedItem.ToString());
            陰陽陣TextBox.Text = iniManager.GetIntValue(FormsConstant.config156R3SectionName, 陰陽陣TextBox.Name).ToString();
            
            soundFilePath = iniManager.GetValue(FormsConstant.config156R3SectionName, 陰陽陣SoundStr, 陰陽陣TimeupAudioPlayer?.filePath);
            if (soundFilePath.EndsWith(mp3Str) || soundFilePath.EndsWith(wavStr)) {
                陰陽陣TimeupAudioPlayer = new AudioPlayer(soundFilePath);
            }

            三連ComboBox.Text = iniManager.GetValue(FormsConstant.config156R3SectionName, 三連ComboBox.Name, 三連ComboBox.SelectedItem.ToString());
            三連TextBox.Text = iniManager.GetIntValue(FormsConstant.config156R3SectionName, 三連TextBox.Name).ToString();
            
            soundFilePath = iniManager.GetValue(FormsConstant.config156R3SectionName, 三連SoundStr, 三連TimeupAudioPlayer?.filePath);
            if (soundFilePath.EndsWith(mp3Str) || soundFilePath.EndsWith(wavStr)) {
                三連TimeupAudioPlayer = new AudioPlayer(soundFilePath);
            }

            R3156控場ComboBox.Text = iniManager.GetValue(FormsConstant.config156R3SectionName, R3156控場ComboBox.Name, R3156控場ComboBox.SelectedItem.ToString());
            R3156控場TextBox.Text = iniManager.GetIntValue(FormsConstant.config156R3SectionName, R3156控場TextBox.Name).ToString();
            
            soundFilePath = iniManager.GetValue(FormsConstant.config156R3SectionName, R3156控場SoundStr, R3156控場TimeupAudioPlayer?.filePath);
            if (soundFilePath.EndsWith(mp3Str) || soundFilePath.EndsWith(wavStr)) {
                R3156控場TimeupAudioPlayer = new AudioPlayer(soundFilePath);
            }

            重置計時器156R3ComboBox.Text = iniManager.GetValue(FormsConstant.config156R3SectionName, 重置計時器156R3ComboBox.Name, 重置計時器156R3ComboBox.SelectedItem.ToString());
        }

        private void LoadConfigCustomize(IniManager iniManager)
        {
            重置計時器CustomizeComboBox.Text = iniManager.GetValue(FormsConstant.configCustomizeSectionName, 重置計時器CustomizeComboBox.Name, 重置計時器CustomizeComboBox.SelectedItem.ToString());
            bool radioResult = iniManager.GetBoolValue(FormsConstant.configCustomizeSectionName, 預設音效CustomizeRadioButton.Name);
            if (radioResult) {
                預設音效CustomizeRadioButton.Checked = radioResult;
            }
            radioResult = iniManager.GetBoolValue(FormsConstant.configCustomizeSectionName, 自訂音效CustomizeRadioButton.Name);
            if (radioResult) {
                自訂音效CustomizeRadioButton.Checked = radioResult;
            }
            radioResult = iniManager.GetBoolValue(FormsConstant.configCustomizeSectionName, 關閉音效CustomizeRadioButton.Name);
            if (radioResult) {
                關閉音效CustomizeRadioButton.Checked = radioResult;
            }

            isLoadCustomizeConfig = true;
        }

        private void TriggerLoadCustomizeConfig()
        {
            isLoadCustomizeConfig = false;

            FormsCustomizeUtils.ProcessLoadConfigRemoveComponent(this.TabPageCustomize);
            this.ProcessCompoenetBackOriginPos();
            FormsConstant.indexForCustomizeName = 0;
            this.customizeTaskTimerList.Clear();

            IniManager iniManager = new IniManager();

            int indexForCustomizeName = iniManager.GetIntValue(FormsConstant.configCustomizeSectionName, indexForCustomizeNameStr);
            if (indexForCustomizeName == 0)
            {
                return;
            }

            string[] mechanicLabels = iniManager.GetValue(FormsConstant.configCustomizeSectionName, CustomizeMechanicLabelListStr).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            string[] comboBoxs = iniManager.GetValue(FormsConstant.configCustomizeSectionName, CustomizeComboBoxListStr).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            string[] textBoxs = iniManager.GetValue(FormsConstant.configCustomizeSectionName, CustomizeTextBoxListStr).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < indexForCustomizeName; i++)
            {
                ControlStrategyParameters controlStrategyParameters = new ControlStrategyParameters
                {
                    tabPage = this.TabPageCustomize,
                    custSettingFormsInputData = mechanicLabels[i],
                    customizeTaskTimerList = this.customizeTaskTimerList
                };
                ControlStrategyManager controlStrategyManager = new ControlStrategyManager(controlStrategyParameters);
                controlStrategyManager.RegisterStrategy(new HotKeyLabelStrategy())
                                      .RegisterStrategy(new MechanicNameLabelStrategy())
                                      .RegisterStrategy(new TimeLeftLabelStrategy())
                                      .RegisterStrategy(new ComboBoxStrategy(comboBoxs[i]))
                                      .RegisterStrategy(new LineTextBoxStrategy(textBoxs[i]))
                                      .RegisterStrategy(new RemoveButtonStrategy())
                                      .RegisterStrategy(new CustomizeTaskTimerStrategy(關閉音效CustomizeRadioButton.Checked))
                                      .RegisterStrategy(new AudioPlayerButtonStrategy(自訂音效CustomizeRadioButton.Checked));
                controlStrategyManager.ExecuteAll();
            }

            string[] customizeSounds = iniManager.GetValue(FormsConstant.configCustomizeSectionName, CustomizeSoundListStr).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            if (customizeSounds.Length == 0)
            {
                foreach (CustomizeTaskTimer customizeTaskTimer in customizeTaskTimerList)
                {
                    customizeTaskTimer.setAudioPlayer(null);
                }
            }
            else
            {
                for (int i = 0; i < customizeSounds.Length; i++)
                {
                    if (customizeSounds[i] != DefaultStr && (customizeSounds[i].EndsWith(mp3Str) || customizeSounds[i].EndsWith(wavStr)))
                    {
                        this.customizeTaskTimerList[i].setAudioPlayer(new AudioPlayer(customizeSounds[i]));
                    }
                }
            }
        }

        private void SaveSettingButton_Click(object sender, EventArgs e)
        {
            IniManager iniManager = new IniManager();
            this.SaveConfig127R3(iniManager);
            this.SaveConfig156R1(iniManager);
            this.SaveConfig156R3(iniManager);
            this.SaveConfigCustomize(iniManager);
            iniManager.SetValue(FormsConstant.configGlobalSectionName, autoLoadStr, AutoLoadCheckBox.Checked.ToString());
            iniManager.SetValue(FormsConstant.configGlobalSectionName, topMostStr, TopMostCheckBox.Checked.ToString());
            iniManager.Save();
        }

        private void SaveConfig127R3(IniManager iniManager)
        {
            iniManager.SetValue(FormsConstant.config127R3SectionName, 小荊棘ComboBox.Name, 小荊棘ComboBox.SelectedItem.ToString());
            iniManager.SetValue(FormsConstant.config127R3SectionName, 小荊棘TextBox.Name, 小荊棘TextBox.Text);
            iniManager.SetValue(FormsConstant.config127R3SectionName, 小荊棘SoundStr, 小荊棘TimeupAudioPlayer?.filePath);

            iniManager.SetValue(FormsConstant.config127R3SectionName, 雷射ComboBox.Name, 雷射ComboBox.SelectedItem.ToString());
            iniManager.SetValue(FormsConstant.config127R3SectionName, 雷射TextBox.Name, 雷射TextBox.Text);
            iniManager.SetValue(FormsConstant.config127R3SectionName, 雷射SoundStr, 雷射TimeupAudioPlayer?.filePath);

            iniManager.SetValue(FormsConstant.config127R3SectionName, 荊棘延遲ComboBox.Name, 荊棘延遲ComboBox.SelectedItem.ToString());
            iniManager.SetValue(FormsConstant.config127R3SectionName, 荊棘延遲TextBox.Name, 荊棘延遲TextBox.Text);
            iniManager.SetValue(FormsConstant.config127R3SectionName, 荊棘延遲SoundStr, 荊棘延遲TimeupAudioPlayer?.filePath);

            iniManager.SetValue(FormsConstant.config127R3SectionName, 控場ComboBox.Name, 控場ComboBox.SelectedItem.ToString());
            iniManager.SetValue(FormsConstant.config127R3SectionName, 控場TextBox.Name, 控場TextBox.Text);
            iniManager.SetValue(FormsConstant.config127R3SectionName, 控場SoundStr, 控場TimeupAudioPlayer?.filePath);

            iniManager.SetValue(FormsConstant.config127R3SectionName, 重置計時器ComboBox.Name, 重置計時器ComboBox.SelectedItem.ToString());
            iniManager.SetValue(FormsConstant.config127R3SectionName, 預設音效RadioButton.Name, 預設音效RadioButton.Checked.ToString());
            iniManager.SetValue(FormsConstant.config127R3SectionName, 自訂音效RadioButton.Name, 自訂音效RadioButton.Checked.ToString());
            iniManager.SetValue(FormsConstant.config127R3SectionName, 關閉音效RadioButton.Name, 關閉音效RadioButton.Checked.ToString());
        }

        private void SaveConfig156R1(IniManager iniManager)
        {
            iniManager.SetValue(FormsConstant.config156R1SectionName, 大招ComboBox.Name, 大招ComboBox.SelectedItem.ToString());
            iniManager.SetValue(FormsConstant.config156R1SectionName, 大招TextBox.Name, 大招TextBox.Text);
            iniManager.SetValue(FormsConstant.config156R1SectionName, 大招SoundStr, 大招TimeupAudioPlayer?.filePath);

            iniManager.SetValue(FormsConstant.config156R1SectionName, 大刺ComboBox.Name, 大刺ComboBox.SelectedItem.ToString());
            iniManager.SetValue(FormsConstant.config156R1SectionName, 大刺TextBox.Name, 大刺TextBox.Text);
            iniManager.SetValue(FormsConstant.config156R1SectionName, 大刺SoundStr, 大刺TimeupAudioPlayer?.filePath);

            iniManager.SetValue(FormsConstant.config156R1SectionName, 翻桌ComboBox.Name, 翻桌ComboBox.SelectedItem.ToString());
            iniManager.SetValue(FormsConstant.config156R1SectionName, 翻桌TextBox.Name, 翻桌TextBox.Text);
            iniManager.SetValue(FormsConstant.config156R1SectionName, 翻桌SoundStr, 翻桌TimeupAudioPlayer?.filePath);

            iniManager.SetValue(FormsConstant.config156R1SectionName, R1156控場ComboBox.Name, R1156控場ComboBox.SelectedItem.ToString());
            iniManager.SetValue(FormsConstant.config156R1SectionName, R1156控場TextBox.Name, R1156控場TextBox.Text);
            iniManager.SetValue(FormsConstant.config156R1SectionName, R1156控場SoundStr, R1156控場TimeupAudioPlayer?.filePath);

            iniManager.SetValue(FormsConstant.config156R1SectionName, 重置計時器156R1ComboBox.Name, 重置計時器156R1ComboBox.SelectedItem.ToString());
            iniManager.SetValue(FormsConstant.config156R1SectionName, 預設音效156R1RadioButton.Name, 預設音效156R1RadioButton.Checked.ToString());
            iniManager.SetValue(FormsConstant.config156R1SectionName, 自訂音效156R1RadioButton.Name, 自訂音效156R1RadioButton.Checked.ToString());
            iniManager.SetValue(FormsConstant.config156R1SectionName, 關閉音效156R1RadioButton.Name, 關閉音效156R1RadioButton.Checked.ToString());
        }

        private void SaveConfig156R3(IniManager iniManager)
        {
            iniManager.SetValue(FormsConstant.config156R3SectionName, 大黑ComboBox.Name, 大黑ComboBox.SelectedItem.ToString());
            iniManager.SetValue(FormsConstant.config156R3SectionName, 大黑TextBox.Name, 大黑TextBox.Text);
            iniManager.SetValue(FormsConstant.config156R3SectionName, 大黑SoundStr, 大黑TimeupAudioPlayer?.filePath);

            iniManager.SetValue(FormsConstant.config156R3SectionName, 陰陽陣ComboBox.Name, 陰陽陣ComboBox.SelectedItem.ToString());
            iniManager.SetValue(FormsConstant.config156R3SectionName, 陰陽陣TextBox.Name, 陰陽陣TextBox.Text);
            iniManager.SetValue(FormsConstant.config156R3SectionName, 陰陽陣SoundStr, 陰陽陣TimeupAudioPlayer?.filePath);

            iniManager.SetValue(FormsConstant.config156R3SectionName, 三連ComboBox.Name, 三連ComboBox.SelectedItem.ToString());
            iniManager.SetValue(FormsConstant.config156R3SectionName, 三連TextBox.Name, 三連TextBox.Text);
            iniManager.SetValue(FormsConstant.config156R3SectionName, 三連SoundStr, 三連TimeupAudioPlayer?.filePath);

            iniManager.SetValue(FormsConstant.config156R3SectionName, R3156控場ComboBox.Name, R3156控場ComboBox.SelectedItem.ToString());
            iniManager.SetValue(FormsConstant.config156R3SectionName, R3156控場TextBox.Name, R3156控場TextBox.Text);
            iniManager.SetValue(FormsConstant.config156R3SectionName, R3156控場SoundStr, R3156控場TimeupAudioPlayer?.filePath);

            iniManager.SetValue(FormsConstant.config156R3SectionName, 重置計時器156R3ComboBox.Name, 重置計時器156R3ComboBox.SelectedItem.ToString());
            iniManager.SetValue(FormsConstant.config156R3SectionName, 預設音效156R3RadioButton.Name, 預設音效156R3RadioButton.Checked.ToString());
            iniManager.SetValue(FormsConstant.config156R3SectionName, 自訂音效156R3RadioButton.Name, 自訂音效156R3RadioButton.Checked.ToString());
            iniManager.SetValue(FormsConstant.config156R3SectionName, 關閉音效156R3RadioButton.Name, 關閉音效156R3RadioButton.Checked.ToString());
        }

        private void SaveConfigCustomize(IniManager iniManager)
        {
            iniManager.SetValue(FormsConstant.configCustomizeSectionName, 重置計時器CustomizeComboBox.Name, 重置計時器CustomizeComboBox.SelectedItem.ToString());
            iniManager.SetValue(FormsConstant.configCustomizeSectionName, 預設音效CustomizeRadioButton.Name, 預設音效CustomizeRadioButton.Checked.ToString());
            iniManager.SetValue(FormsConstant.configCustomizeSectionName, 自訂音效CustomizeRadioButton.Name, 自訂音效CustomizeRadioButton.Checked.ToString());
            iniManager.SetValue(FormsConstant.configCustomizeSectionName, 關閉音效CustomizeRadioButton.Name, 關閉音效CustomizeRadioButton.Checked.ToString());
            iniManager.SetValue(FormsConstant.configCustomizeSectionName, indexForCustomizeNameStr, FormsConstant.indexForCustomizeName.ToString());

            Dictionary<string, Label> mechanicLabelMap = FormsCustomizeUtils.GetTheSetControlMap<Label>(this.TabPageCustomize, FormsConstant.mechanicLabelBaseName);
            List<string> saveValue = new List<string>();
            foreach (Label mechanicLabel in mechanicLabelMap.Values)
            {
                saveValue.Add(mechanicLabel.Text.Substring(0, mechanicLabel.Text.Length - 1));
            }
            iniManager.SetValue(FormsConstant.configCustomizeSectionName, CustomizeMechanicLabelListStr, string.Join("|", saveValue.Cast<string>()));

            Dictionary<string, GunaComboBox> gunaComboBoxMap = FormsCustomizeUtils.GetTheSetControlMap<GunaComboBox>(this.TabPageCustomize, FormsConstant.comboBoxBaseName);
            saveValue.Clear();
            foreach (GunaComboBox gunaComboBox in gunaComboBoxMap.Values )
            {
                saveValue.Add(gunaComboBox.SelectedItem.ToString());
            }
            iniManager.SetValue(FormsConstant.configCustomizeSectionName, CustomizeComboBoxListStr, string.Join("|", saveValue.Cast<string>()));

            Dictionary<string, GunaLineTextBox> gunaLineTextBoxMap = FormsCustomizeUtils.GetTheSetControlMap<GunaLineTextBox>(this.TabPageCustomize, FormsConstant.textBoxBaseName);
            saveValue.Clear();
            foreach (GunaLineTextBox gunaLineTextBox in gunaLineTextBoxMap.Values)
            {
                saveValue.Add(gunaLineTextBox.Text);
            }
            iniManager.SetValue(FormsConstant.configCustomizeSectionName, CustomizeTextBoxListStr, string.Join("|", saveValue.Cast<string>()));

            if (關閉音效CustomizeRadioButton.Checked)
            {
                iniManager.SetValue(FormsConstant.configCustomizeSectionName, CustomizeSoundListStr, "");
            } else
            {
                saveValue.Clear();
                foreach (CustomizeTaskTimer customizeTaskTimer in customizeTaskTimerList)
                {
                    string data = customizeTaskTimer.getAudioPlayer().filePath;
                    if (data == null)
                    {
                        data = DefaultStr;
                    }
                    saveValue.Add(data);
                }
                iniManager.SetValue(FormsConstant.configCustomizeSectionName, CustomizeSoundListStr, string.Join("|", saveValue.Cast<string>()));
            }
        }
    }
}
