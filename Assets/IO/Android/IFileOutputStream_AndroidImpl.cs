using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Routes calls to Android native API.
*/
public class IFileOutputStream_AndroidImpl : IFileOutputStream
{
    private AndroidJavaObject m_jFileOutputStreamClassObj;
    public IFileOutputStream_AndroidImpl(string sFileName)
    {
        m_FileName = sFileName;
        m_jFileOutputStreamClassObj = new AndroidJavaObject("com.thatcompany.iolib.JFileOutputStream", sFileName);
    }

    public override void writeByte(sbyte bByte)
    {
        m_jFileOutputStreamClassObj.Call("writeByte", bByte);
    }
    public override void writeShort(short iShort)
    {
        m_jFileOutputStreamClassObj.Call("writeShort", iShort);
    }
    public override void writeInt(int iInt)
    {
        m_jFileOutputStreamClassObj.Call("writeInt", iInt);
    }
    public override void writeLong(long lLong)
    {
        m_jFileOutputStreamClassObj.Call("writeLong", lLong);
    }
    public override void writeLine(string sLine)
    {
        m_jFileOutputStreamClassObj.Call("writeLine", sLine);
    }
    public override void write(byte[] bByteArray)
    {
        m_jFileOutputStreamClassObj.Call("write", bByteArray);
    }
    public override void write(byte[] bByteArray, int iOffset, int iLength)
    {
        object[] funcParams = new object[3];
        {
            funcParams[0] = bByteArray;
            funcParams[1] = iOffset;
            funcParams[2] = iLength;
        }

        m_jFileOutputStreamClassObj.Call("write", funcParams);
    }
    public override void close()
    {
        m_jFileOutputStreamClassObj.Call("close");
    }
}
