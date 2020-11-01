using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Platformer.Mechanics;


public class HealthController : MonoBehaviour
{
    public Image[] hearts;

    public PlayerController player;

    public int livesRemaining;

    public void LoseLife(){

        livesRemaining--;

        hearts[livesRemaining].enabled = false;

        if(livesRemaining == 0){
            Debug.Log("You Lost");
            hearts[0].enabled = true;
            hearts[1].enabled = true;
            hearts[2].enabled = true;
            livesRemaining = livesRemaining + 3;
        }
    }
}