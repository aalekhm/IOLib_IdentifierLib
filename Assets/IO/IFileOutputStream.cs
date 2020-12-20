/*
 * Interface that the platform specific implementors should abide by.
 * The implementor provides more specific API for low-level file Write operations.
 */

public abstract class IFileOutputStream
{
    public abstract void writeByte(sbyte bByte);
    public abstract void writeShort(short iShort);
    public abstract void writeInt(int iInt);
    public abstract void writeLong(long lLong);
    public abstract void writeLine(string sLine);
    public abstract void write(byte[] bByteArray);
    public abstract void write(byte[] bByteArray, int iOffset, int iLength);
    public abstract void close();
    
    protected string     m_FileName;
}
