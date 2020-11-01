using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TimeManager
{
    public static bool isPaused => Time.timeScale == 0;  
    // Start is called before the first frame update
    public static void Pause()
    {
        if (Time.timeScale > 0) {
            Time.timeScale = 0;
        }
    }

    // Update is called once per frame
    public static void Unpause()
    {
        if (Time.timeScale == 0) { 
            Time.timeScale = 1;
        }        
    }
}
