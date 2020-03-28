using Dart.ContentPipeline.Ogmo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dart.ContentPipeline.Ogmo
{
    public class OgmoProcessorResult
    {
        public OgmoProject Project { get; set; }

        public Dictionary<string, OgmoLayerType> LayerTypeLookup { get; set; }

        public OgmoLevel[] Levels { get; set; }

        public OgmoProcessorResult()
        {
            LayerTypeLookup = new Dictionary<string, OgmoLayerType>();
        }
    }
}
