using ElsClockStrikes.Core;
using ElsClockStrikes.Forms;
using Guna.UI.WinForms;
using MetroSuite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ElsClockStrikes
{
    public partial class ElsClockStrikesForm : MetroForm
    {
        private Point 小荊棘LabelOriginPos;
        private Point 雷射LabelOriginPos;
        private Point 荊棘延遲LabelOriginPos;
        private Point 控場LabelOriginPos;
        private Point 重置計時器LabelOriginPos;
        private Point TopMostCheckBoxOriginPos;
        private Point WindowsSettingOriginPos;
        private Point CopyrightTagLabelOriginPos;
        private Size WindowsOriginSize;
        private Size metroTabControlVS1OriginSize;
        private Size WindowsSettingButtonOriginSize;
        private AudioPlayer 小荊棘TimeupAudioPlayer;
        private AudioPlayer 雷射TimeupAudioPlayer;
        private AudioPlayer 荊棘延遲TimeupAudioPlayer;
        private AudioPlayer 控場TimeupAudioPlayer;
        private HotKeyManager hotKeyManager;
        private List<ElsClockStrikesFormTimerInstance> formTimerInstances;
        private Dictionary<string, Point> formTimerInstancePos;

        public ElsClockStrikesForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.metroTabControlVS1.Controls.Remove(TopMostCheckBox);
            this.Controls.Add(TopMostCheckBox);
            TopMostCheckBox.BringToFront();
            TopMostCheckBox.Location = new Point(119, 453);
            小荊棘LabelOriginPos = 小荊棘Label.Location;
            雷射LabelOriginPos = 雷射Label.Location;
            荊棘延遲LabelOriginPos = 荊棘延遲Label.Location;
            控場LabelOriginPos = 控場Label.Location;
            重置計時器LabelOriginPos = 重置計時器Label.Location;
            TopMostCheckBoxOriginPos = TopMostCheckBox.Location;
            CustomizeTopMostCheckBoxPos = TopMostCheckBox.Location;
            WindowsSettingOriginPos = WindowsSetting.Location;
            CopyrightTagLabelOriginPos = CopyrightTagLabel.Location;
            CustomizeTabCopyrightTagLabelPos = CopyrightTagLabel.Location;
            WindowsOriginSize = this.Size;
            CustomizeTabWinFormsSize = this.Size;
            metroTabControlVS1OriginSize = this.metroTabControlVS1.Size;
            CustomizeMetroTabControlVS1Size = this.metroTabControlVS1.Size;
            WindowsSettingButtonOriginSize = this.WindowsSetting.Size;
            CustomizeWindowsSettingButtonOriginSize = this.WindowsSettingCustomize.Size;

            大招LabelOriginPos = 大招Label.Location;
            大刺LabelOriginPos = 大刺Label.Location;
            翻桌LabelOriginPos = 翻桌Label.Location;
            控場156R1LabelOriginPos = R1156控場Label.Location;

            大黑LabelOriginPos = 大黑Label.Location;
            陰陽陣LabelOriginPos = 陰陽陣Label.Location;
            三連LabelOriginPos = 三連Label.Location;
            控場156R3LabelOriginPos = R3156控場Label.Location;
            InitFirstStart陰陽陣();
            Is大黑Delay = false;
            Is陰陽陣Delay = false;

            預設音效RadioButton.Checked = true;
            預設音效156R1RadioButton.Checked = true;
            預設音效156R3RadioButton.Checked = true;
            CopyrightTagLabel.Text = FormsConstant.copyrightTag;
            this.ProcessAutoLoadConfig();
        }

        private void ElsClockStrikesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            hotKeyManager?.Dispose();
        }

        private void ElsClockStrikesForm_Resize(object sender, EventArgs e)
        {
            if (this.Width <= 212)
            {
                this.Text = "ElsClockStrikes";
            }
            else
            {
                this.Text = FormsConstant.titleName;
            }
        }

        private void 小荊棘Timer_Tick(object sender, EventArgs e)
        {
            小荊棘CDLabel.Text = FormsConstant.小荊棘Time == 0 ? "0" : (--FormsConstant.小荊棘Time).ToString();

            if (FormsConstant.小荊棘Time <= 10)
            {
                小荊棘CDLabel.ForeColor = Color.FromArgb(185, 45, 45);
            }
            else if (FormsConstant.小荊棘Time == Int32.Parse(小荊棘TextBox.Text) / 2)
            {
                小荊棘CDLabel.ForeColor = Color.FromArgb(185, 145, 52);
            }

            if (FormsConstant.小荊棘Time == 0)
            {
                FormsConstant.set小荊棘Time(小荊棘TextBox.Text);
                小荊棘Timer.Stop();
                if (預設音效RadioButton.Checked || 自訂音效RadioButton.Checked)
                {
                    小荊棘TimeupAudioPlayer.Play();
                }
            }
        }

        private void 雷射Timer_Tick(object sender, EventArgs e)
        {
            雷射CDLabel.Text = FormsConstant.雷射Time == 0 ? "0" : (--FormsConstant.雷射Time).ToString();

            if (FormsConstant.雷射Time <= 10)
            {
                雷射CDLabel.ForeColor = Color.FromArgb(185, 45, 45);
            }
            else if (FormsConstant.雷射Time == Int32.Parse(雷射TextBox.Text) / 2)
            {
                雷射CDLabel.ForeColor = Color.FromArgb(185, 145, 52);
            }

            if (FormsConstant.雷射Time == 0)
            {
                FormsConstant.set雷射Time(雷射TextBox.Text);
                雷射Timer.Stop();
                if (預設音效RadioButton.Checked || 自訂音效RadioButton.Checked)
                {
                    雷射TimeupAudioPlayer.Play();
                }
            }
        }

        private void 荊棘延遲Timer_Tick(object sender, EventArgs e)
        {
            荊棘延遲CDLabel.Text = FormsConstant.荊棘延遲Time == 0 ? "0" : (--FormsConstant.荊棘延遲Time).ToString();

            if (FormsConstant.荊棘延遲Time <= 10)
            {
                荊棘延遲CDLabel.ForeColor = Color.FromArgb(185, 45, 45);
            }
            else if (FormsConstant.荊棘延遲Time == Int32.Parse(荊棘延遲TextBox.Text) / 2)
            {
                荊棘延遲CDLabel.ForeColor = Color.FromArgb(185, 145, 52);
            }

            if (FormsConstant.荊棘延遲Time == 0)
            {
                FormsConstant.set荊棘延遲Time(荊棘延遲TextBox.Text);
                荊棘延遲Timer.Stop();
                if (預設音效RadioButton.Checked || 自訂音效RadioButton.Checked)
                {
                    荊棘延遲TimeupAudioPlayer.Play();
                }
            }
        }

        private void 控場_Tick(object sender, EventArgs e)
        {
            控場CDLabel.Text = FormsConstant.控場Time == 0 ? "0" : (--FormsConstant.控場Time).ToString();

            if (FormsConstant.控場Time <= 10)
            {
                控場CDLabel.ForeColor = Color.FromArgb(185, 45, 45);
            }
            else if (FormsConstant.控場Time == Int32.Parse(控場TextBox.Text) / 2)
            {
                控場CDLabel.ForeColor = Color.FromArgb(185, 145, 52);
            }

            if (FormsConstant.控場Time == 0)
            {
                FormsConstant.set控場Time(控場TextBox.Text);
                控場Timer.Stop();
                if (預設音效RadioButton.Checked || 自訂音效RadioButton.Checked)
                {
                    控場TimeupAudioPlayer.Play();
                }
            }
        }

        private void TopMostCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (TopMostCheckBox.Checked)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }

        private void ProcessComponentDisplay(bool isBackToOriginCheck)
        {
            if (isBackToOriginCheck)
            {
                this.Controls.Remove(小荊棘按鍵Label);
                this.Controls.Remove(小荊棘Label);
                this.Controls.Remove(小荊棘CDLabel);
                this.Controls.Remove(雷射按鍵Label);
                this.Controls.Remove(雷射Label);
                this.Controls.Remove(雷射CDLabel);
                this.Controls.Remove(荊棘延遲按鍵Label);
                this.Controls.Remove(荊棘延遲Label);
                this.Controls.Remove(荊棘延遲CDLabel);
                this.Controls.Remove(控場按鍵Label);
                this.Controls.Remove(控場Label);
                this.Controls.Remove(控場CDLabel);
                this.Controls.Remove(重置計時器按鍵Label);
                this.Controls.Remove(重置計時器Label);
                this.Controls.Remove(WindowsSetting);

                TabPage127R3.Controls.Add(小荊棘按鍵Label);
                TabPage127R3.Controls.Add(小荊棘Label);
                TabPage127R3.Controls.Add(小荊棘CDLabel);
                TabPage127R3.Controls.Add(雷射按鍵Label);
                TabPage127R3.Controls.Add(雷射Label);
                TabPage127R3.Controls.Add(雷射CDLabel);
                TabPage127R3.Controls.Add(荊棘延遲按鍵Label);
                TabPage127R3.Controls.Add(荊棘延遲Label);
                TabPage127R3.Controls.Add(荊棘延遲CDLabel);
                TabPage127R3.Controls.Add(控場按鍵Label);
                TabPage127R3.Controls.Add(控場Label);
                TabPage127R3.Controls.Add(控場CDLabel);
                TabPage127R3.Controls.Add(重置計時器按鍵Label);
                TabPage127R3.Controls.Add(重置計時器Label);
                TabPage127R3.Controls.Add(WindowsSetting);
            }
            else
            {
                TabPage127R3.Controls.Remove(小荊棘按鍵Label);
                TabPage127R3.Controls.Remove(小荊棘Label);
                TabPage127R3.Controls.Remove(小荊棘CDLabel);
                TabPage127R3.Controls.Remove(雷射按鍵Label);
                TabPage127R3.Controls.Remove(雷射Label);
                TabPage127R3.Controls.Remove(雷射CDLabel);
                TabPage127R3.Controls.Remove(荊棘延遲按鍵Label);
                TabPage127R3.Controls.Remove(荊棘延遲Label);
                TabPage127R3.Controls.Remove(荊棘延遲CDLabel);
                TabPage127R3.Controls.Remove(控場按鍵Label);
                TabPage127R3.Controls.Remove(控場Label);
                TabPage127R3.Controls.Remove(控場CDLabel);
                TabPage127R3.Controls.Remove(重置計時器按鍵Label);
                TabPage127R3.Controls.Remove(重置計時器Label);
                TabPage127R3.Controls.Remove(WindowsSetting);

                this.Controls.Add(小荊棘按鍵Label);
                this.Controls.Add(小荊棘Label);
                this.Controls.Add(小荊棘CDLabel);
                this.Controls.Add(雷射按鍵Label);
                this.Controls.Add(雷射Label);
                this.Controls.Add(雷射CDLabel);
                this.Controls.Add(荊棘延遲按鍵Label);
                this.Controls.Add(荊棘延遲Label);
                this.Controls.Add(荊棘延遲CDLabel);
                this.Controls.Add(控場按鍵Label);
                this.Controls.Add(控場Label);
                this.Controls.Add(控場CDLabel);
                this.Controls.Add(重置計時器按鍵Label);
                this.Controls.Add(重置計時器Label);
                this.Controls.Add(WindowsSetting);
            }
        }

        private void ProcessFormInstance(bool isBackToOriginCheck)
        {
            if (isBackToOriginCheck)
            {
                if (formTimerInstancePos == null)
                {
                    formTimerInstancePos = new Dictionary<string, Point>();
                }
                foreach (ElsClockStrikesFormTimerInstance timerInstance in formTimerInstances)
                {
                    Console.WriteLine($"{timerInstance.GetMechanicName()} {formTimerInstances.Count}");
                    formTimerInstancePos[timerInstance.GetMechanicName()] = timerInstance.Location;
                    timerInstance.Close();
                }
                this.Size = WindowsOriginSize;
                小荊棘Label.Location = 小荊棘LabelOriginPos;
                雷射Label.Location = 雷射LabelOriginPos;
                荊棘延遲Label.Location = 荊棘延遲LabelOriginPos;
                控場Label.Location = 控場LabelOriginPos;
                重置計時器Label.Location = 重置計時器LabelOriginPos;
                WindowsSetting.Location = WindowsSettingOriginPos;
            }
            else
            {
                int MaxLabelWidth = FormsUtils.GetLabelMaxWidth(this);
                int KeyLabelAddY = 40;
                Dictionary<string, TimerInstanceParameters> nonInstanceMap = new Dictionary<string, TimerInstanceParameters>();
                List<GunaCheckBox> cbList = FormsUtils.GetCheckBoxByMechanicNames(this.TabPage127R3, FormsConstant.tipNames127R3);
                Dictionary<string, TimerInstanceParameters> tipMap = FormsUtils.GetTIPMapByMechanicNames(this, FormsConstant.tipNames127R3);
                formTimerInstances = new List<ElsClockStrikesFormTimerInstance>();
                foreach (GunaCheckBox checkBox in cbList)
                {
                    string tipMapKey = checkBox.Name.Replace("分離視窗CheckBox", "");
                    Console.WriteLine($"{checkBox.Name} = {checkBox.Checked}");
                    if (checkBox.Checked)
                    {
                        if (formTimerInstancePos != null && formTimerInstancePos.ContainsKey(tipMapKey))
                        {
                            formTimerInstances.Add(new ElsClockStrikesFormTimerInstance(tipMap[tipMapKey], WindowsSetting, MaxLabelWidth, this.TopMost, formTimerInstancePos[tipMapKey]));
                        }
                        else
                        {
                            formTimerInstances.Add(new ElsClockStrikesFormTimerInstance(tipMap[tipMapKey], WindowsSetting, MaxLabelWidth, this.TopMost));
                        }
                    }
                    else
                    {
                        nonInstanceMap.Add(tipMapKey, tipMap[tipMapKey]);
                    }
                }

                foreach (ElsClockStrikesFormTimerInstance timerInstance in formTimerInstances)
                {
                    timerInstance.Show();
                }

                this.Size = new Size(180, 225 - (tipMap.Count - nonInstanceMap.Count) * 39);
                Label firstNameLabel = null;
                Label labelSign = null;
                bool firstCheck = false;

                foreach (KeyValuePair<string, TimerInstanceParameters> kvp in nonInstanceMap)
                {
                    if (!firstCheck)
                    {
                        kvp.Value.keyLabel.Location = new Point(5, 30);
                        kvp.Value.nameLabel.Location = new Point(MaxLabelWidth - kvp.Value.nameLabel.Width + kvp.Value.keyLabel.Width - 5, kvp.Value.keyLabel.Top + kvp.Value.keyLabel.Height - kvp.Value.nameLabel.Height - 3);
                        kvp.Value.timeLeftLabel.Location = new Point(kvp.Value.nameLabel.Left + kvp.Value.nameLabel.Width, kvp.Value.keyLabel.Location.Y);
                        firstNameLabel = kvp.Value.nameLabel;
                        labelSign = kvp.Value.keyLabel;
                        firstCheck = true;
                    }
                    else
                    {
                        kvp.Value.keyLabel.Location = new Point(labelSign.Location.X, labelSign.Location.Y + KeyLabelAddY);
                        kvp.Value.nameLabel.Location = new Point(firstNameLabel.Left + firstNameLabel.Width - kvp.Value.nameLabel.Width, kvp.Value.keyLabel.Top + kvp.Value.keyLabel.Height - kvp.Value.nameLabel.Height - 3);
                        kvp.Value.timeLeftLabel.Location = new Point(kvp.Value.nameLabel.Left + kvp.Value.nameLabel.Width, kvp.Value.keyLabel.Location.Y);
                        labelSign = kvp.Value.keyLabel;
                    }
                }

                重置計時器按鍵Label.Location = new Point(labelSign.Location.X, labelSign.Location.Y + KeyLabelAddY);
                重置計時器Label.Location = new Point(firstNameLabel.Left + firstNameLabel.Width - 重置計時器Label.Width + 27, 重置計時器按鍵Label.Top + 重置計時器按鍵Label.Height - 重置計時器Label.Height - 3);
                WindowsSetting.Location = new Point(130, 5);
            }
        }

        private void ProcessWindowsSetting(bool isBackToOriginCheck)
        {
            小荊棘CDLabel.Visible = !小荊棘CDLabel.Visible;
            雷射CDLabel.Visible = !雷射CDLabel.Visible;
            荊棘延遲CDLabel.Visible = !荊棘延遲CDLabel.Visible;
            控場CDLabel.Visible = !控場CDLabel.Visible;
            小荊棘按鍵Label.Visible = !小荊棘按鍵Label.Visible;
            雷射按鍵Label.Visible = !雷射按鍵Label.Visible;
            荊棘延遲按鍵Label.Visible = !荊棘延遲按鍵Label.Visible;
            控場按鍵Label.Visible = !控場按鍵Label.Visible;
            重置計時器按鍵Label.Visible = !重置計時器按鍵Label.Visible;
            ZoomOutControlBox.Visible = !ZoomOutControlBox.Visible;
            CloseControlBox.Visible = !CloseControlBox.Visible;
            metroTabControlVS1.Visible = !metroTabControlVS1.Visible;

            ProcessComponentDisplay(isBackToOriginCheck);
            ProcessFormInstance(isBackToOriginCheck);

            小荊棘按鍵Label.Text = FormsUtils.ProcessLayoutString(小荊棘ComboBox.Text);
            雷射按鍵Label.Text = FormsUtils.ProcessLayoutString(雷射ComboBox.Text);
            荊棘延遲按鍵Label.Text = FormsUtils.ProcessLayoutString(荊棘延遲ComboBox.Text);
            控場按鍵Label.Text = FormsUtils.ProcessLayoutString(控場ComboBox.Text);
            重置計時器按鍵Label.Text = FormsUtils.ProcessLayoutString(重置計時器ComboBox.Text);
            小荊棘CDLabel.Text = 小荊棘TextBox.Text;
            雷射CDLabel.Text = 雷射TextBox.Text;
            荊棘延遲CDLabel.Text = 荊棘延遲TextBox.Text;
            控場CDLabel.Text = 控場TextBox.Text;
        }

        private void ProcessRegisterHotKey(bool isBackToOriginCheck)
        {
            if (isBackToOriginCheck)
            {
                hotKeyManager.Dispose();
            }
            else
            {
                hotKeyManager = new HotKeyManager(this.TabPage127R3, typeof(ElsClockStrikesForm));
            }
        }

        private void WindowsSetting_Click(object sender, EventArgs e)
        {
            if (WindowsSetting.Text.Equals("設定完成"))
            {
                WindowsSetting.BaseColor = Color.FromArgb(40, 40, 40);
                WindowsSetting.OnHoverBaseColor = Color.FromArgb(120, 120, 120);
                WindowsSetting.Text = "";
                WindowsSetting.Image = Properties.Resources.setimg;
                WindowsSetting.Size = new Size(43, 25);
                this.ProcessRegisterHotKey(false);
                this.ProcessWindowsSetting(false);
                this.ProcessSoundVolume();
                FormsConstant.init127Timer(小荊棘TextBox.Text, 雷射TextBox.Text, 荊棘延遲TextBox.Text, 控場TextBox.Text);
            }
            else
            {
                WindowsSetting.BaseColor = Color.FromArgb(184, 44, 44);
                WindowsSetting.OnHoverBaseColor = Color.FromArgb(150, 20, 20);
                WindowsSetting.Text = "設定完成";
                WindowsSetting.Image = null;
                WindowsSetting.Size = WindowsSettingButtonOriginSize;
                this.ProcessRegisterHotKey(true);
                this.ProcessWindowsSetting(true);
            }
        }

        private void 小荊棘TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormsUtils.ProcessKeyPress(e);
        }

        private void 雷射TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormsUtils.ProcessKeyPress(e);
        }

        private void 荊棘延遲TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormsUtils.ProcessKeyPress(e);
        }

        private void 控場TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormsUtils.ProcessKeyPress(e);
        }

        private void 小荊棘音量TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormsUtils.ProcessKeyPress(e);
        }

        private void 雷射音量TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormsUtils.ProcessKeyPress(e);
        }

        private void 荊棘延遲音量TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormsUtils.ProcessKeyPress(e);
        }

        private void 控場音量TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormsUtils.ProcessKeyPress(e);
        }

        private void 小荊棘音量TextBox_Leave(object sender, EventArgs e)
        {
            FormsUtils.ProcessSoundTextBoxLeave(小荊棘音量TextBox);
        }

        private void 雷射音量TextBox_Leave(object sender, EventArgs e)
        {
            FormsUtils.ProcessSoundTextBoxLeave(雷射音量TextBox);
        }

        private void 荊棘延遲音量TextBox_Leave(object sender, EventArgs e)
        {
            FormsUtils.ProcessSoundTextBoxLeave(荊棘延遲音量TextBox);
        }

        private void 控場音量TextBox_Leave(object sender, EventArgs e)
        {
            FormsUtils.ProcessSoundTextBoxLeave(控場音量TextBox);
        }

        private void ProcessSoundVolume()
        {
            if (小荊棘TimeupAudioPlayer != null)
            {
                小荊棘TimeupAudioPlayer.Volume = Int32.Parse(小荊棘音量TextBox.Text) / 100f;
            }
            if (雷射TimeupAudioPlayer != null)
            {
                雷射TimeupAudioPlayer.Volume = Int32.Parse(雷射音量TextBox.Text) / 100f;
            }
            if (荊棘延遲TimeupAudioPlayer != null)
            {
                荊棘延遲TimeupAudioPlayer.Volume = Int32.Parse(荊棘延遲音量TextBox.Text) / 100f;
            }
            if (控場TimeupAudioPlayer != null)
            {
                控場TimeupAudioPlayer.Volume = Int32.Parse(控場音量TextBox.Text) / 100f;
            }
        }

        private void LoadDefaultSound()
        {
            小荊棘TimeupAudioPlayer = new AudioPlayer(Properties.Resources.小荊棘大招大黑DefultSound);
            雷射TimeupAudioPlayer = new AudioPlayer(Properties.Resources.雷射大刺三連DefultSound);
            荊棘延遲TimeupAudioPlayer = new AudioPlayer(Properties.Resources.荊棘延遲翻桌陰陽陣DefultSound);
            控場TimeupAudioPlayer = new AudioPlayer(Properties.Resources.控場DefultSound);
        }

        private void 預設音效RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadDefaultSound();
        }

        private void 自訂音效RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (自訂音效RadioButton.Checked)
            {
                小荊棘設定音效Button.Enabled = true;
                雷射設定音效Button.Enabled = true;
                荊棘延遲設定音效Button.Enabled = true;
                控場設定音效Button.Enabled = true;
            }
            else
            {
                小荊棘設定音效Button.Enabled = false;
                雷射設定音效Button.Enabled = false;
                荊棘延遲設定音效Button.Enabled = false;
                控場設定音效Button.Enabled = false;
            }
            this.LoadDefaultSound();
        }

        private void 關閉音效RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            小荊棘TimeupAudioPlayer = null;
            雷射TimeupAudioPlayer = null;
            荊棘延遲TimeupAudioPlayer = null;
            控場TimeupAudioPlayer = null;
        }

        private void 小荊棘設定音效Button_Click(object sender, EventArgs e)
        {
            小荊棘TimeupAudioPlayer = FormsUtils.ProcessSelectSoundFile(Properties.Resources.小荊棘大招大黑DefultSound);
        }

        private void 雷射設定音效Button_Click(object sender, EventArgs e)
        {
            雷射TimeupAudioPlayer = FormsUtils.ProcessSelectSoundFile(Properties.Resources.雷射大刺三連DefultSound);
        }

        private void 荊棘延遲設定音效Button_Click(object sender, EventArgs e)
        {
            荊棘延遲TimeupAudioPlayer = FormsUtils.ProcessSelectSoundFile(Properties.Resources.荊棘延遲翻桌陰陽陣DefultSound);
        }

        private void 控場設定音效Button_Click(object sender, EventArgs e)
        {
            控場TimeupAudioPlayer = FormsUtils.ProcessSelectSoundFile(Properties.Resources.控場DefultSound);
        }

        private void 小荊棘設定Button_Click(object sender, EventArgs e)
        {
            FormsUtils.ProcessSettingBtnClick(小荊棘GunaPanel, 小荊棘設定Button);
            FormsUtils.StartExpandAnimation(小荊棘GunaPanel);
        }

        private void 雷射設定Button_Click(object sender, EventArgs e)
        {
            FormsUtils.ProcessSettingBtnClick(雷射GunaPanel, 雷射設定Button);
            FormsUtils.StartExpandAnimation(雷射GunaPanel);
        }

        private void 荊棘延遲設定Button_Click(object sender, EventArgs e)
        {
            FormsUtils.ProcessSettingBtnClick(荊棘延遲GunaPanel, 荊棘延遲設定Button);
            FormsUtils.StartExpandAnimation(荊棘延遲GunaPanel);
        }

        private void 控場設定Button_Click(object sender, EventArgs e)
        {
            FormsUtils.ProcessSettingBtnClick(控場GunaPanel, 控場設定Button);
            FormsUtils.StartExpandAnimation(控場GunaPanel);
        }

        private void metroTabControlVS1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroTabControlVS1.SelectedTab.Name == TabPageCustomize.Name)
            {
                TopMostCheckBox.Visible = true;
                TopMostCheckBox.Location = CustomizeTopMostCheckBoxPos;
                this.Size = CustomizeTabWinFormsSize;
                this.metroTabControlVS1.Size = CustomizeMetroTabControlVS1Size;
                CopyrightTagLabel.Location = CustomizeTabCopyrightTagLabelPos;

                if (isLoadCustomizeConfig)
                {
                    this.TriggerLoadCustomizeConfig();
                }
            }
            else
            {
                if (metroTabControlVS1.SelectedTab.Name == TabPageAbout.Name || metroTabControlVS1.SelectedTab.Name == TabPageConfig.Name)
                {
                    TopMostCheckBox.Visible = false;
                }
                else
                {
                    TopMostCheckBox.Visible = true;
                }
                TopMostCheckBox.Location = TopMostCheckBoxOriginPos;
                this.Size = WindowsOriginSize;
                this.metroTabControlVS1.Size = metroTabControlVS1OriginSize;
                CopyrightTagLabel.Location = CopyrightTagLabelOriginPos;
            }
        }

        private void GoToGitHubButton_Click(object sender, EventArgs e)
        {
            Process.Start(FormsConstant.sourceCodeGitHubURL);
        }
    }
}
