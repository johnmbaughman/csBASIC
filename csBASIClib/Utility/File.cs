using System;
using System.IO;

namespace csBASIClib.Utility
{
    public static class File
    {
        /// <summary>
        /// Asts the name of the file name from class.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <returns>System.String.</returns>
        public static string AstFileNameFromClassName(this string className)
        {
            return $"{className}.ast.txt";
        }

        /// <summary>
        /// Classes the name of the file name from class.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <returns>System.String.</returns>
        public static string ClassFileNameFromClassName(this string className)
        {
            return $"{className}.cs";
        }

        /// <summary>
        /// Classes the name of the name from file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>System.String.</returns>
        public static string ClassNameFromFileName(this string fileName)
        {
            return Path.GetFileNameWithoutExtension(fileName);
        }

        /// <summary>
        /// Logs the name of the file name from class.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <returns>System.String.</returns>
        public static string LogFileNameFromClassName(this string className)
        {
            return $"{className}.log";
        }

        /// <summary>
        /// Gets the output file stream.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="outputFolder">The output folder.</param>
        /// <returns>FileStream.</returns>
        public static FileStream GetOutputFileStream(this string fileName, string outputFolder)
        {
            string fullFileName;

            if (!string.IsNullOrEmpty(outputFolder))
            {
                fullFileName = Path.Combine(outputFolder, Path.GetFileName(fileName));
                if (!Directory.Exists(outputFolder))
                {
                    Directory.CreateDirectory(outputFolder);
                }
            }
            else
            {
                fullFileName = fileName;
            }

            return new FileStream(fullFileName, FileMode.Create, FileAccess.Write);
        }

        /// <summary>
        /// Statics the name of the analysis file name from class.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <returns>System.String.</returns>
        public static string StaticAnalysisFileNameFromClassName(this string className)
        {
            return $"{className}.analysis.txt";
        }
    }
}