﻿namespace ConsoleApplication1
{
    public class LowWarningPreRuleHandler : 
        IPreRuleHandler<LowWarningRuleExecutor>
    {
        public void Handle(
            LowWarningRuleExecutor executor, 
            IRuleContext<double> context)
        {
            // TODO: Implement point value scaling which updates the context with scaled value
        }
    }
}