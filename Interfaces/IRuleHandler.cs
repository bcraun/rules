namespace ConsoleApplication1
{
    public interface IRuleHandler<in TRuleExecutor, out TResponse>
        where TRuleExecutor : IRuleExecutor
    {
        TResponse Handle(
            TRuleExecutor executor, 
            IRuleContext<double> context);
    }
}