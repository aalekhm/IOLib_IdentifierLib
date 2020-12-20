using UnityEngine;

namespace IdentityWrapper
{
    /*
    * A bridge wrapper for IIdentity, that routes the calls to platform specific implementations.
    */

    public class Identity
    {
        static IIdentity    m_IdentityImpl;
        public static void Initialize()
        {
#if UNITY_STANDALONE_WIN
            m_IdentityImpl = new IIdentity_PCImpl();
#elif UNITY_ANDROID
            m_IdentityImpl = new IIdentity_AndroidImpl();
#endif
            m_IdentityImpl.Initialize();
        }

        public static string GetUniqueIdentifier()
        {
            return m_IdentityImpl.GetUniqueIdentifier();
        }
    }
}