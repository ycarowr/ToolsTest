using System;
using UnityEngine;

namespace Patterns
{
    public class SingletonMB<T> : MonoBehaviour where T : class
    {
        //singleton generic instance
        public static T Instance { get; private set; }
        //multi thread locker
        private static readonly object locker = new object();

        [Tooltip("Mark it whether this singleton will be destroyed when the scene changes")]
        [SerializeField]
        private bool isDontDestroyOnLoad = false;

        [Tooltip("Mark it whether the script raises an exception when another singleton like this is present in the scene")]
        [SerializeField]
        private bool isSilent = false;

        protected virtual void Awake()
        {
            //multi thread lock
            lock (locker)
            {
                // if null we set the instance to be this and mark the
                // gameobject whether or not is destroyed on load
                if (Instance == null)
                    Initialize();
                else if (Instance as SingletonMB<T> != this) HandleDuplication();
            }
        }

        protected virtual void OnDestroy()
        {
            if (Instance as SingletonMB<T> == this) Instance = null;
        }

        private void Initialize()
        {
            Instance = this as T;
            if (isDontDestroyOnLoad)
                DontDestroyOnLoad(gameObject);

            OnAwake();
        }

        protected virtual void OnAwake()
        {
            //override this call instead using awake
        }

        private void HandleDuplication()
        {
            //if not null we grab all possible objects of this type
            var allSingletonsOfThis = FindObjectsOfType(typeof(T));

            if (isSilent)
            {
                foreach (var duplicated in allSingletonsOfThis)
                    //if the singleton is silent, just destroy the sparing objects
                    if (duplicated != Instance)
                        Destroy(duplicated);
            }
            else
            {
                //if not silent, we raise an error with the names of the all the objets
                var singletonsNames = string.Empty;
                foreach (var duplicated in allSingletonsOfThis)
                    singletonsNames += duplicated.name + ", ";

                //throws an error with all objects that have this monobehavior as message
                var message = "[" + GetType() + "] Something went really wrong, " +
                              "there is more than one Singleton: \"" + typeof(T) +
                              "\". GameObject names: " +
                              singletonsNames;

                throw new SingletonMBException(message);
            }
        }

        public class SingletonMBException : Exception
        {
            public SingletonMBException(string message) : base(message)
            {
            }
        }
    }
}