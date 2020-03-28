using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dart.Ogmo
{
    public abstract class OgmoLayer
    {
        public OgmoLayerType LayerType { get; }
        public string Name { get; }
        public Vector2 Offset { get; }
        public Size CellSize { get; }
        public int RowCount { get; }
        public int ColumnCount { get; }

        public OgmoLayer(string name, OgmoLayerType layerType, Vector2 offset, Size cellSize, int rowCount, int columnCount)
        {
            Name = name;
            LayerType = layerType;
            Offset = offset;
            CellSize = cellSize;
            RowCount = rowCount;
            ColumnCount = columnCount;

        }

        public virtual void Update() { }
        public virtual void Render() { }


    }
}
