namespace ElsClockStrikes.Forms
{
    partial class ElsClockStrikesFormTimerInstance
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElsClockStrikesFormTimerInstance));
            this.CDTimer = new System.Windows.Forms.Timer(this.components);
            this.WindowsSetting = new Guna.UI.WinForms.GunaButton();
            this.SuspendLayout();
            // 
            // WindowsSetting
            // 
            this.WindowsSetting.Animated = true;
            this.WindowsSetting.AnimationHoverSpeed = 0.07F;
            this.WindowsSetting.AnimationSpeed = 0.03F;
            this.WindowsSetting.BackColor = System.Drawing.Color.Transparent;
            this.WindowsSetting.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.WindowsSetting.BorderColor = System.Drawing.Color.Transparent;
            this.WindowsSetting.DialogResult = System.Windows.Forms.DialogResult.None;
            this.WindowsSetting.FocusedColor = System.Drawing.Color.Empty;
            this.WindowsSetting.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.WindowsSetting.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.WindowsSetting.Image = global::ElsClockStrikes.Properties.Resources.setimg;
            this.WindowsSetting.ImageSize = new System.Drawing.Size(24, 24);
            this.WindowsSetting.Location = new System.Drawing.Point(130, 5);
            this.WindowsSetting.Name = "WindowsSetting";
            this.WindowsSetting.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.WindowsSetting.OnHoverBorderColor = System.Drawing.Color.Black;
            this.WindowsSetting.OnHoverForeColor = System.Drawing.Color.White;
            this.WindowsSetting.OnHoverImage = null;
            this.WindowsSetting.OnPressedColor = System.Drawing.Color.Black;
            this.WindowsSetting.Size = new System.Drawing.Size(43, 25);
            this.WindowsSetting.TabIndex = 111;
            this.WindowsSetting.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WindowsSetting.Click += new System.EventHandler(this.WindowsSetting_Click);
            // 
            // ElsClockStrikesFormTimerInstance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(180, 69);
            this.Controls.Add(this.WindowsSetting);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ElsClockStrikesFormTimerInstance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.State = MetroSuite.MetroForm.FormState.Custom;
            this.Style = MetroSuite.Design.Style.Custom;
            this.Text = "ElsClockStrikes";
            this.Load += new System.EventHandler(this.ElsClockStrikesFormTimerInstance_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer CDTimer;
        private Guna.UI.WinForms.GunaButton WindowsSetting;
    }
}