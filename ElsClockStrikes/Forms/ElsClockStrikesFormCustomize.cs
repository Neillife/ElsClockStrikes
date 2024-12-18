﻿using ElsClockStrikes.Core;
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

        private void TabPageCustomize_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (e.Control is GunaButton gunaButton)
            {
                if (FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(gunaButton.Name) == FormsConstant.buttonBaseName)
                {
                    FormsCustomizeUtils.ProcessComponentLayout(this.TabPageCustomize, gunaButton);
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
            {
                if (elsClockStrikesFormCustomizeSetting.ShowDialog() == DialogResult.OK)
                {
                    string inputData = elsClockStrikesFormCustomizeSetting.inputData;
                    if (inputData != null && inputData.Trim() != "")
                    {
                        ControlStrategyParameters controlStrategyParameters = new ControlStrategyParameters
                        {
                            tabPage = this.TabPageCustomize,
                            custSettingFormsInputData = inputData,
                            customizeTaskTimerList = this.customizeTaskTimerList
                        };
                        ControlStrategyManager controlStrategyManager = new ControlStrategyManager(controlStrategyParameters);
                        controlStrategyManager.RegisterStrategy(new HotKeyLabelStrategy())
                                              .RegisterStrategy(new MechanicNameLabelStrategy())
                                              .RegisterStrategy(new TimeLeftLabelStrategy())
                                              .RegisterStrategy(new ComboBoxStrategy(null))
                                              .RegisterStrategy(new LineTextBoxStrategy("10"))
                                              .RegisterStrategy(new RemoveButtonStrategy())
                                              .RegisterStrategy(new CustomizeTaskTimerStrategy(關閉音效CustomizeRadioButton.Checked))
                                              .RegisterStrategy(new AudioPlayerButtonStrategy(自訂音效CustomizeRadioButton.Checked));
                        controlStrategyManager.ExecuteAll();
                    }
                }
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

            int custSizeHeight = 225;

            if (customizeLabelMap.Count / 3 < 4)
            {
                custSizeHeight = customizeLabelMap.Count / 3 * 39 + 69;
            } else
            {
                custSizeHeight += (customizeLabelMap.Count / 3  - 4) * 40;
            }

            this.Size = isBackToOriginCheck ? CustomizeTabWinFormsSize : new Size(180, custSizeHeight);
            TopMostCheckBox.Visible = !TopMostCheckBox.Visible;
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
            int KeyLabelAddY = 40;
            Label firstCustLabel = null;
            Label labelSign = null;

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
                foreach (Control control in this.Controls)
                {
                    if (control is Label firstLabel && labelSign == null &&
                        FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(firstLabel.Name) == FormsConstant.hotKeyLabelBaseName)
                    {
                        labelSign = firstLabel;
                        labelSign.Location = new Point(5, 30);
                        continue;
                    }
                    if (control is Label timeLeftLabel && FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(timeLeftLabel.Name) == FormsConstant.timeLeftLabelBaseName)
                    {
                        customizeLabelMap[timeLeftLabel.Name].Location = new Point(
                            customizeLabelMap[$"{FormsConstant.mechanicLabelBaseName}{FormsCustomizeUtils.GetIndexOfString(timeLeftLabel.Name)}"].Left + 
                            customizeLabelMap[$"{FormsConstant.mechanicLabelBaseName}{FormsCustomizeUtils.GetIndexOfString(timeLeftLabel.Name)}"].Width, 
                            customizeLabelMap[$"{FormsConstant.hotKeyLabelBaseName}{FormsCustomizeUtils.GetIndexOfString(timeLeftLabel.Name)}"].Location.Y
                            );
                    }
                    else if (control is Label hotKeyLable && FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(hotKeyLable.Name) == FormsConstant.hotKeyLabelBaseName)
                    {
                        customizeLabelMap[hotKeyLable.Name].Location = new Point(labelSign.Location.X, labelSign.Location.Y + KeyLabelAddY);
                        labelSign = hotKeyLable;
                    }
                    else if (control is Label label && FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(label.Name) == FormsConstant.mechanicLabelBaseName)
                    {
                        if (firstCustLabel == null)
                        {
                            firstCustLabel = label;
                            customizeLabelMap[label.Name].Location = new Point(
                                MaxLabelWidth - label.Width + 
                                customizeLabelMap[$"{FormsConstant.hotKeyLabelBaseName}{FormsCustomizeUtils.GetIndexOfString(label.Name)}"].Width - 5,
                                customizeLabelMap[$"{FormsConstant.hotKeyLabelBaseName}{FormsCustomizeUtils.GetIndexOfString(label.Name)}"].Top +
                                customizeLabelMap[$"{FormsConstant.hotKeyLabelBaseName}{FormsCustomizeUtils.GetIndexOfString(label.Name)}"].Height -
                                label.Height - 3
                                );
                        }
                        else
                        {
                            customizeLabelMap[label.Name].Location = new Point(
                                firstCustLabel.Left + firstCustLabel.Width - label.Width,
                                customizeLabelMap[$"{FormsConstant.hotKeyLabelBaseName}{FormsCustomizeUtils.GetIndexOfString(label.Name)}"].Top +
                                customizeLabelMap[$"{FormsConstant.hotKeyLabelBaseName}{FormsCustomizeUtils.GetIndexOfString(label.Name)}"].Height -
                                label.Height - 3
                                );
                        }
                    }
                }
                重置計時器Customize按鍵Label.Location = new Point(labelSign.Location.X, labelSign.Location.Y + KeyLabelAddY);
                重置計時器CustomizeLabel.Location = new Point(firstCustLabel.Left + firstCustLabel.Width - 重置計時器CustomizeLabel.Width + 27, 重置計時器Customize按鍵Label.Top + 重置計時器Customize按鍵Label.Height - 重置計時器CustomizeLabel.Height - 3);
                WindowsSettingCustomize.Location = new Point(130, 5);
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
                if (control is GunaButton gunaButton && FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(gunaButton.Name) == FormsConstant.audioPlayerButtonBaseName)
                {
                    gunaButton.Visible = !gunaButton.Visible;
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
