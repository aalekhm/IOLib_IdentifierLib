package com.thatcompany.iolib;

import java.io.IOException;
import java.io.RandomAccessFile;

/*
    This class provides more specific API for low-level file Write operations.
    Can be used to Write data in binary format.
 */
public class JFileOutputStream
{
    private String              mFileName;
    private RandomAccessFile    mFileObj;

    /*
        Creates a file object that will be later used for writing contents to a file.
     */
    public JFileOutputStream(String sFileName)
    {
        try
        {
            mFileObj = new RandomAccessFile(sFileName, "rw");
        }
        catch(IOException ioe)
        {
            JLogger.Log("Exception in JFileOutputStream() "+ioe.toString());
        }
    }

    /*
        Writes a signed 8-bit(byte) value to the file.
        This method writes a 'byte' at the current file pointer.
     */
    public void writeByte(byte bByte)
    {
        try
        {
            mFileObj.writeByte(bByte);
        }
        catch(IOException ioe)
        {
            JLogger.Log("Exception in writeByte() "+ioe.toString());
        }
    }

    /*
        Writes a signed 16-bit(short) value to the file.
        This method writes a 'short' at the current file pointer.
     */
    public void writeShort(short iShort)
    {
        try
        {
            mFileObj.writeShort(iShort);
        }
        catch(IOException ioe)
        {
            JLogger.Log("Exception in writeShort() "+ioe.toString());
        }
    }

    /*
        Writes a signed 32-bit(int) value to the file.
        This method writes a 'int' at the current file pointer.
     */
    public void writeInt(int iInt)
    {
        try
        {
            mFileObj.writeInt(iInt);
        }
        catch(IOException ioe)
        {
            JLogger.Log("Exception in writeInt() "+ioe.toString());
        }
    }

    /*
        Writes a signed 64-bit(long) value to the file.
        This method writes a 'long' at the current file pointer.
     */
    public void writeLong(long lLong)
    {
        try
        {
            mFileObj.writeLong(lLong);
        }
        catch(IOException ioe)
        {
            JLogger.Log("Exception in writeLong() "+ioe.toString());
        }
    }

    /*
        Writes a line of text at the current file-pointer.
     */
    public void writeLine(String sLine)
    {
        try
        {
            mFileObj.writeBytes(sLine+"\r\n");
        }
        catch(IOException ioe)
        {
            JLogger.Log("Exception in writeLine() "+ioe.toString());
        }
    }

    /*
        Writes the entire contents of the byte array at the current file-pointer.
     */
    public void write(byte[] bByteArray)
    {
        try
        {
            mFileObj.write(bByteArray);
        }
        catch(IOException ioe)
        {
            JLogger.Log("Exception in write() "+ioe.toString());
        }
    }

    /*
        Writes a specified('iLen') number of bytes from the bByteArray starting from the 'iOffset' from the beginning of the array.
     */
    public void write(byte[] bByteArray, int iOffset, int iLen)
    {
        try
        {
            mFileObj.write(bByteArray, iOffset, iLen);
        }
        catch(IOException ioe)
        {
            JLogger.Log("Exception in write(byte[], int, int) "+ioe.toString());
        }
    }

    /*
        Closes the file for use, after which the object can no longer be used to write.
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
