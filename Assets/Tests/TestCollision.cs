using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Platformer.Mechanics;
using Platformer.Gameplay;
using UnityEngine.Assertions;

namespace Tests
{
    public class TestCollision
    {
        [UnityTest]
        public void TestEnemyDeathCollision()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            var player = new PlayerController(); 
            var enemy = new EnemyController();
            player.Awake();
            enemy.Awake();
            player.Bounds.center.y = 1;
            enemy.Bounds.center.y = 0; 
            var collision = new PlayerEnemyCollision();
            collision.player = player; 
            collision.enemy = enemy;
            collision.Execute(); 
            Assert.AreEqual(0, enemy.health.getHP);
        }

        [UnityTest]
        public void TestPlayerDeathCollision()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            var player = new PlayerController(); 
            var enemy = new EnemyController();
            player.Awake();
            enemy.Awake();
            player.Bounds.center.y = 0;
            enemy.Bounds.center.y = 0; 
            var collision = new PlayerEnemyCollision();
            collision.player = player; 
            collision.enemy = enemy;
            collision.Execute(); 
            Assert.AreEqual(0, player.health.getHP);
        }
    }
}
