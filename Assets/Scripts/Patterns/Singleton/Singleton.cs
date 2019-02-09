using UnityEngine;

namespace Patterns
{
    public class Singleton<T> where T : class, new()
    {
        //instance of T
        private static T instance;
        
        //multi thread locker
        private static readonly object locker = new object();

        //a protected constructor
        protected Singleton()
        {
            
        }

        public static T Instance
        {
            get
            {
                //multi thread locking
                lock (locker)
                {
                    if (instance == null)
                        Initialize();
                }

                return instance;
            }
        }

        //lazy initialization
        private static void Initialize()
        {
            instance = new T();
        }

        //call this method if you need to raise errors when the instance is not null
        private void HandleDuplicates()
        {
            Debug.LogError("[Singleton] Something went really wrong there is more than one Singleton: " + typeof(T));
        }
    }
}