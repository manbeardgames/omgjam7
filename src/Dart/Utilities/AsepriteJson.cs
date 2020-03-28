using System.Runtime.Serialization;

namespace Dart
{
    [DataContract]
    public class AsepriteJson
    {
        [DataMember(Name = "frames")]
        public AsepriteFrame[] Frames { get; set; }

        [DataMember(Name = "meta")]
        public AsepriteMeta Meta { get; set; }

        [DataContract]
        public class AsepriteFrame
        {
            [DataMember(Name = "filename")]
            public string Filename { get; set; }

            [DataMember(Name = "frame")]
            public AsepriteRectangle Frame { get; set; }

            [DataMember(Name = "rotated")]
            public bool Rotated { get; set; }

            [DataMember(Name = "trimmed")]
            public bool Trimmed { get; set; }

            [DataMember(Name = "spriteSourceSize")]
            public AsepriteRectangle SpriteSourceSize { get; set; }

            [DataMember(Name = "sourceSize")]
            public AsepriteSize SourceSize { get; set; }

            [DataMember(Name = "duration")]
            public int Duration { get; set; }
        }

        [DataContract]
        public class AsepriteMeta
        {
            [DataMember(Name = "app")]
            public string App { get; set; }

            [DataMember(Name = "version")]
            public string Version { get; set; }

            [DataMember(Name = "image")]
            public string Image { get; set; }

            [DataMember(Name = "format")]
            public string Format { get; set; }

            [DataMember(Name = "size")]
            public AsepriteSize Size { get; set; }

            [DataMember(Name = "scale")]
            public int Scale { get; set; }

            [DataMember(Name = "frameTags")]
            public AsepriteFrameTag[] FrameTags { get; set; }

            [DataMember(Name = "layers")]
            public AsepriteLayer[] Layers { get; set; }
        }

        [DataContract]
        public class AsepriteSize
        {
            [DataMember(Name = "w")]
            public int Width { get; set; }

            [DataMember(Name = "h")]
            public int Height { get; set; }
        }

        [DataContract]
        public class AsepriteRectangle
        {
            [DataMember(Name = "x")]
            public int X { get; set; }

            [DataMember(Name = "y")]
            public int Y { get; set; }

            [DataMember(Name = "w")]
            public int Width { get; set; }

            [DataMember(Name = "h")]
            public int Height { get; set; }
        }

        [DataContract]
        public class AsepriteFrameTag
        {
            [DataMember(Name = "name")]
            public string Name { get; set; }

            [DataMember(Name = "from")]
            public int From { get; set; }

            [DataMember(Name = "to")]
            public int To { get; set; }

            [DataMember(Name = "direction")]
            public string Direction { get; set; }
        }

        [DataContract]
        public class AsepriteLayer
        {
            [DataMember(Name = "name")]
            public string Name { get; set; }

            [DataMember(Name = "opacity")]
            public int Opacity { get; set; }

            [DataMember(Name = "blendMode")]
            public string BlendMode { get; set; }
        }
    }


}
