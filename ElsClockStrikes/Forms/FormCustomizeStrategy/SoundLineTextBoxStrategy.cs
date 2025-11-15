using Guna.UI.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ElsClockStrikes.Forms.FormCustomizeStrategy
{
    public class SoundLineTextBoxStrategy : BaseControlStrategy
    {
        private readonly string textBoxText;

        public SoundLineTextBoxStrategy(string textBoxText)
        {
            this.textBoxText = textBoxText;
        }

        public override void AddControl(ControlStrategyParameters controlStrategyParameters)
        {
            GunaLineTextBox gunaLineTextBox = new GunaLineTextBox();
            gunaLineTextBox.Animated = true;
            gunaLineTextBox.BackColor = Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            gunaLineTextBox.Cursor = Cursors.IBeam;
            gunaLineTextBox.FocusedLineColor = Color.Red;
            gunaLineTextBox.Font = new Font(Font, 18F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            gunaLineTextBox.LineColor = Color.Gainsboro;
            gunaLineTextBox.LineSize = 1;
            gunaLineTextBox.Location = new Point(75, 59);
            gunaLineTextBox.MaxLength = 3;
            gunaLineTextBox.Name = $"{FormsConstant.soundTextBoxBaseName}{FormsConstant.indexForCustomizeName}";
            gunaLineTextBox.PasswordChar = '\0';
            gunaLineTextBox.Size = new Size(45, 42);
            //gunaLineTextBox.TabIndex = 999;
            gunaLineTextBox.Text = this.textBoxText;
            gunaLineTextBox.TextAlign = HorizontalAlignment.Center;
            gunaLineTextBox.TextOffsetX = 3;
            gunaLineTextBox.KeyPress += new KeyPressEventHandler(
                (object sender, KeyPressEventArgs e) => {
                    FormsUtils.ProcessKeyPress(e);
                }
            );
            gunaLineTextBox.Leave += new EventHandler(
                (object sender, EventArgs e) => {
                    FormsUtils.ProcessSoundTextBoxLeave(gunaLineTextBox);
                }
            );
            controlStrategyParameters.gunaPanel.Controls.Add(gunaLineTextBox);
            controlStrategyParameters.soundLineTextBox = gunaLineTextBox;
        }
    }
}
