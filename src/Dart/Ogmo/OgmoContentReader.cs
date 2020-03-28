using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;

namespace Dart.Ogmo
{
    public class OgmoContentReader : ContentTypeReader<OgmoProject>
    {
        protected override OgmoProject Read(ContentReader input, OgmoProject existinInstance)
        {
            //  Initialize a new project instance.
            OgmoProject project = new OgmoProject();

            //  Read the total number of layer definitions
            int layerTypeCount = input.ReadInt32();

            //  Read each of the layer definitions
            for (int i = 0; i < layerTypeCount; i++)
            {
                //  Read the string for what type of layer this is
                string layerTypeName = input.ReadString();

                //  Read the string for the name of the layer
                string layerName = input.ReadString();

                //  Convert the string for the type of layer into the enum
                OgmoLayerType layerType;
                if (layerTypeName.Equals("tile", StringComparison.InvariantCultureIgnoreCase))
                {
                    layerType = OgmoLayerType.Tile;
                }
                else if (layerTypeName.Equals("grid", StringComparison.InvariantCultureIgnoreCase))
                {
                    layerType = OgmoLayerType.Grid;
                }
                else if (layerTypeName.Equals("decal", StringComparison.InvariantCultureIgnoreCase))
                {
                    layerType = OgmoLayerType.Decal;
                }
                else if (layerTypeName.Equals("entity", StringComparison.InvariantCultureIgnoreCase))
                {
                    layerType = OgmoLayerType.Entity;
                }
                else
                {
                    throw new Exception($"Unknown layer type: '{layerTypeName}'");
                }

                //  Add the layer definition to the lookup dictionary of the project
                project.LayerTypeLookup.Add(layerName, layerType);
            }

            //  Read the total number of tilesets that need to be processed
            int tilesetCount = input.ReadInt32();

            //  Process each tileset
            for (int tileSetIndex = 0; tileSetIndex < tilesetCount; tileSetIndex++)
            {
                //  Read the name of the tileset
                string tilesetName = input.ReadString();

                //  Read the image data of the tileset
                string tileSetImageData = input.ReadString();

                //  Read the size of the tiles in the tileset. Read order is width then height
                Size tilesetTileSize = new Size
                {
                    Width = input.ReadInt32(),
                    Height = input.ReadInt32()
                };

                //  Read the tileseperation values for the tileset.  Read order is x then y.
                Point tilesetTileSeperation = new Point
                {
                    X = input.ReadInt32(),
                    Y = input.ReadInt32()
                };

                //  Create a new Texture2D from the image data
                Texture2D texture;
                byte[] imageData = Convert.FromBase64String(tileSetImageData);
                using (var stream = new MemoryStream(imageData))
                {
                    texture = Texture2D.FromStream(Engine.Graphics.Device, stream);
                }

                //  Create the tileset instance
                OgmoTileset tileSet = new OgmoTileset(tilesetName, new VirtualTexture2D(texture), tilesetTileSize, tilesetTileSeperation);

                //  Add the tileset to the project
                project.AddTileset(tileSet);
            }

            //  Read the total number of levels that need to be processed
            int levelCount = input.ReadInt32();

            //  Process each level and add them to the project
            for (int i = 0; i < levelCount; i++)
            {
                //  Read the name of the level
                string levelName = input.ReadString();

                //  Read the level size. Order of read is width then height
                Size levelSize = new Size()
                {
                    Width = input.ReadInt32(),
                    Height = input.ReadInt32()
                };

                //  Read the level offset. Order of read is x then y
                Vector2 levelOffset = new Vector2
                {
                    X = input.ReadInt32(),
                    Y = input.ReadInt32()
                };

                //  Create a new level instance.
                OgmoLevel level = new OgmoLevel(levelName, levelSize, levelOffset);

                //  Read the total number of layers for this level
                int layerCount = input.ReadInt32();

                //  Read each layer and add it to the level
                for (int layerIndex = 0; layerIndex < layerCount; layerIndex++)
                {
                    //  Read the type of layer.  The value is an int and needs to be converted to enum
                    OgmoLayerType layerType = (OgmoLayerType)input.ReadInt32();

                    //  Read the name of the layer
                    string layerName = input.ReadString();

                    //  Read the x and y offset of the layer. Order of read is x and then y
                    Vector2 layerOffset = new Vector2
                    {
                        X = input.ReadInt32(),
                        Y = input.ReadInt32()
                    };

                    //  Read the size of the grid cells.  Order of read is width and then height
                    Size layerCellSize = new Size
                    {
                        Width = input.ReadInt32(),
                        Height = input.ReadInt32()
                    };

                    //  Read the column count for the layer
                    int layerColumnCount = input.ReadInt32();

                    //  Read the row count for the layer
                    int layerRowCount = input.ReadInt32();

                    //  The next values that are read are dependent on the type of layer that is being processed
                    //  in at this moment.
                    if (layerType == OgmoLayerType.Tile)
                    {
                        //  Read the name of the tileset used for this layer
                        string tilesetName = input.ReadString();

                        //  Read the total number of elements in the data array
                        int dataLength = input.ReadInt32();

                        //  Read each of the data elements
                        int[] data = new int[dataLength];
                        for (int dataIndex = 0; dataIndex < dataLength; dataIndex++)
                        {
                            data[dataIndex] = input.ReadInt32();
                        }

                        //  Read the export mode used
                        int exportMode = input.ReadInt32();

                        //  Read the array mode used
                        int arrayMode = input.ReadInt32();

                        //  Create a new OgmoTileLayer instance
                        OgmoTileLayer tileLayer = new OgmoTileLayer(layerName,
                                                                    layerOffset,
                                                                    layerCellSize,
                                                                    layerRowCount,
                                                                    layerColumnCount,
                                                                    project.GetTileset(tilesetName),
                                                                    data);

                        //  Add the layer to the level
                        level.AddLayer(tileLayer);

                    }
                    else if (layerType == OgmoLayerType.Grid)
                    {
                        OgmoGridLayer gridLayer = new OgmoGridLayer(layerName, layerOffset, layerCellSize, layerRowCount, layerColumnCount);
                        level.AddLayer(gridLayer);
                    }
                    else if (layerType == OgmoLayerType.Decal)
                    {
                        OgmoDecalLayer gridLayer = new OgmoDecalLayer(layerName, layerOffset, layerCellSize, layerRowCount, layerColumnCount);
                        level.AddLayer(gridLayer);
                    }
                    else if (layerType == OgmoLayerType.Entity)
                    {
                        OgmoEntityLayer gridLayer = new OgmoEntityLayer(layerName, layerOffset, layerCellSize, layerRowCount, layerColumnCount);
                        level.AddLayer(gridLayer);
                    }
                    else
                    {
                        throw new Exception($"Unsupported layer type: '{layerType.ToString()}'");
                    }
                }

                //  Add the level to the project
                project.AddLevel(level);
            }

            //  Return the project
            return project;
        }


    }
}
