using Microsoft.Xna.Framework.Content.Pipeline;
using System.IO;


namespace Dart.ContentPipeline.Ogmo
{
    [ContentImporter(".ogmo", DefaultProcessor = "OgmoProcessor", DisplayName = "Ogmo Project Importer")]
    public class OgmoImporter : ContentImporter<OgmoImportResult>
    {
        public override OgmoImportResult Import(string filename, ContentImporterContext context)
        {
            //  Create an import result object instance that we'll return
            OgmoImportResult result = new OgmoImportResult();

            //  First, get the absolute path to the directory that the file is in
            string rootDir = Path.GetDirectoryName(filename);

            //  Next, we get an collection of every level file in that directory that goes with the project
            string[] levels = Directory.GetFiles(rootDir, "*.json");

            //  Next, read the content of the project file
            result.ProjectJson = File.ReadAllText(filename);

            //  Next read the content of each level file
            result.LevelJson = new string[levels.Length];
            result.LevelNames = new string[levels.Length];
            for (int i = 0; i < levels.Length; i++)
            {
                result.LevelJson[i] = File.ReadAllText(levels[i]);
                result.LevelNames[i] = Path.GetFileNameWithoutExtension(levels[i]);
            }

            //  return the import result
            return result;
        }
    }
}
