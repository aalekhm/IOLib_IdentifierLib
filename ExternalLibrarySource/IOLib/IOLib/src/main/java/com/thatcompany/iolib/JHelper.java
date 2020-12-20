package com.thatcompany.iolib;

import android.app.Activity;
import android.os.Environment;

/*
    This class provides a helper functionality to access the persistent storage of the device.
    Additionally, Assets data path functionality can be made available.
    Activity context needs to be set before any other function call.
 */
public class JHelper
{
    static Activity m_pActivityInstance;

    /*
        Caches the Activity instance for future use.
     */
    public static void setContext(Activity pActivityInstance)
    {
        JLogger.Log("Setting Context");
        m_pActivityInstance = pActivityInstance;
    }

    /*
        Returns persistence data storage path that can be used save application specific data.
        The 'cache' path is not visible to the user via any file explorer applications unless the device is rooted.
        But if the user clears the 'cache', files saved in the folder will be erased.
        Alternatively, external storage can be used for application specific storage needs via the code below:

        String sExternalStorage = Environment.getExternalStorageDirectory().getPath();
        sExternalStorage += "/Android/data/"+m_pActivityInstance.getPackageName()+"/files/";
     */
    public static String persistentDataPath()
    {
        return m_pActivityInstance.getCacheDir().getPath() + "/";
    }
}
