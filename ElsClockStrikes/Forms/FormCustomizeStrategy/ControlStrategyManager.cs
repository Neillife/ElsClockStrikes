using System.Collections.Generic;

namespace ElsClockStrikes.Forms.FormCustomizeStrategy
{
    public class ControlStrategyManager
    {
        private readonly List<BaseControlStrategy> strategyList = new List<BaseControlStrategy>();
        private ControlStrategyParameters controlStrategyParameters;

        public ControlStrategyManager(ControlStrategyParameters controlStrategyParameters)
        {
            this.controlStrategyParameters = controlStrategyParameters;
            FormsConstant.indexForCustomizeName++;
        }

        public void UpdateParameters(ControlStrategyParameters controlStrategyParameters)
        {
            this.controlStrategyParameters = controlStrategyParameters;
        }

        public void ClearStrategyList()
        {
            strategyList.Clear();
        }

        public ControlStrategyManager RegisterStrategy(BaseControlStrategy strategy)
        {
            strategyList.Add(strategy);
            return this;
        }

        public ControlStrategyManager Execute(BaseControlStrategy strategy)
        {
            strategy.AddControl(this.controlStrategyParameters);
            return this;
        }

        public ControlStrategyManager ExecuteAll()
        {
            foreach (BaseControlStrategy strategy in strategyList)
            {
                strategy.AddControl(this.controlStrategyParameters);
            }
            return this;
        }
    }
}
