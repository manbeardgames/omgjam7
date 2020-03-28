using System.Runtime.Serialization;

namespace Dart.ContentPipeline.Ogmo.Models
{
    [DataContract]
    public class OgmoLevel
    {
        [IgnoreDataMember]
        public string Name { get; set; }

        [DataMember(Name = "ogmoVersion")]
        public string OgmoVersion { get; set; }

        [DataMember(Name = "width")]
        public int Width { get; set; }

        [DataMember(Name = "height")]
        public int Height { get; set; }

        [DataMember(Name = "offsetX")]
        public int OffsetX { get; set; }

        [DataMember(Name = "offsetY")]
        public int OffsetY { get; set; }


        //public string[] Values { get; set; }

        [DataMember(Name = "layers")]
        public OgmoLayer[] Layers { get; set; }

    }
}
