namespace ConsoleApplication1
{
    public class RuleExecutionResponse : IRuleExecutor
    {
        public bool Result { get; set; }
        public CurrentStateType CurrentState { get; set; }
    }
}