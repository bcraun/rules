using System;
using System.Linq;
using SimpleInjector;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main()
        {
            var container = new Container();

            container.RegisterCollection(typeof (IPointRulePreHandler<>), AppDomain.CurrentDomain.GetAssemblies());
            container.RegisterCollection(typeof (IPointRuleHandler<,>), AppDomain.CurrentDomain.GetAssemblies());
            container.RegisterCollection(typeof (IPointRulePostHandler<,>), AppDomain.CurrentDomain.GetAssemblies());
            container.RegisterCollection(typeof (IRequest<>), AppDomain.CurrentDomain.GetAssemblies());
            container.RegisterCollection(typeof (IRuleFactory<>), AppDomain.CurrentDomain.GetAssemblies());
            container.Register(typeof (IPointConfigurationProvider), typeof(ServiceFabricPointConfigurationProvider));

            container.RegisterDecorator(typeof (IPointRuleHandler<,>), typeof (PointRuleMediatorPipeline<,>));

            container.Verify(VerificationOption.VerifyAndDiagnose);

            // Test point value changed rule
            var pointWarningHandler =
                container.GetAllInstances(typeof (IPointRuleHandler<PointWarningRuleRequest, RuleResponse>))
                    .Cast<IPointRuleHandler<PointWarningRuleRequest, RuleResponse>>()
                    .First();
            var pointWarningRequest =
                (PointWarningRuleRequest)
                    container.GetAllInstances(typeof(IRequest<RuleResponse>))
                        .First(i => i.GetType() == typeof(PointWarningRuleRequest));
            Console.WriteLine($"[50.034 >= 323.23] --> {pointWarningHandler.Handle(pointWarningRequest).Result}\n");

            var pointValueChangedHandler =
                container.GetAllInstances(typeof (IPointRuleHandler<PointValueChangedRuleRequest, RuleResponse>))
                    .Cast<IPointRuleHandler<PointValueChangedRuleRequest, RuleResponse>>()
                    .First();
            var pointValueChangedRequest =
                (PointValueChangedRuleRequest)
                    container.GetAllInstances(typeof (IRequest<RuleResponse>))
                        .First(i => i.GetType() == typeof (PointValueChangedRuleRequest));
            Console.WriteLine($"[23.3213 == 23.3214] --> {pointValueChangedHandler.Handle(pointValueChangedRequest).Result}\n");

            // Test point alarm rule
            var pointAlarmHandler =
                container.GetAllInstances(typeof (IPointRuleHandler<PointAlarmRuleRequest, RuleResponse>))
                    .Cast<IPointRuleHandler<PointAlarmRuleRequest, RuleResponse>>()
                    .First();
            var pointAlarmRuleRequest =
                (PointAlarmRuleRequest)
                    container.GetAllInstances(typeof (IRequest<RuleResponse>))
                        .First(i => i.GetType() == typeof (PointAlarmRuleRequest));
            Console.WriteLine($"[43.324 >= 23.3214] --> {pointAlarmHandler.Handle(pointAlarmRuleRequest).Result}\n");
        }
    }
}