using System.Drawing;
using System.Windows.Forms;

namespace ElsClockStrikes.Forms.FormCustomizeStrategy
{
    public class SoundLabelStrategy : BaseControlStrategy
    {
        public override void AddControl(ControlStrategyParameters controlStrategyParameters)
        {
            Label label = new Label();
            controlStrategyParameters.gunaPanel.Controls.Add(label);
            label.Name = $"{FormsConstant.soundLabelBaseName}{FormsConstant.indexForCustomizeName}"; ;
            label.Text = "音量 (%)";
            label.AutoSize = true;
            label.Font = new Font(Font, 11.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            label.Location = new Point(3, 72);
            label.Size = new Size(72, 20);
        }
    }
}
