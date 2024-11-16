using Guna.UI.WinForms;
using System.Reflection;
using System.Windows.Forms;

namespace ElsClockStrikes.Core
{
    public class HotKeyContainer
    {
        public Label label { get; set; }
        public GunaLineTextBox textBox { get; set; }
        public Timer timer { get; set; }
        public MethodInfo method { get; set; }
        public AudioPlayer audioPlayer { get; set; }
        public MethodInfo actionMethod { get; set; }
        public object invokeObj { get; set; } = null;
    }
}
