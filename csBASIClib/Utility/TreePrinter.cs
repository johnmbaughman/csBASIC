using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using csBASIClib.antlr;
using csBASIClib.Iterator;

namespace csBASIClib.Utility
{
    public class TreePrinter : ISimpleTreeWalkerCallback
    {
        private readonly TextWriter _printWriter;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreePrinter"/> class.
        /// </summary>
        /// <param name="astOutputStream">The ast output stream.</param>
        public TreePrinter(FileStream astOutputStream)
        {
            _printWriter = astOutputStream != null 
                ? new StreamWriter(astOutputStream) 
                : Console.Out;
        }

        /// <summary>
        /// Prints the tree.
        /// </summary>
        /// <param name="tree">The tree.</param>
        public void PrintTree(IParseTree tree)
        {
            SimpleTreeWalker.Iterate(tree, this);
            _printWriter.Flush();
            _printWriter.Close();
        }

        /// <summary>
        /// Parsers the rule.
        /// </summary>
        /// <param name="parserRuleContext">The parser rule context.</param>
        /// <param name="contextLevel">The context level.</param>
        public void ParserRule(ParserRuleContext parserRuleContext, int contextLevel)
        {
            _printWriter.WriteLine(IndentString(contextLevel) + "[" + parserRuleContext.RuleIndex + " " + jvmBasicParser.ruleNames[parserRuleContext.RuleIndex] + "]");
        }

        /// <summary>
        /// Indents the string.
        /// </summary>
        /// <param name="contextLevel">The context level.</param>
        /// <returns>System.String.</returns>
        private string IndentString(int contextLevel)
        {
            var sb = new StringBuilder(contextLevel);
            for (var i = 0; i < contextLevel; i++)
            {
                sb.Append(" ");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Tokens the specified common token.
        /// </summary>
        /// <param name="commonToken">The common token.</param>
        /// <param name="contextLevel">The context level.</param>
        public void Token(CommonToken commonToken, int contextLevel)
        {
            if (commonToken.Type != -1)
            {
                _printWriter.WriteLine(IndentString(contextLevel) + "[" + commonToken.Type + " " + jvmBasicParser.DefaultVocabulary.GetDisplayName(commonToken.Type) + "] " + commonToken.Text);
            }
        }
    }
}