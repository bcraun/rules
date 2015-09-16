namespace ConsoleApplication1
{
    /// <summary>
    /// Defines the expected members of a RuleEngine
    /// </summary>
    public interface IRuleEngine
    {
        /// <summary>
        /// Matches all rules.
        /// </summary>
        /// <returns></returns>
        bool MatchAllRules();

        /// <summary>
        /// Matches any rule.
        /// </summary>
        /// <returns></returns>
        bool MatchesAnyRule();
    }
}