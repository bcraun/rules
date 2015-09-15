using System;
using System.Linq;
using ConsoleApplication1;
using SimpleInjector;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            var container = new Container();

            container.RegisterCollection(typeof(IPreRuleHandler<>), AppDomain.CurrentDomain.GetAssemblies());
            container.RegisterCollection(typeof(IRuleHandler<,>), AppDomain.CurrentDomain.GetAssemblies());
            container.RegisterCollection(typeof(IPostRuleHandler<,>), AppDomain.CurrentDomain.GetAssemblies());
            container.RegisterCollection(typeof(IRequest<>), AppDomain.CurrentDomain.GetAssemblies());

            container.RegisterDecorator(typeof(IRuleHandler<,>), typeof(RuleMediatorPipeline<,>));

            container.Verify(VerificationOption.VerifyAndDiagnose);

            var handler = container.GetAllInstances(typeof(IRuleHandler<RuleRequest, RuleResponse>)).Cast<IRuleHandler<RuleRequest, RuleResponse>>().First();

            var analogRequest = (RuleRequest)container.GetAllInstances(typeof(IRequest<RuleResponse>)).First();

            handler.Handle(analogRequest);
        }
    }

    public interface IRequest<TResponse>
    {

    }

    public class RuleRequest : IRequest<RuleResponse>
    {
    }

    public class RuleResponse : IRequest<bool>
    {

    }

    //    public interface IRuleRunner<in TBaseRule, out TRuleResponse, T> where TBaseRule : BaseRule<T> where T : struct
    //    {
    //        TRuleResponse ExecuteRule(TBaseRule rule);
    //    }

    public class IntegerGreaterThanRule : BaseRule<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerGreaterThanRule"/> class.
        /// </summary>
        /// <param name="threshold">The threshold.</param>
        public IntegerGreaterThanRule(int threshold)
            : base(threshold)
        {
            Initialize();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public override sealed void Initialize()
        {
            // Clear any existing conditions
            Conditions.Clear();

            // Create our conditions
            var condition1 = new IntegerGreaterThanCondition(Threshold);

            // ...and add them to our collection of conditions
            Conditions.Add(condition1);
        }

        /// <summary>
        /// Matches the conditions.
        /// </summary>
        /// <returns></returns>
        public override bool MatchConditions()
        {
            return MatchesAnyCondition();
        }
    }
}

public class RuleMediatorPipeline<TRequest, TResponse>
    : IRuleHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{

    private readonly IRuleHandler<TRequest, TResponse> _inner;
    private readonly IPreRuleHandler<TRequest>[] _preRuleHandlers;
    private readonly IPostRuleHandler<TRequest, TResponse>[] _postRuleHandlers;

    public RuleMediatorPipeline(
        IRuleHandler<TRequest, TResponse> inner,
        IPreRuleHandler<TRequest>[] preRuleHandlers,
        IPostRuleHandler<TRequest, TResponse>[] postRuleHandlers
        )
    {
        _inner = inner;
        _preRuleHandlers = preRuleHandlers;
        _postRuleHandlers = postRuleHandlers;
    }

    public TResponse Handle(TRequest message)
    {

        foreach (var preRequestHandler in _preRuleHandlers)
        {
            preRequestHandler.Handle(message);
            Console.WriteLine("Pre handler executed");
        }

        var result = _inner.Handle(message);
        Console.WriteLine("Handler executed");

        foreach (var postRequestHandler in _postRuleHandlers)
        {
            postRequestHandler.Handle(message, result);
            Console.WriteLine("Post handler executed");
        }

        return result;
    }
}
