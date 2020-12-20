using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Routes calls to PC native API.
*/
public class IIFileInputStream_PCImpl : IIFileInputStream
{
    public IIFileInputStream_PCImpl(string sFileName)
    {
        // ToDo
    }

    public override long length()
    {
        // ToDo
        return -1;
    }
    public override sbyte readByte()
    {
        // ToDo
        return -1;
    }
    public override short readShort()
    {
        // ToDo
        return -1;
    }
    public override int readInt()
    {
        // ToDo
        return -1;
    }
    public override long readLong()
    {
        // ToDo
        return -1;
    }
    public override void seek(long lPos)
    {
        // ToDo
    }
    public override string readLine()
    {
        // ToDo
        return "";
    }
    public override byte[] read()
    {
        // ToDo
        return null;
    }
    public override byte[] read(int iOffset, int iLength)
    {
        // ToDo
        return null;
    }
    public override void close()
    {
        // ToDo
    }
}
