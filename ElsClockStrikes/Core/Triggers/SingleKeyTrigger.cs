using System.Drawing;
using System.Windows.Forms;

namespace ElsClockStrikes.Core.Triggers
{
    public class SingleKeyTrigger : IHotKeyTrigger
    {
        private readonly Control formsInstance;
        public HotKeyContainer hotKeyContainer { get; }

        public SingleKeyTrigger(Control control, HotKeyContainer container)
        {
            this.formsInstance = control;
            this.hotKeyContainer = container;
        }

        public bool OnKeyDown(Keys inputKey)
        {
            if (inputKey != (Keys)hotKeyContainer.triggerKey)
                return false;

            if (hotKeyContainer.timer == null)
                return true;

            if (hotKeyContainer.timer.Enabled)
            {
                hotKeyContainer.method.Invoke(hotKeyContainer.invokeObj, new object[] { hotKeyContainer.textBox.Text });
            }
            else
            {
                hotKeyContainer.timer.Start();
            }

            hotKeyContainer.label.ForeColor = Color.FromArgb(245, 245, 245);
            hotKeyContainer.audioPlayer?.Stop();
            hotKeyContainer.actionMethod?.Invoke(formsInstance.Parent.Parent, null);
            return false;
        }

        public void Reset()
        {
            if (hotKeyContainer.timer != null)
            {
                hotKeyContainer.label.Text = hotKeyContainer.textBox.Text;
                hotKeyContainer.label.ForeColor = Color.FromArgb(245, 245, 245);
                hotKeyContainer.method.Invoke(hotKeyContainer.invokeObj, new object[] { hotKeyContainer.textBox.Text });
                hotKeyContainer.timer?.Stop();
                hotKeyContainer.audioPlayer?.Stop();
            } 
            else
            {
                // Invoke resetKey action
                hotKeyContainer.actionMethod?.Invoke(null, null);
            }
        }
    }
}
