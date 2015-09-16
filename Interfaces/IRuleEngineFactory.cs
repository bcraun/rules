namespace ConsoleApplication1
{
    public interface IRuleEngineFactory<T>
    {
        RuleEngine<T> Make(T value);
    }
}