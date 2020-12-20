/*
 * Interface that the platform specific implementors should abide by.
 * The implementor provides more specific API for low-level file Read operations.
 */
public abstract class IIFileInputStream
{
    public abstract long length();
    public abstract sbyte readByte();
    public abstract short readShort();
    public abstract int readInt();
    public abstract long readLong();
    public abstract void seek(long lPos);
    public abstract string readLine();
    public abstract byte[] read();
    public abstract byte[] read(int iOffset, int iLength);
    public abstract void close();

    protected string      m_FileName; 
}
