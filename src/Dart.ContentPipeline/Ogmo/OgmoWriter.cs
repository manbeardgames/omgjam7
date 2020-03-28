using Dart.ContentPipeline.Ogmo.Models;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

namespace Dart.ContentPipeline.Ogmo
{
    [ContentTypeWriter]
    public class OgmoWriter : ContentTypeWriter<OgmoProcessorResult>
    {
        protected override void Write(ContentWriter output, OgmoProcessorResult value)
        {
            //  write the number of layer definitions
            output.Write(value.Project.Layers.Length);

            //  Write each layer definition in sequence
            for (int i = 0; i < value.Project.Layers.Length; i++)
            {
                //   Write the layer type
                output.Write(value.Project.Layers[i].LayerType.ToString());

                //  Write the layer name
                output.Write(value.Project.Layers[i].Name);
            }

            //  Write the number of tilesets
            output.Write(value.Project.Tilesets.Length);

            //  Write each tileset in sequence
            for(int tileSetIndex = 0; tileSetIndex < value.Project.Tilesets.Length; tileSetIndex++)
            {
                //  Write the name of the tileset
                output.Write(value.Project.Tilesets[tileSetIndex].Label);

                //  Write the image data for the tileset
                output.Write(value.Project.Tilesets[tileSetIndex].Image);

                //  Write the width of each tile in the tileset
                output.Write(value.Project.Tilesets[tileSetIndex].TileWidth);

                //  Write the height of each tile in the tileset
                output.Write(value.Project.Tilesets[tileSetIndex].TileHeight);

                //  Write the x seperation of each tile in the tileset
                output.Write(value.Project.Tilesets[tileSetIndex].TileSeperationX);

                //  Write the y seperation of each tile in the tileset
                output.Write(value.Project.Tilesets[tileSetIndex].TileSeperationY);
            }

            //  Write the number of levels 
            output.Write(value.Levels.Length);

            //  Write each level in sequence
            for (int levelIndex = 0; levelIndex < value.Levels.Length; levelIndex++)
            {
                //  Write the level name 
                output.Write(value.Levels[levelIndex].Name);

                //  Write the level width
                output.Write(value.Levels[levelIndex].Width);

                //  Write the level Height
                output.Write(value.Levels[levelIndex].Height);

                //  Write the level x-offset
                output.Write(value.Levels[levelIndex].OffsetX);

                //  Write the level y-offset
                output.Write(value.Levels[levelIndex].OffsetY);

                //  Write the total number of layers
                output.Write(value.Levels[levelIndex].Layers.Length);

                //  Write each layer in the level in sequence
                for (int layerindex = 0; layerindex < value.Levels[levelIndex].Layers.Length; layerindex++)
                {
                    //  Get refernece to the layer to make writing code eaiser lol
                    OgmoLayer layer = value.Levels[levelIndex].Layers[layerindex];

                    //  Get the type of layer from the layer lookup dictionary
                    OgmoLayerType layerType = value.LayerTypeLookup[layer.Name];

                    //  Write the type of layer
                    output.Write((int)layerType);

                    //  Write the name of the layer
                    output.Write(layer.Name);

                    //  Write the x-offset of the layer
                    output.Write(layer.OffsetX);

                    //  Write the y-offset of the layer
                    output.Write(layer.OffsetY);

                    //  Write the grid cell width for the layer
                    output.Write(layer.GridCellWidth);

                    //  Write the grid cell height for the layer
                    output.Write(layer.GridCellHeight);

                    //  Write the total number of columns in the layer
                    output.Write(layer.GridCellsX);

                    //  Write the total number of rows in the layer
                    output.Write(layer.GridCellsY);

                    //  Write the layer type specific properties
                    if (layerType == OgmoLayerType.Tile)
                    {
                        //  Write the name of the tileset used by this layer
                        output.Write(layer.Tileset);

                        //  Write the total number of elements in the layer data
                        output.Write(layer.Data.Length);

                        //  Write each element of the layer data
                        for (int dataIndex = 0; dataIndex < layer.Data.Length; dataIndex++)
                        {
                            output.Write(layer.Data[dataIndex]);
                        }

                        //  Write the export mode
                        output.Write(layer.ExportMode);

                        //  Writ the array mode
                        output.Write(layer.ArrayMode);
                    }
                }
            }
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return "Dart.Ogmo.OgmoContentReader, Dart";
        }
    }
}
