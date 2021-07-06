using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using csBASIClib.antlr;

namespace csBASIClib.Iterator
{
    public static class SimpleTreeWalker
    {
        /// <summary>
        /// Iterates the specified parse tree.
        /// </summary>
        /// <param name="parseTree">The parse tree.</param>
        /// <param name="simpleTreeWalkerCallback">The simple tree walker callback.</param>
        public static void Iterate(IParseTree parseTree, ISimpleTreeWalkerCallback simpleTreeWalkerCallback)
        {
            Iterate(parseTree, simpleTreeWalkerCallback, 0);
        }

        /// <summary>
        /// Iterates the specified parse tree.
        /// </summary>
        /// <param name="parseTree">The parse tree.</param>
        /// <param name="simpleTreeWalkerCallback">The simple tree walker callback.</param>
        /// <param name="contextLevel">The context level.</param>
        private static void Iterate(IParseTree parseTree, ISimpleTreeWalkerCallback simpleTreeWalkerCallback, int contextLevel)
        {
            for (int i = 0; i < parseTree.ChildCount; i++)
            {
                var obj = parseTree.GetChild(i).Payload;
                if (obj.GetType() == typeof(CommonToken))
                {
                    simpleTreeWalkerCallback.Token((CommonToken)obj, contextLevel);
                }
                else
                {
                    simpleTreeWalkerCallback.ParserRule((ParserRuleContext)obj, contextLevel);
                    Iterate((IParseTree)obj, simpleTreeWalkerCallback, contextLevel + 1);
                }
            }
        }
    }
}