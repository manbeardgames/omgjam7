using System.Runtime.Serialization;

namespace Dart.ContentPipeline.Ogmo.Models
{
    [DataContract]
    public class OgmoLegend
    {
        [DataMember(Name = "0")]
        public string Zero { get; set; }

        [DataMember(Name = "1")]
        public string One { get; set; }
    }
}
