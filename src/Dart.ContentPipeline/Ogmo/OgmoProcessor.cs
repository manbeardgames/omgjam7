using Dart.ContentPipeline.Ogmo.Models;
using Microsoft.Xna.Framework.Content.Pipeline;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Dart.ContentPipeline.Ogmo
{
    [ContentProcessor(DisplayName = "Ogmo Project Processor")]
    public class OgmoProcessor : ContentProcessor<OgmoImportResult, OgmoProcessorResult>
    {
        public override OgmoProcessorResult Process(OgmoImportResult input, ContentProcessorContext context)
        {
            //  Create an insteance of the result object that we'll return back.
            OgmoProcessorResult result = new OgmoProcessorResult();

            //  Initialize the project object
            result.Project = new OgmoProject();

            //  Create the JSON serializer for the project object
            var projectSerializer = new DataContractJsonSerializer(result.Project.GetType());

            //  Deserialize the project JSON
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(input.ProjectJson)))
            {
                result.Project = projectSerializer.ReadObject(stream) as OgmoProject;
            }

            //  For each tileset in the project, we need to split the image data string so that
            //  it only contains the actual base64 encoded image string.
            for(int i = 0; i < result.Project.Tilesets.Length; i++)
            {
                string[] split = result.Project.Tilesets[i].Image.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                result.Project.Tilesets[i].Image = split[1];
            }


            //  Initialize the layer type lookup dictionary
            for (int i = 0; i < result.Project.Layers.Length; i++)
            {
                OgmoLayerType layerType;

                if(result.Project.Layers[i].LayerType.Equals("tile", System.StringComparison.InvariantCultureIgnoreCase))
                {
                    layerType = OgmoLayerType.Tile;
                }
                else if(result.Project.Layers[i].LayerType.Equals("grid", System.StringComparison.InvariantCultureIgnoreCase))
                {
                    layerType = OgmoLayerType.Grid;
                }
                else if (result.Project.Layers[i].LayerType.Equals("decal", System.StringComparison.InvariantCultureIgnoreCase))
                {
                    layerType = OgmoLayerType.Decal;
                }
                else if (result.Project.Layers[i].LayerType.Equals("entity", System.StringComparison.InvariantCultureIgnoreCase))
                {
                    layerType = OgmoLayerType.Entity;
                }
                else
                {
                    throw new Exception($"Unrecognized layer type '{result.Project.Layers[i].LayerType}'");
                }
                result.LayerTypeLookup.Add(result.Project.Layers[i].Name, layerType);
            }

            //  Create the JSON serializer for the level objects
            var levelSerializer = new DataContractJsonSerializer(typeof(OgmoLevel));

            //  Deserialize each of the level jsons
            result.Levels = new OgmoLevel[input.LevelJson.Length];
            for (int i = 0; i < input.LevelJson.Length; i++)
            {
                using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(input.LevelJson[i])))
                {
                    result.Levels[i] = levelSerializer.ReadObject(stream) as OgmoLevel;
                }

                result.Levels[i].Name = input.LevelNames[i];
            }

            //  Return the result
            return result;
        }
    }
}
