namespace ConsoleApplication1
{
    public class IntegerEqualToCondition : BaseCondition<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerEqualToCondition"/> class.
        /// </summary>
        /// <param name="threshold">The threshold value.</param>
        public IntegerEqualToCondition(int threshold)
            : base(threshold)
        {
        }

        /// <summary>
        /// Determines whether this instance is satisfied.
        /// </summary>
        /// <returns></returns>
        public override bool IsSatisfied => Value == Threshold;
    }
}