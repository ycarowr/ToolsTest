using System;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns
{
    /// <summary>
    ///     Attribute that allows to mark an Interface
    ///     class is going to be listened by other classes.
    ///     Usage: [GameEventAttribute] public IMyInterface { }
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = true)]
    public class GameEventAttribute : Attribute
    {
    }

    /// <summary>
    ///     This class contains a register that contains Subjects and Listeners. So,
    ///     every time a Subject value is updated we notify this list to broadcast
    ///     the modification to the Listeners.
    /// Refs:
    /// 1. https://forum.unity.com/threads/observer-pattern-hell.219749/
    /// 2. https://www.youtube.com/watch?v=Yy7Dt2usGy0
    /// 3. https://www.habrador.com/tutorials/programming-patterns/3-observer-pattern/
    /// 4. https://forum.unity.com/threads/observer-design-pattern-with-game-objects.388713/
    /// 5. https://jacekrojek.github.io/JacekRojek/2016/c-observer-design-pattern/
    /// </summary>
    public class Observer : SingletonMB<Observer>
    {
        /// <summary>
        ///     List of listeners of each Interface that is marked as GameEvent. I am using object as
        ///     base in order to subscribe both, Mono and Non-Monobehaviors.
        /// </summary>
        private readonly Dictionary<Type, List<object>>
            listeners = new Dictionary<Type, List<object>>();


        /// <summary>
        ///     Register a object as in the subscribers list based
        ///     on each GameEvent Interface that this object implements.
        /// </summary>
        /// <param name="obj"></param>
        public void AddListener(object obj)
        {
            if(obj == null)
                throw new ArgumentNullException("Can't register Null as a Listener");

            //find the type of object
            var type = obj.GetType();

            //get all implemented interfaces by the type class
            var interfaces = type.GetInterfaces();

            //iterate on all interfaces 
            foreach (var element in interfaces)
            {
                //gets the event attribute from the interface type
                var attr = Attribute.GetCustomAttribute(element, typeof(GameEventAttribute));

                //if the attribute exists, Add the object to list
                if (attr != null) CreateAndAdd(element, obj);
            }
        }

        /// <summary>
        ///     Remove an object that is already inside the subscribers list.
        /// </summary>
        /// <param name="obj"></param>
        public void RemoveListener(object obj)
        {
            foreach (var pair in listeners)
                pair.Value.Remove(obj);
        }

        /// <summary>
        ///     Broadcasts the Game Event Interface over the subscribers.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        public void Notify<T>(Action<T> subject) where T : class
        {
            var isSubject = this.listeners.TryGetValue(typeof(T), out var listeners);

            if (!isSubject) return;
            if (listeners.Count == 0) return;

            //broadcasts over the listeners
            for (var i = 0; i < listeners.Count; i++)
            {    
                var obj = listeners[i];
                if (obj != null)
                    subject(obj as T);
            }
        }

        /// <summary>
        ///     Create or Subscribe an object to a list
        ///     according to its implemented GameEvent Interface.
        /// </summary>
        /// <param name="anInterface"></param>
        /// <param name="anObject"></param>
        private void CreateAndAdd(Type anInterface, object anObject)
        {
            if (listeners.ContainsKey(anInterface))
                listeners[anInterface].Add(anObject);
            else
                listeners.Add(anInterface, new List<object> {anObject});
        }
    }
}