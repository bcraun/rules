namespace ConsoleApplication1
{
    public interface IPreRuleHandler<TRuleExecutor, TResponse>
    {
        TResponse Handle(
            TRuleExecutor executor, 
            IRuleContext<double> context);
    }
}