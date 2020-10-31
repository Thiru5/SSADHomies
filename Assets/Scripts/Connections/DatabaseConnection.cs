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
    private static Dictionary<string, string> textBank;
    // we need to fetch all questions from db and alloc
    public async static void init() { 
        // method fetches all questions/answer tuple from database
        var questionReq = WebRequest.Create(DBAddr + "/questions.json"); // our structure here is dict(str: dict(str, str)) 
        var response = await questionReq.GetResponseAsync();
        var stream = response.GetResponseStream();
        var reader = new StreamReader(stream);
        questionBank = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(reader.ReadToEnd());
        response.Close();
        var textReq = WebRequest.Create(DBAddr + "/tokenText.json"); // our structure here is dict(str: dict(str, str)) 
        response = await textReq.GetResponseAsync();
        stream = response.GetResponseStream();
        reader = new StreamReader(stream);
        textBank = JsonConvert.DeserializeObject<Dictionary<string, string>>(reader.ReadToEnd());
    }

    // use this to get a question - can change signature to be void -> string if we want to rack within this
    public static string getText(int index) { 
        return textBank[(index / textBank.Count).ToString()];
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
