package com.thatcompany.iolib;

import java.io.IOException;
import java.io.RandomAccessFile;

/*
    This class provides more specific API for low-level file Read operations.
    Can be used to Read data in binary format.
 */
public class JFileInputStream
{
    private String              mFileName;
    private RandomAccessFile    mFileObj;
    private long                mLength;

    /*
        Creates a file object that will be later used for reading its contents.
     */
    public JFileInputStream(String sFileName)
    {
        try
        {
            mFileObj = new RandomAccessFile(sFileName, "r");
            mLength = mFileObj.length();
        }
        catch(IOException ioe)
        {
            JLogger.Log("Exception in JFileInputStream() "+ioe.toString());
        }
    }

    /*
        Returns the length of the file in bytes.
     */
    public long length()
    {
        return mLength;
    }

    /*
        Reads a signed 8-bit(byte) value from this file.
        This method reads a 'byte' from the current file pointer.
     */
    public byte readByte()
    {
        try
        {
            return mFileObj.readByte();
        }
        catch(IOException ioe)
        {
            JLogger.Log("Exception in readByte() "+ioe.toString());
        }

        return -1;
    }

    /*
        Reads a signed 16-bit(short) value from this file.
        This method reads a 'short' from the current file pointer.
     */
    public short readShort()
    {
        try
        {
            return mFileObj.readShort();
        }
        catch(IOException ioe)
        {
            JLogger.Log("Exception in readShort() "+ioe.toString());
        }

        return -1;
    }

    /*
        Reads a signed 32-bit(int) value from this file.
        This method reads a 'int' from the current file pointer.
     */
    public int readInt()
    {
        try
        {
            return mFileObj.readInt();
        }
        catch(IOException ioe)
        {
            JLogger.Log("Exception in readInt() "+ioe.toString());
        }

        return -1;
    }

    /*
        Reads a signed 64-bit(long) value from this file.
        This method reads a 'long' from the current file pointer.
     */
    public long readLong()
    {
        try
        {
            return mFileObj.readLong();
        }
        catch(IOException ioe)
        {
            JLogger.Log("Exception in readLong() "+ioe.toString());
        }

        return -1;
    }

    /*
        This function sets the file-pointer offset to the specified position measured from
        the beginning of the file.
     */
    public void seek(long lPos)
    {
        try
        {
            mFileObj.seek(lPos);
        }
        catch(IOException ioe)
        {
            JLogger.Log("Exception in seek() "+ioe.toString());
        }
    }

    /*
        Reads a line of text from the current file-pointer.
     */
    public String readLine()
    {
        try
        {
            return mFileObj.readLine();
        }
        catch(IOException ioe)
        {
            JLogger.Log("Exception in readLine() "+ioe.toString());
        }

        return null;
    }

    /*
        Reads the entire contents of the file & returns in a byte array.
        The file-pointer offset will be changed after this call.
     */
    public byte[] read()
    {
        try
        {
            byte[] bByteContents = new byte[(int)mLength];
            mFileObj.seek(0);
            mFileObj.read(bByteContents);

            return bByteContents;
        }
        catch(IOException ioe)
        {
            JLogger.Log("Exception in read() "+ioe.toString());
        }

        return null;
    }

    /*
        Reads a specified('iLen') number of bytes from the 'iOffset' measured from the beginning of the file.
     */
    public byte[] read(int iOffset, int iLen)
    {
        try
        {
            byte[] bByteContents = new byte[(int)iLen];
            mFileObj.seek(iOffset);
            mFileObj.read(bByteContents, iOffset, iLen);

            return bByteContents;
        }
        catch(IOException ioe)
        {
            JLogger.Log("Exception in read(int, int) "+ioe.toString());
        }

        return null;
    }

    /*
        Closes the file for use, after which the object can no longer be used to read.
     */
    public void close()
    {
        try
        {
            mFileObj.close();
        }
        catch(IOException ioe)
        {
            JLogger.Log("Exception in close() "+ioe.toString());
        }
    }
}
