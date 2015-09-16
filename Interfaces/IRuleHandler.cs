namespace ConsoleApplication1
{
    public interface IRuleHandler<TRuleExecutor, TResponse>
        where TRuleExecutor : IRuleExecutor
    {
        TResponse Handle(
            TRuleExecutor executor, 
            IRuleContext<double> context);
    }
}