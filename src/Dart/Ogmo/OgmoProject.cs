using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dart.Ogmo
{
    public class OgmoProject
    {
        private Dictionary<string, OgmoLevel> _levelLookup;
        private Dictionary<string, OgmoTileset> _tilesetLookup { get; set; }
        public Dictionary<string, OgmoLayerType> LayerTypeLookup { get; set; }


        /// <summary>
        ///     Creates a new OgmoProject instance
        /// </summary>
        public OgmoProject()
        {
            _levelLookup = new Dictionary<string, OgmoLevel>();
            _tilesetLookup = new Dictionary<string, OgmoTileset>();
            LayerTypeLookup = new Dictionary<string, OgmoLayerType>();
        }

        /// <summary>
        ///     Given a level, adds it to this project.
        /// </summary>
        /// <param name="level">
        ///     The OgmoLevel to add.
        /// </param>
        /// <returns>
        ///     The level that was added.
        /// </returns>
        public OgmoLevel AddLevel(OgmoLevel level)
        {
            if(_levelLookup.ContainsKey(level.Name))
            {
                throw new ArgumentException($"A level with the name {level.Name} has already been added");
            }

            _levelLookup.Add(level.Name, level);

            return level;
        }

        /// <summary>
        ///     Given the name of a level, returns the level.
        /// </summary>
        /// <param name="name">
        ///     The name of the level.
        /// </param>
        /// <returns>
        ///     The OgmoLevel instance with the matching name.
        /// </returns>
        public OgmoLevel GetLevel(string name)
        {
            if(_levelLookup.ContainsKey(name))
            {
                return _levelLookup[name];
            }
            else
            {
                return null;
            }
        }

        public void AddTileset(OgmoTileset tileSet)
        {
            if(_tilesetLookup.ContainsKey(tileSet.Name))
            {
                throw new Exception($"A tileset with the name '{tileSet.Name}' has already been added");
            }

            _tilesetLookup.Add(tileSet.Name, tileSet);
        }

        public OgmoTileset GetTileset(string name)
        {
            if(_tilesetLookup.ContainsKey(name))
            {
                return _tilesetLookup[name];
            }

            return null;
        }





    }
}
