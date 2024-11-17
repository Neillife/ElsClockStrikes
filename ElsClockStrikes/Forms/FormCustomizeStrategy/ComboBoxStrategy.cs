using Guna.UI.WinForms;
using System.Drawing;
using ElsClockStrikes.Core;
using System.Windows.Forms;

namespace ElsClockStrikes.Forms.FormCustomizeStrategy
{
    public class ComboBoxStrategy : BaseControlStrategy
    {
        private readonly object[] keySet =
        {
            nameof(HotKeySet.KeySet.F1),
            nameof(HotKeySet.KeySet.F2),
            nameof(HotKeySet.KeySet.F3),
            nameof(HotKeySet.KeySet.F4),
            nameof(HotKeySet.KeySet.F5),
            nameof(HotKeySet.KeySet.F6),
            nameof(HotKeySet.KeySet.F7),
            nameof(HotKeySet.KeySet.F8),
            nameof(HotKeySet.KeySet.F9),
            nameof(HotKeySet.KeySet.F10),
            nameof(HotKeySet.KeySet.F11),
            nameof(HotKeySet.KeySet.F12),
            nameof(HotKeySet.KeySet.A),
            nameof(HotKeySet.KeySet.B),
            nameof(HotKeySet.KeySet.C),
            nameof(HotKeySet.KeySet.D),
            nameof(HotKeySet.KeySet.E),
            nameof(HotKeySet.KeySet.F),
            nameof(HotKeySet.KeySet.G),
            nameof(HotKeySet.KeySet.H),
            nameof(HotKeySet.KeySet.I),
            nameof(HotKeySet.KeySet.J),
            nameof(HotKeySet.KeySet.K),
            nameof(HotKeySet.KeySet.L),
            nameof(HotKeySet.KeySet.M),
            nameof(HotKeySet.KeySet.N),
            nameof(HotKeySet.KeySet.O),
            nameof(HotKeySet.KeySet.P),
            nameof(HotKeySet.KeySet.Q),
            nameof(HotKeySet.KeySet.R),
            nameof(HotKeySet.KeySet.S),
            nameof(HotKeySet.KeySet.T),
            nameof(HotKeySet.KeySet.U),
            nameof(HotKeySet.KeySet.V),
            nameof(HotKeySet.KeySet.W),
            nameof(HotKeySet.KeySet.X),
            nameof(HotKeySet.KeySet.Y),
            nameof(HotKeySet.KeySet.Z),
            nameof(HotKeySet.KeySet.主鍵盤0),
            nameof(HotKeySet.KeySet.主鍵盤1),
            nameof(HotKeySet.KeySet.主鍵盤2),
            nameof(HotKeySet.KeySet.主鍵盤3),
            nameof(HotKeySet.KeySet.主鍵盤4),
            nameof(HotKeySet.KeySet.主鍵盤5),
            nameof(HotKeySet.KeySet.主鍵盤6),
            nameof(HotKeySet.KeySet.主鍵盤7),
            nameof(HotKeySet.KeySet.主鍵盤8),
            nameof(HotKeySet.KeySet.主鍵盤9),
            nameof(HotKeySet.KeySet.小鍵盤0),
            nameof(HotKeySet.KeySet.小鍵盤1),
            nameof(HotKeySet.KeySet.小鍵盤2),
            nameof(HotKeySet.KeySet.小鍵盤3),
            nameof(HotKeySet.KeySet.小鍵盤4),
            nameof(HotKeySet.KeySet.小鍵盤5),
            nameof(HotKeySet.KeySet.小鍵盤6),
            nameof(HotKeySet.KeySet.小鍵盤7),
            nameof(HotKeySet.KeySet.小鍵盤8),
            nameof(HotKeySet.KeySet.小鍵盤9)
        };

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
            gunaComboBox.Items.AddRange(this.keySet);
            gunaComboBox.Location = this.ProcessGunaComboBoxLayout(lastgunaComboBox);
            gunaComboBox.Name = $"{FormsConstant.comboBoxBaseName}{FormsConstant.indexForCustomizeName}";
            gunaComboBox.OnHoverItemBaseColor = Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            gunaComboBox.OnHoverItemForeColor = SystemColors.ControlDark;
            gunaComboBox.Size = new Size(84, 26);
            gunaComboBox.StartIndex = 0;
            controlStrategyParameters.tabPage.Controls.Add(gunaComboBox);
        }

        private Point ProcessGunaComboBoxLayout(GunaComboBox lastGunaComboBox)
        {
            return new Point(111, lastGunaComboBox == null ? 39 : lastGunaComboBox.Location.Y + LayoutYAxisNum);
        }
    }
}
