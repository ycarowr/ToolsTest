using UnityEngine;
using System;

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

        //Setter used to injectec an instance 
        public void SetInstance(T _instance)
        {
            instance = _instance;
        }
    }
}