using Microsoft.Xna.Framework;

namespace Dart.Ogmo
{
    public class OgmoTileLayer : OgmoLayer
    {
        /// <summary>
        ///     Gets the name of the tileset to use when rendering this layer
        /// </summary>
        //public string TilesetName { get; }

        public OgmoTileset Tileset { get; }

        /// <summary>
        ///     Gets the tile data for this layer.
        /// </summary>
        public int[] Data { get; }

        public OgmoTileLayer(string name, Vector2 offset, Size cellSize, int rowCount, int columnCount, OgmoTileset tileSet, int[] data)
            : base(name, OgmoLayerType.Tile, offset, cellSize, rowCount, columnCount)
        {
            Tileset = tileSet;
            Data = data;
        }

        public override void Render()
        {
            //  Get the texture being used 
            for(int i = 0; i < Data.Length; i++)
            {
                //   Calculate the row and column from the data index
                int column = i % ColumnCount;
                int row = i / ColumnCount;

                //  Calculate the position to rneder the tile at
                Vector2 position = new Vector2
                {
                    X = column * CellSize.Width,
                    Y = row * CellSize.Height
                };

                //  Get the virtual texture of the tile to rener
                VirtualTexture2D tileTexture = Tileset.GetTile(Data[i]);

                //  Render the tile
                Draw.VirtualTexture2D(tileTexture, position);
            }
        }

    }
}
