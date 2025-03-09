using System;

namespace MesCycle.ClientApp.Helpers.Base
{
    /// <summary>
    /// Author: Can DOĞU
    /// </summary>
    public abstract class HelperBase<T> where T : class, new()
    {
        private static T instanceObject;
        private static readonly object lockObject = new object();

        public static T GetInstance
        {
            get
            {
                if (instanceObject == null)
                {
                    lock (lockObject)
                    {
                        if (instanceObject == null)
                        {
                            instanceObject = Activator.CreateInstance<T>();
                        }
                    }
                }
                return instanceObject;
            }
        }
    }
}
