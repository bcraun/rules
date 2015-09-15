using ConsoleApplication1;

public class RuleHandler : IRuleHandler<RuleRequest, RuleResponse>
{
    public RuleResponse Handle(RuleRequest message)
    {
        return new RuleResponse();
    }
}