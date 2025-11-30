using Guna.UI.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace ElsClockStrikes.Forms.FormCustomizeStrategy
{
    public abstract class BaseControlStrategy
    {
        protected string Font = "Segoe UI";

        protected BaseControlStrategy()
        {
            // Base class prohibits instances.
        }

        protected TControl GetControlByName<TControl>(TabPage tabPage, string name) where TControl : Control
        {
            foreach (Control control in tabPage.Controls)
            {
                if (control is TControl tControl && tControl.Name == name)
                    return tControl;
            }
            return null;
        }

        protected Point ProcessLabelLayout(Label label, Label lastLabel, int x, int y)
        {
            return new Point(x - (label == null ? 0 : label.Width), lastLabel == null ? y : lastLabel.Location.Y + FormsConstant.ControlLayoutOffset);
        }

        protected Point ProcessButtonLayout(GunaButton lastGunaButton, int x)
        {
            return new Point(x, lastGunaButton == null ? 30 : lastGunaButton.Location.Y + FormsConstant.ControlLayoutOffset);
        }

        protected Point ProcessGunaComboBoxLayout(GunaComboBox lastGunaComboBox)
        {
            return new Point(111, lastGunaComboBox == null ? 39 : lastGunaComboBox.Location.Y + FormsConstant.ControlLayoutOffset);
        }

        public abstract void AddControl(ControlStrategyParameters controlStrategyParameters);
    }
}
