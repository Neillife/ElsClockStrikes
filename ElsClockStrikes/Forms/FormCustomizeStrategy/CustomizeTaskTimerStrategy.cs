using ElsClockStrikes.Core;

namespace ElsClockStrikes.Forms.FormCustomizeStrategy
{
    public class CustomizeTaskTimerStrategy : BaseControlStrategy
    {
        private bool isDisableSound;

        public CustomizeTaskTimerStrategy(bool isDisableSound)
        {
            this.isDisableSound = isDisableSound;
        }

        public override void AddControl(ControlStrategyParameters controlStrategyParameters)
        {
            CustomizeTaskTimer customizeTaskTimer = new CustomizeTaskTimer($"{FormsConstant.timerBaseName}{FormsConstant.indexForCustomizeName}");
            customizeTaskTimer.setTimeLeftLabel(controlStrategyParameters.timeLeftLabel)
                .setCustomTimeGunaLineTextBox(controlStrategyParameters.gunaLineTextBox)
                .setCustomVolumeGunaLineTextBox(controlStrategyParameters.soundLineTextBox);

            if (isDisableSound)
            {
                customizeTaskTimer.setAudioPlayer(null);
            } else
            {
                customizeTaskTimer.setAudioPlayer(new AudioPlayer(Properties.Resources.荊棘延遲翻桌陰陽陣DefultSound));
            }

            controlStrategyParameters.customizeTaskTimerList.Add(customizeTaskTimer);
        }
    }
}
