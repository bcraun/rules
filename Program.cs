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

            var analogContext = new PointRuleContext
            {
                Key = "432234145142314_8973",
                // TODO: Fix the runtime exception when point is disabled and 
                // TODO: mediator pipeline returns default(RuleExecutionResult)
                IsEnabled = true,
                HighAlarmEnabled = true,
                LowAlarmEnabled = true,
                HighWarningEnabled = true,
                LowWarningEnabled = true,
                CurrentValue = 105.543,
                HighAlarmValue = 100.532,
                HighWarningValue = 50.907,
                LowWarningValue = 25.123,
                LowAlarmValue = 5.234
            };

            // Test the high alarm rule
            ExecuteHighAlarmRules(analogContext);

            // Test the high warning rule
            ExecuteHighWarningRules(analogContext);

            // Test the low warning rule
            ExecuteLowWarningRules(analogContext);

            // Test the low alarm rule
            ExecuteLowAlarmRules(analogContext);

            var digitalContextRising = new PointRuleContext
            {
                Key = "432234145142314_8973",
                IsEnabled = true,
                AlarmOnOne = true,
                CurrentValue = 1,
                PreviousValue = 0
            };

            // Test the rising edge rule
            ExecuteDigitalRisingEdgeRules(digitalContextRising);

            var digitalContextFalling = new PointRuleContext
            {
                Key = "432234145142314_8973",
                IsEnabled = true,
                AlarmOnZero = true,
                CurrentValue = 0,
                PreviousValue = 1
            };

            // Test the falling edge rule
            ExecuteDigitalFallingEdgeRules(digitalContextFalling);
        }

        private static void ExecuteHighAlarmRules(PointRuleContext analogContext)
        {
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
            Console.WriteLine($"High Alarm (threshold/cur) [{analogContext.HighAlarmValue} - {analogContext.ScaledValue}] --> {highAlarmHandler.Handle(highAlarmRuleExecutor, analogContext).CurrentState}\n");
        }

        private static void ExecuteLowAlarmRules(PointRuleContext analogContext)
        {
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
            Console.WriteLine($"Low Alarm (threshold/cur) [{analogContext.LowAlarmValue} - {analogContext.ScaledValue}] --> {lowAlarmHandler.Handle(lowAlarmRuleExecutor, analogContext).CurrentState}\n");
        }

        private static void ExecuteHighWarningRules(PointRuleContext analogContext)
        {
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
            Console.WriteLine($"High Warning (threshold/cur) [{analogContext.HighWarningValue} - {analogContext.ScaledValue}] --> {highWarningHandler.Handle(highWarningRuleExecutor, analogContext).CurrentState}\n");
        }

        private static void ExecuteLowWarningRules(PointRuleContext analogContext)
        {
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
            Console.WriteLine($"Low Warning (threshold/cur) [{analogContext.LowWarningValue} - {analogContext.ScaledValue}] --> {lowWarningHandler.Handle(lowWarningRuleExecutor, analogContext).CurrentState}\n");
        }

        private static void ExecuteDigitalRisingEdgeRules(PointRuleContext digitalContextRising)
        {
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
            Console.WriteLine($"Digital Rising (prev/cur) [{digitalContextRising.PreviousValue} - {digitalContextRising.CurrentValue}] --> {risingEdgeHandler.Handle(risingEdgeRuleExecutor, digitalContextRising).CurrentState}\n");
        }

        private static void ExecuteDigitalFallingEdgeRules(PointRuleContext digitalContextFalling)
        {
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
            Console.WriteLine($"Digital Falling (prev/cur) [{digitalContextFalling.PreviousValue} - {digitalContextFalling.CurrentValue}] --> {fallingEdgeHandler.Handle(fallingEdgeRuleExecutor, digitalContextFalling).CurrentState}\n");
        }
    }
}