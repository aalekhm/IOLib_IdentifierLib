#include <stdint.h>
#include <android/log.h>
#include <android/native_activity.h>
#include <string>

#define TAG "UnityTest [Native]"
#define LOG(...) __android_log_print(ANDROID_LOG_VERBOSE, "UnityTest [C++]", __VA_ARGS__)

extern "C"
{
    /*
        Receives the input byte array & returns an encrypted version of the same.
        Extremely simple encryption is used to depict the library usage.
    */
    char* EncryptString(const char* sData)
    {
        LOG("UnityTest [Native] Encrypt(ing) == [%d] %s", strlen(sData), sData);

        int iLen = strlen(sData);
        char* pEncryptedData = (char*)malloc(iLen + 1);
        for(int i = 0; i < iLen; i++)
        {
            pEncryptedData[i] = (sData[i] + 1);
        }
        pEncryptedData[iLen] = '\0';

        LOG("UnityTest [Native] Encrypt(ed) == [%d] %s", strlen(pEncryptedData), pEncryptedData);

        return pEncryptedData;
    }

    /*
        Receives the input byte array & returns an decrypted version of the same.
        Extremely simple decryption is used to depict the library usage.
    */
    char* DecryptString(const char* sData)
    {
        LOG("UnityTest [Native] Decrypt(ing) == [%d] %s", strlen(sData), sData);

        int iLen = strlen(sData);
        char* pDecryptedData = (char*)malloc(iLen + 1);
        for(int i = 0; i < iLen; i++)
        {
            pDecryptedData[i] = (sData[i] - 1);
        }
        pDecryptedData[iLen] = '\0';

        LOG("UnityTest [Native] Decrypt(ed) == [%d] %s", strlen(pDecryptedData), pDecryptedData);

        return pDecryptedData;
    }
}
