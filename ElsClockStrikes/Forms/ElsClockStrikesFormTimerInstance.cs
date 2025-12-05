using Guna.UI.WinForms;
using MetroSuite;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ElsClockStrikes.Forms
{
    public partial class ElsClockStrikesFormTimerInstance : MetroForm
    {
        private Label externalKeyLabel;
        private Control originKeyParent;
        private Label externalNameLabel;
        private Control originNameParent;
        private Label externalCDLabel;
        private Control originCDParent;
        private GunaButton externalSettingBtn;
        private int maxLabelWidth;

        public ElsClockStrikesFormTimerInstance(FormInstanceParameters tip, GunaButton settingBtn, int maxLabelWidth, bool topMost, Point pos = default(Point))
        {
            InitializeComponent();
            externalKeyLabel = tip.keyLabel;
            originKeyParent = tip.keyLabel.Parent;

            externalNameLabel = tip.nameLabel;
            originNameParent = tip.nameLabel.Parent;

            externalCDLabel = tip.timeLeftLabel;
            originCDParent = tip.timeLeftLabel.Parent;

            externalSettingBtn = settingBtn;
            this.maxLabelWidth = maxLabelWidth;
            this.TopMost = topMost;

            if (pos.X != 0)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = pos;
            }
        }

        public string GetMechanicName()
        {
            return externalNameLabel.Name;
        }

        public Label GetHotKeyLabel()
        {
            return externalKeyLabel;
        }

        public Label GetMechanicLabel()
        {
            return externalNameLabel;
        }

        public Label GetTimeLeftLabel()
        {
            return externalCDLabel;
        }

        public void ProcessFormClose()
        {
            Controls.Remove(externalKeyLabel);
            originKeyParent.Controls.Add(externalKeyLabel);
            Controls.Remove(externalNameLabel);
            originNameParent.Controls.Add(externalNameLabel);
            Controls.Remove(externalCDLabel);
            originCDParent.Controls.Add(externalCDLabel);
        }

        private void WindowsSetting_Click(object sender, EventArgs e)
        {
            this.ProcessFormClose();
            externalSettingBtn.PerformClick();
            this.Close();
        }

        private void ElsClockStrikesFormTimerInstance_Load(object sender, EventArgs e)
        {
            originKeyParent.Controls.Remove(externalKeyLabel);
            Controls.Add(externalKeyLabel);
            originNameParent.Controls.Remove(externalNameLabel);
            Controls.Add(externalNameLabel);
            originCDParent.Controls.Remove(externalCDLabel);
            Controls.Add(externalCDLabel);

            if (FormsCustomizeUtils.GetSeqSplitStrs(externalKeyLabel.Text).Length == 1)
            {
                externalKeyLabel.Location = new Point(5, 30);
                externalNameLabel.Location = new Point(maxLabelWidth - externalNameLabel.Width + externalKeyLabel.Width - 5, externalKeyLabel.Top + externalKeyLabel.Height - externalNameLabel.Height - 3);
                externalCDLabel.Location = new Point(externalNameLabel.Left + externalNameLabel.Width, externalKeyLabel.Location.Y);
            }
            else
            {
                externalKeyLabel.Location = new Point(5, 40);
                externalNameLabel.Location = new Point(maxLabelWidth - externalNameLabel.Width + externalKeyLabel.Width - 28, externalKeyLabel.Top + externalKeyLabel.Height - externalNameLabel.Height + 4);
                externalCDLabel.Location = new Point(125, 32);
            }
        }
    }
}
