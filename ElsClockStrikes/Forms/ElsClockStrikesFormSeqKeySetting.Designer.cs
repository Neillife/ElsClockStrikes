namespace ElsClockStrikes.Forms
{
    partial class ElsClockStrikesFormSeqKeySetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElsClockStrikesFormSeqKeySetting));
            this.CloseControlBox = new Guna.UI.WinForms.GunaControlBox();
            this.TimerSeqKeySettingLabel = new System.Windows.Forms.Label();
            this.AddFeatureNameButton = new Guna.UI.WinForms.GunaButton();
            this.FeatureNameTextBox = new Guna.UI.WinForms.GunaLineTextBox();
            this.FiestKeyLabel = new System.Windows.Forms.Label();
            this.FirstKeyComboBox = new Guna.UI.WinForms.GunaComboBox();
            this.TwoKeyLabel = new System.Windows.Forms.Label();
            this.TwoKeyComboBox = new Guna.UI.WinForms.GunaComboBox();
            this.ThreeKeyLabel = new System.Windows.Forms.Label();
            this.ThreeKeyComboBox = new Guna.UI.WinForms.GunaComboBox();
            this.SinKeyFeatureButton = new Guna.UI.WinForms.GunaButton();
            this.SuspendLayout();
            // 
            // CloseControlBox
            // 
            this.CloseControlBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseControlBox.Animated = true;
            this.CloseControlBox.AnimationHoverSpeed = 0.07F;
            this.CloseControlBox.AnimationSpeed = 0.03F;
            this.CloseControlBox.IconColor = System.Drawing.Color.White;
            this.CloseControlBox.IconSize = 15F;
            this.CloseControlBox.Location = new System.Drawing.Point(300, 7);
            this.CloseControlBox.Name = "CloseControlBox";
            this.CloseControlBox.OnHoverBackColor = System.Drawing.Color.RoyalBlue;
            this.CloseControlBox.OnHoverIconColor = System.Drawing.Color.White;
            this.CloseControlBox.OnPressedColor = System.Drawing.Color.Black;
            this.CloseControlBox.Size = new System.Drawing.Size(45, 29);
            this.CloseControlBox.TabIndex = 111;
            // 
            // TimerSeqKeySettingLabel
            // 
            this.TimerSeqKeySettingLabel.AutoSize = true;
            this.TimerSeqKeySettingLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerSeqKeySettingLabel.Location = new System.Drawing.Point(29, 39);
            this.TimerSeqKeySettingLabel.Name = "TimerSeqKeySettingLabel";
            this.TimerSeqKeySettingLabel.Size = new System.Drawing.Size(304, 20);
            this.TimerSeqKeySettingLabel.TabIndex = 186;
            this.TimerSeqKeySettingLabel.Text = "請設定計時 機制 / 按鍵 並點擊「新增」";
            // 
            // AddFeatureNameButton
            // 
            this.AddFeatureNameButton.Animated = true;
            this.AddFeatureNameButton.AnimationHoverSpeed = 0.07F;
            this.AddFeatureNameButton.AnimationSpeed = 0.03F;
            this.AddFeatureNameButton.BackColor = System.Drawing.Color.Transparent;
            this.AddFeatureNameButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(149)))), ((int)(((byte)(180)))));
            this.AddFeatureNameButton.BorderColor = System.Drawing.Color.Transparent;
            this.AddFeatureNameButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.AddFeatureNameButton.FocusedColor = System.Drawing.Color.Empty;
            this.AddFeatureNameButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.AddFeatureNameButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.AddFeatureNameButton.Image = null;
            this.AddFeatureNameButton.ImageSize = new System.Drawing.Size(24, 24);
            this.AddFeatureNameButton.Location = new System.Drawing.Point(150, 77);
            this.AddFeatureNameButton.Name = "AddFeatureNameButton";
            this.AddFeatureNameButton.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(120)))), ((int)(((byte)(170)))));
            this.AddFeatureNameButton.OnHoverBorderColor = System.Drawing.Color.Black;
            this.AddFeatureNameButton.OnHoverForeColor = System.Drawing.Color.White;
            this.AddFeatureNameButton.OnHoverImage = null;
            this.AddFeatureNameButton.OnPressedColor = System.Drawing.Color.Black;
            this.AddFeatureNameButton.Size = new System.Drawing.Size(85, 42);
            this.AddFeatureNameButton.TabIndex = 185;
            this.AddFeatureNameButton.Text = "新增";
            this.AddFeatureNameButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AddFeatureNameButton.Click += new System.EventHandler(this.AddFeatureNameButton_Click);
            // 
            // FeatureNameTextBox
            // 
            this.FeatureNameTextBox.Animated = true;
            this.FeatureNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(82)))), ((int)(((byte)(80)))));
            this.FeatureNameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.FeatureNameTextBox.FocusedLineColor = System.Drawing.Color.Red;
            this.FeatureNameTextBox.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FeatureNameTextBox.LineColor = System.Drawing.Color.Gainsboro;
            this.FeatureNameTextBox.LineSize = 1;
            this.FeatureNameTextBox.Location = new System.Drawing.Point(15, 77);
            this.FeatureNameTextBox.MaxLength = 10;
            this.FeatureNameTextBox.Name = "FeatureNameTextBox";
            this.FeatureNameTextBox.PasswordChar = '\0';
            this.FeatureNameTextBox.Size = new System.Drawing.Size(110, 42);
            this.FeatureNameTextBox.TabIndex = 184;
            this.FeatureNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FeatureNameTextBox.TextOffsetX = 3;
            this.FeatureNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FeatureNameTextBox_KeyDown);
            // 
            // FiestKeyLabel
            // 
            this.FiestKeyLabel.AutoSize = true;
            this.FiestKeyLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FiestKeyLabel.Location = new System.Drawing.Point(75, 145);
            this.FiestKeyLabel.Name = "FiestKeyLabel";
            this.FiestKeyLabel.Size = new System.Drawing.Size(64, 20);
            this.FiestKeyLabel.TabIndex = 187;
            this.FiestKeyLabel.Text = "第一鍵:";
            // 
            // FirstKeyComboBox
            // 
            this.FirstKeyComboBox.BackColor = System.Drawing.Color.Transparent;
            this.FirstKeyComboBox.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.FirstKeyComboBox.BorderColor = System.Drawing.Color.Silver;
            this.FirstKeyComboBox.BorderSize = 1;
            this.FirstKeyComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.FirstKeyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FirstKeyComboBox.FocusedColor = System.Drawing.Color.Empty;
            this.FirstKeyComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FirstKeyComboBox.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.FirstKeyComboBox.FormattingEnabled = true;
            this.FirstKeyComboBox.Location = new System.Drawing.Point(191, 142);
            this.FirstKeyComboBox.Name = "FirstKeyComboBox";
            this.FirstKeyComboBox.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.FirstKeyComboBox.OnHoverItemForeColor = System.Drawing.SystemColors.ControlDark;
            this.FirstKeyComboBox.Size = new System.Drawing.Size(84, 26);
            this.FirstKeyComboBox.TabIndex = 188;
            // 
            // TwoKeyLabel
            // 
            this.TwoKeyLabel.AutoSize = true;
            this.TwoKeyLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TwoKeyLabel.Location = new System.Drawing.Point(75, 196);
            this.TwoKeyLabel.Name = "TwoKeyLabel";
            this.TwoKeyLabel.Size = new System.Drawing.Size(64, 20);
            this.TwoKeyLabel.TabIndex = 189;
            this.TwoKeyLabel.Text = "第二鍵:";
            // 
            // TwoKeyComboBox
            // 
            this.TwoKeyComboBox.BackColor = System.Drawing.Color.Transparent;
            this.TwoKeyComboBox.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.TwoKeyComboBox.BorderColor = System.Drawing.Color.Silver;
            this.TwoKeyComboBox.BorderSize = 1;
            this.TwoKeyComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.TwoKeyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TwoKeyComboBox.FocusedColor = System.Drawing.Color.Empty;
            this.TwoKeyComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TwoKeyComboBox.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.TwoKeyComboBox.FormattingEnabled = true;
            this.TwoKeyComboBox.Location = new System.Drawing.Point(191, 193);
            this.TwoKeyComboBox.Name = "TwoKeyComboBox";
            this.TwoKeyComboBox.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.TwoKeyComboBox.OnHoverItemForeColor = System.Drawing.SystemColors.ControlDark;
            this.TwoKeyComboBox.Size = new System.Drawing.Size(84, 26);
            this.TwoKeyComboBox.TabIndex = 190;
            // 
            // ThreeKeyLabel
            // 
            this.ThreeKeyLabel.AutoSize = true;
            this.ThreeKeyLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThreeKeyLabel.Location = new System.Drawing.Point(75, 247);
            this.ThreeKeyLabel.Name = "ThreeKeyLabel";
            this.ThreeKeyLabel.Size = new System.Drawing.Size(64, 20);
            this.ThreeKeyLabel.TabIndex = 191;
            this.ThreeKeyLabel.Text = "第三鍵:";
            // 
            // ThreeKeyComboBox
            // 
            this.ThreeKeyComboBox.BackColor = System.Drawing.Color.Transparent;
            this.ThreeKeyComboBox.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ThreeKeyComboBox.BorderColor = System.Drawing.Color.Silver;
            this.ThreeKeyComboBox.BorderSize = 1;
            this.ThreeKeyComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ThreeKeyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ThreeKeyComboBox.FocusedColor = System.Drawing.Color.Empty;
            this.ThreeKeyComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ThreeKeyComboBox.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.ThreeKeyComboBox.FormattingEnabled = true;
            this.ThreeKeyComboBox.Location = new System.Drawing.Point(191, 244);
            this.ThreeKeyComboBox.Name = "ThreeKeyComboBox";
            this.ThreeKeyComboBox.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ThreeKeyComboBox.OnHoverItemForeColor = System.Drawing.SystemColors.ControlDark;
            this.ThreeKeyComboBox.Size = new System.Drawing.Size(84, 26);
            this.ThreeKeyComboBox.TabIndex = 192;
            // 
            // SinKeyFeatureButton
            // 
            this.SinKeyFeatureButton.Animated = true;
            this.SinKeyFeatureButton.AnimationHoverSpeed = 0.07F;
            this.SinKeyFeatureButton.AnimationSpeed = 0.03F;
            this.SinKeyFeatureButton.BackColor = System.Drawing.Color.Transparent;
            this.SinKeyFeatureButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(138)))), ((int)(((byte)(149)))));
            this.SinKeyFeatureButton.BorderColor = System.Drawing.Color.Transparent;
            this.SinKeyFeatureButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.SinKeyFeatureButton.FocusedColor = System.Drawing.Color.Empty;
            this.SinKeyFeatureButton.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.SinKeyFeatureButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.SinKeyFeatureButton.Image = global::ElsClockStrikes.Properties.Resources.Title_20190;
            this.SinKeyFeatureButton.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SinKeyFeatureButton.ImageSize = new System.Drawing.Size(80, 40);
            this.SinKeyFeatureButton.Location = new System.Drawing.Point(250, 77);
            this.SinKeyFeatureButton.Name = "SinKeyFeatureButton";
            this.SinKeyFeatureButton.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.SinKeyFeatureButton.OnHoverBorderColor = System.Drawing.Color.Black;
            this.SinKeyFeatureButton.OnHoverForeColor = System.Drawing.Color.White;
            this.SinKeyFeatureButton.OnHoverImage = null;
            this.SinKeyFeatureButton.OnPressedColor = System.Drawing.Color.Black;
            this.SinKeyFeatureButton.Size = new System.Drawing.Size(85, 42);
            this.SinKeyFeatureButton.TabIndex = 199;
            this.SinKeyFeatureButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SinKeyFeatureButton.Click += new System.EventHandler(this.SinKeyFeatureButton_Click);
            // 
            // ElsClockStrikesFormSeqKeySetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(350, 300);
            this.Controls.Add(this.SinKeyFeatureButton);
            this.Controls.Add(this.ThreeKeyLabel);
            this.Controls.Add(this.ThreeKeyComboBox);
            this.Controls.Add(this.TwoKeyLabel);
            this.Controls.Add(this.TwoKeyComboBox);
            this.Controls.Add(this.FiestKeyLabel);
            this.Controls.Add(this.FirstKeyComboBox);
            this.Controls.Add(this.TimerSeqKeySettingLabel);
            this.Controls.Add(this.AddFeatureNameButton);
            this.Controls.Add(this.FeatureNameTextBox);
            this.Controls.Add(this.CloseControlBox);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ElsClockStrikesFormSeqKeySetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.State = MetroSuite.MetroForm.FormState.Custom;
            this.Style = MetroSuite.Design.Style.Custom;
            this.Text = "ElsClockStrikes | Author by DC:  .le._.vi.";
            this.Activated += new System.EventHandler(this.ElsClockStrikesFormSeqKeySetting_Activated);
            this.Load += new System.EventHandler(this.ElsClockStrikesFormSeqKeySetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaControlBox CloseControlBox;
        private System.Windows.Forms.Label TimerSeqKeySettingLabel;
        private Guna.UI.WinForms.GunaButton AddFeatureNameButton;
        private Guna.UI.WinForms.GunaLineTextBox FeatureNameTextBox;
        private System.Windows.Forms.Label FiestKeyLabel;
        private Guna.UI.WinForms.GunaComboBox FirstKeyComboBox;
        private System.Windows.Forms.Label TwoKeyLabel;
        private Guna.UI.WinForms.GunaComboBox TwoKeyComboBox;
        private System.Windows.Forms.Label ThreeKeyLabel;
        private Guna.UI.WinForms.GunaComboBox ThreeKeyComboBox;
        private Guna.UI.WinForms.GunaButton SinKeyFeatureButton;
    }
}