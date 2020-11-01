using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VictoryPopUp : MonoBehaviour
{
    public GameObject victoryPop;

    public TMP_Text victoryPopText;



    public void Start(){
        victoryPop.SetActive(false);
    }
    public void PopUp(){
        victoryPop.SetActive(true);
    }
}