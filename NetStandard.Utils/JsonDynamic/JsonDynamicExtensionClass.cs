using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetStandard.Utils.JsonDynamic
{
    public static class JsonDynamicExtensionClass
    {
        public static dynamic Convert(string s) {
            object obj = JsonConvert.DeserializeObject(s);
            if (obj is string) {
                return obj as string;
            } else {
                return ConvertJson((JToken)obj);
            }
        }

        private static dynamic ConvertJson(JToken token) {
            if (token is JValue) {
                return ((JValue)token).Value;
            } else if (token is JObject) {
                ExpandoObject expando = new ExpandoObject();
                (from childToken in ((JToken)token) where childToken is JProperty select childToken as JProperty).ToList().ForEach(property => {
                    ((IDictionary<string, object>)expando).Add(property.Name, ConvertJson(property.Value));
                });
                return expando;
            } else if (token is JArray) {
                List<ExpandoObject> items = new List<ExpandoObject>();
                foreach (JToken arrayItem in ((JArray)token)) {
                    items.Add(ConvertJson(arrayItem));
                }
                return items;
            }
            throw new ArgumentException(string.Format("Unknown token type '{0}'", token.GetType()), "token");
        }
    }
}