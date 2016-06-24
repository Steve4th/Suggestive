using Newtonsoft.Json;

namespace Suggestive.Web.Services
{
    internal static class DeepObjectCopy
    {
        internal static T DeepCopy<T>(this T sourceObject) where T: class
        {
            var deserialseSettings = new JsonSerializerSettings()
            {
                ObjectCreationHandling = ObjectCreationHandling.Replace
            };

            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(sourceObject), deserialseSettings);
        }
    }
}
