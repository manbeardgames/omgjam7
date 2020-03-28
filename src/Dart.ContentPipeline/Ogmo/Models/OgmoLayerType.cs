using System.Runtime.Serialization;

namespace Dart.ContentPipeline.Ogmo.Models
{
    [DataContract]
    public enum OgmoLayerType
    {
        [EnumMember(Value = "tile")]
        Tile,

        [EnumMember(Value = "grid")]
        Grid,

        [EnumMember(Value = "decal")]
        Decal,

        [EnumMember(Value = "entity")]
        Entity
    }
}
