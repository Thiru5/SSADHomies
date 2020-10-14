using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    public GameObject ui; 
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I am alive!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open() { 
        ui.SetActive(true);
    }

    public void Close() { 
        ui.SetActive(false);
    }
}
