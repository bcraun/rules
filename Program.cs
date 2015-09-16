using System;
using System.Linq;
using ConsoleApplication1.CompositionRoot;
using SimpleInjector;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static Container _container;
        private static void Main()
        {
            _container = Bootstrapper.Compose();

            // Test the high alarm rule
            ExecuteHighAlarmRules();

            // Test the low alarm rule
            ExecuteLowAlarmRules();
        
            // Test the high warning rule
            ExecuteHighWarningRules();

            // Test the low warning rule
            ExecuteLowWarningRules();

            // Test the rising edge rule
            ExecuteDigitalRisingEdgeRules();

            // Test the falling edge rule
            ExecuteDigitalFallingEdgeRules();
        }

        private static void ExecuteHighAlarmRules()
        {
            var context = new DoubleRuleContext { Key = "432234145142314_8973", HighAlarmEnabled = true, CurrentValue = 39.543, HighAlarmValue = 32.532 };

            var highAlarmHandler =
                _container.GetAllInstances(typeof(IRuleHandler<HighAlarmRuleExecutor, RuleExecutionResponse>))
                    .Cast<IRuleHandler<HighAlarmRuleExecutor, RuleExecutionResponse>>()
                    .First();
            var highAlarmRuleExecutor =
                (HighAlarmRuleExecutor)
                    _container
                        .GetAllInstances(typeof(IRuleExecutor))
                        .First(i => i.GetType() == typeof(HighAlarmRuleExecutor));

            // Returns whether the current value is greater than the threshold value
            Console.WriteLine($"[{context.HighAlarmValue} < {context.CurrentValue}] --> {highAlarmHandler.Handle(highAlarmRuleExecutor, context).Result}\n");
        }

        private static void ExecuteLowAlarmRules()
        {
            var context = new DoubleRuleContext { Key = "432234145142314_8973", LowAlarmEnabled = true, CurrentValue = 42.890, LowAlarmValue = 43.234 };

            var lowAlarmHandler =
                _container
                    .GetAllInstances(typeof(IRuleHandler<LowAlarmRuleExecutor, RuleExecutionResponse>))
                    .Cast<IRuleHandler<LowAlarmRuleExecutor, RuleExecutionResponse>>()
                    .First();
            var lowAlarmRuleExecutor =
                (LowAlarmRuleExecutor)
                    _container
                        .GetAllInstances(typeof(IRuleExecutor))
                        .First(i => i.GetType() == typeof(LowAlarmRuleExecutor));

            // Returns whether the threshold value is less than the current value
            Console.WriteLine($"[{context.LowAlarmValue} < {context.CurrentValue}] --> {lowAlarmHandler.Handle(lowAlarmRuleExecutor, context).Result}\n");
        }

        private static void ExecuteHighWarningRules()
        {
            var context = new DoubleRuleContext { Key = "432234145142314_8973", HighWarningEnabled = true, CurrentValue = 65.435, HighWarningValue = 43.907 };

            var highWarningHandler =
                _container
                    .GetAllInstances(typeof(IRuleHandler<HighWarningRuleExecutor, RuleExecutionResponse>))
                    .Cast<IRuleHandler<HighWarningRuleExecutor, RuleExecutionResponse>>()
                    .First();
            var highWarningRuleExecutor =
                (HighWarningRuleExecutor)
                    _container
                        .GetAllInstances(typeof(IRuleExecutor))
                        .First(i => i.GetType() == typeof(HighWarningRuleExecutor));

            // Returns whether the current value is greater than the threshold value
            Console.WriteLine($"[{context.HighWarningValue} < {context.CurrentValue}] --> {highWarningHandler.Handle(highWarningRuleExecutor, context).Result}\n");
        }

        private static void ExecuteLowWarningRules()
        {
            var context = new DoubleRuleContext { Key = "432234145142314_8973", LowWarningEnabled = true, CurrentValue = 79.435, LowWarningValue = 43.123 };

            var lowWarningHandler =
                _container
                    .GetAllInstances(typeof(IRuleHandler<LowWarningRuleExecutor, RuleExecutionResponse>))
                    .Cast<IRuleHandler<LowWarningRuleExecutor, RuleExecutionResponse>>()
                    .First();
            var lowWarningRuleExecutor =
                (LowWarningRuleExecutor)
                    _container
                        .GetAllInstances(typeof(IRuleExecutor))
                        .First(i => i.GetType() == typeof(LowWarningRuleExecutor));

            // Returns whether the threshold value is less than the current value
            Console.WriteLine($"[{context.LowWarningValue} < {context.CurrentValue}] --> {lowWarningHandler.Handle(lowWarningRuleExecutor, context).Result}\n");
        }

        private static void ExecuteDigitalRisingEdgeRules()
        {
            var context = new DoubleRuleContext { Key = "432234145142314_8973", AlarmOnOne = true, CurrentValue = 0, PreviousValue = 1 };

            var risingEdgeHandler =
                _container
                    .GetAllInstances(typeof(IRuleHandler<DigitalRisingEdgeRuleExecutor, RuleExecutionResponse>))
                    .Cast<IRuleHandler<DigitalRisingEdgeRuleExecutor, RuleExecutionResponse>>()
                    .First();
            var risingEdgeRuleExecutor =
                (DigitalRisingEdgeRuleExecutor)
                    _container
                        .GetAllInstances(typeof(IRuleExecutor))
                        .First(i => i.GetType() == typeof(DigitalRisingEdgeRuleExecutor));

            // Returns whether the current value is greater than the previous value
            Console.WriteLine($"[{context.PreviousValue} < {context.CurrentValue}] --> {risingEdgeHandler.Handle(risingEdgeRuleExecutor, context).Result}\n");
        }

        private static void ExecuteDigitalFallingEdgeRules()
        {
            var context = new DoubleRuleContext { Key = "432234145142314_8973", AlarmOnZero = true, CurrentValue = 1, PreviousValue = 0 };

            var fallingEdgeHandler =
                _container
                    .GetAllInstances(typeof(IRuleHandler<DigitalFallingEdgeRuleExecutor, RuleExecutionResponse>))
                    .Cast<IRuleHandler<DigitalFallingEdgeRuleExecutor, RuleExecutionResponse>>()
                    .First();
            var fallingEdgeRuleExecutor =
                (DigitalFallingEdgeRuleExecutor)
                    _container
                        .GetAllInstances(typeof(IRuleExecutor))
                        .First(i => i.GetType() == typeof(DigitalFallingEdgeRuleExecutor));

            // Returns whether the current value is less than the previous value
            Console.WriteLine($"[{context.PreviousValue} < {context.CurrentValue}] --> {fallingEdgeHandler.Handle(fallingEdgeRuleExecutor, context).Result}\n");
        }
    }
}