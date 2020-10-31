using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Platformer.Mechanics;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private TokenController token;
    public TMP_Text token_score;
    public int _enemy_score = 0;

    public void incrementEnemyScore() { 
        _enemy_score++;
    }

    public TMP_Text enemy_score;
    
    // Start is called before the first frame update
    void Start()
    {
        token_score.text = "0";
    }

    // Update is called once per frame
    // just poll and update
    void Update()
    {
        token_score.text = token.getCount.ToString();
        enemy_score.text = _enemy_score.ToString();
    }
}
