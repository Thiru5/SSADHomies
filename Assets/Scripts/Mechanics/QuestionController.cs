﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _question;
    [SerializeField]
    private TMP_InputField _answer;
    // Start is called before the first frame update
    public string question {get; set;} 
    public string answer {get; set;} 
    void Start()
    {
        if (question != null && question != "") {
            _question.text = question;
        }
        _question.text = "asdf";
        answer = "skwe"; 
    }

    public bool Check() { 
        Debug.Log((_answer.text + " " + answer));
        Debug.Log("skwe" == answer);
        Debug.Log("skwe" == _answer.text);
        return string.Equals(_answer.text, answer); 
    }
}
