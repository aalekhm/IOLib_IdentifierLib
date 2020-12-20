using System;
using UnityEngine;
using System.Runtime.InteropServices;

/*
* A bridge wrapper for route calls to platform implementations exposed via a shared library(.so).
*/
public class CryptoWrapper
{
#if UNITY_STANDALONE_WIN
    const string dll = "cryptoclib";    // Not implemented
#elif UNITY_ANDROID
    const string dll = "cryptoclib";    // Android specific shared library(libcryptoclib.so)
#endif

    [DllImport(dll)]
    unsafe private static extern byte* EncryptString(byte* sData);

    [DllImport(dll)]
    unsafe private static extern byte* DecryptString(byte* sCipher);

    public static unsafe string EncryptString(string sData)
    {
        string sRetEncryptedString = "";
#if UNITY_STANDALONE_WIN
        // ToDo
#elif UNITY_ANDROID        
        IntPtr pIntPtr = (IntPtr)Marshal.StringToHGlobalAnsi(sData);
        if (pIntPtr != IntPtr.Zero)
        {
            IntPtr pEncryptedIntPtr = (IntPtr)EncryptString((byte*)pIntPtr.ToPointer());
            Marshal.FreeHGlobal(pIntPtr);

            if (pEncryptedIntPtr != IntPtr.Zero)
            {
                sRetEncryptedString = Marshal.PtrToStringAnsi(pEncryptedIntPtr);
                Marshal.FreeHGlobal(pEncryptedIntPtr);
            }
        }
#endif
        return sRetEncryptedString;
    }

    public static unsafe string DecryptString(string sCipher)
    {
        string sRetDecryptedString = "";
#if UNITY_STANDALONE_WIN
        // ToDo
#elif UNITY_ANDROID
        IntPtr pIntPtr = (IntPtr)Marshal.StringToHGlobalAnsi(sCipher);
        if (pIntPtr != IntPtr.Zero)
        {
            IntPtr pDecryptedIntPtr = (IntPtr)DecryptString((byte*)pIntPtr.ToPointer());
            Marshal.FreeHGlobal(pIntPtr);

            if (pDecryptedIntPtr != IntPtr.Zero)
            {
                sRetDecryptedString = Marshal.PtrToStringAnsi(pDecryptedIntPtr);
                Marshal.FreeHGlobal(pDecryptedIntPtr);
            }
        }
#endif
        return sRetDecryptedString;
    }
}
