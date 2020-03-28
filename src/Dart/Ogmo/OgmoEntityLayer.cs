using Microsoft.Xna.Framework;

namespace Dart.Ogmo
{
    public class OgmoEntityLayer : OgmoLayer
    {
        public OgmoEntityLayer(string name, Vector2 offset, Size cellSize, int rowCount, int columnCount)
            : base(name, OgmoLayerType.Grid, offset, cellSize, rowCount, columnCount)
        {

        }
    }
}
