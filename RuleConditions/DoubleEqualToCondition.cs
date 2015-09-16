using System;
using static System.Double;

namespace ConsoleApplication1
{
    public class DoubleEqualToCondition : BaseCondition<double>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleEqualToCondition"/> class.
        /// </summary>
        /// <param name="threshold">The threshold value.</param>
        public DoubleEqualToCondition(double threshold)
            : base(threshold)
        {
        }

        /// <summary>
        /// Determines whether this instance is satisfied.
        /// </summary>
        /// <returns></returns>
        public override bool IsSatisfied => Math.Abs(Value - Threshold) < Epsilon;
    }
}