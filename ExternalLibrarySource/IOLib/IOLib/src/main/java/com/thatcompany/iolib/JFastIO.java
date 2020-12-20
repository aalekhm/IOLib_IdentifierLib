package com.thatcompany.iolib;

import java.io.File;
import java.io.IOException;
import java.io.PrintWriter;
import java.io.RandomAccessFile;

/*
    This class offers brute force RW(readAllBytes() & writeAllBytes()) contents on a specified file
    along with regular file checking operations like 'exists()', 'clear()', 'rename()' & 'delete()'.
 */
public class JFastIO
{
    /*
        Checks if the specified 'sFileName' in a path exists.
     */
    static boolean exists(String sFileName)
    {
        JLogger.Log("Checking if File Exists "+sFileName);

        if(sFileName != null && !sFileName.isEmpty())
        {
            File pFile = new File(sFileName);
            if(pFile != null)
            {
                return pFile.exists();
            }
        }

        return false;
    }

    /*
        Reads the entire contents of a file specified in the 'sFileName' and returns it.
        Alternatively, the if the content is encrypted, its decrypted & read from the disk.
     */
    public static byte[] readAllBytes(String sFileName)
    {
        JLogger.Log("ReadAllBytes: "+sFileName);
        if(sFileName != null && !sFileName.isEmpty())
        {
            try
            {
                RandomAccessFile raf = new RandomAccessFile(sFileName, "r");
                if(raf != null)
                {
                    long iSize = raf.length();
                    byte[] bByteContents = new byte[(int)iSize];
                    raf.read(bByteContents);
                    raf.close();

                    byte[] bTempArray = bByteContents;
                    boolean bIsEncrypted = (Crypto.isEncrypted(bByteContents) >= 0);
                    if(bIsEncrypted)
                    {
                        bTempArray = Crypto.decrypt(bByteContents);
                    }

                    JLogger.Log("Size = "+iSize+", Content: "+new String(bTempArray));
                    return bTempArray;
                }
                raf.close();
            }
            catch(IOException ioe)
            {
                JLogger.Log("Exception in ReadAllBytes() "+ioe.toString());
            }
        }

        return null;
    }

    /*
        Writes the entire contents of the byte array to a file specified in the 'sFileName'.
        Alternatively, the content can be encrypted before flushing to disk.
        Returns 'true' if the entire operation is successful.
     */
    public static boolean writeAllBytes(String sFileName, byte[] bByteArray, int iSize, boolean bEncrypt)
    {
        JLogger.Log("WriteAllBytes: "+sFileName);
        boolean bReturn = false;
        if(sFileName != null && !sFileName.isEmpty())
        {
            try
            {
                RandomAccessFile raf = new RandomAccessFile(sFileName, "rw");
                if(raf != null)
                {
                    byte[] bTempArray = bByteArray;
                    if(bEncrypt)
                    {
                        bTempArray = Crypto.encrypt(bByteArray, iSize);
                    }

                    raf.write(bTempArray);

                    JLogger.Log("Contents: "+new String(bByteArray));
                    bReturn = true;
                }
                raf.close();
            }
            catch(IOException ioe)
            {
                JLogger.Log("Exception in WriteAllBytes() "+ioe.toString());
            }
        }

        return bReturn;
    }

    /*
        Clears the contents of the specified 'sFileName'.
     */
    public static boolean clear(String sFileName)
    {
        JLogger.Log("clearing: "+sFileName);
        boolean bReturn = false;

        if(sFileName != null && !sFileName.isEmpty())
        {
            File f = new File(sFileName);
            if(f != null)
            {
                try
                {
                    PrintWriter pw = new PrintWriter(f);
                    pw.flush();
                    pw.close();

                    JLogger.Log("cleared: "+f.exists());
                    bReturn = true;
                }
                catch(IOException ioe)
                {
                    JLogger.Log("Exception in clear() "+ioe.toString());
                }
            }
        }

        return bReturn;
    }

    /*
        Renames the specified 'sSrcFile' to 'sDestFile'.
     */
    public static boolean rename(String sSrcFile, String sDestFile)
    {
        JLogger.Log("rename(ing): "+sSrcFile+" to "+sDestFile);
        boolean bReturn = false;

        if(sSrcFile != null && !sSrcFile.isEmpty() && sDestFile != null && !sDestFile.isEmpty())
        {
            File fSrc = new File(sSrcFile);
            if(fSrc != null)
            {
                File fDst = new File(sDestFile);
                if(fDst != null)
                {
                    fSrc.renameTo(fDst);
                    fSrc = null;
                    fDst = null;

                    JLogger.Log("rename(ed): "+sSrcFile+" to "+sDestFile);
                    bReturn = true;
                }
            }
        }

        return bReturn;
    }

    /*
        Deletes the specified 'sFileName' from disk.
     */
    public static boolean delete(String sFileName)
    {
        JLogger.Log("delete: "+sFileName);
        boolean bReturn = false;

        if(sFileName != null && !sFileName.isEmpty())
        {
            File fSrc = new File(sFileName);
            if(fSrc != null)
            {
                fSrc.delete();
                fSrc = null;

                bReturn = true;
            }
        }

        return bReturn;
    }
}
