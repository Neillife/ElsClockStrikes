using ElsClockStrikes.Core.Triggers;
using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ElsClockStrikes.Core
{
    public abstract class BaseHotKeyManager : IDisposable
    {
        private IKeyboardMouseEvents globalHook;
        protected List<IHotKeyTrigger> triggerList;

        protected BaseHotKeyManager(Type type)
        {
            globalHook = Hook.GlobalEvents();
            globalHook.KeyDown += GlobalHookKeyDown;
        }

        public void InitializeKeyMapWithTriggers(Control parent, Type type)
        {
            triggerList = this.GetTriggerListByComboBoxSelect(parent, type);
        }

        public List<IHotKeyTrigger> GetTriggerList()
        {
            return triggerList;
        }

        public void Dispose()
        {
            if (globalHook != null)
            {
                globalHook.KeyDown -= GlobalHookKeyDown;
                globalHook.Dispose();
                globalHook = null;

                foreach (IHotKeyTrigger hotKeyTrigger in triggerList)
                {
                    if (hotKeyTrigger.hotKeyContainer.timer != null)
                    {
                        hotKeyTrigger.hotKeyContainer.timer.Stop();
                        hotKeyTrigger.hotKeyContainer.label.ForeColor = Color.FromArgb(245, 245, 245);
                    }
                    if (hotKeyTrigger.hotKeyContainer.audioPlayer != null)
                    {
                        hotKeyTrigger.hotKeyContainer.audioPlayer.Stop();
                    }
                }
            }
        }

        private void GlobalHookKeyDown(object sender, KeyEventArgs e)
        {
            foreach (IHotKeyTrigger hotKeyTrigger in triggerList)
            {
                if (hotKeyTrigger.OnKeyDown(e.KeyCode))
                {
                    ResetAllTriggers();
                    break;
                }
            }
        }

        private void ResetAllTriggers()
        {
            foreach (IHotKeyTrigger hotKeyTrigger in triggerList)
            {
                hotKeyTrigger.Reset();
            }
        }

        protected abstract List<IHotKeyTrigger> GetTriggerListByComboBoxSelect(Control parent, Type type);
    }
}
