using Guna.UI.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace ElsClockStrikes.Forms.FormCustomizeStrategy
{
    public class ComboBoxStrategy : BaseControlStrategy
    {
        private string comboBoxText;

        public ComboBoxStrategy(string comboBoxText)
        {
            this.comboBoxText = comboBoxText;
        }

        public override void AddControl(ControlStrategyParameters controlStrategyParameters)
        {
            GunaComboBox lastgunaComboBox = this.GetControlByName<GunaComboBox>(controlStrategyParameters.tabPage, $"{FormsConstant.comboBoxBaseName}{FormsConstant.indexForCustomizeName - 1}");
            GunaComboBox gunaComboBox = new GunaComboBox();
            gunaComboBox.BackColor = Color.Transparent;
            gunaComboBox.BaseColor = Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            gunaComboBox.BorderColor = Color.Silver;
            gunaComboBox.BorderSize = 1;
            gunaComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            gunaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            gunaComboBox.FocusedColor = Color.Empty;
            gunaComboBox.Font = new Font(Font, 10F);
            gunaComboBox.ForeColor = Color.DeepSkyBlue;
            gunaComboBox.FormattingEnabled = true;
            gunaComboBox.Location = this.ProcessGunaComboBoxLayout(lastgunaComboBox);
            gunaComboBox.Name = $"{FormsConstant.comboBoxBaseName}{FormsConstant.indexForCustomizeName}";
            gunaComboBox.OnHoverItemBaseColor = Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            gunaComboBox.OnHoverItemForeColor = SystemColors.ControlDark;
            gunaComboBox.Size = new Size(84, 26);
            controlStrategyParameters.tabPage.Controls.Add(gunaComboBox);
            FormsUtils.GetComboBoxItemsFormHotKeySet(gunaComboBox, comboBoxText);
        }
    }
}
