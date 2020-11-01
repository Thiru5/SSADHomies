using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    public GameObject ui;
    public ScoreController sc;
    // Start is called before the first frame update
    void Start()
    {
        ui.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        var controller = ui.GetComponent<QuestionController>();
        if (TimeManager.isPaused && Input.GetKeyDown(KeyCode.Return)) {
                if (controller.Check()) {
                    sc.incrementEnemyScore();
                };
                Close();
        }
    }

    public void Open() { 
        ui.SetActive(true);
        // freeze the game
        TimeManager.Pause();
    }

    public void Close() { 
        // get input, check, then unfreeze
        ui.SetActive(false);
        TimeManager.Unpause();
    }
}
