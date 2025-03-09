using MesCycle.Web.Shared.Extensions;
using MesCycle.Web.Shared.Helpers.Base;
using Newtonsoft.Json;

namespace MesCycle.Web.Shared.Helpers.Derived
{
    /// <summary>
    /// Author: Can DOĞU
    /// </summary>
    public sealed class SerializationHelper : HelperBase<SerializationHelper>
    {
        public T? DeserializeObject<T>(object obj)
        {
            if (obj == null) return Activator.CreateInstance<T>();

            try
            {
                var objStr = Convert.ToString(obj);

                if (objStr == null || objStr.IsNullOrEmpty())
                {
                    return Activator.CreateInstance<T>();
                }

                return JsonConvert.DeserializeObject<T>(objStr, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            }
            catch (Exception)
            { }

            return default;
        }

        public string SerializeObject(object obj, bool isCamelCase = false)
        {
            try
            {
                if (isCamelCase)
                {
                    return JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
                    });
                }
                else
                {
                    return JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                }
            }
            catch (Exception)
            { }

            return string.Empty;
        }
    }
}
