package com.thatcompany.identitylib;

import android.util.Log;

/*
    Custom Log class.
 */
public class JLogger
{
    static String DEFAULT_TAG = "UnityTest [Java]";
    static boolean DEBUG = true;

    public static void Log(String sLog)
    {
        if(DEBUG)
        {
            Log(DEFAULT_TAG, sLog);
        }
    }

    public static void Log(String sTag, String sLog)
    {
        if(DEBUG)
        {
            Log.v(sTag, sLog);
        }
    }
}
