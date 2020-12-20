using UnityEngine;

/*
* Routes calls to Android native API.
*/
public class IIdentity_AndroidImpl : IIdentity
{
    private static AndroidJavaClass m_jHelper;
    private static AndroidJavaClass m_jFileClass;

    private const string CLASS_UNITYPLAYER          = "com.unity3d.player.UnityPlayer";
    private const string CLASS_JIDENTITYHELPER      = "com.thatcompany.identitylib.JIdentityHelper";

    private const string FUNC_SETCONTEXT            = "setContext";
    private const string FUNC_GETUNIQUEIDENTIFIER   = "getUniqueIdentifier";

    public override void Initialize()
    {
        m_jHelper = new AndroidJavaClass(CLASS_JIDENTITYHELPER);

        AndroidJavaClass playerClass = new AndroidJavaClass(CLASS_UNITYPLAYER);
        if (playerClass != null)
        {
            AndroidJavaObject activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
            m_jHelper.CallStatic(FUNC_SETCONTEXT, activity);
        }
    }
    public override string GetUniqueIdentifier()
    {
        return m_jHelper.CallStatic<string>(FUNC_GETUNIQUEIDENTIFIER);
    }
}