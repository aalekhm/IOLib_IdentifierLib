using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Routes calls to PC native API.
*/
public class IFastIO_PCImpl : IFastIO
{
    public override void Initialize()
    {
        // ToDo
    }
    public override bool Exists(string sFile)
    {
        // ToDo
        return false;
    }
    public override byte[] ReadAllBytes(string sFile)
    {
        // ToDo
        return null;
    }
    public override bool WriteAllBytes(string sFile, byte[] byteArrray, int iSize, bool bEncrypt)
    {
        // ToDo
        return false;
    }

    public override bool Clear(string sFile)
    {
        // ToDo
        return false;
    }

    public override bool Rename(string sFileSrc, string sFileDst)
    {
        // ToDo
        return false;
    }

    public override bool Delete(string sFile)
    {
        // ToDo
        return false;
    }
}
