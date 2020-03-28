using Microsoft.Xna.Framework;

namespace Dart.Ogmo
{
    public class OgmoTileset
    {
        private int _rowCount;
        private int _columnCount;
        public VirtualTexture2D Texture { get; }
        public string Name { get; }
        public Size TileSize { get; }
        public Point TileSeperation { get; }

        public OgmoTileset(string name, VirtualTexture2D texture, Size tileSize, Point tileSeperation)
        {
            Name = name;
            Texture = texture;
            TileSize = tileSize;
            TileSeperation = tileSeperation;

            _columnCount = texture.Width / (tileSize.Width + tileSeperation.X);
            _rowCount = texture.Height / (tileSize.Height + tileSeperation.Y);
        }

        public VirtualTexture2D GetTile(int index)
        {
            //  Get the column of the tile from the index
            int column = index % _rowCount;
            int row = index / _rowCount;

            //  Calculate the x and y coords of the tile within the tileset
            int x = (column * TileSize.Width) + (column * TileSeperation.X);
            int y = (row * TileSize.Height) + (column * TileSeperation.Y);


            return Texture.GetSubTexture(x, y, TileSize.Width, TileSize.Height);
        }
    }

}
