using System;

/*
 * Interface that the platform specific implementors should abide by.
 * The implementor offers brute force RW(readAllBytes() & writeAllBytes()) contents on a specified file
   along with regular file checking operations like 'exists()', 'clear()', 'rename()' & 'delete()'.
 */
public abstract class IFastIO
{
    public abstract void Initialize();
    public abstract bool Exists(string sFile);
    public abstract byte[] ReadAllBytes(string sFile);
    public abstract bool WriteAllBytes(string sFile, byte[] byteArrray, int iSize, bool bEncrypt);
    public abstract bool Clear(string sFile);
    public abstract bool Rename(string sFileSrc, string sFileDst);
    public abstract bool Delete(string sFile);

    public string m_persistentDataPath;
}
