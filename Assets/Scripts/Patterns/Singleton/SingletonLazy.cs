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
                    //lazy initialization
                    if (instance == null)
                        instance = new T();
                }

                return instance;
            }
        }
        
        //Setter used to inject an instance 
        public void InjectInstance(T _instance)
        {
            if (_instance != null)
                instance = _instance;
        }
    }
}