using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.TestTools;
using Platformer.Mechanics; 

namespace Tests
{
    public class TestHealth
    {
        [Test]
        public void TestHealthInitialization()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            var health = new Health();
            health.Awake();
            Assert.AreEqual(3, health.getHP);
        }

        [Test]
        public void TestValidDecrement()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            var health = new Health();
            health.Awake(); 
            health.Decrement();
            Assert.AreEqual(2, health.getHP);
        }
        
        [Test]
        public void TestInvalidDecrement()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            var health = new Health();
            health.Die(); 
            health.Decrement();
            Assert.AreEqual(0, health.getHP);
        }
        
        [Test]
        public void TestInvalidIncrement()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            var health = new Health();
            health.Awake(); 
            health.Increment();
            Assert.AreEqual(3, health.getHP);
        }

        [Test]
        public void TestValidIncrement()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            var health = new Health();
            health.Awake();
            health.Decrement();
            health.Increment();
            Assert.AreEqual(3, health.getHP);
        }

        [Test]
        public void TestDie()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            var health = new Health();
            health.Awake(); 
            health.Die();
            Assert.AreEqual(0, health.getHP);
        }
    }
}
