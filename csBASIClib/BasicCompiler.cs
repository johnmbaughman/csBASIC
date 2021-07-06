using System;
using System.Diagnostics;
using System.IO;
using Antlr4.Runtime;
using csBASIClib.antlr;
using csBASIClib.Utility;
using Serilog.Events;

namespace csBASIClib
{
    public class BasicCompiler
    {
        /// <summary>
        /// Gets the compiler parameters.
        /// </summary>
        /// <value>The compiler parameters.</value>
        public CompilerParameters CompilerParameters { get; }

        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <value>The logger.</value>
        public Logger Logger { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicCompiler"/> class.
        /// </summary>
        /// <param name="compilerParameters">The compiler parameters.</param>
        public BasicCompiler(CompilerParameters compilerParameters)
        {
            CompilerParameters = compilerParameters;

            Logger = new Logger(compilerParameters.InputFile);
        }

        /// <summary>
        /// Compiles to class file.
        /// </summary>
        /// <param name="outputAst">if set to <c>true</c> [output ast].</param>
        /// <param name="outputStaticAnalysis">if set to <c>true</c> [output static analysis].</param>
        public void CompileToClassFile(bool outputAst, bool outputStaticAnalysis)
        {

            var fileName = Path.GetFileNameWithoutExtension(CompilerParameters.InputFile);

            var basInputFileStream = new FileStream(CompilerParameters.InputFile, FileMode.Open, FileAccess.Read);

            var className = CompilerParameters.InputFile.ClassNameFromFileName();

            FileStream astOutputStream = null;

            if (outputAst)
            {
                astOutputStream = className.AstFileNameFromClassName().GetOutputFileStream(CompilerParameters.OutputFolder);
            }

            var classOutputStream = className.ClassNameFromFileName().GetOutputFileStream(CompilerParameters.OutputFolder);

            FileStream staticAnalysisOutputStream = null;

            if (outputStaticAnalysis)
            {
                staticAnalysisOutputStream = className.StaticAnalysisFileNameFromClassName().GetOutputFileStream(CompilerParameters.OutputFolder);
            }

            byte[] classBytes = Compile(basInputFileStream, astOutputStream, staticAnalysisOutputStream, className, fileName);
        }

        /// <summary>
        /// Compiles the specified bas input file stream.
        /// </summary>
        /// <param name="basInputFileStream">The bas input file stream.</param>
        /// <param name="astOutputStream">The ast output stream.</param>
        /// <param name="staticAnalysisOutputStream">The static analysis output stream.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>System.Byte[].</returns>
        private byte[] Compile(FileStream basInputFileStream, FileStream astOutputStream, FileStream staticAnalysisOutputStream, string className, string? fileName)
        {
            try
            {
                Logger.WriteToLog(LogEventLevel.Information, $"Parsing input for class name: {className}");

                var progContext = Parse(basInputFileStream);

                if (astOutputStream != null)
                {
                    var treePrinter = new TreePrinter(astOutputStream);
                    treePrinter.PrintTree(progContext);
                }

                // TODO: Start Roslyn use here
                var roslyn = new object();
                // TODO: End Roslyn use here?

                GenerateInit(className, roslyn);

                return null;
            }
            catch
            {
                throw;
            }
        }

        private void GenerateInit(string className, object roslyn)
        {
            try
            {
                var methodVistor = roslyn
            }
            catch (Exception e)
            {
                throw new Exception("Exception in GenerateInit", e);
            }
        }

        /// <summary>
        /// Parses the specified bas input file stream.
        /// </summary>
        /// <param name="basInputFileStream">The bas input file stream.</param>
        /// <returns>csBASIClib.antlr.jvmBasicParser.ProgContext.</returns>
        /// <exception cref="jvmBasicLexer">new AntlrInputStream(basInputFileStream)</exception>
        /// <exception cref="jvmBasicLexer">new AntlrInputStream(basInputFileStream)</exception>
        private jvmBasicParser.ProgContext Parse(FileStream basInputFileStream)
        {
            try
            {
                if (basInputFileStream == null) 
                    throw new ArgumentNullException();

                var basicLexer = new jvmBasicLexer(new AntlrInputStream(basInputFileStream));
                var tokens = new CommonTokenStream(basicLexer);
                var basicParser = new jvmBasicParser(tokens) { BuildParseTree = true };
                return basicParser.prog();

            }
            catch (Exception e)
            {
                throw new Exception("Exception reading and parsing file", e);
            }
        }
    }
}
