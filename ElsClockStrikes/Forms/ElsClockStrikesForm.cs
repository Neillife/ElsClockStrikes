using System;
using System.Windows.Forms;
using ElsClockStrikes.Forms;
using ElsClockStrikes.Core;
using MetroSuite;
using System.Drawing;

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
        private Size WindowsOriginSize;
        private AudioPlayer 小荊棘TimeupAudioPlayer;
        private AudioPlayer 雷射TimeupAudioPlayer;
        private AudioPlayer 荊棘延遲TimeupAudioPlayer;
        private AudioPlayer 控場TimeupAudioPlayer;
        private HotKeyManager hotKeyManager;

        public ElsClockStrikesForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            小荊棘LabelOriginPos = 小荊棘Label.Location;
            雷射LabelOriginPos = 雷射Label.Location;
            荊棘延遲LabelOriginPos = 荊棘延遲Label.Location;
            控場LabelOriginPos = 控場Label.Location;
            重置計時器LabelOriginPos = 重置計時器Label.Location;
            TopMostCheckBoxOriginPos = TopMostCheckBox.Location;
            WindowsSettingOriginPos = WindowsSetting.Location;
            WindowsOriginSize = this.Size;

            大招LabelOriginPos = 大招Label.Location;
            大刺LabelOriginPos = 大刺Label.Location;
            翻桌LabelOriginPos = 翻桌Label.Location;
            控場156R1LabelOriginPos = R1156控場Label.Location;

            大黑LabelOriginPos = 大黑Label.Location;
            陰陽陣LabelOriginPos = 陰陽陣Label.Location;
            三連LabelOriginPos = 三連Label.Location;
            控場156R3LabelOriginPos = R3156控場Label.Location;

            預設音效RadioButton.Checked = true;
            預設音效156R1RadioButton.Checked = true;
            預設音效156R3RadioButton.Checked = true;
            CopyrightTagLabel.Text = FormsConstant.copyrightTag;
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
            this.TopMost = !this.TopMost;
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
                this.Controls.Remove(TopMostCheckBox);
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
                TabPage127R3.Controls.Add(TopMostCheckBox);
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
                TabPage127R3.Controls.Remove(TopMostCheckBox);
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
                this.Controls.Add(TopMostCheckBox);
                this.Controls.Add(WindowsSetting);
            }

            this.Size = isBackToOriginCheck ? WindowsOriginSize : new Size(180, 330);

            int MaxLabelWidth = FormsUtils.GetLabelMaxWidth(this);
            int KeyLabelAddY = 40;
            小荊棘按鍵Label.Location = new Point(5, 30);
            小荊棘Label.Location = isBackToOriginCheck ? 小荊棘LabelOriginPos : new Point(MaxLabelWidth - 小荊棘Label.Width + 小荊棘按鍵Label.Width - 5, 小荊棘按鍵Label.Top + 小荊棘按鍵Label.Height - 小荊棘Label.Height - 3);
            小荊棘CDLabel.Location = new Point(小荊棘Label.Left + 小荊棘Label.Width, 小荊棘按鍵Label.Location.Y);

            雷射按鍵Label.Location = new Point(小荊棘按鍵Label.Location.X, 小荊棘按鍵Label.Location.Y + KeyLabelAddY);
            雷射Label.Location = isBackToOriginCheck ? 雷射LabelOriginPos : new Point(小荊棘Label.Left + 小荊棘Label.Width - 雷射Label.Width, 雷射按鍵Label.Top + 雷射按鍵Label.Height - 雷射Label.Height - 3);
            雷射CDLabel.Location = new Point(雷射Label.Left + 雷射Label.Width, 雷射按鍵Label.Location.Y);

            荊棘延遲按鍵Label.Location = new Point(雷射按鍵Label.Location.X, 雷射按鍵Label.Location.Y + KeyLabelAddY);
            荊棘延遲Label.Location = isBackToOriginCheck ? 荊棘延遲LabelOriginPos : new Point(小荊棘Label.Left + 小荊棘Label.Width - 荊棘延遲Label.Width, 荊棘延遲按鍵Label.Top + 荊棘延遲按鍵Label.Height - 荊棘延遲Label.Height - 3);
            荊棘延遲CDLabel.Location = new Point(荊棘延遲Label.Left + 荊棘延遲Label.Width, 荊棘延遲按鍵Label.Location.Y);

            控場按鍵Label.Location = new Point(荊棘延遲按鍵Label.Location.X, 荊棘延遲按鍵Label.Location.Y + KeyLabelAddY);
            控場Label.Location = isBackToOriginCheck ? 控場LabelOriginPos : new Point(小荊棘Label.Left + 小荊棘Label.Width - 控場Label.Width, 控場按鍵Label.Top + 控場按鍵Label.Height - 控場Label.Height - 3);
            控場CDLabel.Location = new Point(控場Label.Left + 控場Label.Width, 控場按鍵Label.Location.Y);

            重置計時器按鍵Label.Location = new Point(控場按鍵Label.Location.X, 控場按鍵Label.Location.Y + KeyLabelAddY);
            重置計時器Label.Location = isBackToOriginCheck ? 重置計時器LabelOriginPos : new Point(小荊棘Label.Left + 小荊棘Label.Width - 重置計時器Label.Width + 10, 重置計時器按鍵Label.Top + 重置計時器按鍵Label.Height - 重置計時器Label.Height - 3); ;
            TopMostCheckBox.Location = isBackToOriginCheck ? TopMostCheckBoxOriginPos : new Point(this.Size.Width / 2 - TopMostCheckBox.Width / 2, 重置計時器按鍵Label.Location.Y + KeyLabelAddY);
            WindowsSetting.Location = isBackToOriginCheck ? WindowsSettingOriginPos : new Point(this.Size.Width / 2 - WindowsSetting.Width / 2, TopMostCheckBox.Location.Y + KeyLabelAddY);

            小荊棘按鍵Label.Text = 小荊棘ComboBox.Text;
            雷射按鍵Label.Text = 雷射ComboBox.Text;
            荊棘延遲按鍵Label.Text = 荊棘延遲ComboBox.Text;
            控場按鍵Label.Text = 控場ComboBox.Text;
            重置計時器按鍵Label.Text = 重置計時器ComboBox.Text;
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
                WindowsSetting.BaseColor = Color.FromArgb(65, 105, 225);
                WindowsSetting.OnHoverBaseColor = Color.FromArgb(45, 85, 205);
                WindowsSetting.Text = "調整設定";
                this.ProcessRegisterHotKey(false);
                this.ProcessWindowsSetting(false);
                FormsConstant.init127Timer(小荊棘TextBox.Text, 雷射TextBox.Text, 荊棘延遲TextBox.Text, 控場TextBox.Text);
            } else
            {
                WindowsSetting.BaseColor = Color.FromArgb(184, 44, 44);
                WindowsSetting.OnHoverBaseColor = Color.FromArgb(150, 20, 20);
                WindowsSetting.Text = "設定完成";
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
            小荊棘設定音效Button.Visible = !小荊棘設定音效Button.Visible;
            雷射設定音效Button.Visible = !雷射設定音效Button.Visible;
            荊棘延遲設定音效Button.Visible = !荊棘延遲設定音效Button.Visible;
            控場設定音效Button.Visible = !控場設定音效Button.Visible;
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

        private void metroTabControlVS1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TopMostCheckBox.Checked || TopMost156R1CheckBox.Checked || TopMost156R3CheckBox.Checked)
            {
                TopMostCheckBox.Checked = false;
                TopMost156R1CheckBox.Checked = false;
                TopMost156R3CheckBox.Checked = false;
            }
        }
    }
}
