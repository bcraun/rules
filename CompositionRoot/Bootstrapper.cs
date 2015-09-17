using System;
using SimpleInjector;

namespace ConsoleApplication1.CompositionRoot
{
    public static class Bootstrapper
    {
        public static Container Compose()
        {
            var container = new Container();

            container.Register(typeof(IRuleEngineFactory<>), typeof(DoubleRuleEngineFactory));
            container.RegisterCollection(typeof(IRuleExecutionResponse), AppDomain.CurrentDomain.GetAssemblies());
            container.RegisterCollection(typeof(IPreRuleHandler<,>), AppDomain.CurrentDomain.GetAssemblies());
            container.RegisterCollection(typeof(IRuleHandler<,>), AppDomain.CurrentDomain.GetAssemblies());
            container.RegisterCollection(typeof(IPostRuleHandler<,>), AppDomain.CurrentDomain.GetAssemblies());
            container.RegisterCollection(typeof(IRuleExecutor), AppDomain.CurrentDomain.GetAssemblies());
            container.RegisterCollection(typeof(IRuleFactory<>), AppDomain.CurrentDomain.GetAssemblies());

            container.RegisterDecorator(typeof(IRuleHandler<,>), typeof(RuleMediatorPipeline<,>));

            container.Verify(VerificationOption.VerifyAndDiagnose);

            return container;
        }
    }
}