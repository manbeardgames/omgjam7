using System.Runtime.Serialization;

namespace Dart.ContentPipeline.Ogmo.Models
{
    [DataContract]
    public class OgmoTilesetDefinition
    {
        [DataMember(Name = "label")]
        public string Label { get; set; }

        [DataMember(Name = "path")]
        public string Path { get; set; }

        [DataMember(Name = "image")]
        public string Image { get; set; }

        [DataMember(Name = "tileWidth")]
        public int TileWidth { get; set; }

        [DataMember(Name = "tileHeight")]
        public int TileHeight { get; set; }

        [DataMember(Name = "tileSeperationX")]
        public int TileSeperationX { get; set; }

        [DataMember(Name = "tileSeperationY")]
        public int TileSeperationY { get; set; }
    }
}
