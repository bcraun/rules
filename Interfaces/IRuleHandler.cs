using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public interface IRuleHandler<TRuleExecutor, TResponse>
        where TRuleExecutor : IRuleExecutor
    {
        TResponse HandleAsync(
            TRuleExecutor executor,
            IRuleContext context);
    }
}