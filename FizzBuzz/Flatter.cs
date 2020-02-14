using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace FizzBuzz
{
    class Flatter
    {
        #region Fields
        private static List<string> jsonKeys = new List<string>();
        private static List<object> jsonValues = new List<object>();
        #endregion

        #region Property
        /// <summary>
        /// Returns JSON string that represents keys array
        /// </summary>
        public static string JsonKeys => JsonConvert.SerializeObject(jsonKeys, Formatting.Indented);

        /// <summary>
        /// Returns JSON string that represents values array
        /// </summary>
        public static string JsonValues => JsonConvert.SerializeObject(jsonValues, Formatting.Indented);

        public static List<string> GetKeys => jsonKeys;

        public static List<object> GetValues => jsonValues;
        #endregion

        #region Methods
        public static void Parse(string jsonText)
        {
            JObject jObject = JObject.Parse(jsonText);
            Dictionary<string, object> nodes = new Dictionary<string, object>();

            FillDictionaty(jObject, nodes);

            jsonKeys.AddRange(nodes.Keys);
            jsonValues.AddRange(nodes.Values);
        }

        public static void Parse(object obj)
        {
            string jsonText = JsonConvert.SerializeObject(obj);
            JObject jObject = JObject.Parse(jsonText);
            Dictionary<string, object> nodes = new Dictionary<string, object>();

            FillDictionaty(jObject, nodes);

            jsonKeys.AddRange(nodes.Keys);
            jsonValues.AddRange(nodes.Values);
        }

        private static void FillDictionaty(JToken jToken, Dictionary<string, object> nodes, string parentNode = "")
        {
            if (jToken.HasValues)
            {
                int i = 0;
                foreach (var child in jToken.Children())
                {
                    if (jToken.Type == JTokenType.Property)
                    {
                        parentNode = parentNode.Equals(string.Empty) ? ((JProperty)jToken).Name : $"{parentNode}.{((JProperty)jToken).Name}";
                    }
                    FillDictionaty(child, nodes, jToken.Type == JTokenType.Array ? $"{parentNode}.[{i++}]" : parentNode);
                }
            }
            else
            {
                nodes.Add(parentNode, ((JProperty)jToken.Parent).Value);
            }
        }
        #endregion
    }
}