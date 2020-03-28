using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dart
{
    public class BitTag
    {
        internal static int _totalTags = 0;
        internal static BitTag[] _byID = new BitTag[32];

        private static Dictionary<string, BitTag> _byName = new Dictionary<string, BitTag>(StringComparer.OrdinalIgnoreCase);

        public static BitTag Get(string name)
        {
            return _byName[name];
        }

        public int ID { get; set; } 
        public int Value { get; set; }
        public string Name { get; set; }

        public BitTag(string name)
        {
            ID = _totalTags;
            Value = 1 << _totalTags;
            Name = name;

            _byID[ID] = this;
            _byName[name] = this;

            _totalTags++;
        }

        public static implicit operator int(BitTag tag)
        {
            return tag.Value;
        }


    }
}
