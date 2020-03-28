using Microsoft.Xna.Framework;

namespace Dart.Ogmo
{
    public class OgmoDecalLayer : OgmoLayer
    {
        public OgmoDecalLayer(string name, Vector2 offset, Size cellSize, int rowCount, int columnCount)
            : base(name, OgmoLayerType.Grid, offset, cellSize, rowCount, columnCount)
        {

        }
    }
}
