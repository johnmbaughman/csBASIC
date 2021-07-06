using System;
using System.Collections.Generic;
using CommandLine;
using csBASIClib;

namespace csBASIC
{
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<CompilerParameters>(args)
                .WithParsed(CompileFile)
                .WithNotParsed(HandleParseError);
        }

        /// <summary>
        /// Handles the parse error.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <exception cref="NotImplementedException"></exception>
        private static void HandleParseError(IEnumerable<Error> obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Compiles the file.
        /// </summary>
        /// <param name="compilerParameters">The compiler parameters.</param>
        private static void CompileFile(CompilerParameters compilerParameters)
        {
            var basicCompiler = new BasicCompiler(compilerParameters);
            basicCompiler.CompileToClassFile(true, true);
        }
    }
}
