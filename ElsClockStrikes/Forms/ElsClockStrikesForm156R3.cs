using ElsClockStrikes.Core;
using ElsClockStrikes.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ElsClockStrikes
{
    public partial class ElsClockStrikesForm
    {
        private Point 大黑LabelOriginPos;
        private Point 陰陽陣LabelOriginPos;
        private Point 三連LabelOriginPos;
        private Point 控場156R3LabelOriginPos;
        private AudioPlayer 大黑TimeupAudioPlayer;
        private AudioPlayer 陰陽陣TimeupAudioPlayer;
        private AudioPlayer 三連TimeupAudioPlayer;
        private AudioPlayer R3156控場TimeupAudioPlayer;
        private static bool IsFirstStart陰陽陣;
        private bool Is大黑Delay;
        private bool Is陰陽陣Delay;

        public static void InitFirstStart陰陽陣()
        {
            IsFirstStart陰陽陣 = true;
        }

        public void Process大黑Delay()
        {
            if (FormsConstant.大黑Time <= 80)
            {
                Is大黑Delay = true;
            }
        }

        public void Process陰陽陣Delay()
        {
            if (FormsConstant.陰陽陣Time <= 80)
            {
                Is陰陽陣Delay = true;
            }
        }

        private void 大黑Timer_Tick(object sender, EventArgs e)
        {
            if (Is大黑Delay)
            {
                FormsConstant.set大黑Time("80");
                Is大黑Delay = false;
            }

            大黑CDLabel.Text = FormsConstant.大黑Time == 0 ? "0" : (--FormsConstant.大黑Time).ToString();

            if (FormsConstant.大黑Time <= 10)
            {
                大黑CDLabel.ForeColor = Color.FromArgb(185, 45, 45);
            }
            else if (FormsConstant.大黑Time == Int32.Parse(大黑TextBox.Text) / 2)
            {
                大黑CDLabel.ForeColor = Color.FromArgb(185, 145, 52);
            }

            if (FormsConstant.大黑Time == 0)
            {
                FormsConstant.set大黑Time(大黑TextBox.Text);
                大黑Timer.Stop();
                if (預設音效156R3RadioButton.Checked || 自訂音效156R3RadioButton.Checked)
                {
                    大黑TimeupAudioPlayer.Play();
                }
            }
        }

        private void 陰陽陣Timer_Tick(object sender, EventArgs e)
        {
            if (IsFirstStart陰陽陣)
            {
                FormsConstant.set陰陽陣Time("290");
                IsFirstStart陰陽陣 = false;
            }
            if (Is陰陽陣Delay)
            {
                FormsConstant.set陰陽陣Time("80");
                Is陰陽陣Delay = false;
            }

            陰陽陣CDLabel.Text = FormsConstant.陰陽陣Time == 0 ? "0" : (--FormsConstant.陰陽陣Time).ToString();

            if (FormsConstant.陰陽陣Time <= 10)
            {
                陰陽陣CDLabel.ForeColor = Color.FromArgb(185, 45, 45);
            }
            else if (FormsConstant.陰陽陣Time == Int32.Parse(陰陽陣TextBox.Text) / 2)
            {
                陰陽陣CDLabel.ForeColor = Color.FromArgb(185, 145, 52);
            }

            if (FormsConstant.陰陽陣Time == 0)
            {
                FormsConstant.set陰陽陣Time(陰陽陣TextBox.Text);
                陰陽陣Timer.Stop();
                if (預設音效156R3RadioButton.Checked || 自訂音效156R3RadioButton.Checked)
                {
                    陰陽陣TimeupAudioPlayer.Play();
                }
            }
        }

        private void 三連Timer_Tick(object sender, EventArgs e)
        {
            三連CDLabel.Text = FormsConstant.三連Time == 0 ? "0" : (--FormsConstant.三連Time).ToString();

            if (FormsConstant.三連Time <= 10)
            {
                三連CDLabel.ForeColor = Color.FromArgb(185, 45, 45);
            }
            else if (FormsConstant.三連Time == Int32.Parse(三連TextBox.Text) / 2)
            {
                三連CDLabel.ForeColor = Color.FromArgb(185, 145, 52);
            }

            if (FormsConstant.三連Time == 0)
            {
                FormsConstant.set三連Time(三連TextBox.Text);
                三連Timer.Stop();
                if (預設音效156R3RadioButton.Checked || 自訂音效156R3RadioButton.Checked)
                {
                    三連TimeupAudioPlayer.Play();
                }
            }
        }

        private void R3156控場Timer_Tick(object sender, EventArgs e)
        {
            R3156控場CDLabel.Text = FormsConstant.R3156控場Time == 0 ? "0" : (--FormsConstant.R3156控場Time).ToString();

            if (FormsConstant.R3156控場Time <= 10)
            {
                R3156控場CDLabel.ForeColor = Color.FromArgb(185, 45, 45);
            }
            else if (FormsConstant.R3156控場Time == Int32.Parse(R3156控場TextBox.Text) / 2)
            {
                R3156控場CDLabel.ForeColor = Color.FromArgb(185, 145, 52);
            }

            if (FormsConstant.R3156控場Time == 0)
            {
                FormsConstant.setR3156控場Time(R3156控場TextBox.Text);
                R3156控場Timer.Stop();
                if (預設音效156R3RadioButton.Checked || 自訂音效156R3RadioButton.Checked)
                {
                    R3156控場TimeupAudioPlayer.Play();
                }
            }
        }

        private void ProcessWindowsSetting156R3(bool isBackToOriginCheck)
        {
            大黑CDLabel.Visible = !大黑CDLabel.Visible;
            陰陽陣CDLabel.Visible = !陰陽陣CDLabel.Visible;
            三連CDLabel.Visible = !三連CDLabel.Visible;
            R3156控場CDLabel.Visible = !R3156控場CDLabel.Visible;
            大黑按鍵Label.Visible = !大黑按鍵Label.Visible;
            陰陽陣按鍵Label.Visible = !陰陽陣按鍵Label.Visible;
            三連按鍵Label.Visible = !三連按鍵Label.Visible;
            R3156控場按鍵Label.Visible = !R3156控場按鍵Label.Visible;
            重置計時器156R3按鍵Label.Visible = !重置計時器156R3按鍵Label.Visible;
            ZoomOutControlBox.Visible = !ZoomOutControlBox.Visible;
            CloseControlBox.Visible = !CloseControlBox.Visible;
            metroTabControlVS1.Visible = !metroTabControlVS1.Visible;

            if (isBackToOriginCheck)
            {
                this.Controls.Remove(大黑按鍵Label);
                this.Controls.Remove(大黑Label);
                this.Controls.Remove(大黑CDLabel);
                this.Controls.Remove(陰陽陣按鍵Label);
                this.Controls.Remove(陰陽陣Label);
                this.Controls.Remove(陰陽陣CDLabel);
                this.Controls.Remove(三連按鍵Label);
                this.Controls.Remove(三連Label);
                this.Controls.Remove(三連CDLabel);
                this.Controls.Remove(R3156控場按鍵Label);
                this.Controls.Remove(R3156控場Label);
                this.Controls.Remove(R3156控場CDLabel);
                this.Controls.Remove(重置計時器156R3按鍵Label);
                this.Controls.Remove(重置計時器156R3Label);
                this.Controls.Remove(WindowsSetting156R3);

                TabPage156R3.Controls.Add(大黑按鍵Label);
                TabPage156R3.Controls.Add(大黑Label);
                TabPage156R3.Controls.Add(大黑CDLabel);
                TabPage156R3.Controls.Add(陰陽陣按鍵Label);
                TabPage156R3.Controls.Add(陰陽陣Label);
                TabPage156R3.Controls.Add(陰陽陣CDLabel);
                TabPage156R3.Controls.Add(三連按鍵Label);
                TabPage156R3.Controls.Add(三連Label);
                TabPage156R3.Controls.Add(三連CDLabel);
                TabPage156R3.Controls.Add(R3156控場按鍵Label);
                TabPage156R3.Controls.Add(R3156控場Label);
                TabPage156R3.Controls.Add(R3156控場CDLabel);
                TabPage156R3.Controls.Add(重置計時器156R3按鍵Label);
                TabPage156R3.Controls.Add(重置計時器156R3Label);
                TabPage156R3.Controls.Add(WindowsSetting156R3);
            }
            else
            {
                TabPage156R3.Controls.Remove(大黑按鍵Label);
                TabPage156R3.Controls.Remove(大黑Label);
                TabPage156R3.Controls.Remove(大黑CDLabel);
                TabPage156R3.Controls.Remove(陰陽陣按鍵Label);
                TabPage156R3.Controls.Remove(陰陽陣Label);
                TabPage156R3.Controls.Remove(陰陽陣CDLabel);
                TabPage156R3.Controls.Remove(三連按鍵Label);
                TabPage156R3.Controls.Remove(三連Label);
                TabPage156R3.Controls.Remove(三連CDLabel);
                TabPage156R3.Controls.Remove(R3156控場按鍵Label);
                TabPage156R3.Controls.Remove(R3156控場Label);
                TabPage156R3.Controls.Remove(R3156控場CDLabel);
                TabPage156R3.Controls.Remove(重置計時器156R3按鍵Label);
                TabPage156R3.Controls.Remove(重置計時器156R3Label);
                TabPage156R3.Controls.Remove(WindowsSetting156R3);

                this.Controls.Add(大黑按鍵Label);
                this.Controls.Add(大黑Label);
                this.Controls.Add(大黑CDLabel);
                this.Controls.Add(陰陽陣按鍵Label);
                this.Controls.Add(陰陽陣Label);
                this.Controls.Add(陰陽陣CDLabel);
                this.Controls.Add(三連按鍵Label);
                this.Controls.Add(三連Label);
                this.Controls.Add(三連CDLabel);
                this.Controls.Add(R3156控場按鍵Label);
                this.Controls.Add(R3156控場Label);
                this.Controls.Add(R3156控場CDLabel);
                this.Controls.Add(重置計時器156R3按鍵Label);
                this.Controls.Add(重置計時器156R3Label);
                this.Controls.Add(WindowsSetting156R3);
            }

            this.Size = isBackToOriginCheck ? WindowsOriginSize : new Size(180, 225);

            int MaxLabelWidth = FormsUtils.GetLabelMaxWidth(this);
            int KeyLabelAddY = 40;
            大黑按鍵Label.Location = new Point(5, 30);
            大黑Label.Location = isBackToOriginCheck ? 大黑LabelOriginPos : new Point(MaxLabelWidth - 大黑Label.Width + 大黑按鍵Label.Width - 5, 大黑按鍵Label.Top + 大黑按鍵Label.Height - 大黑Label.Height - 3);
            大黑CDLabel.Location = new Point(大黑Label.Left + 大黑Label.Width, 大黑按鍵Label.Location.Y);

            陰陽陣按鍵Label.Location = new Point(大黑按鍵Label.Location.X, 大黑按鍵Label.Location.Y + KeyLabelAddY);
            陰陽陣Label.Location = isBackToOriginCheck ? 陰陽陣LabelOriginPos : new Point(大黑Label.Left + 大黑Label.Width - 陰陽陣Label.Width, 陰陽陣按鍵Label.Top + 陰陽陣按鍵Label.Height - 陰陽陣Label.Height - 3);
            陰陽陣CDLabel.Location = new Point(陰陽陣Label.Left + 陰陽陣Label.Width, 陰陽陣按鍵Label.Location.Y);

            三連按鍵Label.Location = new Point(陰陽陣按鍵Label.Location.X, 陰陽陣按鍵Label.Location.Y + KeyLabelAddY);
            三連Label.Location = isBackToOriginCheck ? 三連LabelOriginPos : new Point(大黑Label.Left + 大黑Label.Width - 三連Label.Width, 三連按鍵Label.Top + 三連按鍵Label.Height - 三連Label.Height - 3);
            三連CDLabel.Location = new Point(三連Label.Left + 三連Label.Width, 三連按鍵Label.Location.Y);

            R3156控場按鍵Label.Location = new Point(三連按鍵Label.Location.X, 三連按鍵Label.Location.Y + KeyLabelAddY);
            R3156控場Label.Location = isBackToOriginCheck ? 控場156R3LabelOriginPos : new Point(大黑Label.Left + 大黑Label.Width - R3156控場Label.Width, R3156控場按鍵Label.Top + R3156控場按鍵Label.Height - R3156控場Label.Height - 3);
            R3156控場CDLabel.Location = new Point(R3156控場Label.Left + R3156控場Label.Width, R3156控場按鍵Label.Location.Y);

            重置計時器156R3按鍵Label.Location = new Point(R3156控場按鍵Label.Location.X, R3156控場按鍵Label.Location.Y + KeyLabelAddY);
            重置計時器156R3Label.Location = isBackToOriginCheck ? 重置計時器LabelOriginPos : new Point(大黑Label.Left + 大黑Label.Width - 重置計時器156R3Label.Width + 27, 重置計時器156R3按鍵Label.Top + 重置計時器156R3按鍵Label.Height - 重置計時器156R3Label.Height - 3); ;
            TopMostCheckBox.Visible = !TopMostCheckBox.Visible;
            WindowsSetting156R3.Location = isBackToOriginCheck ? WindowsSettingOriginPos : new Point(130, 5);

            大黑按鍵Label.Text = FormsUtils.ProcessLayoutString(大黑ComboBox.Text);
            陰陽陣按鍵Label.Text = FormsUtils.ProcessLayoutString(陰陽陣ComboBox.Text);
            三連按鍵Label.Text = FormsUtils.ProcessLayoutString(三連ComboBox.Text);
            R3156控場按鍵Label.Text = FormsUtils.ProcessLayoutString(R3156控場ComboBox.Text);
            重置計時器156R3按鍵Label.Text = FormsUtils.ProcessLayoutString(重置計時器156R3ComboBox.Text);
            大黑CDLabel.Text = 大黑TextBox.Text;
            陰陽陣CDLabel.Text = 陰陽陣TextBox.Text;
            三連CDLabel.Text = 三連TextBox.Text;
            R3156控場CDLabel.Text = R3156控場TextBox.Text;
        }

        private void ProcessRegisterHotKey156R3(bool isBackToOriginCheck)
        {
            if (isBackToOriginCheck)
            {
                hotKeyManager.Dispose();
            }
            else
            {
                hotKeyManager = new HotKeyManager(this.TabPage156R3, typeof(ElsClockStrikesForm));
                Dictionary<string, List<HotKeyContainer>> keyMapWithContainer = hotKeyManager.GetKeyMapWithContainer();
                int isCanBreakCount = 0;
                foreach (KeyValuePair<string, List<HotKeyContainer>> kvp in keyMapWithContainer)
                {
                    if (kvp.Key.Equals(重置計時器156R3ComboBox.Text))
                    {
                        foreach (HotKeyContainer hotKeyContainer in kvp.Value)
                        {
                            hotKeyContainer.actionMethod = typeof(ElsClockStrikesForm).GetMethod("InitFirstStart陰陽陣");
                        }
                        isCanBreakCount++;
                    }

                    if (kvp.Key.Equals(大黑ComboBox.Text))
                    {
                        foreach (HotKeyContainer hotKeyContainer in kvp.Value)
                        {
                            hotKeyContainer.actionMethod = typeof(ElsClockStrikesForm).GetMethod("Process陰陽陣Delay");
                        }
                        isCanBreakCount++;
                    }

                    if (kvp.Key.Equals(陰陽陣ComboBox.Text))
                    {
                        foreach (HotKeyContainer hotKeyContainer in kvp.Value)
                        {
                            hotKeyContainer.actionMethod = typeof(ElsClockStrikesForm).GetMethod("Process大黑Delay");
                        }
                        isCanBreakCount++;
                    }

                    if (isCanBreakCount == 3)
                    {
                        break;
                    }
                }
            }
        }

        private void WindowsSetting156R3_Click(object sender, EventArgs e)
        {
            if (WindowsSetting156R3.Text.Equals("設定完成"))
            {
                WindowsSetting156R3.BaseColor = Color.FromArgb(40, 40, 40);
                WindowsSetting156R3.OnHoverBaseColor = Color.FromArgb(120, 120, 120);
                WindowsSetting156R3.Text = "";
                WindowsSetting156R3.Image = Properties.Resources.setimg;
                WindowsSetting156R3.Size = new Size(43, 25);
                this.ProcessRegisterHotKey156R3(false);
                this.ProcessWindowsSetting156R3(false);
                FormsConstant.init156R3Timer(大黑TextBox.Text, 陰陽陣TextBox.Text, 三連TextBox.Text, R3156控場TextBox.Text);
            }
            else
            {
                WindowsSetting156R3.BaseColor = Color.FromArgb(184, 44, 44);
                WindowsSetting156R3.OnHoverBaseColor = Color.FromArgb(150, 20, 20);
                WindowsSetting156R3.Text = "設定完成";
                WindowsSetting156R3.Image = null;
                WindowsSetting156R3.Size = WindowsSettingButtonOriginSize;
                this.ProcessRegisterHotKey156R3(true);
                this.ProcessWindowsSetting156R3(true);
                InitFirstStart陰陽陣();
            }
        }

        private void 大黑TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormsUtils.ProcessKeyPress(e);
        }

        private void 陰陽陣TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormsUtils.ProcessKeyPress(e);
        }

        private void 三連TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormsUtils.ProcessKeyPress(e);
        }

        private void R3156控場TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormsUtils.ProcessKeyPress(e);
        }

        private void LoadDefaultSound156R3()
        {
            大黑TimeupAudioPlayer = new AudioPlayer(Properties.Resources.小荊棘大招大黑DefultSound);
            陰陽陣TimeupAudioPlayer = new AudioPlayer(Properties.Resources.雷射大刺三連DefultSound);
            三連TimeupAudioPlayer = new AudioPlayer(Properties.Resources.荊棘延遲翻桌陰陽陣DefultSound);
            R3156控場TimeupAudioPlayer = new AudioPlayer(Properties.Resources.控場DefultSound);
        }

        private void 預設音效156R3RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadDefaultSound156R3();
        }

        private void 自訂音效156R3RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (自訂音效156R3RadioButton.Checked)
            {
                大黑設定音效Button.Enabled = true;
                陰陽陣設定音效Button.Enabled = true;
                三連設定音效Button.Enabled = true;
                R3156控場設定音效Button.Enabled = true;
            }
            else
            {
                大黑設定音效Button.Enabled = false;
                陰陽陣設定音效Button.Enabled = false;
                三連設定音效Button.Enabled = false;
                R3156控場設定音效Button.Enabled = false;
            }
            this.LoadDefaultSound156R3();
        }

        private void 關閉音效156R3RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            大黑TimeupAudioPlayer = null;
            陰陽陣TimeupAudioPlayer = null;
            三連TimeupAudioPlayer = null;
            R3156控場TimeupAudioPlayer = null;
        }

        private void 大黑設定音效Button_Click(object sender, EventArgs e)
        {
            大黑TimeupAudioPlayer = FormsUtils.ProcessSelectSoundFile(Properties.Resources.小荊棘大招大黑DefultSound);
        }

        private void 陰陽陣設定音效Button_Click(object sender, EventArgs e)
        {
            陰陽陣TimeupAudioPlayer = FormsUtils.ProcessSelectSoundFile(Properties.Resources.雷射大刺三連DefultSound);
        }

        private void 三連設定音效Button_Click(object sender, EventArgs e)
        {
            三連TimeupAudioPlayer = FormsUtils.ProcessSelectSoundFile(Properties.Resources.荊棘延遲翻桌陰陽陣DefultSound);
        }

        private void R3156控場設定音效Button_Click(object sender, EventArgs e)
        {
            R3156控場TimeupAudioPlayer = FormsUtils.ProcessSelectSoundFile(Properties.Resources.控場DefultSound);
        }

        private void 大黑設定Button_Click(object sender, EventArgs e)
        {
            FormsUtils.ProcessSettingBtnClick(大黑GunaPanel, 大黑設定Button);
            FormsUtils.StartExpandAnimation(大黑GunaPanel);
        }

        private void 陰陽陣設定Button_Click(object sender, EventArgs e)
        {
            FormsUtils.ProcessSettingBtnClick(陰陽陣GunaPanel, 陰陽陣設定Button);
            FormsUtils.StartExpandAnimation(陰陽陣GunaPanel);
        }

        private void 三連設定Button_Click(object sender, EventArgs e)
        {
            FormsUtils.ProcessSettingBtnClick(三連GunaPanel, 三連設定Button);
            FormsUtils.StartExpandAnimation(三連GunaPanel);
        }

        private void R3156控場設定Button_Click(object sender, EventArgs e)
        {
            FormsUtils.ProcessSettingBtnClick(R3156控場GunaPanel, R3156控場設定Button);
            FormsUtils.StartExpandAnimation(R3156控場GunaPanel);
        }
    }
}
