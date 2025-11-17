using Guna.UI.WinForms;
using System.Drawing;

namespace ElsClockStrikes.Forms.FormCustomizeStrategy
{
    public class FormInstanceCheckBoxStrategy : BaseControlStrategy
    {
        private readonly bool isChrcked;

        public FormInstanceCheckBoxStrategy(bool isChrcked)
        {
            this.isChrcked = isChrcked;
        }

        public override void AddControl(ControlStrategyParameters controlStrategyParameters)
        {
            GunaCheckBox gunaCheckBox = new GunaCheckBox();
            gunaCheckBox.BaseColor = Color.White;
            gunaCheckBox.CheckedOffColor = Color.Gray;
            gunaCheckBox.CheckedOnColor = Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            gunaCheckBox.FillColor = Color.White;
            gunaCheckBox.Font = new Font(Font, 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            gunaCheckBox.ForeColor = Color.WhiteSmoke;
            gunaCheckBox.Location = new Point(20, 107);
            gunaCheckBox.Name = $"{FormsConstant.formInstanceCheckBoxBaseName}{FormsConstant.indexForCustomizeName}";
            gunaCheckBox.Size = new Size(100, 25);
            gunaCheckBox.Text = "分離介面";
            gunaCheckBox.Checked = isChrcked;
            controlStrategyParameters.gunaPanel.Controls.Add(gunaCheckBox);
        }
    }
}
