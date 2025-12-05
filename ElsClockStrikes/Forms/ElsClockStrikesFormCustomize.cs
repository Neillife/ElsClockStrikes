using ElsClockStrikes.Core;
using ElsClockStrikes.Forms;
using ElsClockStrikes.Forms.FormCustomizeStrategy;
using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ElsClockStrikes
{
    public partial class ElsClockStrikesForm
    {
        public List<CustomizeTaskTimer> customizeTaskTimerList = new List<CustomizeTaskTimer>();
        private Dictionary<string, Point> customizeComponentOriginPosMap = new Dictionary<string, Point>();
        private Dictionary<string, Label> customizeLabelMap = new Dictionary<string, Label>();
        private HotKeyManagerForCustomize hotKeyManagerForCustomize;
        private Size CustomizeTabWinFormsSize;
        private Size CustomizeMetroTabControlVS1Size;
        private Size CustomizeWindowsSettingButtonOriginSize;
        private Point CustomizeTabCopyrightTagLabelPos;
        private Point CustomizeTopMostCheckBoxPos;
        private Dictionary<string, Point> customizeFormTimerInstancePos;

        private void TabPageCustomize_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (e.Control is GunaButton gunaButton)
            {
                if (FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(gunaButton.Name) == FormsConstant.buttonBaseName)
                {
                    FormsCustomizeUtils.ProcessComponentLayout(this.TabPageCustomize, gunaButton);
                    ShiftIndexKeys(gunaButton);
                    ProcessResetComponent(false);
                    if (this.Size.Height > WindowsOriginSize.Height)
                    {
                        ProcessWindowsSize(false);
                    }
                    if (metroTabControlVS1.Size.Height > metroTabControlVS1OriginSize.Height)
                    {
                        ProcessTabControlSize(false);
                    }
                    if (TopMostCheckBox.Location.Y > TopMostCheckBoxOriginPos.Y)
                    {
                        ProcessTopMostCheckBoxLocation(false);
                    }
                    if (重置計時器CustomizeComboBox.Location.Y >= FormsConstant.LayoutSign)
                    {
                        ProcessWindowsSettingCustomizeLocation(false);
                        ProcessAddCustomizeTimerLocation(false);
                        ProcessSoundSettingCustomizeGroupBox(false);
                    }
                    if (CopyrightTagLabel.Location.Y > CopyrightTagLabelOriginPos.Y)
                    {
                        ProcessCopyrightTagLabelLocation(false);
                    }
                }
            }
        }

        private void TabPageCustomize_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control is GunaLineTextBox)
            {
                ProcessResetComponent(true);
                if (重置計時器CustomizeComboBox.Location.Y > FormsConstant.LayoutSign)
                {
                    ProcessWindowsSize(true);
                    ProcessTabControlSize(true);
                    ProcessTopMostCheckBoxLocation(true);
                    ProcessWindowsSettingCustomizeLocation(true);
                    ProcessAddCustomizeTimerLocation(true);
                    ProcessSoundSettingCustomizeGroupBox(true);
                    ProcessCopyrightTagLabelLocation(true);
                }
            }
        }

        private void AddCustomizeTimer_Click(object sender, EventArgs e)
        {
            using (ElsClockStrikesFormCustomizeSetting elsClockStrikesFormCustomizeSetting = new ElsClockStrikesFormCustomizeSetting(this.TopMost))
            using (ElsClockStrikesFormSeqKeySetting elsClockStrikesFormSeqKeySetting = new ElsClockStrikesFormSeqKeySetting(this.TopMost))
            {
                while ((elsClockStrikesFormCustomizeSetting.DialogResult != DialogResult.Cancel && elsClockStrikesFormCustomizeSetting.DialogResult != DialogResult.OK) &&
                    (elsClockStrikesFormSeqKeySetting.DialogResult != DialogResult.Cancel && elsClockStrikesFormSeqKeySetting.DialogResult != DialogResult.OK))
                {
                    elsClockStrikesFormCustomizeSetting.ShowDialog();
                    if (elsClockStrikesFormCustomizeSetting.DialogResult == DialogResult.OK)
                    {
                        ProcessControlStrategy(elsClockStrikesFormCustomizeSetting.inputData);
                    }
                    else if (elsClockStrikesFormCustomizeSetting.DialogResult == DialogResult.Retry)
                    {
                        elsClockStrikesFormSeqKeySetting.ShowDialog();
                        if (elsClockStrikesFormSeqKeySetting.DialogResult == DialogResult.OK)
                        {
                            ProcessControlStrategy(elsClockStrikesFormSeqKeySetting.inputData, elsClockStrikesFormSeqKeySetting.sequenceData);
                        }
                    }
                }
            }
        }

        private void ProcessControlStrategy(string inputData, string sequenceData = "")
        {
            if (inputData != null && inputData.Trim() != "")
            {
                ControlStrategyParameters controlStrategyParameters = new ControlStrategyParameters
                {
                    tabPage = this.TabPageCustomize,
                    custSettingFormsInputData = inputData,
                    customizeTaskTimerList = this.customizeTaskTimerList
                };
                ControlStrategyManager controlStrategyManager = new ControlStrategyManager(controlStrategyParameters);
                if (sequenceData == "")
                {
                    controlStrategyManager.RegisterStrategy(new HotKeyLabelStrategy());
                }
                else
                {
                    controlStrategyManager.RegisterStrategy(new HotKeyLabelStrategy(true));
                }

                controlStrategyManager.RegisterStrategy(new MechanicNameLabelStrategy())
                                      .RegisterStrategy(new TimeLeftLabelStrategy());

                if (sequenceData == "")
                {
                    controlStrategyManager.RegisterStrategy(new ComboBoxStrategy("F1"));
                }
                else
                {
                    controlStrategyManager.RegisterStrategy(new SequenceComboBoxStrategy(sequenceData));
                }

                controlStrategyManager.RegisterStrategy(new LineTextBoxStrategy("10"))
                                      .RegisterStrategy(new RemoveButtonStrategy())
                                      .RegisterStrategy(new SettingButtonStrategy(Properties.Resources.setimg))
                                      .RegisterStrategy(new PanelStrategy())
                                      .RegisterStrategy(new AudioPlayerButtonStrategy(自訂音效CustomizeRadioButton.Checked))
                                      .RegisterStrategy(new SoundLabelStrategy())
                                      .RegisterStrategy(new SoundLineTextBoxStrategy("100"))
                                      .RegisterStrategy(new FormInstanceCheckBoxStrategy(false))
                                      .RegisterStrategy(new CustomizeTaskTimerStrategy(關閉音效CustomizeRadioButton.Checked));
                controlStrategyManager.ExecuteAll();
            }
        }

        private void ProcessCompoenetBackOriginPos()
        {
            this.CustomizeTabWinFormsSize = WindowsOriginSize;

            this.CustomizeTopMostCheckBoxPos = TopMostCheckBoxOriginPos;
            TopMostCheckBox.Location = CustomizeTopMostCheckBoxPos;

            WindowsSettingCustomize.Location = new Point(323, 382);
            AddCustomizeTimer.Location = new Point(213, 382);

            this.CustomizeMetroTabControlVS1Size = metroTabControlVS1OriginSize;

            音效設定CustomizeGroupBox.Location = new Point(115, 441);

            this.CustomizeTabCopyrightTagLabelPos = CopyrightTagLabelOriginPos;
            CopyrightTagLabel.Location = CustomizeTabCopyrightTagLabelPos;
        }

        private void ProcessSoundSettingCustomizeGroupBox(bool isAdd)
        {
            if (isAdd)
            {
                音效設定CustomizeGroupBox.Location = new Point(音效設定CustomizeGroupBox.Location.X, 音效設定CustomizeGroupBox.Location.Y + FormsConstant.FormSizeOffset);
            }
            else
            {
                音效設定CustomizeGroupBox.Location = new Point(音效設定CustomizeGroupBox.Location.X, 音效設定CustomizeGroupBox.Location.Y - FormsConstant.FormSizeOffset);
            }
        }

        private void ShiftIndexKeys(GunaButton gunaButton)
        {
            if (customizeFormTimerInstancePos == null)
            {
                return;
            }

            Dictionary<string, Point> newData = new Dictionary<string, Point>();
            foreach (KeyValuePair<string, Point> kvp in customizeFormTimerInstancePos)
            {
                int newKey = Int32.Parse(kvp.Key) - 1;
                if (newKey > 0)
                    newData[newKey.ToString()] = kvp.Value;
            }
            customizeFormTimerInstancePos = newData;

            List<GunaCheckBox> cbList = FormsCustomizeUtils.GetFormInstanceCheckBoxByTabPage(this.TabPageCustomize);
            foreach (GunaCheckBox formInstanceCheckBox in cbList)
            {
                if (formInstanceCheckBox.Checked && FormsCustomizeUtils.GetIndexOfString(formInstanceCheckBox.Name) == FormsCustomizeUtils.GetIndexOfString(gunaButton.Name))
                {
                    int newKey = Int32.Parse(FormsCustomizeUtils.GetIndexOfString(formInstanceCheckBox.Name)) - 1;
                    if (newKey > 0)
                        customizeFormTimerInstancePos.Remove(newKey.ToString());
                }
            }
        }

        private void ProcessResetComponent(bool idAdd)
        {
            if (idAdd)
            {
                重置計時器CustomizeLabel.Location = new Point(重置計時器CustomizeLabel.Location.X, 重置計時器CustomizeLabel.Location.Y + FormsConstant.ControlLayoutOffset);
                重置計時器Customize按鍵Label.Location = new Point(重置計時器Customize按鍵Label.Location.X, 重置計時器Customize按鍵Label.Location.Y + FormsConstant.ControlLayoutOffset);
                重置計時器CustomizeComboBox.Location = new Point(重置計時器CustomizeComboBox.Location.X, 重置計時器CustomizeComboBox.Location.Y + FormsConstant.ControlLayoutOffset);
            }
            else
            {
                重置計時器CustomizeLabel.Location = new Point(重置計時器CustomizeLabel.Location.X, 重置計時器CustomizeLabel.Location.Y - FormsConstant.ControlLayoutOffset);
                重置計時器Customize按鍵Label.Location = new Point(重置計時器Customize按鍵Label.Location.X, 重置計時器Customize按鍵Label.Location.Y - FormsConstant.ControlLayoutOffset);
                重置計時器CustomizeComboBox.Location = new Point(重置計時器CustomizeComboBox.Location.X, 重置計時器CustomizeComboBox.Location.Y - FormsConstant.ControlLayoutOffset);
            }
        }

        private void ProcessWindowsSize(bool isAdd)
        {
            if (isAdd)
            {
                this.CustomizeTabWinFormsSize = new Size(550, this.Size.Height + FormsConstant.FormSizeOffset);
                this.Size = CustomizeTabWinFormsSize;
            }
            else
            {
                int CustomizeTabWinFormsSizeHeight = this.Size.Height - FormsConstant.FormSizeOffset;
                if (CustomizeTabWinFormsSizeHeight < WindowsOriginSize.Height)
                {
                    CustomizeTabWinFormsSizeHeight = WindowsOriginSize.Height;
                }
                this.CustomizeTabWinFormsSize = new Size(550, CustomizeTabWinFormsSizeHeight);
                this.Size = CustomizeTabWinFormsSize;
            }
        }

        private void ProcessTabControlSize(bool isAdd)
        {
            if (isAdd)
            {
                this.CustomizeMetroTabControlVS1Size = new Size(this.metroTabControlVS1.Width, this.metroTabControlVS1.Height + FormsConstant.FormSizeOffset);
                this.metroTabControlVS1.Size = CustomizeMetroTabControlVS1Size;
            }
            else
            {
                this.CustomizeMetroTabControlVS1Size = new Size(this.metroTabControlVS1.Width, this.metroTabControlVS1.Height - FormsConstant.FormSizeOffset);
                this.metroTabControlVS1.Size = CustomizeMetroTabControlVS1Size;
            }
        }

        private void ProcessTopMostCheckBoxLocation(bool isAdd)
        {
            if (isAdd)
            {
                this.CustomizeTopMostCheckBoxPos = new Point(TopMostCheckBox.Location.X, TopMostCheckBox.Location.Y + FormsConstant.FormSizeOffset);
                TopMostCheckBox.Location = CustomizeTopMostCheckBoxPos;
            }
            else
            {
                this.CustomizeTopMostCheckBoxPos = new Point(TopMostCheckBox.Location.X, TopMostCheckBox.Location.Y - FormsConstant.FormSizeOffset);
                TopMostCheckBox.Location = CustomizeTopMostCheckBoxPos;
            }
        }

        private void ProcessWindowsSettingCustomizeLocation(bool isAdd)
        {
            if (isAdd)
            {
                WindowsSettingCustomize.Location = new Point(WindowsSettingCustomize.Location.X, WindowsSettingCustomize.Location.Y + FormsConstant.FormSizeOffset);
            }
            else
            {
                WindowsSettingCustomize.Location = new Point(WindowsSettingCustomize.Location.X, WindowsSettingCustomize.Location.Y - FormsConstant.FormSizeOffset);
            }
        }

        private void ProcessAddCustomizeTimerLocation(bool isAdd)
        {
            if (isAdd)
            {
                AddCustomizeTimer.Location = new Point(AddCustomizeTimer.Location.X, AddCustomizeTimer.Location.Y + FormsConstant.FormSizeOffset);
            }
            else
            {
                AddCustomizeTimer.Location = new Point(AddCustomizeTimer.Location.X, AddCustomizeTimer.Location.Y - FormsConstant.FormSizeOffset);
            }
        }

        private void ProcessCopyrightTagLabelLocation(bool isAdd)
        {
            if (isAdd)
            {
                this.CustomizeTabCopyrightTagLabelPos = new Point(CopyrightTagLabel.Location.X, CopyrightTagLabel.Location.Y + FormsConstant.FormSizeOffset);
                CopyrightTagLabel.Location = CustomizeTabCopyrightTagLabelPos;
            }
            else
            {
                this.CustomizeTabCopyrightTagLabelPos = new Point(CopyrightTagLabel.Location.X, CopyrightTagLabel.Location.Y - FormsConstant.FormSizeOffset);
                CopyrightTagLabel.Location = CustomizeTabCopyrightTagLabelPos;
            }
        }

        private void ProcessRegisterHotKeyCustomize(bool isBackToOriginCheck)
        {
            if (isBackToOriginCheck)
            {
                hotKeyManagerForCustomize.Dispose();
            }
            else
            {
                hotKeyManagerForCustomize = new HotKeyManagerForCustomize(this.TabPageCustomize, typeof(ElsClockStrikesForm), customizeTaskTimerList, 重置計時器CustomizeComboBox.SelectedItem.ToString());
            }
        }

        private void ProcessFormInstanceCustomize(bool isBackToOriginCheck)
        {
            if (isBackToOriginCheck)
            {
                if (customizeFormTimerInstancePos == null)
                {
                    customizeFormTimerInstancePos = new Dictionary<string, Point>();
                }
                foreach (ElsClockStrikesFormTimerInstance timerInstance in formTimerInstances)
                {
                    customizeFormTimerInstancePos[FormsCustomizeUtils.GetIndexOfString(timerInstance.GetMechanicName())] = timerInstance.Location;
                    timerInstance.ProcessFormClose();
                    timerInstance.Close();
                    this.Controls.Remove(timerInstance.GetHotKeyLabel());
                    this.TabPageCustomize.Controls.Add(timerInstance.GetHotKeyLabel());
                    timerInstance.GetHotKeyLabel().Visible = false;
                    this.Controls.Remove(timerInstance.GetMechanicLabel());
                    this.TabPageCustomize.Controls.Add(timerInstance.GetMechanicLabel());
                    this.Controls.Remove(timerInstance.GetTimeLeftLabel());
                    this.TabPageCustomize.Controls.Add(timerInstance.GetTimeLeftLabel());
                    timerInstance.GetTimeLeftLabel().Visible = false;
                }
            }
            else
            {
                int MaxLabelWidth = FormsUtils.GetLabelMaxWidth(this);
                Dictionary<string, FormInstanceParameters> nonInstanceMap = new Dictionary<string, FormInstanceParameters>();
                List<GunaCheckBox> cbList = FormsCustomizeUtils.GetFormInstanceCheckBoxByTabPage(this.TabPageCustomize);
                Dictionary<string, FormInstanceParameters> fipMap = FormsCustomizeUtils.GetCustomFIPMapByTabPage(this);
                formTimerInstances = new List<ElsClockStrikesFormTimerInstance>();
                foreach (GunaCheckBox checkBox in cbList)
                {
                    string fipMapKey = FormsCustomizeUtils.GetIndexOfString(checkBox.Name);
                    if (checkBox.Checked)
                    {
                        if (customizeFormTimerInstancePos != null && customizeFormTimerInstancePos.ContainsKey(fipMapKey))
                        {
                            formTimerInstances.Add(new ElsClockStrikesFormTimerInstance(fipMap[fipMapKey], WindowsSettingCustomize, MaxLabelWidth, this.TopMost, customizeFormTimerInstancePos[fipMapKey]));
                        }
                        else
                        {
                            formTimerInstances.Add(new ElsClockStrikesFormTimerInstance(fipMap[fipMapKey], WindowsSettingCustomize, MaxLabelWidth, this.TopMost));
                        }
                    }
                    else
                    {
                        nonInstanceMap.Add(fipMapKey, fipMap[fipMapKey]);
                    }
                }

                foreach (ElsClockStrikesFormTimerInstance timerInstance in formTimerInstances)
                {
                    timerInstance.Show();
                }
            }
        }

        private void ProcessWindowsSettingCustomize(bool isBackToOriginCheck)
        {
            FormsCustomizeUtils.ProcessSettingText(this.TabPageCustomize);
            重置計時器Customize按鍵Label.Text = FormsUtils.ProcessLayoutString(重置計時器CustomizeComboBox.Text);

            重置計時器Customize按鍵Label.Visible = !重置計時器Customize按鍵Label.Visible;
            FormsCustomizeUtils.ProcessVisible(this.TabPageCustomize, isBackToOriginCheck);
            ZoomOutControlBox.Visible = !ZoomOutControlBox.Visible;
            CloseControlBox.Visible = !CloseControlBox.Visible;
            metroTabControlVS1.Visible = !metroTabControlVS1.Visible;

            this.SetCustomizeComponentOriginPosMap(isBackToOriginCheck);
            FormsCustomizeUtils.ProcessComponentDisplaySettings(this.TabPageCustomize, isBackToOriginCheck);
            if (isBackToOriginCheck)
            {
                this.Controls.Remove(重置計時器Customize按鍵Label);
                this.Controls.Remove(重置計時器CustomizeLabel);
                this.Controls.Remove(WindowsSettingCustomize);
                TabPageCustomize.Controls.Add(重置計時器Customize按鍵Label);
                TabPageCustomize.Controls.Add(重置計時器CustomizeLabel);
                TabPageCustomize.Controls.Add(WindowsSettingCustomize);
            }
            else
            {
                TabPageCustomize.Controls.Remove(重置計時器Customize按鍵Label);
                TabPageCustomize.Controls.Remove(重置計時器CustomizeLabel);
                TabPageCustomize.Controls.Remove(WindowsSettingCustomize);
                this.Controls.Add(重置計時器Customize按鍵Label);
                this.Controls.Add(重置計時器CustomizeLabel);
                this.Controls.Add(WindowsSettingCustomize);
            }

            TopMostCheckBox.Visible = !TopMostCheckBox.Visible;
            this.ProcessFormInstanceCustomize(isBackToOriginCheck);
            this.ProcessComponentLocation(isBackToOriginCheck);
        }

        private void SetCustomizeComponentOriginPosMap(bool isBackToOriginCheck)
        {
            if (isBackToOriginCheck)
            {
                return;
            }
            foreach (Control control in this.TabPageCustomize.Controls)
            {
                if (control is Label label &&
                    (FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(label.Name) == FormsConstant.timeLeftLabelBaseName ||
                    FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(label.Name) == FormsConstant.hotKeyLabelBaseName ||
                    FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(label.Name) == FormsConstant.mechanicLabelBaseName))
                {
                    customizeLabelMap.Add(label.Name, label);
                    customizeComponentOriginPosMap.Add(label.Name, label.Location);
                }
            }
            customizeComponentOriginPosMap.Add(重置計時器Customize按鍵Label.Name, 重置計時器Customize按鍵Label.Location);
            customizeComponentOriginPosMap.Add(重置計時器CustomizeLabel.Name, 重置計時器CustomizeLabel.Location);
            customizeComponentOriginPosMap.Add(重置計時器CustomizeComboBox.Name, 重置計時器CustomizeComboBox.Location);
            customizeComponentOriginPosMap.Add(WindowsSettingCustomize.Name, WindowsSettingCustomize.Location);
        }

        private void ProcessComponentLocation(bool isBackToOriginCheck)
        {
            if (isBackToOriginCheck)
            {
                foreach (Control control in this.TabPageCustomize.Controls)
                {
                    if (control is Label label &&
                        (FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(label.Name) == FormsConstant.timeLeftLabelBaseName ||
                        FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(label.Name) == FormsConstant.hotKeyLabelBaseName ||
                        FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(label.Name) == FormsConstant.mechanicLabelBaseName))
                    {
                        label.Location = customizeComponentOriginPosMap[label.Name];
                    }
                }

                this.Size = CustomizeTabWinFormsSize;
                重置計時器Customize按鍵Label.Location = customizeComponentOriginPosMap[重置計時器Customize按鍵Label.Name];
                重置計時器CustomizeLabel.Location = customizeComponentOriginPosMap[重置計時器CustomizeLabel.Name];
                重置計時器CustomizeComboBox.Location = customizeComponentOriginPosMap[重置計時器CustomizeComboBox.Name];
                WindowsSettingCustomize.Location = customizeComponentOriginPosMap[WindowsSettingCustomize.Name];
                customizeComponentOriginPosMap.Clear();
                customizeLabelMap.Clear();
            }
            else
            {
                int MaxLabelWidth = FormsUtils.GetLabelMaxWidth(this);
                int KeyLabelAddY = 40;
                Label firstCustLabel = null;
                Label labelSign = null;
                bool isSeqKey = false;

                foreach (Control control in this.Controls)
                {
                    if (control is Label firstLabel && labelSign == null &&
                        FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(firstLabel.Name) == FormsConstant.hotKeyLabelBaseName)
                    {
                        labelSign = firstLabel;
                        isSeqKey = (firstLabel.Tag as bool?) ?? false;
                        labelSign.Location = new Point(5, isSeqKey && customizeLabelMap.Count / 3 - formTimerInstances.Count > 1 ? 40 : 30);
                        continue;
                    }
                    if (control is Label timeLeftLabel && FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(timeLeftLabel.Name) == FormsConstant.timeLeftLabelBaseName)
                    {
                        isSeqKey = (customizeLabelMap[$"{FormsConstant.hotKeyLabelBaseName}{FormsCustomizeUtils.GetIndexOfString(timeLeftLabel.Name)}"].Tag as bool?) ?? false;
                        customizeLabelMap[timeLeftLabel.Name].Location = new Point(
                            customizeLabelMap[$"{FormsConstant.mechanicLabelBaseName}{FormsCustomizeUtils.GetIndexOfString(timeLeftLabel.Name)}"].Left +
                            customizeLabelMap[$"{FormsConstant.mechanicLabelBaseName}{FormsCustomizeUtils.GetIndexOfString(timeLeftLabel.Name)}"].Width,
                            isSeqKey ?
                            customizeLabelMap[$"{FormsConstant.hotKeyLabelBaseName}{FormsCustomizeUtils.GetIndexOfString(timeLeftLabel.Name)}"].Location.Y - 9:
                            customizeLabelMap[$"{FormsConstant.hotKeyLabelBaseName}{FormsCustomizeUtils.GetIndexOfString(timeLeftLabel.Name)}"].Location.Y
                            );
                    }
                    else if (control is Label hotKeyLable && FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(hotKeyLable.Name) == FormsConstant.hotKeyLabelBaseName)
                    {
                        isSeqKey = (labelSign.Tag as bool?) ?? false;
                        customizeLabelMap[hotKeyLable.Name].Location = new Point(labelSign.Location.X,
                            isSeqKey ? labelSign.Location.Y + 30 : labelSign.Location.Y + KeyLabelAddY);
                        labelSign = hotKeyLable;
                    }
                    else if (control is Label label && FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(label.Name) == FormsConstant.mechanicLabelBaseName)
                    {
                        int mechanicLabelBaseNamePointX;
                        int mechanicLabelBaseNamePointY;
                        isSeqKey = (customizeLabelMap[$"{FormsConstant.hotKeyLabelBaseName}{FormsCustomizeUtils.GetIndexOfString(label.Name)}"].Tag as bool?) ?? false;
                        if (firstCustLabel == null)
                        {
                            if (isSeqKey)
                            {
                                mechanicLabelBaseNamePointX = MaxLabelWidth - label.Width + customizeLabelMap[$"{FormsConstant.hotKeyLabelBaseName}{FormsCustomizeUtils.GetIndexOfString(label.Name)}"].Width - 28;
                                mechanicLabelBaseNamePointY = customizeLabelMap[$"{FormsConstant.hotKeyLabelBaseName}{FormsCustomizeUtils.GetIndexOfString(label.Name)}"].Top +
                                    customizeLabelMap[$"{FormsConstant.hotKeyLabelBaseName}{FormsCustomizeUtils.GetIndexOfString(label.Name)}"].Height -
                                    label.Height + 4;
                            }
                            else
                            {
                                mechanicLabelBaseNamePointX = MaxLabelWidth - label.Width + customizeLabelMap[$"{FormsConstant.hotKeyLabelBaseName}{FormsCustomizeUtils.GetIndexOfString(label.Name)}"].Width - 5;
                                mechanicLabelBaseNamePointY = customizeLabelMap[$"{FormsConstant.hotKeyLabelBaseName}{FormsCustomizeUtils.GetIndexOfString(label.Name)}"].Top + 
                                    customizeLabelMap[$"{FormsConstant.hotKeyLabelBaseName}{FormsCustomizeUtils.GetIndexOfString(label.Name)}"].Height - 
                                    label.Height - 3;
                            }
                            firstCustLabel = label;
                            customizeLabelMap[label.Name].Location = new Point(mechanicLabelBaseNamePointX, mechanicLabelBaseNamePointY);
                        }
                        else
                        {
                            mechanicLabelBaseNamePointX = firstCustLabel.Left + firstCustLabel.Width - label.Width;
                            if (isSeqKey)
                            {
                                mechanicLabelBaseNamePointY = customizeLabelMap[$"{FormsConstant.hotKeyLabelBaseName}{FormsCustomizeUtils.GetIndexOfString(label.Name)}"].Top +
                                    customizeLabelMap[$"{FormsConstant.hotKeyLabelBaseName}{FormsCustomizeUtils.GetIndexOfString(label.Name)}"].Height -
                                    label.Height + 4;
                            }
                            else
                            {
                                mechanicLabelBaseNamePointY = customizeLabelMap[$"{FormsConstant.hotKeyLabelBaseName}{FormsCustomizeUtils.GetIndexOfString(label.Name)}"].Top +
                                    customizeLabelMap[$"{FormsConstant.hotKeyLabelBaseName}{FormsCustomizeUtils.GetIndexOfString(label.Name)}"].Height -
                                    label.Height - 3;
                            }
                            customizeLabelMap[label.Name].Location = new Point(mechanicLabelBaseNamePointX, mechanicLabelBaseNamePointY);
                        }
                    }
                }
                重置計時器Customize按鍵Label.Location = labelSign == null ? new Point(5, 30) : new Point(labelSign.Location.X, labelSign.Location.Y + KeyLabelAddY);
                重置計時器CustomizeLabel.Location = firstCustLabel == null ? new Point(58, 37) : new Point(firstCustLabel.Left + firstCustLabel.Width - 重置計時器CustomizeLabel.Width + 27, 重置計時器Customize按鍵Label.Top + 重置計時器Customize按鍵Label.Height - 重置計時器CustomizeLabel.Height - 3);
                WindowsSettingCustomize.Location = new Point(130, 5);

                isSeqKey = (labelSign?.Tag as bool?) ?? false;
                if (labelSign != null && isSeqKey)
                {
                    Label hotKeyLabel = customizeLabelMap[$"{FormsConstant.hotKeyLabelBaseName}{FormsCustomizeUtils.GetIndexOfString(labelSign.Name)}"];
                    Label mechanicLabel = customizeLabelMap[$"{FormsConstant.mechanicLabelBaseName}{FormsCustomizeUtils.GetIndexOfString(labelSign.Name)}"];
                    Label timeLeftLabel = customizeLabelMap[$"{FormsConstant.timeLeftLabelBaseName}{FormsCustomizeUtils.GetIndexOfString(labelSign.Name)}"];
                    hotKeyLabel.Location = new Point(hotKeyLabel.Location.X, hotKeyLabel.Location.Y + 10);
                    mechanicLabel.Location = new Point(mechanicLabel.Location.X, mechanicLabel.Location.Y + 10);
                    timeLeftLabel.Location = new Point(timeLeftLabel.Location.X, timeLeftLabel.Location.Y + 10);
                }

                int custSizeHeight = 225;
                if (customizeLabelMap.Count / 3 < 4)
                {
                    custSizeHeight = customizeLabelMap.Count / 3 * 39 + 69;
                }
                else
                {
                    custSizeHeight += (customizeLabelMap.Count / 3 - 4) * 40;
                }

                int finalSizeHeight = 重置計時器CustomizeLabel.Top + 重置計時器CustomizeLabel.Height + 8;

                if (finalSizeHeight < custSizeHeight - formTimerInstances.Count * 39)
                {
                    custSizeHeight = finalSizeHeight;
                }
                else
                {
                    custSizeHeight -= formTimerInstances.Count * 39;
                }
                this.Size = new Size(180, custSizeHeight);
            }
        }

        private void WindowsSettingCustomize_Click(object sender, EventArgs e)
        {
            if (!customizeTaskTimerList.Any())
            {
                return;
            }

            if (WindowsSettingCustomize.Text.Equals("設定完成"))
            {
                WindowsSettingCustomize.BaseColor = Color.FromArgb(40, 40, 40);
                WindowsSettingCustomize.OnHoverBaseColor = Color.FromArgb(120, 120, 120);
                WindowsSettingCustomize.Text = "";
                WindowsSettingCustomize.Image = Properties.Resources.setimg;
                WindowsSettingCustomize.Size = new Size(43, 25);
                this.ProcessRegisterHotKeyCustomize(false);
                this.ProcessWindowsSettingCustomize(false);
                this.ProcessCustomizeFeatureSoundVolume();
            }
            else
            {
                WindowsSettingCustomize.BaseColor = Color.FromArgb(184, 44, 44);
                WindowsSettingCustomize.OnHoverBaseColor = Color.FromArgb(150, 20, 20);
                WindowsSettingCustomize.Text = "設定完成";
                WindowsSettingCustomize.Image = null;
                WindowsSettingCustomize.Size = CustomizeWindowsSettingButtonOriginSize;
                this.ProcessRegisterHotKeyCustomize(true);
                this.ProcessWindowsSettingCustomize(true);
            }
        }

        private void ProcessCustomizeFeatureSoundVolume()
        {
            foreach (CustomizeTaskTimer customizeTaskTimer in customizeTaskTimerList)
            {
                if (customizeTaskTimer.getAudioPlayer() != null)
                {
                    FormsUtils.ProcessSoundTextBoxLeave(customizeTaskTimer.getCustomVolumeGunaLineTextBox());
                    customizeTaskTimer.getAudioPlayer().Volume = Int32.Parse(customizeTaskTimer.getCustomVolumeGunaLineTextBox().Text) / 100f;
                }
            }
        }

        private void LoadCustomizeFeatureDefaultSound()
        {
            foreach (CustomizeTaskTimer customizeTaskTimer in customizeTaskTimerList)
            {
                customizeTaskTimer.setAudioPlayer(new AudioPlayer(Properties.Resources.荊棘延遲翻桌陰陽陣DefultSound));
            }
        }

        private void 預設音效CustomizeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!customizeTaskTimerList.Any())
            {
                return;
            }
            this.LoadCustomizeFeatureDefaultSound();
        }

        private void 自訂音效CustomizeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!customizeTaskTimerList.Any())
            {
                return;
            }

            foreach (Control control in this.TabPageCustomize.Controls)
            {
                if (control is GunaPanel gunaPanel && FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(gunaPanel.Name) == FormsConstant.panelBaseName)
                {
                    foreach (Control panelControl in gunaPanel.Controls)
                    {
                        if (panelControl is GunaButton gunaButton && FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(gunaButton.Name) == FormsConstant.audioPlayerButtonBaseName)
                        {
                            gunaButton.Enabled = !gunaButton.Enabled;
                            break;
                        }
                    }
                }
            }

            this.LoadCustomizeFeatureDefaultSound();
        }

        private void 關閉音效CustomizeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!customizeTaskTimerList.Any())
            {
                return;
            }

            foreach (CustomizeTaskTimer customizeTaskTimer in customizeTaskTimerList)
            {
                customizeTaskTimer.setAudioPlayer(null);
            }
        }
    }
}
