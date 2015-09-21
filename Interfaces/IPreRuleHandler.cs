using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public interface IPreRuleHandler<TRuleExecutor>
    {
        Task HandleASync(
            TRuleExecutor executor, 
            IRuleContext context);
    }
}