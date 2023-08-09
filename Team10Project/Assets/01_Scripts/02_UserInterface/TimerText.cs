using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class TimeText : MonoBehaviour
{
    public string m_Timer = @"00:00:00.000";
    bool m_IsPlaying;
    public float m_TotalSeconds; // 카운트 다운 전체 초(5분 X 60초), 인스펙트 창에서 수정해야 함. 
    public TextMeshProUGUI m_Text;

    void Start()
    {
        m_Timer = CountdownTimer(false); // Text에 초기값을 넣어 주기 위해
        m_IsPlaying = !m_IsPlaying;
    }

    void Update()
    {

        if (m_IsPlaying)
        {
            m_Timer = CountdownTimer();
        }

        // 사망했을 때를 기점으로
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