// NOTE: this class is provided SOLELY to demarshall questions from json into usable objects
using System.Collections.Generic;  

// class should only be modified when the data definition change
// do NOT crowd this file with other definitions. if needed, namespace it and create another file
namespace Data.Definitions {
    public class Question { 
        public string answer {get; set;} 
        public Dictionary<string, string> options {get; set;}
        public string question {get; set;} 
    }
}