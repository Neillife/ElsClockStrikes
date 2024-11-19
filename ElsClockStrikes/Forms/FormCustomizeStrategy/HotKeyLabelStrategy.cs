﻿using System.Drawing;
using System.Windows.Forms;

namespace ElsClockStrikes.Forms.FormCustomizeStrategy
{
    public class HotKeyLabelStrategy : BaseControlStrategy
    {
        public override void AddControl(ControlStrategyParameters controlStrategyParameters)
        {
            Label lastLabel = this.GetControlByName<Label>(controlStrategyParameters.tabPage, $"{FormsConstant.hotKeyLabelBaseName}{FormsConstant.indexForCustomizeName - 1}");
            Label label = new Label();
            controlStrategyParameters.tabPage.Controls.Add(label);
            label.AutoSize = true;
            label.Font = new Font(this.Font, 15.25F, FontStyle.Bold);
            label.Location = this.ProcessLabelLayout(label, lastLabel, 106, 6);
            label.Name = $"{FormsConstant.hotKeyLabelBaseName}{FormsConstant.indexForCustomizeName}";
            label.Size = new Size(36, 30);
            label.Text = "F1";
            label.Visible = false;
        }
    }
}
