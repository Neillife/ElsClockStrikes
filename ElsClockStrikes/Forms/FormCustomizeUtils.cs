using ElsClockStrikes.Core;
using Guna.UI.WinForms;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace ElsClockStrikes.Forms
{
    public class FormCustomizeUtils
    {
        public static int index = 0;
        public static string LastRetrievedTimeLeftLabelName { get; set;} = $"CustomizeTimeLeftLabelName{index}";
        private static string LastRetrievedHotKeyLabelName {get; set;} = $"CustomizeHotKeyLabelName{index}";
        private static string LastRetrievedLabelName {get; set;} = $"CustomizeLabelName{index}";
        private static string LastRetrievedGunaComboBoxName {get; set;} = $"CustomizeComboBoxName{index}";
        private static string LastRetrievedGunaLineTextBoxName {get; set;} = $"CustomizeTextBoxName{index}";
        public static string LastRetrievedTimerName {get; set;} = $"CustomizeTimerName{index}";
        private static string Font = "Segoe UI";
        private static object[] keySet =
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

        public static void StartAddCustomize(TabPage tabPage, string custSettingFormsInputData)
        {
            AddTimeLeftLabel(tabPage);
            AddHotKeyLabel(tabPage);
            AddLabel(tabPage, custSettingFormsInputData);
            AddGunaComboBox(tabPage);
            AddGunaLineTextBox(tabPage);
            index++;
            LastRetrievedTimeLeftLabelName = $"CustomizeTimeLeftLabelName{index}";
            LastRetrievedHotKeyLabelName = $"CustomizeHotKeyLabelName{index}";
            LastRetrievedLabelName = $"CustomizeLabelName{index}";
            LastRetrievedGunaComboBoxName = $"CustomizeComboBoxName{index}";
            LastRetrievedGunaLineTextBoxName = $"CustomizeTextBoxName{index}";
            LastRetrievedTimerName = $"CustomizeTimerName{index}";
        }

        public static CustomizeTaskTimer getTimerByCustomizeIndex(Control parent, string customizeIndex)
        {
            CustomizeTaskTimer result = null;
            FieldInfo[] fields = parent.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

            foreach (FieldInfo field in fields)
            {
                if (field.FieldType == typeof(CustomizeTaskTimer))
                {
                    CustomizeTaskTimer timer = (CustomizeTaskTimer)field.GetValue(parent);
                    if (timer != null)
                    {
                        string timerTagStr = timer.Tag.ToString();
                        if (timerTagStr.Substring(timerTagStr.Length - 1, 1) == customizeIndex)
                        {
                            result = timer;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        public static Label getLabelByCustomizeIndex(Control parent, string customizeIndex)
        {
            Label result = null;
            foreach (Control control in parent.Controls)
            {
                if (control is Label label)
                {
                    if (label.Name.Substring(label.Name.Length - 1, 1) == customizeIndex)
                    {
                        result = label;
                        break;
                    }
                }
            }
            return result;
        }

        public static GunaLineTextBox getGunaLineTextBoxByCustomizeIndex(Control parent, string customizeIndex)
        {
            GunaLineTextBox result = null;
            foreach (Control control in parent.Controls)
            {
                if (control is GunaLineTextBox textBox)
                {
                    if (textBox.Name.Substring(textBox.Name.Length - 1, 1) == customizeIndex)
                    {
                        result = textBox;
                        break;
                    }
                }
            }
            return result;
        }

        public static void AddTimeLeftLabel(TabPage tabPage)
        {
            Label lastLabel = GetLastLabelByLabelName(tabPage, LastRetrievedTimeLeftLabelName);
            Label label = new Label();
            tabPage.Controls.Add(label);
            label.AutoSize = true;
            label.Font = new Font(Font, 15.25F, FontStyle.Bold);
            label.Location = ProcessLabelLayout(label, lastLabel, 49, 42);
            label.Name = LastRetrievedTimeLeftLabelName;
            label.Size = new Size(49, 30);
            label.Text = "10";
            label.Visible = true;
        }

        public static void AddHotKeyLabel(TabPage tabPage)
        {
            Label lastLabel = GetLastLabelByLabelName(tabPage, LastRetrievedHotKeyLabelName);
            Label label = new Label();
            tabPage.Controls.Add(label);
            label.AutoSize = true;
            label.Font = new Font(Font, 15.25F, FontStyle.Bold);
            label.Location = ProcessLabelLayout(label, lastLabel, 106, 6);
            label.Name = LastRetrievedHotKeyLabelName;
            label.Size = new Size(36, 30);
            label.Text = "F1";
            label.Visible = true;
        }

        public static void AddLabel(TabPage tabPage, string featureName)
        {
            Label lastLabel = GetLastLabelByLabelName(tabPage, LastRetrievedLabelName);
            Label label = new Label();
            tabPage.Controls.Add(label);
            label.Name = LastRetrievedLabelName;
            label.Text = $"{featureName.Trim()}:";
            label.AutoSize = true;
            label.Font = new Font(Font, 11.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            label.Location = ProcessLabelLayout(label, lastLabel, 314, 42);
            label.Size = new Size(47, 20);
        }

        public static Point ProcessLabelLayout(Label label, Label lastLabel, int x, int y)
        {
            return new Point(x - (label == null ? 0 : label.Width), lastLabel == null ? y : lastLabel.Location.Y + 72);
        }

        public static Label GetLastLabelByLabelName(TabPage tabPage, string lastRetrievedLabelName)
        {
            Label lastLabel = null;
            foreach (Control control in tabPage.Controls)
            {
                if (control is Label && control.Name == lastRetrievedLabelName)
                {
                    lastLabel = (Label)control;
                }
            }
            return lastLabel;
        }

        public static void AddGunaComboBox(TabPage tabPage)
        {
            GunaComboBox lastgunaComboBox = GetLastGunaComboBoxByGunaComboBoxName(tabPage);
            GunaComboBox gunaComboBox = new GunaComboBox();
            tabPage.Controls.Add(gunaComboBox);
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
            gunaComboBox.Items.AddRange(keySet);
            gunaComboBox.Location = ProcessGunaComboBoxLayout(lastgunaComboBox);
            gunaComboBox.Name = LastRetrievedGunaComboBoxName;
            gunaComboBox.OnHoverItemBaseColor = Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            gunaComboBox.OnHoverItemForeColor = SystemColors.ControlDark;
            gunaComboBox.Size = new Size(84, 26);
            gunaComboBox.StartIndex = 0;
        }

        public static Point ProcessGunaComboBoxLayout(GunaComboBox lastGunaComboBox)
        {
            return new Point(111, lastGunaComboBox == null ? 39 : lastGunaComboBox.Location.Y + 72);
        }

        public static GunaComboBox GetLastGunaComboBoxByGunaComboBoxName(TabPage tabPage)
        {
            GunaComboBox lastGunaComboBox = null;
            foreach (Control control in tabPage.Controls)
            {
                if (control is GunaComboBox && control.Name == LastRetrievedGunaComboBoxName)
                {
                    lastGunaComboBox = (GunaComboBox)control;
                }
            }
            return lastGunaComboBox;
        }

        public static void AddGunaLineTextBox(TabPage tabPage)
        {
            GunaLineTextBox lastGunaLineTextBox = GetLastGunaLineTextBoxByGunaLineTextBoxName(tabPage);
            GunaLineTextBox gunaLineTextBox = new GunaLineTextBox();
            tabPage.Controls.Add(gunaLineTextBox);
            gunaLineTextBox.Animated = true;
            gunaLineTextBox.BackColor = Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(82)))), ((int)(((byte)(80)))));
            gunaLineTextBox.Cursor = Cursors.IBeam;
            gunaLineTextBox.FocusedLineColor = Color.Red;
            gunaLineTextBox.Font = new Font(Font, 18F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            gunaLineTextBox.LineColor = Color.Gainsboro;
            gunaLineTextBox.LineSize = 1;
            gunaLineTextBox.Location = ProcessGunaLineTextBoxLayout(lastGunaLineTextBox);
            gunaLineTextBox.MaxLength = 3;
            gunaLineTextBox.Name = LastRetrievedGunaLineTextBoxName;
            gunaLineTextBox.PasswordChar = '\0';
            gunaLineTextBox.Size = new Size(90, 42);
            gunaLineTextBox.TabIndex = 999;
            gunaLineTextBox.Text = "10";
            gunaLineTextBox.TextAlign = HorizontalAlignment.Center;
            gunaLineTextBox.TextOffsetX = 3;
            gunaLineTextBox.KeyPress += new KeyPressEventHandler(
                (object sender, KeyPressEventArgs e) => {
                    FormsUtils.ProcessKeyPress(e);
                }
            );
        }

        public static Point ProcessGunaLineTextBoxLayout(GunaLineTextBox lastGunaLineTextBox)
        {
            return new Point(333, lastGunaLineTextBox == null ? 29 : lastGunaLineTextBox.Location.Y + 72);
        }

        public static GunaLineTextBox GetLastGunaLineTextBoxByGunaLineTextBoxName(TabPage tabPage)
        {
            GunaLineTextBox lastGunaLineTextBox = null;
            foreach (Control control in tabPage.Controls)
            {
                if (control is GunaLineTextBox && control.Name == LastRetrievedGunaLineTextBoxName)
                {
                    lastGunaLineTextBox = (GunaLineTextBox)control;
                }
            }
            return lastGunaLineTextBox;
        }
    }
}
