namespace ConsoleApplication1
{
    public interface IRuleFactory<TType>
    {
        BaseRule<TType> Make(TType threshold);
    }
}