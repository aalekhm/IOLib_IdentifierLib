using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Routes calls to Android native API.
*/
public class IIFileInputStream_AndroidImpl : IIFileInputStream
{
    private AndroidJavaObject m_jFileInputStreamClassObj;

    public IIFileInputStream_AndroidImpl(string sFileName)
    {
        m_jFileInputStreamClassObj = new AndroidJavaObject("com.thatcompany.iolib.JFileInputStream", sFileName);
    }

    public override long length()
    {
        return m_jFileInputStreamClassObj.Call<long>("length");
    }
    public override sbyte readByte()
    {
        return m_jFileInputStreamClassObj.Call<sbyte>("readByte");
    }
    public override short readShort()
    {
        return m_jFileInputStreamClassObj.Call<short>("readShort");
    }
    public override int readInt()
    {
        return m_jFileInputStreamClassObj.Call<int>("readInt");
    }
    public override long readLong()
    {
        return m_jFileInputStreamClassObj.Call<long>("readLong");
    }
    public override void seek(long lPos)
    {
        m_jFileInputStreamClassObj.Call("seek", lPos);
    }
    public override string readLine()
    {
        return m_jFileInputStreamClassObj.Call<string>("readLine");
    }
    public override byte[] read()
    {
        return m_jFileInputStreamClassObj.Call<byte[]>("read");
    }
    public override byte[] read(int iOffset, int iLength)
    {
        object[] funcParams = new object[2];
        {
            funcParams[0] = iOffset;
            funcParams[1] = iLength;
        }

        return m_jFileInputStreamClassObj.Call<byte[]>("read", funcParams);
    }
    public override void close()
    {
        m_jFileInputStreamClassObj.Call("close");
    }
}
