using System;
using CommandLine;

namespace csBASIClib
{
    public class CompilerParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompilerParameters"/> class.
        /// </summary>
        public CompilerParameters()
        {
            UserProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }

        /// <summary>
        /// Gets the user profile.
        /// </summary>
        /// <value>The user profile.</value>
        public string UserProfile { get; }

        /// <summary>
        /// Gets or sets the input file.
        /// </summary>
        /// <value>The input file.</value>
        [Option('i', "inputFile", Required = true)]
        public string InputFile { get; set; }

        /// <summary>
        /// Gets or sets the namespace.
        /// </summary>
        /// <value>The namespace.</value>
        [Option('n', "namespace", Required = false)]
        public string Namespace { get; set; } = null;

        /// <summary>
        /// Gets or sets the output folder.
        /// </summary>
        /// <value>The output folder.</value>
        [Option('o', "outputFolder", Required = false)]
        public string OutputFolder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [verbose output].
        /// </summary>
        /// <value><c>true</c> if [verbose output]; otherwise, <c>false</c>.</value>
        [Option('v', "verbose", Required = false)]
        public bool VerboseOutput { get; set; }
    }
}