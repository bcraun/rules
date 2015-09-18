namespace ConsoleApplication1
{
    public class RuleExecutionResponse : IRuleExecutionResponse
    {
        public CurrentStateType CurrentState { get; set; }

        public RuleExecutionResponse()
        {
            CurrentState = CurrentStateType.Normal;
        }
    }

    public interface IRuleExecutionResponse
    {
    }
}