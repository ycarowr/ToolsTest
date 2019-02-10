using UnityEngine;
using System;
using System.Dynamic;

namespace Patterns
{
    public class Singleton<T> where T : class, new()
    {
        //instance of T
        private static T instance = CreateInstance();

        //public getter
        public static T Instance
        {
            get { return instance; }
        }

        //a protected constructor
        protected Singleton()
        {

        }

        private static T CreateInstance()
        {
            if(instance == null)
                instance = new T();

            return instance;
        }

        //Setter used to inject an instance 
        public void InjectInstance(T _instance)
        {
            if(_instance != null)
                instance = _instance;
        }
    }
}