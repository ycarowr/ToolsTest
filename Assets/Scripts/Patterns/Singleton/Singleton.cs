using UnityEngine;
using System;
using System.Dynamic;

namespace Patterns
{
    public class Singleton<T> where T : class, new()
    {
        //public getter
        public static T Instance { get; private set; } = CreateInstance();

        //a protected constructor
        protected Singleton()
        {

        }

        private static T CreateInstance()
        {
            if(Instance == null)
                Instance = new T();

            return Instance;
        }

        //Setter used to inject an instance 
        public void InjectInstance(T _instance)
        {
            if(_instance != null)
                Instance = _instance;
        }
    }
}