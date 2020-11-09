using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    // this lives on the canvas object
    [SerializeField]
    private GameObject scores; 
    [SerializeField]
    private TMP_Text own_score;
    // Start is called before the first frame update
    public ScoreController sc; 
    private List<Dictionary<string, Dictionary<string, string>>> top_scores;
    void Start()
    {
        if (top_scores == null) { 
            top_scores = DatabaseConnection.GetSorted();
        }
        var scores_array = scores.GetComponents<TMP_Text>();
        int i = 0;
        foreach (TMP_Text score_text in scores_array) {
            var matric = top_scores[i].Keys.ToString();
            score_text.text = $"{score_text.text} {matric} {top_scores[i].Values}";
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        own_score.text = $"Your Score: enemy: {sc._enemy_score}; tokens: {sc.token_score}";
    }
}
