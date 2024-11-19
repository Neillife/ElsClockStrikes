using System.Drawing;
using System.Windows.Forms;

namespace ElsClockStrikes.Forms.FormCustomizeStrategy
{
    public class MechanicNameLabelStrategy : BaseControlStrategy
    {
        public override void AddControl(ControlStrategyParameters controlStrategyParameters)
        {
            Label lastLabel = this.GetControlByName<Label>(controlStrategyParameters.tabPage, $"{FormsConstant.mechanicLabelBaseName}{FormsConstant.indexForCustomizeName - 1}");
            Label label = new Label();
            controlStrategyParameters.tabPage.Controls.Add(label);
            label.Name = $"{FormsConstant.mechanicLabelBaseName}{FormsConstant.indexForCustomizeName}";
            label.Text = $"{controlStrategyParameters.custSettingFormsInputData.Trim()}:";
            label.AutoSize = true;
            label.Font = new Font(Font, 11.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            label.Location = this.ProcessLabelLayout(label, lastLabel, 314, 42);
            label.Size = new Size(47, 20);
        }
    }
}
