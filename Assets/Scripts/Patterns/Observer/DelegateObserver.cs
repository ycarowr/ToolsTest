using System;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns
{
    /// <summary>
    ///     This class contains a register that contains Subjects and Listeners. So,
    ///     every time a Subject value is updated we notify this list to broadcast
    ///     the modification to the Listeners.
    /// Refs:
    /// 1. https://www.youtube.com/watch?v=LPlH87XaWC8&t=314s
    /// 2. https://forum.unity.com/threads/observer-pattern-hell.219749/
    /// 3. https://www.youtube.com/watch?v=Yy7Dt2usGy0
    /// 4. https://www.habrador.com/tutorials/programming-patterns/3-observer-pattern/
    /// 5. https://forum.unity.com/threads/observer-design-pattern-with-game-objects.388713/
    /// 6. https://jacekrojek.github.io/JacekRojek/2016/c-observer-design-pattern/
    /// </summary>
    public class DelegateObserver<T> : MonoBehaviour
    {
        public delegate void StartGameDelegate();
    }
}