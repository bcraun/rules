using System;
using SimpleInjector;

namespace ConsoleApplication1.CompositionRoot
{
    public static class Bootstrapper
    {
        public static Container Compose()
        {
            var container = new Container();

            container.RegisterCollection(typeof(IRulePreHandler<>), AppDomain.CurrentDomain.GetAssemblies());
            container.RegisterCollection(typeof(IRuleHandler<,>), AppDomain.CurrentDomain.GetAssemblies());
            container.RegisterCollection(typeof(IRulePostHandler<,>), AppDomain.CurrentDomain.GetAssemblies());
            container.RegisterCollection(typeof(IRuleExecutor), AppDomain.CurrentDomain.GetAssemblies());
            container.RegisterCollection(typeof(IRuleFactory<>), AppDomain.CurrentDomain.GetAssemblies());
            container.Register(typeof(IRuleContextProvider), typeof(RuleContextProvider));

            container.RegisterDecorator(typeof(IRuleHandler<,>), typeof(RuleMediatorPipeline<,>));

            container.Verify(VerificationOption.VerifyAndDiagnose);

            return container;
        }
    }
}