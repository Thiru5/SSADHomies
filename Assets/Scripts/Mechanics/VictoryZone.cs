using Platformer.Gameplay;
using UnityEngine;
using System.Collections.Generic;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Marks a trigger as a VictoryZone, usually used to end the current game level.
    /// </summary>
    public class VictoryZone : MonoBehaviour
    {
        
        [SerializeField]
        private ScoreController sc; // this is not a good way
        void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null)
            {
                var ev = Schedule<PlayerEnteredVictoryZone>();
                ev.victoryZone = this;
            }
            var userData = new Dictionary<string, string> {
                {"enemies", sc._enemy_score.ToString()},
                {"tokens", sc.token_score.text.ToString()}
            };
            DatabaseConnection.SetData(new List<string>{"/statistics/{DatabaseConnection.username}.json"}, userData);
        }
    }
}