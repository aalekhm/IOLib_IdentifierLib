using UnityEngine;

public class Logger
{
    static string LOGTAG = "UnityTest [Unity]";
    public static void Log(string sData)
    {
//#if VERBOSE
        Debug.Log("["+LOGTAG + "] " + sData);
//#endif
    }
    
}
