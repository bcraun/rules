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

using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class LowWarningRuleExecutor : IRuleExecutor //<RuleExecutionResponse>
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

        public RuleExecutionResponse ExecuteRuleAsync(IRuleContext context)
        {
            var pointContext = (PointRuleContext)context;

            double actual = (double) pointContext.CurrentValue;
            double threshold = pointContext.LowWarningValue;

            var rule = RuleFactory.First(r => r.GetType() == typeof(DoubleLessThanRuleFactory)).Make(threshold);

            var ruleEngine = _engineFactory.Make(actual);
            ruleEngine.Add(rule);

            var result = new RuleExecutionResponse();
            // TODO: Interpret the result and update the RuleExecutionResponse enum
            if (ruleEngine.MatchAny())
            {
                result.CurrentState = CurrentStateType.AnalogLowWarning;
            }

            return result;
        }
    }
}