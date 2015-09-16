namespace ConsoleApplication1
{
    public interface IPostRuleHandler<in TRuleExecutor, in TResponse>
    {
        void Handle(
            TRuleExecutor executor, 
            IRuleContext<double> context, 
            TResponse response);
    }
}