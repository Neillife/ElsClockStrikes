using System.Drawing;
using System.Windows.Forms;

namespace ElsClockStrikes.Forms.FormCustomizeStrategy
{
    public class TimeLeftLabelStrategy : BaseControlStrategy
    {
        public override void AddControl(ControlStrategyParameters controlStrategyParameters)
        {
            Label lastLabel = this.GetControlByName<Label>(controlStrategyParameters.tabPage, $"{FormsConstant.timeLeftLabelBaseName}{FormsConstant.indexForCustomizeName - 1}");
            Label label = new Label();
            controlStrategyParameters.tabPage.Controls.Add(label);
            label.AutoSize = true;
            label.Font = new Font(Font, 15.25F, FontStyle.Bold);
            label.Location = this.ProcessLabelLayout(label, lastLabel, 49, 114);
            label.Name = $"{FormsConstant.timeLeftLabelBaseName}{FormsConstant.indexForCustomizeName}";
            label.Size = new Size(49, 30);
            label.Text = "10";
            label.Visible = false;
            controlStrategyParameters.timeLeftLabel = label;
        }
    }
}
