using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.IO; 
using UnityEngine;
using Newtonsoft.Json;  

public static class DatabaseConnection
{
    private static readonly string DBAddr = "https://thequestofthessadhomies.firebaseio.com/";
    private static Dictionary<string, Dictionary<string, string>> questionBank;
    private static List<Dictionary<string, string>> textBank;
    // we need to fetch all questions from db and alloc
    public static void init() { 
        // method fetches all questions/answer tuple from database
        questionBank = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(getEndpoint("questions"));
        textBank = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(getEndpoint("tokenText"));
        Debug.Log(textBank[2]["value"]);
    }

    private static string getEndpoint(string endpoint) { 
        var req = WebRequest.Create($"{DBAddr}/{endpoint}.json");
        var response = req.GetResponse();
        var stream = response.GetResponseStream();
        var reader = new StreamReader(stream);
        response.Close();
        return reader.ReadToEnd(); 

    }

    // use this to get a question - can change signature to be void -> string if we want to rack within this
    public static string getText(int index) { 
        return textBank[(index % (textBank.Count - 1)) + 1]["value"]; // hacky workaround because first ele null
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
