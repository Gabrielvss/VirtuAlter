using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BugTest 
{
    public static int runs = 0;
    public static int errors = 0;
    public static int time = 0;


    public static void CompareFinishTime ()
    {
        if (time > 44)
        {
            errors = errors + 1;
            runs = runs + 1;
        }
        else
        {
            runs = runs + 1;
        }
        Debug.Log("Runs: " + runs + "\n" + "Errors: " + errors);
    }   
}
