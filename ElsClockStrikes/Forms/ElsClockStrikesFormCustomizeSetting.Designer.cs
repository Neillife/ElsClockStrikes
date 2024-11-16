namespace ElsClockStrikes.Forms
{
    partial class ElsClockStrikesFormCustomizeSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElsClockStrikesFormCustomizeSetting));
            this.CloseControlBox = new Guna.UI.WinForms.GunaControlBox();
            this.FeatureNameTextBox = new Guna.UI.WinForms.GunaLineTextBox();
            this.AddFeatureNameButton = new Guna.UI.WinForms.GunaButton();
            this.TimerCustomizeSettingLabel = new System.Windows.Forms.Label();
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
            this.CloseControlBox.TabIndex = 110;
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
            this.FeatureNameTextBox.Location = new System.Drawing.Point(25, 77);
            this.FeatureNameTextBox.MaxLength = 10;
            this.FeatureNameTextBox.Name = "FeatureNameTextBox";
            this.FeatureNameTextBox.PasswordChar = '\0';
            this.FeatureNameTextBox.Size = new System.Drawing.Size(200, 42);
            this.FeatureNameTextBox.TabIndex = 158;
            this.FeatureNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FeatureNameTextBox.TextOffsetX = 3;
            this.FeatureNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FeatureNameTextBox_KeyDown);
            // 
            // AddFeatureNameButton
            // 
            this.AddFeatureNameButton.Animated = true;
            this.AddFeatureNameButton.AnimationHoverSpeed = 0.07F;
            this.AddFeatureNameButton.AnimationSpeed = 0.03F;
            this.AddFeatureNameButton.BackColor = System.Drawing.Color.Transparent;
            this.AddFeatureNameButton.BaseColor = System.Drawing.Color.RoyalBlue;
            this.AddFeatureNameButton.BorderColor = System.Drawing.Color.Transparent;
            this.AddFeatureNameButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.AddFeatureNameButton.FocusedColor = System.Drawing.Color.Empty;
            this.AddFeatureNameButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.AddFeatureNameButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.AddFeatureNameButton.Image = null;
            this.AddFeatureNameButton.ImageSize = new System.Drawing.Size(24, 24);
            this.AddFeatureNameButton.Location = new System.Drawing.Point(250, 77);
            this.AddFeatureNameButton.Name = "AddFeatureNameButton";
            this.AddFeatureNameButton.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(85)))), ((int)(((byte)(205)))));
            this.AddFeatureNameButton.OnHoverBorderColor = System.Drawing.Color.Black;
            this.AddFeatureNameButton.OnHoverForeColor = System.Drawing.Color.White;
            this.AddFeatureNameButton.OnHoverImage = null;
            this.AddFeatureNameButton.OnPressedColor = System.Drawing.Color.Black;
            this.AddFeatureNameButton.Size = new System.Drawing.Size(84, 42);
            this.AddFeatureNameButton.TabIndex = 182;
            this.AddFeatureNameButton.Text = "新增";
            this.AddFeatureNameButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AddFeatureNameButton.Click += new System.EventHandler(this.AddFeatureNameButton_Click);
            // 
            // TimerCustomizeSettingLabel
            // 
            this.TimerCustomizeSettingLabel.AutoSize = true;
            this.TimerCustomizeSettingLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerCustomizeSettingLabel.Location = new System.Drawing.Point(34, 39);
            this.TimerCustomizeSettingLabel.Name = "TimerCustomizeSettingLabel";
            this.TimerCustomizeSettingLabel.Size = new System.Drawing.Size(281, 20);
            this.TimerCustomizeSettingLabel.TabIndex = 183;
            this.TimerCustomizeSettingLabel.Text = "請輸入計時機制名稱並點擊「新增」";
            // 
            // ElsClockStrikesFormCustomizeSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(350, 150);
            this.Controls.Add(this.TimerCustomizeSettingLabel);
            this.Controls.Add(this.AddFeatureNameButton);
            this.Controls.Add(this.FeatureNameTextBox);
            this.Controls.Add(this.CloseControlBox);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ElsClockStrikesFormCustomizeSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.State = MetroSuite.MetroForm.FormState.Custom;
            this.Style = MetroSuite.Design.Style.Custom;
            this.Text = "ElsClockStrikes | Author by DC:  .le._.vi.";
            this.Activated += new System.EventHandler(this.ElsClockStrikesFormCustomizeSetting_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaControlBox CloseControlBox;
        private Guna.UI.WinForms.GunaLineTextBox FeatureNameTextBox;
        private Guna.UI.WinForms.GunaButton AddFeatureNameButton;
        private System.Windows.Forms.Label TimerCustomizeSettingLabel;
    }
}