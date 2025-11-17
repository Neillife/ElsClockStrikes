using ElsClockStrikes.Core;
using ElsClockStrikes.Forms;
using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ElsClockStrikes
{
    public partial class ElsClockStrikesForm
    {
        private Point 大招LabelOriginPos;
        private Point 大刺LabelOriginPos;
        private Point 翻桌LabelOriginPos;
        private Point 控場156R1LabelOriginPos;
        private AudioPlayer 大招TimeupAudioPlayer;
        private AudioPlayer 大刺TimeupAudioPlayer;
        private AudioPlayer 翻桌TimeupAudioPlayer;
        private AudioPlayer R1156控場TimeupAudioPlayer;

        private void 大招Timer_Tick(object sender, EventArgs e)
        {
            大招CDLabel.Text = FormsConstant.大招Time == 0 ? "0" : (--FormsConstant.大招Time).ToString();

            if (FormsConstant.大招Time <= 10)
            {
                大招CDLabel.ForeColor = Color.FromArgb(185, 45, 45);
            }
            else if (FormsConstant.大招Time == Int32.Parse(大招TextBox.Text) / 2)
            {
                大招CDLabel.ForeColor = Color.FromArgb(185, 145, 52);
            }

            if (FormsConstant.大招Time == 0)
            {
                FormsConstant.set大招Time(大招TextBox.Text);
                大招Timer.Stop();
                if (預設音效156R1RadioButton.Checked || 自訂音效156R1RadioButton.Checked)
                {
                    大招TimeupAudioPlayer.Play();
                }
            }
        }

        private void 大刺Timer_Tick(object sender, EventArgs e)
        {
            大刺CDLabel.Text = FormsConstant.大刺Time == 0 ? "0" : (--FormsConstant.大刺Time).ToString();

            if (FormsConstant.大刺Time <= 10)
            {
                大刺CDLabel.ForeColor = Color.FromArgb(185, 45, 45);
            }
            else if (FormsConstant.大刺Time == Int32.Parse(大刺TextBox.Text) / 2)
            {
                大刺CDLabel.ForeColor = Color.FromArgb(185, 145, 52);
            }

            if (FormsConstant.大刺Time == 0)
            {
                FormsConstant.set大刺Time(大刺TextBox.Text);
                大刺Timer.Stop();
                if (預設音效156R1RadioButton.Checked || 自訂音效156R1RadioButton.Checked)
                {
                    大刺TimeupAudioPlayer.Play();
                }
            }
        }

        private void 翻桌Timer_Tick(object sender, EventArgs e)
        {
            翻桌CDLabel.Text = FormsConstant.翻桌Time == 0 ? "0" : (--FormsConstant.翻桌Time).ToString();

            if (FormsConstant.翻桌Time <= 10)
            {
                翻桌CDLabel.ForeColor = Color.FromArgb(185, 45, 45);
            }
            else if (FormsConstant.翻桌Time == Int32.Parse(翻桌TextBox.Text) / 2)
            {
                翻桌CDLabel.ForeColor = Color.FromArgb(185, 145, 52);
            }

            if (FormsConstant.翻桌Time == 0)
            {
                FormsConstant.set翻桌Time(翻桌TextBox.Text);
                翻桌Timer.Stop();
                if (預設音效156R1RadioButton.Checked || 自訂音效156R1RadioButton.Checked)
                {
                    翻桌TimeupAudioPlayer.Play();
                }
            }
        }

        private void R1156控場Timer_Tick(object sender, EventArgs e)
        {
            R1156控場CDLabel.Text = FormsConstant.R1156控場Time == 0 ? "0" : (--FormsConstant.R1156控場Time).ToString();

            if (FormsConstant.R1156控場Time <= 10)
            {
                R1156控場CDLabel.ForeColor = Color.FromArgb(185, 45, 45);
            }
            else if (FormsConstant.R1156控場Time == Int32.Parse(R1156控場TextBox.Text) / 2)
            {
                R1156控場CDLabel.ForeColor = Color.FromArgb(185, 145, 52);
            }

            if (FormsConstant.R1156控場Time == 0)
            {
                FormsConstant.setR1156控場Time(R1156控場TextBox.Text);
                R1156控場Timer.Stop();
                if (預設音效156R1RadioButton.Checked || 自訂音效156R1RadioButton.Checked)
                {
                    R1156控場TimeupAudioPlayer.Play();
                }
            }
        }

        private void ProcessComponentDisplay156R1(bool isBackToOriginCheck)
        {
            if (isBackToOriginCheck)
            {
                this.Controls.Remove(大招按鍵Label);
                this.Controls.Remove(大招Label);
                this.Controls.Remove(大招CDLabel);
                this.Controls.Remove(大刺按鍵Label);
                this.Controls.Remove(大刺Label);
                this.Controls.Remove(大刺CDLabel);
                this.Controls.Remove(翻桌按鍵Label);
                this.Controls.Remove(翻桌Label);
                this.Controls.Remove(翻桌CDLabel);
                this.Controls.Remove(R1156控場按鍵Label);
                this.Controls.Remove(R1156控場Label);
                this.Controls.Remove(R1156控場CDLabel);
                this.Controls.Remove(重置計時器156R1按鍵Label);
                this.Controls.Remove(重置計時器156R1Label);
                this.Controls.Remove(WindowsSetting156R1);

                TabPage156R1.Controls.Add(大招按鍵Label);
                TabPage156R1.Controls.Add(大招Label);
                TabPage156R1.Controls.Add(大招CDLabel);
                TabPage156R1.Controls.Add(大刺按鍵Label);
                TabPage156R1.Controls.Add(大刺Label);
                TabPage156R1.Controls.Add(大刺CDLabel);
                TabPage156R1.Controls.Add(翻桌按鍵Label);
                TabPage156R1.Controls.Add(翻桌Label);
                TabPage156R1.Controls.Add(翻桌CDLabel);
                TabPage156R1.Controls.Add(R1156控場按鍵Label);
                TabPage156R1.Controls.Add(R1156控場Label);
                TabPage156R1.Controls.Add(R1156控場CDLabel);
                TabPage156R1.Controls.Add(重置計時器156R1按鍵Label);
                TabPage156R1.Controls.Add(重置計時器156R1Label);
                TabPage156R1.Controls.Add(WindowsSetting156R1);
            }
            else
            {
                TabPage156R1.Controls.Remove(大招按鍵Label);
                TabPage156R1.Controls.Remove(大招Label);
                TabPage156R1.Controls.Remove(大招CDLabel);
                TabPage156R1.Controls.Remove(大刺按鍵Label);
                TabPage156R1.Controls.Remove(大刺Label);
                TabPage156R1.Controls.Remove(大刺CDLabel);
                TabPage156R1.Controls.Remove(翻桌按鍵Label);
                TabPage156R1.Controls.Remove(翻桌Label);
                TabPage156R1.Controls.Remove(翻桌CDLabel);
                TabPage156R1.Controls.Remove(R1156控場按鍵Label);
                TabPage156R1.Controls.Remove(R1156控場Label);
                TabPage156R1.Controls.Remove(R1156控場CDLabel);
                TabPage156R1.Controls.Remove(重置計時器156R1按鍵Label);
                TabPage156R1.Controls.Remove(重置計時器156R1Label);
                TabPage156R1.Controls.Remove(WindowsSetting156R1);

                this.Controls.Add(大招按鍵Label);
                this.Controls.Add(大招Label);
                this.Controls.Add(大招CDLabel);
                this.Controls.Add(大刺按鍵Label);
                this.Controls.Add(大刺Label);
                this.Controls.Add(大刺CDLabel);
                this.Controls.Add(翻桌按鍵Label);
                this.Controls.Add(翻桌Label);
                this.Controls.Add(翻桌CDLabel);
                this.Controls.Add(R1156控場按鍵Label);
                this.Controls.Add(R1156控場Label);
                this.Controls.Add(R1156控場CDLabel);
                this.Controls.Add(重置計時器156R1按鍵Label);
                this.Controls.Add(重置計時器156R1Label);
                this.Controls.Add(WindowsSetting156R1);
            }
        }

        private void ProcessFormInstance156R1(bool isBackToOriginCheck)
        {
            if (isBackToOriginCheck)
            {
                if (formTimerInstancePos == null)
                {
                    formTimerInstancePos = new Dictionary<string, Point>();
                }
                foreach (ElsClockStrikesFormTimerInstance timerInstance in formTimerInstances)
                {
                    formTimerInstancePos[timerInstance.GetMechanicName().Replace("Label", "")] = timerInstance.Location;
                    timerInstance.Close();
                }
                this.Size = WindowsOriginSize;
                大招Label.Location = 大招LabelOriginPos;
                大刺Label.Location = 大刺LabelOriginPos;
                翻桌Label.Location = 翻桌LabelOriginPos;
                R1156控場Label.Location = 控場156R1LabelOriginPos;
                重置計時器156R1Label.Location = 重置計時器LabelOriginPos;
                TopMostCheckBox.Visible = true;
                WindowsSetting156R1.Location = WindowsSettingOriginPos;
            }
            else
            {
                int MaxLabelWidth = FormsUtils.GetLabelMaxWidth(this);
                int KeyLabelAddY = 40;
                Dictionary<string, FormInstanceParameters> nonInstanceMap = new Dictionary<string, FormInstanceParameters>();
                List<GunaCheckBox> cbList = FormsUtils.GetFormInstanceCheckBoxListByMechanicNames(this.TabPage156R1, FormsConstant.tipNames156R1);
                Dictionary<string, FormInstanceParameters> fipMap = FormsUtils.GetFIPMapByMechanicNames(this, FormsConstant.tipNames156R1);
                formTimerInstances = new List<ElsClockStrikesFormTimerInstance>();
                foreach (GunaCheckBox checkBox in cbList)
                {
                    string fipMapKey = checkBox.Name.Replace("分離視窗CheckBox", "");
                    if (checkBox.Checked)
                    {
                        if (formTimerInstancePos != null && formTimerInstancePos.ContainsKey(fipMapKey))
                        {
                            formTimerInstances.Add(new ElsClockStrikesFormTimerInstance(fipMap[fipMapKey], WindowsSetting156R1, MaxLabelWidth, this.TopMost, formTimerInstancePos[fipMapKey]));
                        }
                        else
                        {
                            formTimerInstances.Add(new ElsClockStrikesFormTimerInstance(fipMap[fipMapKey], WindowsSetting156R1, MaxLabelWidth, this.TopMost));
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

                this.Size = new Size(180, 225 - formTimerInstances.Count * 39);
                Label firstNameLabel = null;
                Label labelSign = null;
                bool firstCheck = false;

                foreach (KeyValuePair<string, FormInstanceParameters> kvp in nonInstanceMap)
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

                重置計時器156R1按鍵Label.Location = nonInstanceMap.Count == 0 ? new Point(5, 30) : new Point(labelSign.Location.X, labelSign.Location.Y + KeyLabelAddY);
                重置計時器156R1Label.Location = nonInstanceMap.Count == 0 ? new Point(58, 37) : new Point(firstNameLabel.Left + firstNameLabel.Width - 重置計時器156R1Label.Width + 27, 重置計時器156R1按鍵Label.Top + 重置計時器156R1按鍵Label.Height - 重置計時器156R1Label.Height - 3);
                TopMostCheckBox.Visible = false;
                WindowsSetting156R1.Location = new Point(130, 5);
            }
        }

        private void ProcessWindowsSetting156R1(bool isBackToOriginCheck)
        {
            大招CDLabel.Visible = !大招CDLabel.Visible;
            大刺CDLabel.Visible = !大刺CDLabel.Visible;
            翻桌CDLabel.Visible = !翻桌CDLabel.Visible;
            R1156控場CDLabel.Visible = !R1156控場CDLabel.Visible;
            大招按鍵Label.Visible = !大招按鍵Label.Visible;
            大刺按鍵Label.Visible = !大刺按鍵Label.Visible;
            翻桌按鍵Label.Visible = !翻桌按鍵Label.Visible;
            R1156控場按鍵Label.Visible = !R1156控場按鍵Label.Visible;
            重置計時器156R1按鍵Label.Visible = !重置計時器156R1按鍵Label.Visible;
            ZoomOutControlBox.Visible = !ZoomOutControlBox.Visible;
            CloseControlBox.Visible = !CloseControlBox.Visible;
            metroTabControlVS1.Visible = !metroTabControlVS1.Visible;

            ProcessComponentDisplay156R1(isBackToOriginCheck);
            ProcessFormInstance156R1(isBackToOriginCheck);

            大招按鍵Label.Text = FormsUtils.ProcessLayoutString(大招ComboBox.Text);
            大刺按鍵Label.Text = FormsUtils.ProcessLayoutString(大刺ComboBox.Text);
            翻桌按鍵Label.Text = FormsUtils.ProcessLayoutString(翻桌ComboBox.Text);
            R1156控場按鍵Label.Text = FormsUtils.ProcessLayoutString(R1156控場ComboBox.Text);
            重置計時器156R1按鍵Label.Text = FormsUtils.ProcessLayoutString(重置計時器156R1ComboBox.Text);
            大招CDLabel.Text = 大招TextBox.Text;
            大刺CDLabel.Text = 大刺TextBox.Text;
            翻桌CDLabel.Text = 翻桌TextBox.Text;
            R1156控場CDLabel.Text = R1156控場TextBox.Text;
        }

        private void ProcessRegisterHotKey156R1(bool isBackToOriginCheck)
        {
            if (isBackToOriginCheck)
            {
                hotKeyManager.Dispose();
            }
            else
            {
                hotKeyManager = new HotKeyManager(this.TabPage156R1, typeof(ElsClockStrikesForm));
            }
        }

        private void WindowsSetting156R1_Click(object sender, EventArgs e)
        {
            if (WindowsSetting156R1.Text.Equals("設定完成"))
            {
                WindowsSetting156R1.BaseColor = Color.FromArgb(40, 40, 40);
                WindowsSetting156R1.OnHoverBaseColor = Color.FromArgb(120, 120, 120);
                WindowsSetting156R1.Text = "";
                WindowsSetting156R1.Image = Properties.Resources.setimg;
                WindowsSetting156R1.Size = new Size(43, 25);
                this.ProcessRegisterHotKey156R1(false);
                this.ProcessWindowsSetting156R1(false);
                this.ProcessSoundVolume156R1();
                FormsConstant.init156R1Timer(大招TextBox.Text, 大刺TextBox.Text, 翻桌TextBox.Text, R1156控場TextBox.Text);
            }
            else
            {
                WindowsSetting156R1.BaseColor = Color.FromArgb(184, 44, 44);
                WindowsSetting156R1.OnHoverBaseColor = Color.FromArgb(150, 20, 20);
                WindowsSetting156R1.Text = "設定完成";
                WindowsSetting156R1.Image = null;
                WindowsSetting156R1.Size = WindowsSettingButtonOriginSize;
                this.ProcessRegisterHotKey156R1(true);
                this.ProcessWindowsSetting156R1(true);
            }
        }

        private void 大招TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormsUtils.ProcessKeyPress(e);
        }

        private void 大刺TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormsUtils.ProcessKeyPress(e);
        }

        private void 翻桌TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormsUtils.ProcessKeyPress(e);
        }

        private void R1156控場TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormsUtils.ProcessKeyPress(e);
        }

        private void 大招音量TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormsUtils.ProcessKeyPress(e);
        }

        private void 大刺音量TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormsUtils.ProcessKeyPress(e);
        }

        private void 翻桌音量TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormsUtils.ProcessKeyPress(e);
        }

        private void R1156控場音量TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormsUtils.ProcessKeyPress(e);
        }

        private void 大招音量TextBox_Leave(object sender, EventArgs e)
        {
            FormsUtils.ProcessSoundTextBoxLeave(大招音量TextBox);
        }

        private void 大刺音量TextBox_Leave(object sender, EventArgs e)
        {
            FormsUtils.ProcessSoundTextBoxLeave(大刺音量TextBox);
        }

        private void 翻桌音量TextBox_Leave(object sender, EventArgs e)
        {
            FormsUtils.ProcessSoundTextBoxLeave(翻桌音量TextBox);
        }

        private void R1156控場音量TextBox_Leave(object sender, EventArgs e)
        {
            FormsUtils.ProcessSoundTextBoxLeave(R1156控場音量TextBox);
        }

        private void ProcessSoundVolume156R1()
        {
            if (大招TimeupAudioPlayer != null)
            {
                FormsUtils.ProcessSoundTextBoxLeave(大招音量TextBox);
                大招TimeupAudioPlayer.Volume = Int32.Parse(大招音量TextBox.Text) / 100f;
            }
            if (大刺TimeupAudioPlayer != null)
            {
                FormsUtils.ProcessSoundTextBoxLeave(大刺音量TextBox);
                大刺TimeupAudioPlayer.Volume = Int32.Parse(大刺音量TextBox.Text) / 100f;
            }
            if (翻桌TimeupAudioPlayer != null)
            {
                FormsUtils.ProcessSoundTextBoxLeave(翻桌音量TextBox);
                翻桌TimeupAudioPlayer.Volume = Int32.Parse(翻桌音量TextBox.Text) / 100f;
            }
            if (R1156控場TimeupAudioPlayer != null)
            {
                FormsUtils.ProcessSoundTextBoxLeave(R1156控場音量TextBox);
                R1156控場TimeupAudioPlayer.Volume = Int32.Parse(R1156控場音量TextBox.Text) / 100f;
            }
        }

        private void LoadDefaultSound156R1()
        {
            大招TimeupAudioPlayer = new AudioPlayer(Properties.Resources.小荊棘大招大黑DefultSound);
            大刺TimeupAudioPlayer = new AudioPlayer(Properties.Resources.雷射大刺三連DefultSound);
            翻桌TimeupAudioPlayer = new AudioPlayer(Properties.Resources.荊棘延遲翻桌陰陽陣DefultSound);
            R1156控場TimeupAudioPlayer = new AudioPlayer(Properties.Resources.控場DefultSound);
        }

        private void 預設音效156R1RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadDefaultSound156R1();
        }

        private void 自訂音效156R1RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (自訂音效156R1RadioButton.Checked)
            {
                大招設定音效Button.Enabled = true;
                大刺設定音效Button.Enabled = true;
                翻桌設定音效Button.Enabled = true;
                R1156控場設定音效Button.Enabled = true;
            }
            else
            {
                大招設定音效Button.Enabled = false;
                大刺設定音效Button.Enabled = false;
                翻桌設定音效Button.Enabled = false;
                R1156控場設定音效Button.Enabled = false;
            }
            this.LoadDefaultSound156R1();
        }

        private void 關閉音效156R1RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            大招TimeupAudioPlayer = null;
            大刺TimeupAudioPlayer = null;
            翻桌TimeupAudioPlayer = null;
            R1156控場TimeupAudioPlayer = null;
        }

        private void 大招設定音效Button_Click(object sender, EventArgs e)
        {
            大招TimeupAudioPlayer = FormsUtils.ProcessSelectSoundFile(Properties.Resources.小荊棘大招大黑DefultSound);
        }

        private void 大刺設定音效Button_Click(object sender, EventArgs e)
        {
            大刺TimeupAudioPlayer = FormsUtils.ProcessSelectSoundFile(Properties.Resources.雷射大刺三連DefultSound);
        }

        private void 翻桌設定音效Button_Click(object sender, EventArgs e)
        {
            翻桌TimeupAudioPlayer = FormsUtils.ProcessSelectSoundFile(Properties.Resources.荊棘延遲翻桌陰陽陣DefultSound);
        }

        private void R1156控場設定音效Button_Click(object sender, EventArgs e)
        {
            R1156控場TimeupAudioPlayer = FormsUtils.ProcessSelectSoundFile(Properties.Resources.控場DefultSound);
        }

        private void 大招設定Button_Click(object sender, EventArgs e)
        {
            FormsUtils.ProcessSettingBtnClick(大招GunaPanel, 大招設定Button);
            FormsUtils.StartExpandAnimation(大招GunaPanel);
        }

        private void 大刺設定Button_Click(object sender, EventArgs e)
        {
            FormsUtils.ProcessSettingBtnClick(大刺GunaPanel, 大刺設定Button);
            FormsUtils.StartExpandAnimation(大刺GunaPanel);
        }

        private void 翻桌設定Button_Click(object sender, EventArgs e)
        {
            FormsUtils.ProcessSettingBtnClick(翻桌GunaPanel, 翻桌設定Button);
            FormsUtils.StartExpandAnimation(翻桌GunaPanel);
        }

        private void R1156控場設定Button_Click(object sender, EventArgs e)
        {
            FormsUtils.ProcessSettingBtnClick(R1156控場GunaPanel, R1156控場設定Button);
            FormsUtils.StartExpandAnimation(R1156控場GunaPanel);
        }
    }
}
