using System.Windows.Forms;

namespace ElsClockStrikes.Core.Triggers
{
    public interface IHotKeyTrigger
    {
        HotKeyContainer hotKeyContainer { get; }
        bool OnKeyDown(Keys key);
        void Reset();
    }
}
