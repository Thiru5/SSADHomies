using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.CoreModule; 
using UnityEngine.TestTools;
using UnityEngine.Assertions;
using Platformer.Mechanics; 

namespace Tests
{
    public class TestMovement
    {
        [UnityTest]
        public void TestJump()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            var player = new PlayerController();
            player.Awake();
            player.jumpState = PlayerController.JumpState.PrepareToJump;
            yield return null; // skip a frame here and check next frame if player is logically jumping
            Assert.AreEqual(player.jumpState, PlayerController.JumpState.Jumping); 
        }

        [UnityTest]
        public void TestMovement()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            var player = new PlayerController();
            player.Awake();
            player.move = new Vector2(1, 0);
            player.ComputeVelocity();
            yield return null;
            Assert.AreEqual(player.velocity, player.maxSpeed); 
        }
    }
}
