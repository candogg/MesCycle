using MesCycle.ClientApp.Helpers.Derived;

namespace MesCycle.ClientApp.Extensions
{
    /// <summary>
    /// Author: Can DOĞU
    /// </summary>
    public static class GenericExtensions
    {
        public static string Serialize(this object item)
        {
            return SerializationHelper.GetInstance.SerializeObject(item);
        }

        public static T Deserialize<T>(this object obj)
        {
            return SerializationHelper.GetInstance.DeserializeObject<T>(obj);
        }
    }
}
