using UnityEngine;
using System;

namespace Patterns
{
    public class SingletonLazy<T> where T : class, new()
    {
        //instance of T
        private static T instance;
        
        //multi thread locker
        private static readonly object locker = new object();

        //a protected constructor
        protected SingletonLazy()
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

        //Setter used to injectec an instance 
        public void InjectInstance(T _instance)
        {
            if (_instance != null)
                instance = _instance;
        }
    }
}