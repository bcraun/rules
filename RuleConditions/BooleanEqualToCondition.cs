namespace ConsoleApplication1
{
    public class BooleanEqualToCondition : BaseCondition<bool>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BooleanEqualToCondition"/> class.
        /// </summary>
        /// <param name="threshold">The threshold value.</param>
        public BooleanEqualToCondition(bool threshold)
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