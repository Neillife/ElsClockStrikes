using Guna.UI.WinForms;
using System.Drawing;

namespace ElsClockStrikes.Forms.FormCustomizeStrategy
{
    public class PanelStrategy : BaseControlStrategy
    {
        public override void AddControl(ControlStrategyParameters controlStrategyParameters)
        {
            GunaPanel lastGunaPanel = this.GetControlByName<GunaPanel>(controlStrategyParameters.tabPage, $"{FormsConstant.panelBaseName}{FormsConstant.indexForCustomizeName - 1}");
            GunaPanel gunaPanel = new GunaPanel();
            gunaPanel.BackColor = Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            //gunaPanel.Controls.Add(this.控場音量Label);
            //gunaPanel.Controls.Add(this.控場分離視窗CheckBox);
            //gunaPanel.Controls.Add(this.控場音量TextBox);
            //gunaPanel.Controls.Add(this.控場設定音效Button);
            gunaPanel.Location = this.ProcessGunaPanelLayout(lastGunaPanel); ;
            gunaPanel.Name = $"{FormsConstant.panelBaseName}{FormsConstant.indexForCustomizeName}";
            gunaPanel.Size = new Size(130, 0);
            gunaPanel.Visible = false;
            controlStrategyParameters.tabPage.Controls.Add(gunaPanel);
            controlStrategyParameters.gunaPanel = gunaPanel;
        }

        private Point ProcessGunaPanelLayout(GunaPanel lastGunaPanel)
        {
            return new Point(293, lastGunaPanel == null ? 29 : lastGunaPanel.Location.Y + FormsConstant.ControlLayoutOffset);
        }
    }
}
