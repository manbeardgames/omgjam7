//// https://stackoverflow.com/questions/59059989/system-text-json-how-do-i-specify-a-custom-name-for-an-enum-value

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Runtime.Serialization;
//using System.Text.Json;
//using System.Text.Json.Serialization;

//namespace Dart.ContentPipeline.Converters
//{
//    public class CustomJsonStringEnumConverter : JsonConverterFactory
//    {
//        private readonly JsonNamingPolicy _namingPolicy;
//        private readonly bool _allowIntegerValues;
//        private readonly JsonStringEnumConverter _baseConverter;

//        public CustomJsonStringEnumConverter() : this(null, true) { }

//        public CustomJsonStringEnumConverter(JsonNamingPolicy policy = null, bool allowIntegerValues = true)
//        {
//            _namingPolicy = policy;
//            _allowIntegerValues = allowIntegerValues;
//            _baseConverter = new JsonStringEnumConverter(policy, allowIntegerValues);
//        }

//        public override bool CanConvert(Type typeToConvert)
//        {
//            return _baseConverter.CanConvert(typeToConvert);
//        }

//        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
//        {
//            var query = from field in typeToConvert.GetFields(BindingFlags.Public | BindingFlags.Static)
//                        let attr = field.GetCustomAttribute<EnumMemberAttribute>()
//                        where attr != null
//                        select (field.Name, attr.Value);

//            var dictionary = query.ToDictionary(p => p.Item1, p => p.Item2);
//            if (dictionary.Count > 0)
//            {
//                return new JsonStringEnumConverter(new DictionaryLookupNamingPolicy(dictionary, _namingPolicy), _allowIntegerValues)
//                           .CreateConverter(typeToConvert, options);
//            }
//            else
//            {
//                return _baseConverter.CreateConverter(typeToConvert, options);
//            }
//        }
//    }

//    public class JsonNamingPolicyDecorator : JsonNamingPolicy
//    {
//        readonly JsonNamingPolicy _underlyingNamingPolicy;
//        public JsonNamingPolicyDecorator(JsonNamingPolicy underlyingNamingPolicy)
//        {
//            _underlyingNamingPolicy = underlyingNamingPolicy;
//        }

//        public override string ConvertName(string name)
//        {
//            if (_underlyingNamingPolicy == null)
//            {
//                return name;
//            }
//            else
//            {
//                return _underlyingNamingPolicy.ConvertName(name);
//            }
//        }
//    }

//    public class DictionaryLookupNamingPolicy : JsonNamingPolicyDecorator
//    {
//        readonly Dictionary<string, string> _dictionary;

//        public DictionaryLookupNamingPolicy(Dictionary<string, string> dictionary, JsonNamingPolicy underlyingNamingPolicy)
//            : base(underlyingNamingPolicy)
//        {
//            if (dictionary == null) { throw new ArgumentNullException(); }
//            _dictionary = dictionary;
//        }

//        public override string ConvertName(string name)
//        {
//            if (_dictionary.TryGetValue(name, out string value))
//            {
//                return value;
//            }
//            else
//            {
//                return base.ConvertName(name);
//            }
//        }
//    }
//}
