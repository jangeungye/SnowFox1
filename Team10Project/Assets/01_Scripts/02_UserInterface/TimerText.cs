using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class TimeText : MonoBehaviour
{
    public string m_Timer = @"00:00:00.000";
    bool m_IsPlaying;
    public float m_TotalSeconds; // ī��Ʈ �ٿ� ��ü ��(5�� X 60��), �ν���Ʈ â���� �����ؾ� ��. 
    public TextMeshProUGUI m_Text;

    void Start()
    {
        m_Timer = CountdownTimer(false); // Text�� �ʱⰪ�� �־� �ֱ� ����
        m_IsPlaying = !m_IsPlaying;
    }

    void Update()
    {

        if (m_IsPlaying)
        {
            m_Timer = CountdownTimer();
        }

        // ������� ���� ��������
        if (m_TotalSeconds <= 0)
        {
            SetZero();
        }

        if (m_Text)
            m_Text.text = m_Timer;
    }

    string CountdownTimer(bool IsUpdate = true)
    {
        if (IsUpdate)
            m_TotalSeconds += Time.deltaTime;

        TimeSpan timespan = TimeSpan.FromSeconds(m_TotalSeconds);
        string timer = string.Format("{0:00}:{1:00}:{2:00}.{3:000}",
            timespan.Hours, timespan.Minutes, timespan.Seconds, timespan.Milliseconds);

        return timer;
    }

    private void SetZero()
    {
        m_Timer = @"00:00:00.000";
        m_TotalSeconds = 0;
        m_IsPlaying = false;
    }
}