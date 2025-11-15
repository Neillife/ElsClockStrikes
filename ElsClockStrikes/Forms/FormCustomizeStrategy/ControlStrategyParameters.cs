using ElsClockStrikes.Core;
using Guna.UI.WinForms;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ElsClockStrikes.Forms.FormCustomizeStrategy
{
    public class ControlStrategyParameters
    {
        public TabPage tabPage { get; set; }
        public string custSettingFormsInputData { get; set; }
        public List<CustomizeTaskTimer> customizeTaskTimerList { get; set; }
        public Label timeLeftLabel { get; set; }
        public GunaLineTextBox gunaLineTextBox { get; set; }
        public GunaPanel gunaPanel { get; set; }
        public GunaLineTextBox soundLineTextBox { get; set; }
    }
}
