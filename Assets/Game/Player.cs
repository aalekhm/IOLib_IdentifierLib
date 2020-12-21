using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string                   m_PlayerName;
    public int                      m_Level;
    public int                      m_Health;

    private const string            PLAYER_SAVE_FILE = "playerData.dat";
    public void Start()
    {
        LoadFromDisk();
    }

    public void setName(string sName)
    {
        if (sName.Length > 0)
        {
            m_PlayerName = sName;
        }
    }

    public void setLevel(int iAmount)
    {
        m_Level += iAmount;
        if (m_Level < 0)
        {
            m_Level = 0;
        }
    }

    public void setHealth(int iAmount)
    {
        m_Health += iAmount;
        if (m_Health < 0)
        {
            m_Health = 0;
        }
    }

    public void SaveToDisk()
    {
        PlayerData pData = new PlayerData(this);
        if (pData != null)
        {
            SaveManager.SaveToDisk<PlayerData>(pData, PLAYER_SAVE_FILE, true);
        }
    }

    public void LoadFromDisk()
    {
        PlayerData pData = SaveManager.LoadFromDisk<PlayerData>(PLAYER_SAVE_FILE);
        if (pData != null)
        {
            UpdateData(pData);
#if TEST_CRYPTOC
            string sPData = SaveManager.ToJson<PlayerData>(pData);
            Logger.Log("[000] = " + sPData);
            string sEncrypted = CryptoWrapper.EncryptString(sPData);
            Logger.Log("[111] = " + sEncrypted);
            string sDecrypted = CryptoWrapper.DecryptString(sEncrypted);
            Logger.Log("[222] = " + sDecrypted);
#endif
        }
    }

    private void UpdateData(PlayerData pData)
    {
        m_PlayerName = pData.m_PlayerName;
        m_Level = pData.m_Level;
        m_Health = pData.m_Health;
        transform.position = pData.m_Position;
#if VERBOSE
        Logger.Log("m_Name = "+m_PlayerName+", m_Level = " + m_Level + ", m_Health" + m_Health + ", transform.position" + transform.position);
#endif
    }
}
