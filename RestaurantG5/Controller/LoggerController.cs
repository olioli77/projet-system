using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace RestaurantG5.Controller
{
    public class LoggerController
    {
        /// <summary>
        /// Append a Line to a specific text file.
        /// </summary>
        /// <param name="path">
        /// Full path to the logging text file.
        /// </param>
        /// <param name="line">
        /// The content to write in the text file
        /// as a single line.
        /// </param>
        /// <remarks>
        /// Method executed in an asynchronous way.
        /// </remarks>
        public static async Task AppendLineToFile(string path, string line)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentOutOfRangeException(nameof(path), path, "Was null or whitespace.");
            }

            using (var file = File.Open(path, FileMode.Append, FileAccess.Write))
            {
                using (var writer = new StreamWriter(file))
                {
                    await writer.WriteLineAsync("[" + DateTime.Now.ToString() + "]" + line);
                    await writer.FlushAsync();
                }
            }
        }

        /// <summary>
        /// Read the first line of a log text file.
        /// </summary>
        /// <param name="path">
        /// Full path to the logging text file.
        /// </param>
        /// <remarks>
        /// Method executed in an asynchronous way.
        /// </remarks>
        public static async Task<string> ReadFirstLineFromFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File not found.", path);
            }

            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentOutOfRangeException(nameof(path), path, "Was null or whitespace.");
            }

            using (var file = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    string result = await reader.ReadLineAsync();
                    return result;
                }
            }
        }

        internal static void AppendLineToFile(object lOG_PATH, string v)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Read the last line of a log text file.
        /// </summary>
        /// <param name="path">
        /// Full path to the logging text file.
        /// </param>
        /// <remarks>
        /// Method executed in an asynchronous way.
        /// </remarks>
        public static async Task<string> ReadLastLineFromFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File not found.", path);
            }

            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentOutOfRangeException(nameof(path), path, "Was null or whitespace.");
            }

            using (var file = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    string result = string.Empty;

                    while (reader.EndOfStream == false)
                        result = await reader.ReadLineAsync();
                    return result;
                }
            }
        }

        /// <summary>
        /// Read all the lines of a log text file, store them in a list and return it.
        /// </summary>
        /// <param name="path">
        /// Full path to the logging text file.
        /// </param>
        /// <remarks>
        /// Method executed in an asynchronous way.
        /// </remarks>
        public static async Task<IList<string>> ReadAllLinesFromFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File not found.", path);
            }

            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentOutOfRangeException(nameof(path), path, "Was null or whitespace.");
            }

            using (var file = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    IList<string> lines = new List<string>();

                    while (reader.EndOfStream == false)
                        lines.Add(await reader.ReadLineAsync());
                    return lines;
                }
            }
        }

        /// <summary>
        /// Copy the log file to the given path.
        /// </summary>
        /// <param name="logPath">
        /// Path to the log file.
        /// </param>
        /// <param name="copyPath">
        /// Path to the new log file.
        /// </param>
        public static void CopyLogFile(string logPath, string copyPath)
        {
            File.Copy(logPath, copyPath);
        }
    }
}
