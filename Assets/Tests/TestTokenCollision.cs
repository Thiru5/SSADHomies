using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Platformer.Mechanics;
using UnityEngine.Assertions;

namespace Tests
{
    public class TestTokenCollision
    {
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public void TestTokenCollision()
        {
            // Use the Assert class to test conditions
            var token = new TokenInstance();
            var controller = new TokenController();
            var player = new PlayerController(); 
            token.controller = controller; 
            token.Awake(); 
            controller.Awake();
            player.Awake(); 
            token.OnPlayerEnter(player); // collected here 
            yield return null; 
            Assert.AreEqual(true, collected); 
        }
    }
}
