using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    public GameObject ui; 
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open() { 
        ui.SetActive(true);
        Debug.Log(ui);
        // freeze the game
        Time.timeScale = 0;
    }

    public void Close() { 
        // get input, check, then unfreeze
        ui.SetActive(false);
        Time.timeScale = 1;
    }
}
