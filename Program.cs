using System;
using System.Linq;
using System.Threading;
using ConsoleApplication1.CompositionRoot;
using SimpleInjector;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static Container _container;
        private static ManualResetEvent _mre = new ManualResetEvent(false);

        private static void Main()
        {
            _container = Bootstrapper.Compose();

            var analogContext = new PointRuleContext
            {
                SourceKey = "432234145142314_8973",
                IsEnabled = true,
                HighAlarmEnabled = true,
                LowAlarmEnabled = true,
                HighWarningEnabled = true,
                LowWarningEnabled = true,
                CurrentValue = 105.543,
                HighAlarmValue = 100.532,
                HighWarningValue = 50.907,
                LowWarningValue = 25.123,
                LowAlarmValue = 5.234,
                NotificationLevel = 1,
                LastReceiveUtc = DateTime.UtcNow.AddDays(-20),
            };

            // Test the high alarm rule
            ExecuteHighAlarmRules(analogContext);

            // Test the high warning rule
            ExecuteHighWarningRules(analogContext);

            // Test the low warning rule
            ExecuteLowWarningRules(analogContext);

            // Test the low alarm rule
            ExecuteLowAlarmRules(analogContext);

            // Test a disabled rule
            var disabledPointContext = new PointRuleContext
            {
                IsEnabled = false,
            };

            ExecuteDisabledPoint(disabledPointContext);

            // Test the out of alarm rule
            var outOfAlarmContext = new PointRuleContext
            {
                SourceKey = "432234145142314_8973",
                IsEnabled = true,
                NotificationLevel = 1,
                CurrentValue = 0,
                LastValue = 1
            };

            ExecuteDigitalOutOfAlarmRules(outOfAlarmContext);

            // Test the into alarm rule
            var intoAlarmContext = new PointRuleContext
            {
                SourceKey = "432234145142314_8973",
                IsEnabled = true,
                NotificationLevel = 1,
                CurrentValue = 1,
                LastValue = 0
            };

            ExecuteDigitalIntoAlarmRules(intoAlarmContext);

            Console.ReadLine();
        }

        private static async void ExecuteDisabledPoint(PointRuleContext disabledPointContext)
        {
            var highAlarmHandler =
                _container.GetAllInstances(typeof (IRuleHandler<HighAlarmRuleExecutor, RuleExecutionResponse>))
                    .Cast<IRuleHandler<HighAlarmRuleExecutor, RuleExecutionResponse>>()
                    .First();
            var highAlarmRuleExecutor =
                (HighAlarmRuleExecutor)
                    _container
                        .GetAllInstances(typeof (IRuleExecutor))
                        .First(i => i.GetType() == typeof (HighAlarmRuleExecutor));

            var result = highAlarmHandler.HandleAsync(highAlarmRuleExecutor, disabledPointContext);

            // Returns whether the current value is greater than the threshold value
            if (null != result)
            {
                Console.WriteLine("Disabled point\n");
            }
        }

        private static async void ExecuteHighAlarmRules(PointRuleContext analogContext)
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

            var result = highAlarmHandler.HandleAsync(highAlarmRuleExecutor, analogContext);

            // Returns whether the current value is greater than the threshold value
            Console.WriteLine("High Alarm (threshold/cur) " +
                              $"[{analogContext.HighAlarmValue} - {analogContext.CurrentValue}] --> " +
                              $"{result.CurrentState}\n");
        }

        private static async void ExecuteLowAlarmRules(PointRuleContext analogContext)
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

            var result = lowAlarmHandler.HandleAsync(lowAlarmRuleExecutor, analogContext);

            // Returns whether the threshold value is less than the current value
            Console.WriteLine("Low Alarm (threshold/cur) " +
                              $"[{analogContext.LowAlarmValue} - {analogContext.CurrentValue}] --> " +
                              $"{result.CurrentState}\n");
        }

        private static async void ExecuteHighWarningRules(PointRuleContext analogContext)
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

            var result = highWarningHandler.HandleAsync(highWarningRuleExecutor, analogContext);

            // Returns whether the current value is greater than the threshold value
            Console.WriteLine("High Warning (threshold/cur) " +
                              $"[{analogContext.HighWarningValue} - {analogContext.CurrentValue}] --> " +
                              $"{result.CurrentState}\n");
        }

        private static async void ExecuteLowWarningRules(PointRuleContext analogContext)
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

            var result = lowWarningHandler.HandleAsync(lowWarningRuleExecutor, analogContext);

            // Returns whether the threshold value is less than the current value
            Console.WriteLine("Low Warning (threshold/cur) " +
                              $"[{analogContext.LowWarningValue} - {analogContext.CurrentValue}] --> " +
                              $"{result.CurrentState}\n");
        }

        private static async void ExecuteDigitalOutOfAlarmRules(PointRuleContext digitalOutOfAlarmContext)
        {
            var outOfAlarmHandler =
                _container
                    .GetAllInstances(typeof(IRuleHandler<AlarmDetectRuleExecutor, RuleExecutionResponse>))
                    .Cast<IRuleHandler<AlarmDetectRuleExecutor, RuleExecutionResponse>>()
                    .First();
            var outOfAlarmRuleExecutor =
                (AlarmDetectRuleExecutor)
                    _container
                        .GetAllInstances(typeof(IRuleExecutor))
                        .First(i => i.GetType() == typeof(AlarmDetectRuleExecutor));

            var result = outOfAlarmHandler.HandleAsync(outOfAlarmRuleExecutor, digitalOutOfAlarmContext);

            // Returns whether the current value is less than the previous value
            Console.WriteLine("Digital out of alarm (prev/cur) " +
                              $"[{digitalOutOfAlarmContext.LastValue} - {digitalOutOfAlarmContext.CurrentValue}] --> " +
                              $"{result.CurrentState}\n");
        }
        private static async void ExecuteDigitalIntoAlarmRules(PointRuleContext digitalIntoAlarmContext)
        {
            var intoAlarmHandler =
                _container
                    .GetAllInstances(typeof(IRuleHandler<AlarmDetectRuleExecutor, RuleExecutionResponse>))
                    .Cast<IRuleHandler<AlarmDetectRuleExecutor, RuleExecutionResponse>>()
                    .First();

            var intoAlarmRuleExecutor =
                (AlarmDetectRuleExecutor)
                    _container
                        .GetAllInstances(typeof(IRuleExecutor))
                        .First(i => i.GetType() == typeof(AlarmDetectRuleExecutor));

            var result = intoAlarmHandler.HandleAsync(intoAlarmRuleExecutor, digitalIntoAlarmContext);

            // Returns whether the current value is less than the previous value
            Console.WriteLine("Digital into alarm (prev/cur) " +
                              $"[{digitalIntoAlarmContext.LastValue} - {digitalIntoAlarmContext.CurrentValue}] --> " +
                              $"{result.CurrentState}\n");
        }
    }
}