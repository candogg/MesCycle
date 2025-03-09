using MesCycle.ClientApp.Helpers.Base;
using Newtonsoft.Json;
using System;

namespace MesCycle.ClientApp.Helpers.Derived
{
    /// <summary>
    /// Author: Can DOĞU
    /// </summary>
    public sealed class SerializationHelper : HelperBase<SerializationHelper>
    {
        public T DeserializeObject<T>(object obj)
        {
            if (obj == null) Activator.CreateInstance<T>();

            try
            {
                return JsonConvert.DeserializeObject<T>(Convert.ToString(obj), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
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
