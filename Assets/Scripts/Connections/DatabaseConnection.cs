using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.IO; 
using System;
using UnityEngine;
using Newtonsoft.Json;  
using Data.Definitions;

public static class DatabaseConnection
{
    public static string username {get; set;} // ASSIGN MATRIC HERE AFTER CORRECT LOGIN AND NEVER TOUCH IT AGAIN
    private static readonly string DBAddr = "https://thequestofthessadhomies.firebaseio.com/";
    private static Dictionary<string, Question> questionBank;
    private static Dictionary<string, string> textBank;
    
    private static int count = 1;
    // we need to fetch all questions from db and alloc
    public static void init() { 
        // method fetches all questions/answer tuple from database
        textBank = JsonConvert.DeserializeObject<Dictionary<string, string>>(getEndpoint("tokenText"));
        questionBank = JsonConvert.DeserializeObject<Dictionary<string, Question>>(getEndpoint("questions"));
    }

    private static string getEndpoint(string endpoint) { 
        var req = WebRequest.Create($"{DBAddr}/{endpoint}.json");
        var response = req.GetResponse();
        var stream = response.GetResponseStream();
        var reader = new StreamReader(stream);
        var res = reader.ReadToEnd();
        response.Close();
        return res; 
    }

    // use this to get a question - can change signature to be void -> string if we want to rack within this
    public static string GetText(int index) { 
        index = (index % (textBank.Count - 1)) + 1;
        return textBank[$"q{index}_hint"];
    }

    public static Question GetPair() { 
        var question = questionBank[$"qn_{count}"];
        // count = [1, questionBank.count]
        count = (count % (questionBank.Count)) + 1;
        return question;
    }

    // given a list of strings, we join them together and set data at our end point.
    public static void SetData(List<string> path, Dictionary<string, string> data) { 
        var joinedPath = String.Join("/", path); 
        Debug.Log(joinedPath); 
        var req = (HttpWebRequest) WebRequest.Create($"{DBAddr}/path.json");
        req.ContentType = "application/json";
        req.Method = "PUT";
    }

    public static bool isValidUser(string matric, string password) {
        var userReq = WebRequest.Create(DBAddr + $"/accounts/{matric}.json");
        var response = userReq.GetResponse(); 
        var stream = response.GetResponseStream();
        var reader = new StreamReader(stream);
        var userObj = JsonConvert.DeserializeObject<Dictionary<string, string>>(reader.ReadToEnd());
        if (userObj == null) {
            return false; 
        }
        return userObj["password"] == password;
    }
}
