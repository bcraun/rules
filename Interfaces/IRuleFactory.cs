namespace ConsoleApplication1
{
    public interface IRuleFactory<TType>
    {
        BaseRule<TType> MakeRule(TType threshold);
    }
}