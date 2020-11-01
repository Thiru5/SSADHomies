using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Platformer.Mechanics;


public class HealthController : MonoBehaviour
{
    public Image[] hearts;

    private readonly int MAX_HP = 3;

    public int livesRemaining;

    public void LoseLife(){

        livesRemaining--;

        hearts[livesRemaining].enabled = false;

        if(livesRemaining == 0){
            Reset();
        }
    }

    public void ImmediateDeath(){
        livesRemaining = 0;
        hearts[0].enabled = true;
        hearts[1].enabled = true;
        hearts[2].enabled = true;
        livesRemaining = MAX_HP;
    }

    private void Reset() { 
        for (int i = 0; i < hearts.Length; i++) { 
            hearts[i].enabled = true;
        }
        livesRemaining = MAX_HP;
    }
}