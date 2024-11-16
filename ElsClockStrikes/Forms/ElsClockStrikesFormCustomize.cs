using ElsClockStrikes.Core;
using ElsClockStrikes.Forms;
using ElsClockStrikes.Forms.FormCustomizeStrategy;
using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ElsClockStrikes
{
    public partial class ElsClockStrikesForm
    {
        public List<CustomizeTaskTimer> customizeTaskTimerList = new List<CustomizeTaskTimer>();
        private Dictionary<string, Point> labelOriginPosMap = new Dictionary<string, Point>();
        private Dictionary<string, Label> customizeLabelMap = new Dictionary<string, Label>();
        private HotKeyManagerForCustomize hotKeyManagerForCustomize;
        private Size CustomizeTabWinFormsSize;

        private void TabPageCustomize_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (e.Control is GunaButton gunaButton)
            {
                if (FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(gunaButton.Name) == FormsConstant.buttonBaseName)
                {
                    FormsCustomizeUtils.ProcessComponentLayout(this.TabPageCustomize, gunaButton);
                }
                if (this.Size.Height != WindowsOriginSize.Height)
                {
                    ProcessWindowsSizeWithLayout(false);
                }
            }
        }

        private void TabPageCustomize_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control is GunaLineTextBox gunaLineTextBox && gunaLineTextBox.Location.Y > FormsCustomizeUtils.LayoutSign)
            {
                ProcessWindowsSizeWithLayout(true);
            }
        }

        private void AddCustomizeTimer_Click(object sender, EventArgs e)
        {
            using (ElsClockStrikesFormCustomizeSetting elsClockStrikesFormCustomizeSetting = new ElsClockStrikesFormCustomizeSetting())
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
                                              .RegisterStrategy(new ComboBoxStrategy())
                                              .RegisterStrategy(new LineTextBoxStrategy())
                                              .RegisterStrategy(new RemoveButtonStrategy())
                                              .RegisterStrategy(new CustomizeTaskTimerStrategy());
                        controlStrategyManager.ExecuteAll();
                        //FormsCustomizeUtils.StartAddCustomizeWithLayoutCheck(this.TabPageCustomize, inputData, customizeTaskTimerList);
                    }
                }
            }

            //foreach (CustomizeTaskTimer customizeTaskTimer in customizeTaskTimerList)
            //{
            //    this.components.Add(customizeTaskTimer);
            //}

            //GunaLineTextBox result = FormsCustomizeUtils.getGunaLineTextBoxByCustomizeIndex(this.TabPageCustomize, 2);
            //if (result == null)
            //{
            //    Testlabel.Text = $"null {customizeTaskTimerList.Count}";
            //}
            //else
            //{
            //    Testlabel.Text = $"!!!!!!!!! {result.Name}";
            //}
            //Testlabel.Text = FormsCustomizeUtils.getTimerByCustomizeIndex(this.TabPageCustomize, 2).Tag.ToString();

            //Testlabel.Text = "10";
            //customizeTaskTimer.Start();
        }

        private void ProcessWindowsSizeWithLayout(bool isAdd)
        {
            if (isAdd)
            {
                this.CustomizeTabWinFormsSize = new Size(this.Size.Width, this.Size.Height + FormsCustomizeUtils.FormLayoutYAxisNum);
                this.Size = CustomizeTabWinFormsSize;
                this.metroTabControlVS1.Size = new Size(this.metroTabControlVS1.Width, this.metroTabControlVS1.Height + FormsCustomizeUtils.FormLayoutYAxisNum);
                TopMostCustomizeCheckBox.Location = new Point(TopMostCustomizeCheckBox.Location.X, TopMostCustomizeCheckBox.Location.Y + FormsCustomizeUtils.FormLayoutYAxisNum);
                WindowsSettingCustomize.Location = new Point(WindowsSettingCustomize.Location.X, WindowsSettingCustomize.Location.Y + FormsCustomizeUtils.FormLayoutYAxisNum);
                AddCustomizeTimer.Location = new Point(AddCustomizeTimer.Location.X, AddCustomizeTimer.Location.Y + FormsCustomizeUtils.FormLayoutYAxisNum);
                CopyrightTagLabel.Location = new Point(CopyrightTagLabel.Location.X, CopyrightTagLabel.Location.Y + FormsCustomizeUtils.FormLayoutYAxisNum);
            }
            else
            {
                this.CustomizeTabWinFormsSize = new Size(this.Size.Width, this.Size.Height - FormsCustomizeUtils.FormLayoutYAxisNum);
                this.Size = CustomizeTabWinFormsSize;
                this.metroTabControlVS1.Size = new Size(this.metroTabControlVS1.Width, this.metroTabControlVS1.Height - FormsCustomizeUtils.FormLayoutYAxisNum);
                TopMostCustomizeCheckBox.Location = new Point(TopMostCustomizeCheckBox.Location.X, TopMostCustomizeCheckBox.Location.Y - FormsCustomizeUtils.FormLayoutYAxisNum);
                WindowsSettingCustomize.Location = new Point(WindowsSettingCustomize.Location.X, WindowsSettingCustomize.Location.Y - FormsCustomizeUtils.FormLayoutYAxisNum);
                AddCustomizeTimer.Location = new Point(AddCustomizeTimer.Location.X, AddCustomizeTimer.Location.Y - FormsCustomizeUtils.FormLayoutYAxisNum);
                CopyrightTagLabel.Location = new Point(CopyrightTagLabel.Location.X, CopyrightTagLabel.Location.Y - FormsCustomizeUtils.FormLayoutYAxisNum);
            }
        }

        private void TopMostCustomizeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
        }

        private void ProcessRegisterHotKeyCustomize(bool isBackToOriginCheck)
        {
            if (isBackToOriginCheck)
            {
                hotKeyManagerForCustomize.Dispose();
            }
            else
            {
                hotKeyManagerForCustomize = new HotKeyManagerForCustomize(this.TabPageCustomize, typeof(ElsClockStrikesForm), customizeTaskTimerList);
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

            FormsCustomizeUtils.ProcessComponentDisplaySettings(this.TabPageCustomize, isBackToOriginCheck);
            if (isBackToOriginCheck)
            {
                this.Controls.Remove(WindowsSettingCustomize);
                this.Controls.Remove(TopMostCustomizeCheckBox);
                TabPageCustomize.Controls.Add(WindowsSettingCustomize);
                TabPageCustomize.Controls.Add(TopMostCustomizeCheckBox);
            }
            else
            {
                TabPageCustomize.Controls.Remove(WindowsSettingCustomize);
                TabPageCustomize.Controls.Remove(TopMostCustomizeCheckBox);
                this.Controls.Add(WindowsSettingCustomize);
                this.Controls.Add(TopMostCustomizeCheckBox);
            }

            this.Size = isBackToOriginCheck ? CustomizeTabWinFormsSize : new Size(180, 330);
            this.SetCustomizeLabelMapWithLabelOriginPosMap(isBackToOriginCheck);
            this.ProcessComponentLocation(isBackToOriginCheck);
        }

        private void SetCustomizeLabelMapWithLabelOriginPosMap(bool isBackToOriginCheck)
        {
            if (isBackToOriginCheck)
            {
                return;
            }
            foreach (Control control in this.Controls)
            {
                if (control is Label label &&
                    (FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(label.Name) == FormsConstant.timeLeftLabelBaseName ||
                    FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(label.Name) == FormsConstant.hotKeyLabelBaseName ||
                    FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(label.Name) == FormsConstant.mechanicLabelBaseName))
                {
                    customizeLabelMap.Add(label.Name, label);
                    labelOriginPosMap.Add(label.Name, label.Location);
                }
            }
        }

        private void ProcessComponentLocation(bool isBackToOriginCheck)
        {
            int KeyLabelAddY = 40;
            Label lastLabel = null;
            if (isBackToOriginCheck)
            {
                foreach (Control control in this.TabPageCustomize.Controls)
                {
                    if (control is Label label &&
                        (FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(label.Name) == FormsConstant.timeLeftLabelBaseName ||
                        FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(label.Name) == FormsConstant.hotKeyLabelBaseName ||
                        FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(label.Name) == FormsConstant.mechanicLabelBaseName))
                    {
                        label.Location = labelOriginPosMap[label.Name];
                    }
                }
                labelOriginPosMap.Clear();
                customizeLabelMap.Clear();
            }
            else
            {
                int MaxLabelWidth = FormsUtils.GetLabelMaxWidth(this.TabPageCustomize.Parent.Parent);
                Label firstCustLabel = null;
                Label labelSign = null;
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
                        // timeleft
                        customizeLabelMap[timeLeftLabel.Name].Location = new Point(
                            customizeLabelMap[$"{FormsConstant.mechanicLabelBaseName}{FormsCustomizeUtils.GetIndexOfString(timeLeftLabel.Name)}"].Left + 
                            customizeLabelMap[$"{FormsConstant.mechanicLabelBaseName}{FormsCustomizeUtils.GetIndexOfString(timeLeftLabel.Name)}"].Width, 
                            customizeLabelMap[$"{FormsConstant.hotKeyLabelBaseName}{FormsCustomizeUtils.GetIndexOfString(timeLeftLabel.Name)}"].Location.Y
                            ); 
                        //小荊棘CDLabel.Location = new Point(小荊棘Label.Left + 小荊棘Label.Width, 小荊棘按鍵Label.Location.Y);
                        //雷射CDLabel.Location = new Point(雷射Label.Left + 雷射Label.Width, 雷射按鍵Label.Location.Y);
                        lastLabel = timeLeftLabel;
                    }
                    else if (control is Label hotKeyLable && FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(hotKeyLable.Name) == FormsConstant.hotKeyLabelBaseName)
                    {
                        // hotkey
                        customizeLabelMap[hotKeyLable.Name].Location = new Point(labelSign.Location.X, labelSign.Location.Y + KeyLabelAddY);
                        //小荊棘按鍵Label.Location = new Point(5, 30);
                        //雷射按鍵Label.Location = new Point(小荊棘按鍵Label.Location.X, 小荊棘按鍵Label.Location.Y + KeyLabelAddY);
                        labelSign = hotKeyLable;
                    }
                    else if (control is Label label && FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(label.Name) == FormsConstant.mechanicLabelBaseName)
                    {
                        if (firstCustLabel == null)
                        {
                            firstCustLabel = label;
                            customizeLabelMap[label.Name].Location = new Point(
                                MaxLabelWidth - labelSign.Width + 
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
                        // label
                        //小荊棘Label.Location = isBackToOriginCheck ? 小荊棘LabelOriginPos :
                        //    new Point(MaxLabelWidth - 小荊棘Label.Width + 小荊棘按鍵Label.Width - 5, 小荊棘按鍵Label.Top + 小荊棘按鍵Label.Height - 小荊棘Label.Height - 3);
                        //雷射Label.Location = isBackToOriginCheck ? 雷射LabelOriginPos :
                        //    new Point(小荊棘Label.Left + 小荊棘Label.Width - 雷射Label.Width, 雷射按鍵Label.Top + 雷射按鍵Label.Height - 雷射Label.Height - 3);
                    }
                }
            }

            TopMostCustomizeCheckBox.Location = isBackToOriginCheck ? TopMostCheckBoxOriginPos : new Point(this.Size.Width / 2 - TopMostCustomizeCheckBox.Width / 2, lastLabel.Location.Y + KeyLabelAddY);
            WindowsSettingCustomize.Location = isBackToOriginCheck ? WindowsSettingOriginPos : new Point(this.Size.Width / 2 - WindowsSettingCustomize.Width / 2, TopMostCustomizeCheckBox.Location.Y + 40);
        }

        private void WindowsSettingCustomize_Click(object sender, EventArgs e)
        {
            if (WindowsSettingCustomize.Text.Equals("設定完成"))
            {
                WindowsSettingCustomize.BaseColor = Color.FromArgb(65, 105, 225);
                WindowsSettingCustomize.OnHoverBaseColor = Color.FromArgb(45, 85, 205);
                WindowsSettingCustomize.Text = "調整設定";
                this.ProcessRegisterHotKeyCustomize(false);
                this.ProcessWindowsSettingCustomize(false);
            }
            else
            {
                WindowsSettingCustomize.BaseColor = Color.FromArgb(184, 44, 44);
                WindowsSettingCustomize.OnHoverBaseColor = Color.FromArgb(150, 20, 20);
                WindowsSettingCustomize.Text = "設定完成";
                this.ProcessRegisterHotKeyCustomize(true);
                this.ProcessWindowsSettingCustomize(true);
            }
        }
    }
}
