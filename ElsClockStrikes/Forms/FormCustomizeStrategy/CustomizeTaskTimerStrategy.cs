using ElsClockStrikes.Core;

namespace ElsClockStrikes.Forms.FormCustomizeStrategy
{
    public class CustomizeTaskTimerStrategy : BaseControlStrategy
    {
        public override void AddControl(ControlStrategyParameters controlStrategyParameters)
        {
            CustomizeTaskTimer customizeTaskTimer = new CustomizeTaskTimer($"{FormsConstant.timerBaseName}{FormsConstant.indexForCustomizeName}");
            customizeTaskTimer.setTimeLeftLabel(controlStrategyParameters.timeLeftLabel)
                .setCustomTimeGunaLineTextBox(controlStrategyParameters.gunaLineTextBox);
            controlStrategyParameters.customizeTaskTimerList.Add(customizeTaskTimer);
        }
    }
}
