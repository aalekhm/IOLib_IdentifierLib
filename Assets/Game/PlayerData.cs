using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public string   m_PlayerName;
    public int      m_Level;
    public int      m_Health;
    public Vector3  m_Position;

    public PlayerData(Player player)
    {
        m_PlayerName = player.m_PlayerName;
        m_Level = player.m_Level;
        m_Health = player.m_Health;

        m_Position = player.transform.position;
    }
}
