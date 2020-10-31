using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Platformer.Mechanics;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private TokenController controller;
    public TMP_Text token_score;
    
    // Start is called before the first frame update
    void Start()
    {
        token_score.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        token_score.text = controller.getCount.ToString();
    }
}
