﻿using System;
using System.Collections.Generic;

namespace Patterns
{
    public class GenericPooler<T> where T : class, IPoolableObject, new()
    {
        private readonly List<T> busyObjects = new List<T>();

        //lists that control the pool
        private readonly List<T> freeObjects = new List<T>();

        /// <summary>
        ///     Constructor, you must have to specify the starting size of the pool
        /// </summary>
        /// <param name="startingSize"></param>
        public GenericPooler(int startingSize)
        {
            StartSize = startingSize;

            //pool start size
            for (var i = 0; i < StartSize; ++i)
            {
                var obj = new T();
                freeObjects.Add(obj);
            }
        }

        public class GenericPoolerArgumentException : ArgumentException
        {
            public GenericPoolerArgumentException(string message) : base(message)
            {
            }
        }

        #region Utility

        public int StartSize { get; }

        public int SizeFreeObjects => freeObjects.Count;

        public int SizeBusyObjects => busyObjects.Count;

        public Type PoolType => typeof(T);

        #endregion

        #region Operations

        /// <summary>
        ///     Get an object of the type T
        /// </summary>
        /// <returns></returns>
        public T Get()
        {
            T pooled = null;

            if (SizeFreeObjects > 0)
            {
                //pool the last object
                pooled = freeObjects[SizeFreeObjects - 1];
                freeObjects.Remove(pooled);
            }
            else
            {
                //if can't pool create a new object
                pooled = new T();
            }

            //add to the busy list
            busyObjects.Add(pooled);

            return pooled;
        }

        /// <summary>
        ///     Release an object of the type T
        /// </summary>
        /// <param name="released"></param>
        public void Release(T released)
        {
            if (released == null)
                throw new GenericPoolerArgumentException("Can't Release a null object");

            //reset object
            released.Restart();

            //add back to the freelist
            freeObjects.Add(released);

            //remove from busy list
            busyObjects.Remove(released);
        }

        #endregion
    }
}