using System.Collections.Generic;
using System.Windows.Forms;

namespace ElsClockStrikes.Core.Triggers
{
    public class SequenceKeyTrigger : IHotKeyTrigger
    {
        public HotKeyContainer hotKeyContainer { get; }
        private List<HotKeySet.KeySet> sequenceKeys;
        private int currentStep = 0;
        private readonly SingleKeyTrigger singleKeyTrigger;
        private Timer limiTimer;
        private const int LIMIT = 3000;

        public SequenceKeyTrigger(Control control, HotKeyContainer container, List<HotKeySet.KeySet> keys)
        {
            this.hotKeyContainer = container;
            this.sequenceKeys = keys;
            this.singleKeyTrigger = new SingleKeyTrigger(control, hotKeyContainer);
            this.limiTimer = new Timer();
            this.limiTimer.Interval = LIMIT;
            this.limiTimer.Tick += (t, s) => OnTimeout();
        }

        public bool OnKeyDown(Keys inputKey)
        {
            Keys firstKey = (Keys)sequenceKeys[0];

            // 不管在哪一步只要按第一鍵啟動 limiTimer
            if (inputKey == firstKey)
            {
                // 按完第二鍵後又再次按下第一鍵不回到第一步
                if (currentStep != 2)
                {
                    currentStep = 1;
                }
                limiTimer.Stop();
                limiTimer.Start();
                return false;
            }

            // 若還沒開始第一鍵但按的不是第一鍵 忽略
            if (currentStep == 0)
            {
                return false;
            }

            // 方向鍵 (稱號選擇鍵)
            if (IsArrowKey(inputKey))
            {
                ResetSequence();
                return false;
            }

            // currentStep = 2 or currentStep = 3 檢查是否按到對的鍵
            if (inputKey != (Keys)sequenceKeys[currentStep])
            {
                return false;
            }

            // 正確按鍵
            currentStep++;
            limiTimer.Stop();

            // sequence 完成 執行最終觸發
            if (currentStep >= sequenceKeys.Count)
            {
                singleKeyTrigger.OnKeyDown(inputKey);
                ResetSequence();
            }

            return false;
        }

        private bool IsArrowKey(Keys key)
        {
            // limiTimer 限制未啟動 (沒有按下第一鍵 [稱號選擇鍵]) and 按完第二鍵 (選完稱號) 不處理
            if (!limiTimer.Enabled && currentStep == 2)
            {
                return false;
            }

            Keys titleSelectKey = (Keys)sequenceKeys[1];


            // 這個 Trigger 按下正確的第二鍵 (稱號選擇正確) 不處理
            if (key == titleSelectKey)
            {
                limiTimer.Stop();
                return false;
            }

            // 這個 Trigger 按下不正確的第二鍵 (稱號選擇不正確)
            return key == Keys.Up ||
                   key == Keys.Down ||
                   key == Keys.Left ||
                   key == Keys.Right;
        }

        private void OnTimeout()
        {
            limiTimer.Stop();
            if (currentStep != 2)
            {
                currentStep = 0;
            }
        }

        private void ResetSequence()
        {
            limiTimer.Stop();
            currentStep = 0;
        }

        public void Reset()
        {
            singleKeyTrigger.Reset();
            ResetSequence();
        }
    }
}
