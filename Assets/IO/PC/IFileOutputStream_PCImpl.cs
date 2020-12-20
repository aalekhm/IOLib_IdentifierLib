using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Routes calls to PC native API.
*/
public class IFileOutputStream_PCImpl : IFileOutputStream
{
    public IFileOutputStream_PCImpl(string sFileName)
    {
        m_FileName = sFileName;
    }

    public override void writeByte(sbyte bByte)
    {
        // ToDo
    }
    public override void writeShort(short iShort)
    {
        // ToDo
    }
    public override void writeInt(int iInt)
    {
        // ToDo
    }
    public override void writeLong(long lLong)
    {
        // ToDo
    }
    public override void writeLine(string sLine)
    {
        // ToDo
    }
    public override void write(byte[] bByteArray)
    {
        // ToDo
    }
    public override void write(byte[] bByteArray, int iOffset, int iLength)
    {
        // ToDo
    }
    public override void close()
    {
        // ToDo
    }
}
