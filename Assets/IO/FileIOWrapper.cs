using System;
using UnityEngine;

namespace IOWrapper
{
    /*
     * A bridge wrapper for IFastIO, that routes the calls to platform specific implementations.
     */
    public class FastIO
    {
        public static string persistentDataPath
        {
            get 
            { 
                if(m_FastIO != null)
                {
                    return m_FastIO.m_persistentDataPath;
                }

                return "";
            }
        }

        static IFastIO             m_FastIO;
        public static void Initialize()
        {
#if UNITY_STANDALONE_WIN
            m_FastIO = new IFastIO_PCImpl();
#elif UNITY_ANDROID
            m_FastIO = new IFastIO_AndroidImpl();
#endif
            m_FastIO.Initialize();
        }

        public static bool Exists(string sFile)
        {
            return m_FastIO.Exists(sFile);
        }

        public static byte[] ReadAllBytes(string sFile)
        {
            return m_FastIO.ReadAllBytes(sFile);
        }

        public static bool WriteAllBytes(string sFile, string sData, int iSize, bool bEncrypt)
        {
            return WriteAllBytes(sFile, System.Text.Encoding.UTF8.GetBytes(sData), iSize, bEncrypt);
        }

        public static bool WriteAllBytes(string sFile, byte[] byteArrray, int iSize, bool bEncrypt)
        {
            return m_FastIO.WriteAllBytes(sFile, byteArrray, iSize, bEncrypt);
        }

        public static void Clear(string sFile)
        {
            m_FastIO.Clear(sFile);
        }
        public static bool Rename(string sFileSrc, string sFileDst)
        {
            return m_FastIO.Rename(sFileSrc, sFileDst);
        }
        public static void Delete(string sFile)
        {
            m_FastIO.Delete(sFile);
        }

        public static FileInputStream OpenForRead(string sFile)
        {
            if(FastIO.Exists(sFile))
            {
                return new FileInputStream(sFile);
            }

            return null;
        }

        public static FileOutputStream OpenForWrite(string sFile)
        {
            return new FileOutputStream(sFile);
        }
    }

    /*
     * A bridge wrapper for IFileInputStream, that routes the calls to platform specific implementations.
     */
    public class FileInputStream
    {
        IIFileInputStream   m_Implementor;
        public FileInputStream(string sFileName)
        {
#if UNITY_STANDALONE_WIN
            m_Implementor = new IIFileInputStream_PCImpl(sFileName);
#elif UNITY_ANDROID
            m_Implementor = new IIFileInputStream_AndroidImpl(sFileName);
#endif
        }

        public long length()
        {
            return m_Implementor.length();
        }
        public sbyte readByte()
        {
            return m_Implementor.readByte();
        }
        public short readShort()
        {
            return m_Implementor.readShort();
        }
        public int readInt()
        {
            return m_Implementor.readInt();
        }
        public long readLong()
        {
            return m_Implementor.readLong();
        }
        public void seek(long lPos)
        {
            m_Implementor.seek(lPos);
        }
        public string readLine()
        {
            return m_Implementor.readLine();
        }
        public byte[] read()
        {
            return m_Implementor.read();
        }
        public byte[] read(int iOffset, int iLength)
        {
            return m_Implementor.read(iOffset, iLength);
        }
        public void close()
        {
            m_Implementor.close();
        }
    }

    /*
    * A bridge wrapper for IFileOutputStream, that routes the calls to platform specific implementations.
    */
    public class FileOutputStream
    {
        IFileOutputStream       m_Implementor;
        public FileOutputStream(string sFileName)
        {
#if UNITY_STANDALONE_WIN
            m_Implementor = new IFileOutputStream_PCImpl(sFileName);
#elif UNITY_ANDROID
            m_Implementor = new IFileOutputStream_AndroidImpl(sFileName);
#endif
        }

        public void writeByte(sbyte bByte)
        {
            m_Implementor.writeByte(bByte);
        }
        public void writeShort(short iShort)
        {
            m_Implementor.writeShort(iShort);
        }
        public void writeInt(int iInt)
        {
            m_Implementor.writeInt(iInt);
        }
        public void writeLong(long lLong)
        {
            m_Implementor.writeLong(lLong);
        }
        public void writeLine(string sLine)
        {
            m_Implementor.writeLine(sLine);
        }
        public void write(byte[] bByteArray)
        {
            m_Implementor.write(bByteArray);
        }
        public void write(byte[] bByteArray, int iOffset, int iLength)
        {
            m_Implementor.write(bByteArray, iOffset, iLength);
        }
        public void close()
        {
            m_Implementor.close();
        }
    }
}