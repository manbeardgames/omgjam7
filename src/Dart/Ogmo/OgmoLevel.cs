using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dart.Ogmo
{
    public class OgmoLevel
    {
        //  Lookup dictionary for the layers added to this level.
        private Dictionary<string, OgmoLayer> _layers;

        /// <summary>
        ///     Gets the name of the level
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     Gets the size (width and height) of the level.
        /// </summary>
        public Size Size { get; }

        /// <summary>
        ///     Gets the x and y offsets used when rendering the level.
        /// </summary>
        public Vector2 Offset { get; }

        /// <summary>
        ///     Creates a new OgmoLevel instance.
        /// </summary>
        /// <param name="name">
        ///     The name of the level.
        /// </param>
        /// <param name="size">
        ///     The Size (width and height) of the level.
        /// </param>
        /// <param name="offset">
        ///     The x and y offset of the level when rendering
        /// </param>
        public OgmoLevel(string name, Size size, Vector2 offset)
        {
            Name = name;
            Size = size;
            Offset = offset;
            _layers = new Dictionary<string, OgmoLayer>();
        }

        /// <summary>
        ///     Adds a new layer to this level.
        /// </summary>
        /// <param name="layer"></param>
        public void AddLayer(OgmoLayer layer)
        {
            if(_layers.ContainsKey(layer.Name))
            {
                throw new ArgumentException($"A layer with the name '{layer.Name}' already exists in this level");
            }

            _layers.Add(layer.Name, layer);
        }

        /// <summary>
        ///     Given the name of a layer, returns the layer within this level as
        ///     a type <typeparamref name="TLayerType"/>
        /// </summary>
        /// <typeparam name="TLayerType"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public TLayerType GetLayer<TLayerType>(string name) where TLayerType : OgmoLayer
        {
            
            if(_layers.ContainsKey(name))
            {
                return _layers[name] as TLayerType;
            }
            else
            {
                return null;
            }
        }
    }
}
