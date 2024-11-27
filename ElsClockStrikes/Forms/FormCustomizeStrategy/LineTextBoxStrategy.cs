using Guna.UI.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace ElsClockStrikes.Forms.FormCustomizeStrategy
{
    public class LineTextBoxStrategy : BaseControlStrategy
    {
        private string textBoxText;

        public LineTextBoxStrategy(string textBoxText)
        {
            this.textBoxText = textBoxText;
        }

        public override void AddControl(ControlStrategyParameters controlStrategyParameters)
        {
            GunaLineTextBox lastGunaLineTextBox = this.GetControlByName<GunaLineTextBox>(controlStrategyParameters.tabPage, $"{FormsConstant.textBoxBaseName}{FormsConstant.indexForCustomizeName - 1}");
            GunaLineTextBox gunaLineTextBox = new GunaLineTextBox();
            gunaLineTextBox.Animated = true;
            gunaLineTextBox.BackColor = Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(82)))), ((int)(((byte)(80)))));
            gunaLineTextBox.Cursor = Cursors.IBeam;
            gunaLineTextBox.FocusedLineColor = Color.Red;
            gunaLineTextBox.Font = new Font(Font, 18F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            gunaLineTextBox.LineColor = Color.Gainsboro;
            gunaLineTextBox.LineSize = 1;
            gunaLineTextBox.Location = this.ProcessGunaLineTextBoxLayout(lastGunaLineTextBox);
            gunaLineTextBox.MaxLength = 3;
            gunaLineTextBox.Name = $"{FormsConstant.textBoxBaseName}{FormsConstant.indexForCustomizeName}";
            gunaLineTextBox.PasswordChar = '\0';
            gunaLineTextBox.Size = new Size(90, 42);
            gunaLineTextBox.TabIndex = 999;
            gunaLineTextBox.Text = this.textBoxText;
            gunaLineTextBox.TextAlign = HorizontalAlignment.Center;
            gunaLineTextBox.TextOffsetX = 3;
            gunaLineTextBox.KeyPress += new KeyPressEventHandler(
                (object sender, KeyPressEventArgs e) => {
                    FormsUtils.ProcessKeyPress(e);
                }
            );
            controlStrategyParameters.tabPage.Controls.Add(gunaLineTextBox);
            controlStrategyParameters.gunaLineTextBox = gunaLineTextBox;
        }

        private Point ProcessGunaLineTextBoxLayout(GunaLineTextBox lastGunaLineTextBox)
        {
            return new Point(333, lastGunaLineTextBox == null ? 29 : lastGunaLineTextBox.Location.Y + FormsConstant.ControlLayoutOffset);
        }
    }
}
