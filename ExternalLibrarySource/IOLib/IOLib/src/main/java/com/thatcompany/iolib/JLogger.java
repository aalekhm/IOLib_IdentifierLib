package com.thatcompany.iolib;

import android.util.Log;

/*
    Custom Log class.
 */
public class JLogger
{
    static boolean DEBUG = true;
    static String DEFAULT_TAG = "UnityTest [Java]";

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
