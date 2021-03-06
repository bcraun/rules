﻿namespace ConsoleApplication1
{
    public class IntegerLessThanRuleFactory : IRuleFactory<int>
    {
        public BaseRule<int> Make(int threshold) => new IntegerGreaterThanRule(threshold);
    }
}