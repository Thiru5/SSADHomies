using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionController : MonoBehaviour
{
    // [SerializeField]
    // private TMP_Text _question;
    
    // [SerializeField]
    // private TMP_InputField _answer;
    // // Start is called before the first frame update
    // public string question {get; set;} 
    // public string answer {get; set;} 

    // public GameObject options;
    // void Start()
    // {
    //     Assign();
    // }
    
    // void Assign() { 
    //     var question = DatabaseConnection.GetPair();
    //     _question.text = question.question;
    //     _answer.text = "";
    //     answer = question.answer;
    //     var opt = options.GetComponentsInChildren<TMP_Text>();
    //     var tmp_options = question.options.Values;
    //     int i = 0; 
    //     foreach (var kvpair in question.options) { 
    //         opt[i].text = kvpair.Value; 
    //         i++;
    //     }
    // }
    // public bool Check() { 
    //     if (string.Equals(_answer.text, answer)) {
    //         Assign(); 
    //         return true; 
    //     }
    //     return false; 
    // }
}
