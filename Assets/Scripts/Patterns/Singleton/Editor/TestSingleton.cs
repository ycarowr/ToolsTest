using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Patterns;

namespace Test
{
    public class TestableSingleton : Singleton<TestableSingleton>
    {
        public string SomeProperty { get; set; }
    }

    public class TestSingleton
    {
        [Test]
        public void SingletonTest()
        {
            var singleton = new TestableSingleton();
            var someString = "testProperty";
            singleton.SomeProperty = someString;

            //inject singleton instance
            TestableSingleton.Instance.SetInstance(singleton);
            
            //assert if the instances point to the same adress
            Assert.True(object.ReferenceEquals(TestableSingleton.Instance, singleton));
            //assert if the instances are equal
            Assert.AreEqual(TestableSingleton.Instance, singleton);
            //assert if the property on the single is set
            Assert.True(TestableSingleton.Instance.SomeProperty == someString);
        }
    }
}