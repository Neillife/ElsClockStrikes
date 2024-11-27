using System.IO;
using IniParser.Model;
using IniParser;
using ElsClockStrikes.Forms;

namespace ElsClockStrikes.Core
{
    public class IniManager
    {
        private readonly string filePath;
        private readonly FileIniDataParser parser;
        private IniData iniData;

        public IniManager()
        {
            this.filePath = FormsConstant.configININame;
            parser = new FileIniDataParser();
            LoadIniFile();
        }

        private void LoadIniFile()
        {
            if (File.Exists(filePath))
            {
                iniData = parser.ReadFile(filePath);
            }
            else
            {
                iniData = new IniData();
                this.LoadDefault();
            }
        }

        public void LoadDefault()
        {
            this.SetValue(FormsConstant.config127R3SectionName, "小荊棘ComboBox", "F1");
            this.SetValue(FormsConstant.config127R3SectionName, "小荊棘TextBox", "160");
            this.SetValue(FormsConstant.config127R3SectionName, "小荊棘Sound", "");
            this.SetValue(FormsConstant.config127R3SectionName, "雷射ComboBox", "F2");
            this.SetValue(FormsConstant.config127R3SectionName, "雷射TextBox", "70");
            this.SetValue(FormsConstant.config127R3SectionName, "雷射Sound", "");
            this.SetValue(FormsConstant.config127R3SectionName, "荊棘延遲ComboBox", "F3");
            this.SetValue(FormsConstant.config127R3SectionName, "荊棘延遲TextBox", "30");
            this.SetValue(FormsConstant.config127R3SectionName, "荊棘延遲Sound", "");
            this.SetValue(FormsConstant.config127R3SectionName, "控場ComboBox", "F4");
            this.SetValue(FormsConstant.config127R3SectionName, "控場TextBox", "90");
            this.SetValue(FormsConstant.config127R3SectionName, "控場Sound", "");
            this.SetValue(FormsConstant.config127R3SectionName, "重置計時器ComboBox", "F5");
            this.SetValue(FormsConstant.config127R3SectionName, "預設音效RadioButton", "True");
            this.SetValue(FormsConstant.config127R3SectionName, "自訂音效RadioButton", "False");
            this.SetValue(FormsConstant.config127R3SectionName, "關閉音效RadioButton", "False");

            this.SetValue(FormsConstant.config156R1SectionName, "大招ComboBox", "F1");
            this.SetValue(FormsConstant.config156R1SectionName, "大招TextBox", "270");
            this.SetValue(FormsConstant.config156R1SectionName, "大招Sound", "");
            this.SetValue(FormsConstant.config156R1SectionName, "大刺ComboBox", "F2");
            this.SetValue(FormsConstant.config156R1SectionName, "大刺TextBox", "80");
            this.SetValue(FormsConstant.config156R1SectionName, "大刺Sound", "");
            this.SetValue(FormsConstant.config156R1SectionName, "翻桌ComboBox", "F3");
            this.SetValue(FormsConstant.config156R1SectionName, "翻桌TextBox", "115");
            this.SetValue(FormsConstant.config156R1SectionName, "翻桌Sound", "");
            this.SetValue(FormsConstant.config156R1SectionName, "R1156控場ComboBox", "F4");
            this.SetValue(FormsConstant.config156R1SectionName, "R1156控場TextBox", "90");
            this.SetValue(FormsConstant.config156R1SectionName, "R1156控場Sound", "");
            this.SetValue(FormsConstant.config156R1SectionName, "重置計時器156R1ComboBox", "F5");
            this.SetValue(FormsConstant.config156R1SectionName, "預設音效156R1RadioButton", "True");
            this.SetValue(FormsConstant.config156R1SectionName, "自訂音效156R1RadioButton", "False");
            this.SetValue(FormsConstant.config156R1SectionName, "關閉音效156R1RadioButton", "False");

            this.SetValue(FormsConstant.config156R3SectionName, "大黑ComboBox", "F1");
            this.SetValue(FormsConstant.config156R3SectionName, "大黑TextBox", "210");
            this.SetValue(FormsConstant.config156R3SectionName, "大黑Sound", "");
            this.SetValue(FormsConstant.config156R3SectionName, "陰陽陣ComboBox", "F2");
            this.SetValue(FormsConstant.config156R3SectionName, "陰陽陣TextBox", "240");
            this.SetValue(FormsConstant.config156R3SectionName, "陰陽陣Sound", "");
            this.SetValue(FormsConstant.config156R3SectionName, "三連ComboBox", "F3");
            this.SetValue(FormsConstant.config156R3SectionName, "三連TextBox", "140");
            this.SetValue(FormsConstant.config156R3SectionName, "三連Sound", "");
            this.SetValue(FormsConstant.config156R3SectionName, "R3156控場ComboBox", "F4");
            this.SetValue(FormsConstant.config156R3SectionName, "R3156控場TextBox", "90");
            this.SetValue(FormsConstant.config156R3SectionName, "R3156控場Sound", "");
            this.SetValue(FormsConstant.config156R3SectionName, "重置計時器156R3ComboBox", "F5");
            this.SetValue(FormsConstant.config156R3SectionName, "預設音效156R3RadioButton", "True");
            this.SetValue(FormsConstant.config156R3SectionName, "自訂音效156R3RadioButton", "False");
            this.SetValue(FormsConstant.config156R3SectionName, "關閉音效156R3RadioButton", "False");

            this.SetValue(FormsConstant.configCustomizeSectionName, "重置計時器CustomizeComboBox", "F5");
            this.SetValue(FormsConstant.configCustomizeSectionName, "預設音效CustomizeRadioButton", "True");
            this.SetValue(FormsConstant.configCustomizeSectionName, "自訂音效CustomizeRadioButton", "False");
            this.SetValue(FormsConstant.configCustomizeSectionName, "關閉音效CustomizeRadioButton", "False");
            this.SetValue(FormsConstant.configCustomizeSectionName, "indexForCustomizeName", "0");
            this.SetValue(FormsConstant.configCustomizeSectionName, "CustomizeMechanicLabelList", "");
            this.SetValue(FormsConstant.configCustomizeSectionName, "CustomizeComboBoxList", "");
            this.SetValue(FormsConstant.configCustomizeSectionName, "CustomizeTextBoxList", "");
            this.SetValue(FormsConstant.configCustomizeSectionName, "CustomizeSoundList", "");

            this.SetValue(FormsConstant.configGlobalSectionName, "autoLoad", "False");
            this.SetValue(FormsConstant.configGlobalSectionName, "topMost", "False");
            this.Save();
        }

        public string GetValue(string section, string key, string defaultValue = "")
        {
            return iniData[section]?.GetKeyData(key)?.Value ?? defaultValue;
        }

        public int GetIntValue(string section, string key, int defaultValue = 0)
        {
            string value = GetValue(section, key, defaultValue.ToString());
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            return defaultValue;
        }

        public bool GetBoolValue(string section, string key, bool defaultValue = false)
        {
            string value = GetValue(section, key, defaultValue.ToString());
            if (bool.TryParse(value, out bool result))
            {
                return result;
            }
            return defaultValue;
        }

        public void SetValue(string section, string key, string value)
        {
            if (!iniData.Sections.ContainsSection(section))
            {
                iniData.Sections.AddSection(section);
            }
            iniData[section][key] = value;
        }

        public void Save()
        {
            parser.WriteFile(filePath, iniData);
        }
    }
}
