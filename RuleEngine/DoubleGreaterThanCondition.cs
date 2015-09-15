namespace ConsoleApplication1
{
    public class DoubleGreaterThanCondition : BaseCondition<double>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleGreaterThanCondition"/> class.
        /// </summary>
        /// <param name="threshold">The threshold value.</param>
        public DoubleGreaterThanCondition(double threshold)
            : base(threshold)
        {
        }

        /// <summary>
        /// Determines whether this instance is satisfied.
        /// </summary>
        /// <returns></returns>
        public override bool IsSatisfied => Value > Threshold;
    }
}