using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Routes calls to Android native API.
*/
public class IFastIO_AndroidImpl : IFastIO
{
    private static AndroidJavaClass m_jHelper;
    private static AndroidJavaClass m_jFileClass;

    private const string FUNC_PERSISTENTDATAPATH = "persistentDataPath";

    private const string FUNC_EXISTS = "exists";
    private const string FUNC_READALLBYTES = "readAllBytes";
    private const string FUNC_WRITEALLBYTES = "writeAllBytes";
    private const string FUNC_CLEAR = "clear";
    private const string FUNC_RENAME = "rename";
    private const string FUNC_DELETE = "delete";

    public override void Initialize()
    {
        m_jHelper = new AndroidJavaClass("com.thatcompany.iolib.JHelper");
        m_jFileClass = new AndroidJavaClass("com.thatcompany.iolib.JFastIO");

        AndroidJavaClass playerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        if (playerClass != null)
        {
            AndroidJavaObject activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
            m_jHelper.CallStatic("setContext", activity);
        }

        m_persistentDataPath = m_jHelper.CallStatic<string>(FUNC_PERSISTENTDATAPATH);
    }
    public override bool Exists(string sFile)
    {
        return m_jFileClass.CallStatic<bool>(FUNC_EXISTS, sFile);
    }
    public override byte[] ReadAllBytes(string sFile)
    {
        byte[] pRetByteArry = null;

        AndroidJavaObject readAllBytesObj = m_jFileClass.CallStatic<AndroidJavaObject>(FUNC_READALLBYTES, sFile);
        if (readAllBytesObj != null)
        {
            pRetByteArry = AndroidJNIHelper.ConvertFromJNIArray<byte[]>(readAllBytesObj.GetRawObject());
        }

        return pRetByteArry;
    }
    public override bool WriteAllBytes(string sFile, byte[] byteArrray, int iSize, bool bEncrypt)
    {
        object[] funcParams = new object[4];
        {
            funcParams[0] = sFile;
            funcParams[1] = byteArrray;
            funcParams[2] = iSize;
            funcParams[3] = bEncrypt;
        }

        return m_jFileClass.CallStatic<bool>(FUNC_WRITEALLBYTES, funcParams);
    }

    public override bool Clear(string sFile)
    {
        return m_jFileClass.CallStatic<bool>(FUNC_CLEAR, sFile);
    }

    public override bool Rename(string sFileSrc, string sFileDst)
    {
        object[] funcParams = new object[2];
        {
            funcParams[0] = sFileSrc;
            funcParams[1] = sFileDst;
        }

        return m_jFileClass.CallStatic<bool>(FUNC_RENAME, funcParams);
    }

    public override bool Delete(string sFile)
    {
        return m_jFileClass.CallStatic<bool>(FUNC_DELETE, sFile);
    }
}
