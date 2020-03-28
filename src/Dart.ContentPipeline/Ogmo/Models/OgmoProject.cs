


using System.Runtime.Serialization;

namespace Dart.ContentPipeline.Ogmo.Models
{
    [DataContract]
    public class OgmoProject
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "ogmoVersion")]
        public string OgmoVersion { get; set; }

        [DataMember(Name = "levelPaths")]
        public string[] LevelPaths { get; set; }

        [DataMember(Name = "backgroundColor")]
        public string BackgroundColor { get; set; }

        [DataMember(Name = "gridColor")]
        public string GridColor { get; set; }

        [DataMember(Name = "angleRadians")]
        public bool AngleRadians { get; set; }

        [DataMember(Name = "directoryDepth")]
        public int DirectoryDepth { get; set; }

        [DataMember(Name = "layerGridDefaultSize")]
        public Size LayerGridDefaultSize { get; set; }

        [DataMember(Name = "levelDefaultSize")]
        public Size LevelDefaultSize { get; set; }

        [DataMember(Name = "levelMinSize")]
        public Size LevelMinSize { get; set; }

        [DataMember(Name = "levelMaxSize")]
        public Size LevelMaxSize { get; set; }


        //public string[] LevelValues { get; set; }

        [DataMember(Name = "defaultExportMode")]
        public string DefaultExportMode { get; set; }

        [DataMember(Name = "compactExport")]
        public bool CompactExport { get; set; }


        //public string ExternalScript { get; set; }


        //public string PlayCommand { get; set; }


        //public string[] EntityTags { get; set; }

        [DataMember(Name = "layers")]
        public OgmoLayerDefinition[] Layers { get; set; }


        //public string[] Entities { get; set; }

        [DataMember(Name = "tilesets")]
        public OgmoTilesetDefinition[] Tilesets { get; set; }

    }
}
