using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Gameplay
{

    /// <summary>
    /// Fired when a Player collides with an Enemy.
    /// </summary>
    /// <typeparam name="EnemyCollision"></typeparam>
    public class PlayerEnemyCollision : Simulation.Event<PlayerEnemyCollision>
    {
        public EnemyController enemy;
        public PlayerController player;

        public ScoreController scoreController;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            var willHurtEnemy = player.Bounds.center.y >= enemy.Bounds.max.y;

            if (willHurtEnemy)
            {
                var enemyHealth = enemy.GetComponent<Health>();
                var popup = enemy.GetComponent<Popup>(); 
                if (popup != null) { 
                    popup.Open(); 
                } 
                if (enemyHealth != null)
                {
                    enemyHealth.Decrement();
                    if (!enemyHealth.IsAlive)
                    {
                        Schedule<EnemyDeath>().enemy = enemy;
                        enemy.scoreController.incrementEnemyScore(); 
                        player.Bounce(2);
                    }
                    else
                    {
                        player.Bounce(7);
                    }
                }
                else
                {
                    Schedule<EnemyDeath>().enemy = enemy;
                    enemy.scoreController.incrementEnemyScore(); 
                    player.Bounce(2);
                }
            }
            else
            {
                var playerHealth = player.GetComponent<Health>(); 
                playerHealth.Decrement(); 
                var healthCon = player.GetComponent<HealthController>(); 
                healthCon.LoseLife();
                Debug.Log(playerHealth.getHP);
                if (!playerHealth.IsAlive) {
                    Schedule<PlayerDeath>();
                } 
            }
        }
    }
}