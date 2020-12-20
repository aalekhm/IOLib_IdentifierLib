using System;
using UnityEngine;
using IOWrapper;

/*
 * Simple Save Manager that will save an encrypted(if requested) object to a file.
 * The object will be converted to a json format before saving.
 */
public static class SaveManager
{
    public static bool SaveToDisk<T>(T obj, string sFile, bool bEncrypt)
    {
        if (obj != null)
        {
            string sJsonObject = ToJson(obj);
            return SaveToDisk(sJsonObject, sFile, bEncrypt);
        }

        return false;
    }

    public static bool SaveToDisk(String sContents, string sFile, bool bEncrypt)
    {
        bool bReturn = false;
        string sFileName = FastIO.persistentDataPath + sFile;
        string sTempFileName = FastIO.persistentDataPath + "temp_"+sFile;
#if VERBOSE
        Logger.Log("SaveInternal: sFileName " + sFileName + ", sTempFileName = "+ sTempFileName);
#endif

        if(FastIO.WriteAllBytes(    sTempFileName, 
                                    System.Text.Encoding.UTF8.GetBytes(sContents),
                                    sContents.Length,
                                    bEncrypt)
        ) {
#if VERBOSE
            Logger.Log("SavePlayer: Sucessfully written to " + sTempFileName);
#endif
            if (FastIO.Rename(sTempFileName, sFileName))
            {
                bReturn = true;
#if VERBOSE
                Logger.Log("SavePlayer: Sucessfully renamed " + sTempFileName+ " to "+ sFileName);
#endif
            }
            else
            {
                bReturn = false;
#if VERBOSE
                Logger.Log("SavePlayer: Unable to Sucessfully rename. Save fail!");
#endif
            }
        }

        return bReturn;
    }

    public static T LoadFromDisk<T>(string sFilename)
    {
        string sOriginalData = LoadFromDisk(sFilename);
        if(sOriginalData != null)
        {
            return FromJson<T>(sOriginalData);
        }

        return default(T);
    }

    public static String LoadFromDisk(string sFilename)
    {
        string sPath = FastIO.persistentDataPath + sFilename;
#if VERBOSE
        Logger.Log("LoadFromDisk: sPath = " + sPath);
#endif

        if (FastIO.Exists(sPath))
        {
            byte[] bData = FastIO.ReadAllBytes(sPath);
            if (bData != null)
            {
                string sOriginalData = System.Text.Encoding.ASCII.GetString(bData);
#if VERBOSE
                Logger.Log("Decrypt:: == " + sOriginalData);
#endif

                return sOriginalData;
            }
        }

        return null;
    }

    public static string ToJson<T>(T pObj)
    {
        if (pObj != null)
        {
            return JsonUtility.ToJson(pObj);
        }

        return null;
    }

    public static T FromJson<T>(string sData)
    {
        if (sData != null)
        {
            return JsonUtility.FromJson<T>(sData);
        }

        return default(T);
    }
}
