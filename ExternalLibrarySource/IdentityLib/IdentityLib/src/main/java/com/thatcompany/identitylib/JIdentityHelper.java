package com.thatcompany.identitylib;

import android.app.Activity;
import android.os.Build;
import android.provider.Settings;

import java.util.UUID;

/*
    This class provides a helper functionality to return a UniqueI dentifier for a device.
    Activity context needs to be set before any other function call.
 */
public class JIdentityHelper
{
    static Activity m_pActivityInstance;

    /*
        Caches the Activity instance for future use.
     */
    public static void setContext(Activity pActivityInstance)
    {
        JLogger.Log("Setting Context ");
        m_pActivityInstance = pActivityInstance;
    }

    /*
        This returns a 'Universally Unique Identifier(UUID)' specific to this particular device.
        This is achieved by clubbing the device BRAND, MANUFACTURER, MODEL, ANDROID_ID  along with the
        'Application Package Name'.
        Open for modifications in the future if required.
     */
    public static String getUniqueIdentifier()
    {
        String sPackageName = m_pActivityInstance.getPackageName();
        String sAndroidID = Settings.Secure.getString(m_pActivityInstance.getContentResolver(), Settings.Secure.ANDROID_ID);
        JLogger.Log("ANDROID_ID == "+sAndroidID);

        String pseudoId =   Build.BRAND + ":"
                            + Build.MANUFACTURER + ":"
                            + Build.MODEL + ":"
                            + sAndroidID + ":"
                            + sPackageName;

        JLogger.Log("pseudoId == "+pseudoId);

        UUID uuid = UUID.nameUUIDFromBytes(pseudoId.getBytes());
        JLogger.Log("Unique Identifier = "+uuid);

        return uuid.toString();
    }
}
