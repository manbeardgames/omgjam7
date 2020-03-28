using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dart
{
    public static class FileUtilities
    {
        /// <summary>
        ///     Given the path to a file relative to the game's content directory,
        ///     reads the file as text and returns the content as a string.
        /// </summary>
        /// <param name="contentPath">
        ///     The path to the file to read relative to the content directory
        /// </param>
        /// <returns>
        ///     The content of the file as a string.
        /// </returns>
        public static string ReadFile(string contentPath)
        {
            string fileContent = string.Empty;

            using (var stream = TitleContainer.OpenStream(Path.Combine(Engine.Instance.Content.RootDirectory, contentPath)))
            {
                using (var reader = new StreamReader(stream))
                {
                    fileContent = reader.ReadToEnd();
                }
            }

            return fileContent;
        }

        /// <summary>
        ///     Given the path to a file relative to the game's content directory,
        ///     reads the file as text and returns the content as a string.
        /// </summary>
        /// <param name="contentPath">
        ///     The path ot hte file to read relative to the content directory.
        /// </param>
        /// <returns>
        ///     The content of the file as a string.
        /// </returns>
        public static async Task<string> ReadFileAsync(string contentPath)
        {
            string fileContent = string.Empty;            

            using (var stream = TitleContainer.OpenStream(Path.Combine(Engine.Instance.Content.RootDirectory, contentPath)))
            {
                using (var reader = new StreamReader(stream))
                {
                    fileContent = await reader.ReadToEndAsync();
                }
            }

            return fileContent;
        }
    }
}
