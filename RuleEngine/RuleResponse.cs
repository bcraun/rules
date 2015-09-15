namespace ConsoleApplication1
{
    public class RuleResponse : IRequest<bool>
    {
        public bool Result { get; set; }
    }
}