using Antlr4.Runtime;

namespace csBASIClib.Iterator
{
    public interface ISimpleTreeWalkerCallback
    {
        /// <summary>
        /// Parsers the rule.
        /// </summary>
        /// <param name="parserRuleContext">The parser rule context.</param>
        /// <param name="contextLevel">The context level.</param>
        void ParserRule(ParserRuleContext parserRuleContext, int contextLevel);

        /// <summary>
        /// Tokens the specified common token.
        /// </summary>
        /// <param name="commonToken">The common token.</param>
        /// <param name="contextLevel">The context level.</param>
        void Token(CommonToken commonToken, int contextLevel);
    }
}