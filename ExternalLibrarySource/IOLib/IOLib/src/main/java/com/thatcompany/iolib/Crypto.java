package com.thatcompany.iolib;

/*
    Simple X-OR encryption / decryption:
        1. Magic Header         ==> 'C' 'A' 'F' 'E' (4 bytes)
        2. Size of the Data     ==> Total Size of the Data chunk (4 bytes)
        3. Encrypted Data       ==> Each byte XOR'ed with its integer position in the data array.
 */
public class Crypto
{
    private static int ENCRYPT_MAGIC_HEADER = 4;
    private static int ENCRYPT_DATA_SIZE = 4;
    private static int ENCRYPT_PADDING = ENCRYPT_MAGIC_HEADER + ENCRYPT_DATA_SIZE;

    /*
        Receives the input byte array & returns an encrypted version of the same.
        Encrypted data contains encryption specific header.
     */
    public static byte[] encrypt(byte[] bData, int iSize)
    {
        JLogger.Log("Encrypt(ing) == ["+iSize+"] "+ new String(bData));

        int iLen = iSize + ENCRYPT_MAGIC_HEADER + ENCRYPT_DATA_SIZE;
        byte[] pEncryptedData = new byte[iLen];
        constructHeader(pEncryptedData, iSize);

        for(int i = 0; i < iSize; i++)
        {
            pEncryptedData[i + ENCRYPT_PADDING] = encryptInternal(bData[i], i);
        }

        JLogger.Log("Encrypt(ed) == ["+iSize+"] "+ new String(pEncryptedData));

        return pEncryptedData;
    }

    /*
        Checks if the input data is encrypted & in a format understandle by the API.
        If so, Decrypts it & returns an original version of the same.
     */
    public static byte[] decrypt(byte[] bData)
    {
        JLogger.Log("Decrypt(ing) ==> "+ new String(bData));

        int iSize = isEncrypted(bData);
        if(iSize > 0)
        {
            JLogger.Log("Decrypt(--) == ["+iSize+"]");

            byte[] pDecryptedData = new byte[iSize];
            for(int i = 0; i < iSize; i++)
            {
                byte bVal = bData[i + ENCRYPT_PADDING];
                pDecryptedData[i] = encryptInternal(bVal, i);
            }

            JLogger.Log("Decrypt(ed) == ["+iSize+"] "+ new String(pDecryptedData));
            return pDecryptedData;
        }

        return null;
    }

    /*
        Constructs the encryption specific content header.
        Additional fields can be added for future if brute force encryption techniques.
     */
    private static void constructHeader(byte[] bArray, int iSize)
    {
        bArray[0] = 'C';
        bArray[1] = 'A';
        bArray[2] = 'F';
        bArray[3] = 'E';
        bArray[4] = (byte) (iSize >> 24);
        bArray[5] = (byte) (iSize >> 16);
        bArray[6] = (byte) (iSize >> 8);
        bArray[7] = (byte) (iSize >> 0);
    }

    /*
        Checks if the incoming data is encrypted or is in a format understandable by the API.
     */
    public static int isEncrypted(byte[] bArray)
    {
        if(bArray[0] == 'C' && bArray[1] == 'A' && bArray[2] == 'F' && bArray[3] == 'E')
        {
            return (((bArray[4] & 0xff) << 24)
                    | ((bArray[5] & 0xff) << 16)
                    | ((bArray[6] & 0xff) << 8)
                    | ((bArray[7] & 0xff) << 0));
        }

        return -1;
    }

    /*
        The actual encrypt/decrypt function.
        The contents can be modified for better encryption.
     */
    private static byte encryptInternal(byte b, int iPos)
    {
        return (byte)(b ^ iPos);
    }
}
