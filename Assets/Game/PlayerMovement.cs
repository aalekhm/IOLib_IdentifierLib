using System;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    const float                     SPEED = 1.5f;
    Player                          m_PlayerObj;

    public TextMeshProUGUI          m_xPosObj;
    public TextMeshProUGUI          m_yPosObj;
    public TextMeshProUGUI          m_zPosObj;

    public TextMeshProUGUI          m_NameObj;
    public TextMeshProUGUI          m_LevelObj;
    public TextMeshProUGUI          m_HealthObj;

    private TouchScreenKeyboard     m_Keyboard;

    // Start is called before the first frame update
    void Start()
    {
        m_PlayerObj = this.GetComponent<Player>();
#if VERBOSE
        Logger.Log("m_Level = " + m_PlayerObj.m_Level + ", m_Health = " + m_PlayerObj.m_Health);
#endif
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 transform;
        transform = m_PlayerObj.transform.position;

        transform.x += SPEED * Time.deltaTime;
        transform.y += SPEED * Time.deltaTime;
        transform.z += SPEED * Time.deltaTime;

        m_xPosObj.SetText(transform.x.ToString("f2"));
        m_yPosObj.SetText(transform.y.ToString("f2"));
        m_zPosObj.SetText(transform.z.ToString("f2"));

        m_PlayerObj.transform.position = transform;

        m_NameObj.SetText(m_PlayerObj.m_PlayerName);
        m_LevelObj.SetText(m_PlayerObj.m_Level.ToString());
        m_HealthObj.SetText(m_PlayerObj.m_Health.ToString());

        if (m_Keyboard != null && m_Keyboard.status == TouchScreenKeyboard.Status.Done)
        {
            m_NameObj.SetText(m_Keyboard.text);
            m_PlayerObj.setName(m_Keyboard.text);
            m_Keyboard = null;
        }
    }

    public void OpenKeyboard()
    {
        m_Keyboard = new TouchScreenKeyboard("", TouchScreenKeyboardType.ASCIICapable, false, false, false, false, "", 6);
        m_Keyboard = TouchScreenKeyboard.Open("");
    }
}
