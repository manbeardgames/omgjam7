using System.Runtime.Serialization;

namespace Dart.ContentPipeline
{
    [DataContract]
    public class Size
    {
        [DataMember(Name = "x")]
        public int X { get; set; }

        [DataMember(Name = "y")]
        public int Y { get; set; }
    }
}
