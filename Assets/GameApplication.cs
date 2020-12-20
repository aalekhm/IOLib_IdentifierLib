using UnityEngine;
using IOWrapper;
using IdentityWrapper;
using TMPro;

public class GameApplication : MonoBehaviour
{
    public TextMeshProUGUI  m_UniqueIdentifier;

    // Start is called before the first frame update
    void Start()
    {
        InitializeLibraries();

        // Capture the 'Unique Identifier' & display it.
        m_UniqueIdentifier.SetText(Identity.GetUniqueIdentifier());

#if TEST
        // Test
        if (false)
        {
            WriteTest("Text.txt");
            ReadTest("Text.txt");
        
            FastIO.Clear(FastIO.persistentDataPath + "Text.txt");
            FastIO.Delete(FastIO.persistentDataPath + "Text.txt");
        }
#endif
    }

    void InitializeLibraries()
    {
        // Initialize the libraries before calling any specific functions.
        FastIO.Initialize();
        Identity.Initialize();
    }

#if TEST
    static string TAG = "UnityTest [Unity]";
    void WriteTest(string sFile)
    {
        string sFileName = FastIO.persistentDataPath + sFile;
        if (FastIO.Exists(sFileName))
        {
            FastIO.Delete(sFileName);
        }

        FileOutputStream fos = FastIO.OpenForWrite(sFileName);
        if (fos != null)
        {
            fos.writeLine("Google LLC is an American multinational technology company that specializes in Internet-related services and products, which include online advertising technologies, a search engine, cloud computing, software, and hardware.");
            fos.writeLine("It is considered one of the Big Five technology companies in the U.S. information technology industry, alongside Amazon, Facebook, Apple, and Microsoft.");

            fos.writeByte(77);
            fos.writeShort(1977);
            fos.writeInt(197700);
            fos.writeLong(19770077);

            fos.write(System.Text.Encoding.UTF8.GetBytes("1234567890"));

            fos.close();
        }
    }

    void ReadTest(string sFile)
    {
        string sFileName = FastIO.persistentDataPath + sFile;
        FileInputStream fin = FastIO.OpenForRead(sFileName);
        if (fin != null)
        {
            // 1.
            Logger.Log("Length: " + fin.length());
            Logger.Log("Line: " + fin.readLine());
            Logger.Log("Line: " + fin.readLine());
            Logger.Log("byte: " + fin.readByte());
            Logger.Log("short: " + fin.readShort());
            Logger.Log("int: " + fin.readInt());
            Logger.Log("long: " + fin.readLong());
            Logger.Log("bytes: " + System.Text.Encoding.ASCII.GetString(fin.read()));

            fin.close();
        }
    }
#endif
}
