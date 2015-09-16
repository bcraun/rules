// <copyright file="LowWarningRuleExecutor.cs" company="Mesh Systems, LLC">
//
// Copyright (c) year All Right Reserved, http://mesh-systems.com/
//
// NOTICE:  All information contained herein is, and remains the 
// property of Mesh Systems, LLC and its suppliers, if any.
// The intellectual and technical concepts contained herein are 
// proprietary to Mesh Systems, LLC and its suppliers and may be 
// covered by U.S. and Foreign Patents, patents in process, and 
// are protected by trade secret or copyright law. Dissemination
// of this information or reproduction of this material is strictly 
// forbidden unless prior written permission is obtained from 
// Mesh Systems, LLC.
//
// </copyright>

using System.Linq;

namespace ConsoleApplication1
{
    public class LowWarningRuleExecutor : IRuleExecutor
    {
        private readonly IRuleEngineFactory<double> _engineFactory;
        private IRuleFactory<double>[] RuleFactory { get; }

        public LowWarningRuleExecutor(
            IRuleFactory<double>[] ruleFactory, 
            IRuleEngineFactory<double> engineFactory)
        {
            _engineFactory = engineFactory;
            RuleFactory = ruleFactory;
        }

        public RuleExecutionResponse ExecuteRule(IRuleContext<double> context)
        {
            var pointContext = (PointRuleContext)context;

            double actual = pointContext.CurrentValue;
            double threshold = pointContext.LowWarningValue;

            var rule = RuleFactory.First(r => r.GetType() == typeof(DoubleLessThanRuleFactory)).Make(threshold);

            var ruleEngine = _engineFactory.Make(actual);
            ruleEngine.Add(rule);

            return new RuleExecutionResponse { Result = ruleEngine.MatchAny() };
        }
    }
}