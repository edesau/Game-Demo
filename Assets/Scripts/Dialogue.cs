using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue {
    // The lines of dialogue
    public string[] script;
    // The current line that is being read
    private int currLine;

    /** Dialogue
     *  Takes a string representing a path to a .txt 
     *  file containing lines of dialogue
     **/
    public Dialogue (string location) {
        script = System.IO.File.ReadAllLines(location + ".txt");
        currLine = 0;
    }

    /** GetNextLine
     *  Returns the current line of the script and moves on to the next line
     **/
    public string GetNextLine() {
        string msg = "";
        if (!IsDoneReading()) {
            msg = script[currLine];
            currLine++;
        }
        return msg;
    }

    /** IsDoneReading
     *  Returns true if there are no more lines in the current script
     **/
    public bool IsDoneReading() {
        return currLine >= script.Length;
    }
}
