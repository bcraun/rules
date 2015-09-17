namespace ConsoleApplication1
{
    public interface IPostRuleHandler<TRuleExecutor, TResponse>
    {
        TResponse Handle(
            TRuleExecutor executor, 
            IRuleContext<double> context, 
            TResponse response);
    }
}