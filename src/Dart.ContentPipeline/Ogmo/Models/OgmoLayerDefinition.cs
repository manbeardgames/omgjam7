using System.Runtime.Serialization;

namespace Dart.ContentPipeline.Ogmo.Models
{
    [DataContract]
    public class OgmoLayerDefinition
    {
        //  -------------------------------------------------------------------
        //  These properties are used for Tile, Grid, Decal, and Entity
        //  layer definitions
        //  -------------------------------------------------------------------

        [DataMember(Name = "definition")]
        public string LayerType { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "gridSize")]
        public Size GridSize { get; set; }

        [DataMember(Name = "exportID")]
        public string ExportID { get; set; }

        //  -------------------------------------------------------------------
        //  Used by Tile and Grid Layer Definitions
        //  -------------------------------------------------------------------
        [DataMember(Name = "arrayMode")]
        public int ArrayMode { get; set; }


        //  -------------------------------------------------------------------
        //  Used by Tile Layer Definition Only
        //  -------------------------------------------------------------------
        [DataMember(Name = "exportMode")]
        public int ExportMode { get; set; }

        [DataMember(Name = "defaultTileset")]
        public string DefaultTileset { get; set; }

        //  -------------------------------------------------------------------
        //  Used by Grid Layer Definition Only
        //  -------------------------------------------------------------------
        [DataMember(Name = "legend")]
        public OgmoLegend Legend { get; set; }

        //  -------------------------------------------------------------------
        //  Used by Decal Layer Definition Only
        //  -------------------------------------------------------------------
        [DataMember(Name = "folder")]
        public string Folder { get; set; }

        [DataMember(Name = "includeImageSequence")]
        public bool IncludeImageSequence { get; set; }

        [DataMember(Name = "scaleable")]
        public bool Scaleable { get; set; }

        [DataMember(Name = "rotatable")]
        public bool Rotatable { get; set; }

        //public string[] Values { get; set; }

        //  -------------------------------------------------------------------
        //  Used by Entity Layer Definition only
        //  -------------------------------------------------------------------
        [DataMember(Name = "requiredTags")]
        public string[] RequiredTags { get; set; }

        [DataMember(Name = "excludedTags")]
        public string[] ExcludedTags { get; set; }
    }
}
